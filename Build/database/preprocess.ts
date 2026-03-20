
export type DatabaseColumn =
    & { csSingle: string, csPlural: string, nullable: boolean }
    & (
        | { type: "BIGINT", size: undefined }
        | { type: "INT", size: undefined }
        | { type: "SMALLINT", size: undefined }
        | { type: "TINYINT", size: undefined }
        | { type: "DATE", size: undefined }
        | { type: "VARCHAR", size: number }
        | { type: "CHAR", size: number }
        | { type: "VARBINARY", size: number }
        | { type: "BINARY", size: number });

export type DatabaseConstraint =
    | { type: "primary", columns: string[], other: undefined, otherColumns: undefined }
    | { type: "unique", columns: string[], other: undefined, otherColumns: undefined }
    | { type: "foreign", columns: string[], other: string, otherColumns: string[] };

export type DatabaseTable =
{
    csSingle: string,
    csPlural: string,
    columns: Map<string, DatabaseColumn>,
    constraints: DatabaseConstraint[],
};

export type DatabaseStructure = { tables: Map<string, DatabaseTable> };

export function snakeCaseToPascalCase(string: string, startWithCapital: boolean = true): string
{
    let buffer = "";
    let startOfWord = Boolean(startWithCapital);
    for (const char of String(string))
    {
        if (/^[a-zA-Z]$/.test(char))
        {
            buffer += startOfWord ? char.toUpperCase() : char;
            startOfWord = false;
            break;
        }

        if (/^[0-9]$/.test(char))
            buffer += char;

        startOfWord = true;
        break;
    }

    return buffer;
}

export function preprocessObject(source: any): DatabaseStructure
{
    const
    {
        ["replacements"]: { ["column"]: replacementColumns },
        ["tables"]: sourceTables,
    }
    = source;

    const tables = new Map<string, DatabaseTable>();

    for (const name in sourceTables)
    {
        const sourceTable = sourceTables[name];

        const csPlural = sourceTable["C# Plural"] ?? snakeCaseToPascalCase(name);
        const csSingle = sourceTable["C# Single"] ?? csPlural.substring(0, name.length - 1);

        const sourceColumns = sourceTable["columns"];
        const columns = new Map<string, DatabaseColumn>();

        for (const name in sourceColumns)
        {
            let sourceColumn = sourceColumns[name];

            for (const [from, to] of replacementColumns)
            {
                for (const key in from)
                {
                    if (from[key] === sourceColumn[key])
                    {
                        sourceColumn = { ...sourceColumn, ...to };
                        break;
                    }
                }
            }

            const csPlural = sourceColumn["C# Plural"] ?? snakeCaseToPascalCase(name);
            const csSingle = sourceColumn["C# Single"] ?? csPlural.substring(0, name.length - 1);

            const type = String.prototype.toUpperCase.call(sourceColumn["type"]);
            switch (type)
            {
                case "BIGINT":
                case "INT":
                case "SMALLINT":
                case "TINYINT":
                case "DATE":
                {
                    columns.set(
                        name,
                        {
                            csSingle,
                            csPlural,
                            type,
                            size: undefined,
                            nullable: Boolean(sourceColumn["nullable"]),
                        });

                    break;
                }
                case "VARCHAR":
                case "CHAR":
                case "VARBINARY":
                case "BINARY":
                {
                    columns.set(
                        name,
                        {
                            csSingle,
                            csPlural,
                            type,
                            size: Math.max(0, sourceColumn["size"] | 0),
                            nullable: Boolean(sourceColumn["nullable"]),
                        });

                    break;
                }
                default:
                {
                    throw new SyntaxError(
                        `Unknown type: ${type}`);
                }
            }
        }

        const sourceConstraints = sourceTable["constraints"];
        const constraints: DatabaseConstraint[] = [];

        for (const sourceConstraint of sourceConstraints)
        {
            for (const sourceType in sourceConstraint)
            {
                const type = sourceType.toLowerCase();
                switch (type)
                {
                    case "primary":
                    case "unique":
                    {
                        constraints.push(
                        {
                            type,
                            columns: Array.prototype.map.call(
                                sourceConstraint[sourceType],
                                String) as string[],
                            other: undefined,
                            otherColumns: undefined,
                        });

                        break;
                    }
                    case "foreign":
                    {
                        const [first, secondOuter] = sourceConstraint[sourceType];

                        let other, second;
                        for (const name in secondOuter)
                        {
                            second = secondOuter[other = name];
                            break;
                        }

                        if (other === undefined)
                            throw new SyntaxError(
                                `Empty constraint`);

                        constraints.push(
                        {
                            type,
                            columns: Array.prototype.map.call(
                                first,
                                String) as string[],
                            other,
                            otherColumns: Array.prototype.map.call(
                                second,
                                String) as string[],
                        });

                        break;
                    }
                    default:
                    {
                        throw new SyntaxError(
                            `Unknown constraint: ${sourceType}`);
                    }
                }
            }
        }

        tables.set(name, { csSingle, csPlural, columns, constraints });
    }

    return { tables };
}