
export type DatabaseColumn =
    & {
        pascalSingle: string,
        camelSingle: string,
        blockSingle: string,
        pascalShortenedSingle: string,
        camelShortenedSingle: string,
        blockShortenedSingle: string,
        nullable: boolean,
    }
    & (
        | ({ type: "BIGINT", size: undefined, precision: undefined } & typeof typenameMap["BIGINT"])
        | ({ type: "INT", size: undefined, precision: undefined } & typeof typenameMap["INT"])
        | ({ type: "SMALLINT", size: undefined, precision: undefined } & typeof typenameMap["SMALLINT"])
        | ({ type: "TINYINT", size: undefined, precision: undefined } & typeof typenameMap["TINYINT"])
        | ({ type: "DATETIME", size: undefined, precision: undefined } & typeof typenameMap["DATETIME"])
        | ({ type: "BIT", size: undefined, precision: undefined } & typeof typenameMap["BIT"])
        | ({ type: "DECIMAL", size: number, precision: number } & typeof typenameMap["DECIMAL"])
        | ({ type: "VARCHAR", size: number | "MAX", precision: undefined } & typeof typenameMap["VARCHAR"])
        | ({ type: "CHAR", size: number | "MAX", precision: undefined } & typeof typenameMap["CHAR"])
        | ({ type: "VARBINARY", size: number | "MAX", precision: undefined } & typeof typenameMap["VARBINARY"])
        | ({ type: "BINARY", size: number | "MAX", precision: undefined }) & typeof typenameMap["BINARY"]);

export type DatabaseConstraint =
    & { columns: Map<string, DatabaseColumn> }
    & (
        | { type: "primary", other: undefined, otherColumns: undefined }
        | { type: "unique", other: undefined, otherColumns: undefined }
        | { type: "foreign", other: string, otherColumns: Map<string, DatabaseColumn> });

export const typenameMap = Object.freeze(
{
    "BIGINT": Object.freeze({ csType: "long", csSqlType: "SqlInt64", csSqlTypeEnum: "BigInt" }),
    "INT": Object.freeze({ csType: "int", csSqlType: "SqlInt32", csSqlTypeEnum: "Int" }),
    "SMALLINT": Object.freeze({ csType: "short", csSqlType: "SqlInt16", csSqlTypeEnum: "SmallInt" }),
    "TINYINT": Object.freeze({ csType: "byte", csSqlType: "SqlByte", csSqlTypeEnum: "TinyInt" }),
    "DATETIME": Object.freeze({ csType: "DateTime", csSqlType: "SqlDateTime", csSqlTypeEnum: "DateTime" }),
    "BIT": Object.freeze({ csType: "bool", csSqlType: "SqlBoolean", csSqlTypeEnum: "Bit" }),
    "DECIMAL": Object.freeze({ csType: "decimal", csSqlType: "SqlDecimal", csSqlTypeEnum: "Decimal" }),
    "VARCHAR": Object.freeze({ csType: "string", csSqlType: "SqlString", csSqlTypeEnum: "VarChar" }),
    "CHAR": Object.freeze({ csType: "string", csSqlType: "SqlString", csSqlTypeEnum: "Char" }),
    "VARBINARY": Object.freeze({ csType: "byte[]", csSqlType: "SqlBinary", csSqlTypeEnum: "VarBinary" }),
    "BINARY": Object.freeze({ csType: "byte[]", csSqlType: "SqlBinary", csSqlTypeEnum: "Binary" }),
});

export type DatabaseTable =
{
    pascalSingle: string,
    pascalPlural: string,
    camelSingle: string,
    camelPlural: string,
    blockSingle: string,
    blockPlural: string,
    pascalShortenedSingle: string,
    pascalShortenedPlural: string,
    camelShortenedSingle: string,
    camelShortenedPlural: string,
    blockShortenedSingle: string,
    blockShortenedPlural: string,
    columns: Map<string, DatabaseColumn>,
    constraints: DatabaseConstraint[],
};

export type DatabaseStructure = { tables: Map<string, DatabaseTable> };

export function* wordsFromCasedIdentifier(string: string): Generator<RegExpExecArray, undefined>
{
    string = String(string);
    const pattern = /[A-Z](?:[A-Z](?![a-z]))*(?:[a-z]+|[0-9]+)?|[a-z]+|\d+/g;
    let match;
    while ((match = pattern.exec(string)) !== null)
        yield match;
}

export function toPascalCase(string: string): string
{
    let buffer = "";
    for (const [match] of wordsFromCasedIdentifier(string))
    {
        if (match.length > 0)
        {
            buffer += match[0].toUpperCase();
            buffer += match.substring(1).toLowerCase();
        }
    }

    return buffer;
}

export function toBlockCase(string: string): string
{
    let buffer = "";
    let first = true;
    for (const [match] of wordsFromCasedIdentifier(string))
    {
        if (first)
            first = false;
        else
            buffer += "_";

        buffer += match.toUpperCase();
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

        const pascalPlural = String(sourceTable["C# Plural"] ?? toPascalCase(name));
        const pascalSingle = String(sourceTable["C# Single"] ?? pascalPlural.substring(0, pascalPlural.length - 1));
        const camelPlural = pascalPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const camelSingle = pascalSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const blockPlural = toBlockCase(pascalPlural);
        const blockSingle = toBlockCase(pascalSingle);
        const pascalShortenedPlural = String(sourceTable["C# Short Plural"] ?? pascalPlural);
        const pascalShortenedSingle = String(sourceTable["C# Short Single"] ?? pascalSingle);
        const camelShortenedPlural = pascalShortenedPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const camelShortenedSingle = pascalShortenedSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
        const blockShortenedPlural = toBlockCase(pascalShortenedPlural);
        const blockShortenedSingle = toBlockCase(pascalShortenedSingle);

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

            const pascalSingle = String(sourceColumn["C# Single"] ?? toPascalCase(name));
            const camelSingle = pascalSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
            const blockSingle = toBlockCase(pascalSingle);
            const pascalShortenedSingle = String(sourceColumn["C# Short Single"] ?? pascalSingle);
            const camelShortenedSingle = pascalShortenedSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
            const blockShortenedSingle = toBlockCase(pascalShortenedSingle);

            const type = String.prototype.toUpperCase.call(sourceColumn["type"]);
            const nullable = Boolean(sourceColumn["nullable"]);
            let size: any;
            let precision: any;

            switch (type)
            {
                case "BIGINT":
                case "INT":
                case "SMALLINT":
                case "TINYINT":
                case "DATETIME":
                case "BIT":
                {
                    break;
                }
                case "DECIMAL":
                {
                    size = Math.max(0, eval(sourceColumn["size"]) | 0);
                    precision = Math.max(0, eval(sourceColumn["precision"]) | 0);

                    break;
                }
                case "VARCHAR":
                case "CHAR":
                case "VARBINARY":
                case "BINARY":
                {
                    const sourceSize = String(sourceColumn["size"]);

                    switch (sourceSize.toUpperCase())
                    {
                        case "MAX":
                            size = "MAX";
                            break;
                        default:
                            size = Math.max(0, eval(sourceSize) | 0);
                            break;
                    }

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
                    blockSingle,
                    pascalShortenedSingle,
                    camelShortenedSingle,
                    blockShortenedSingle,
                    csType: typenameMap[type].csType as any,
                    csSqlType: typenameMap[type].csSqlType as any,
                    csSqlTypeEnum: typenameMap[type].csSqlTypeEnum as any,
                    type,
                    size,
                    precision,
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
                            columns: new Map(
                                (Iterator.prototype.map<[string, DatabaseColumn]>).call(
                                    sourceConstraint[sourceType][Symbol.iterator](),
                                    (x) => [String(x), null as any])),
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
                            columns: new Map(
                                (Iterator.prototype.map<[string, DatabaseColumn]>).call(
                                    first[Symbol.iterator](),
                                    (x) => [String(x), null as any])),
                            other,
                            otherColumns: new Map(
                                (Iterator.prototype.map<[string, DatabaseColumn]>).call(
                                    second[Symbol.iterator](),
                                    (x) => [String(x), null as any])),
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
                blockSingle,
                blockPlural,
                pascalShortenedPlural,
                pascalShortenedSingle,
                camelShortenedSingle,
                camelShortenedPlural,
                blockShortenedSingle,
                blockShortenedPlural,
                columns,
                constraints,
            });
    }

    for (const [tableName, table] of tables)
    {
        for (const constraint of table.constraints)
        {
            for (const columnName of constraint.columns.keys())
            {
                const column = table.columns.get(columnName);
                if (column === undefined)
                    throw new SyntaxError(
                        `Unknown column in ${tableName}: ${columnName}`);

                constraint.columns.set(columnName, column);
            }

            if (constraint.otherColumns !== undefined)
            {
                const table = tables.get(constraint.other);

                if (table === undefined)
                    throw new SyntaxError(
                        `Unknown table: ${constraint.other}`);

                for (const columnName of constraint.otherColumns.keys())
                {
                    const column = table.columns.get(columnName);
                    if (column === undefined)
                        throw new SyntaxError(
                            `Unknown column in ${tableName}: ${columnName}`);

                    constraint.otherColumns.set(columnName, column);
                }
            }
        }
    }

    return { tables };
}