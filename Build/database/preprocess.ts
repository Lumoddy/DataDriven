
export type DatabaseColumn =
    & {
        pascalSingle: string,
        camelSingle: string,
        pascalShortenedSingle: string,
        camelShortenedSingle: string,
        csType: string,
        csSqlType: string,
        csSqlTypeEnum: string,
        nullable: boolean,
    }
    & (
        | { type: "BIGINT", size: undefined }
        | { type: "INT", size: undefined }
        | { type: "SMALLINT", size: undefined }
        | { type: "TINYINT", size: undefined }
        | { type: "DATETIME", size: undefined }
        | { type: "VARCHAR", size: number | "MAX" }
        | { type: "CHAR", size: number | "MAX" }
        | { type: "VARBINARY", size: number | "MAX" }
        | { type: "BINARY", size: number | "MAX" });

export type DatabaseConstraint =
    | { type: "primary", columns: string[], other: undefined, otherColumns: undefined }
    | { type: "unique", columns: string[], other: undefined, otherColumns: undefined }
    | { type: "foreign", columns: string[], other: string, otherColumns: string[] };

export const typenameMap: Record<
    DatabaseColumn["type"],
    { csType: string, csSqlType: string, csSqlTypeEnum: string }> =
{
    "BIGINT": { csType: "long", csSqlType: "SqlInt64", csSqlTypeEnum: "BigInt" },
    "INT": { csType: "int", csSqlType: "SqlInt32", csSqlTypeEnum: "Int" },
    "SMALLINT": { csType: "short", csSqlType: "SqlInt16", csSqlTypeEnum: "SmallInt" },
    "TINYINT": { csType: "byte", csSqlType: "SqlByte", csSqlTypeEnum: "TinyInt" },
    "DATETIME": { csType: "DateTime", csSqlType: "SqlDateTime", csSqlTypeEnum: "DateTime" },
    "VARCHAR": { csType: "string", csSqlType: "SqlString", csSqlTypeEnum: "VarChar" },
    "CHAR": { csType: "string", csSqlType: "SqlString", csSqlTypeEnum: "Char" },
    "VARBINARY": { csType: "byte[]", csSqlType: "SqlBinary", csSqlTypeEnum: "VarBinary" },
    "BINARY": { csType: "byte[]", csSqlType: "SqlBinary", csSqlTypeEnum: "Binary" },
}

export type DatabaseTable =
{
    pascalSingle: string,
    pascalPlural: string,
    camelSingle: string,
    camelPlural: string,
    pascalShortenedSingle: string,
    pascalShortenedPlural: string,
    camelShortenedSingle: string,
    camelShortenedPlural: string,
    columns: Map<string, DatabaseColumn>,
    constraints: DatabaseConstraint[],
};

export type DatabaseStructure = { tables: Map<string, DatabaseTable> };

export function snakeCaseToPascalCase(string: string): string
{
    let buffer = "";
    let startOfWord = true;
    for (const char of String(string))
    {
        if (/^[a-zA-Z]$/.test(char))
        {
            buffer += startOfWord ? char.toUpperCase() : char;
            startOfWord = false;
        }
        else
        {
            if (/^[0-9]$/.test(char))
                buffer += char;

            startOfWord = true;
        }
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

        const pascalPlural = String(sourceTable["C# Plural"] ?? snakeCaseToPascalCase(name));
        const pascalSingle = String(sourceTable["C# Single"] ?? pascalPlural.substring(0, pascalPlural.length - 1));
        const camelPlural = pascalPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const camelSingle = pascalSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const pascalShortenedPlural = String(sourceTable["C# Short Plural"] ?? pascalPlural);
        const pascalShortenedSingle = String(sourceTable["C# Short Single"] ?? pascalSingle);
        const camelShortenedPlural = pascalShortenedPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const camelShortenedSingle = pascalShortenedSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());

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

            const pascalSingle = String(sourceColumn["C# Single"] ?? snakeCaseToPascalCase(name));
            const camelSingle = pascalSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
            const pascalShortenedSingle = String(sourceColumn["C# Short Single"] ?? pascalSingle);
            const camelShortenedSingle = pascalShortenedSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());

            const type = String.prototype.toUpperCase.call(sourceColumn["type"]);
            const nullable = Boolean(sourceColumn["nullable"]);
            let size: any;

            switch (type)
            {
                case "BIGINT":
                case "INT":
                case "SMALLINT":
                case "TINYINT":
                case "DATETIME":
                {
                    break;
                }
                case "VARCHAR":
                case "CHAR":
                case "VARBINARY":
                case "BINARY":
                {
                    const sourceSize = sourceColumn["size"];
                    try
                    {
                        size = sourceSize.toUpperCase() === "MAX"
                            ? "MAX"
                            : Math.max(0, eval(sourceColumn["size"]) | 0);
                    }
                    catch { size = undefined }

                    break;
                }
                default:
                {
                    throw new SyntaxError(
                        `Unknown type: ${type}`);
                }
            }

            columns.set(
                name,
                {
                    pascalSingle,
                    camelSingle,
                    pascalShortenedSingle,
                    camelShortenedSingle,
                    csType: typenameMap[type].csType,
                    csSqlType: typenameMap[type].csSqlType,
                    csSqlTypeEnum: typenameMap[type].csSqlTypeEnum,
                    type,
                    size,
                    nullable,
                });
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

        tables.set(
            name,
            {
                pascalPlural,
                pascalSingle,
                camelSingle,
                camelPlural,
                pascalShortenedPlural,
                pascalShortenedSingle,
                camelShortenedSingle,
                camelShortenedPlural,
                columns,
                constraints,
            });
    }

    return { tables };
}