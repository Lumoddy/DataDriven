
export type VariousNames = Record<
    `${"pascal" | "camel" | "snake" | "block"}${"Shortened" | ""}${"Single" | "Plural"}`,
    string>;

export type DatabaseColumn =
    & VariousNames
    & {
        nullable: boolean,
        defaultSql: string | undefined,
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
    & VariousNames
    & {
        columns: Map<string, DatabaseColumn>,
        constraints: DatabaseConstraint[],
    };

export type DatabaseEnum =
    & VariousNames
    & {
        fields: Map<string, DatabaseEnumField>,
    };

export type DatabaseEnumField =
    & VariousNames;

export type DatabaseStructure =
{
    tables: Map<string, DatabaseTable>,
    enums: Map<string, DatabaseEnum>,
};

export function* wordsFromCasedIdentifier(string: string): Generator<RegExpExecArray, undefined>
{
    string = String(string);
    const pattern = /[A-Z](?:[A-Z](?![a-z]))*(?:[a-z]+|[0-9]+)?|[a-z]+|\d+/g;
    let match;
    while ((match = pattern.exec(string)) !== null)
        yield match;
}

export function guessPluralOfSingle(single: string)
{
    return String(single)
        .replace(/(?<=[A-Z])S$/, "SES")
        .replace(/(?<=\w)s$/i, "ses")
        .replace(/(?<=[A-Z])(?<!REG)EX$/, "ICIES")
        .replace(/(?<=\w)(?<!reg)ex$/i, "icies");
}

export function guessSingleOfPlural(plural: string)
{
    return String(plural)
        .replace(/(?<=\w)(?:(?<=\Bs)e)?s$/i, "")
        .replace(/(?<=[A-Z])ICIES$/, "EX")
        .replace(/(?<=\w)icies$/i, "ex");
}

export function getVariousNamesFromPair(
    single: string,
    plural: string,
    overrides?: Partial<Record<
        `${"short_" | ""}${"single" | "plural"}` | `C#${" Short" | ""} ${"Single" | "Plural"}`,
        string | null | undefined>> | null | undefined): VariousNames
{
    const sourceSingle = String(overrides?.["single"] ?? single);
    const sourcePlural = String(overrides?.["plural"] ?? plural);

    const pascalSingle = String(overrides?.["C# Single"] ?? toPascalCase(sourceSingle));
    const pascalPlural = String(overrides?.["C# Plural"] ?? toPascalCase(sourcePlural));
    const camelSingle = pascalSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
    const camelPlural = pascalPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
    const snakeSingle = toSnakeCase(pascalSingle);
    const snakePlural = toSnakeCase(pascalPlural);
    const blockSingle = snakeSingle.toUpperCase();
    const blockPlural = snakePlural.toUpperCase();

    const overridesShortSingle = overrides?.["short_single"];
    const overridesShortPlural = overrides?.["short_plural"];

    const
    [
        sourceShortSingle,
        sourceShortPlural,
    ]
    = overridesShortSingle != null
        ? overridesShortPlural != null
            ? [String(overridesShortSingle), String(overridesShortPlural)]
            : [String(overridesShortSingle), guessPluralOfSingle(overridesShortSingle)]
        : overridesShortPlural != null
            ? [guessSingleOfPlural(overridesShortPlural), String(overridesShortPlural)]
            : [pascalSingle, sourcePlural];

    const pascalShortenedSingle = String(overrides?.["C# Short Single"] ?? toPascalCase(sourceShortSingle));
    const pascalShortenedPlural = String(overrides?.["C# Short Plural"] ?? toPascalCase(sourceShortPlural));
    const camelShortenedSingle = pascalShortenedSingle.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
    const camelShortenedPlural = pascalShortenedPlural.replace(/^[A-Z](?![a-z])|[A-Z]/, (x) => x.toLowerCase());
    const snakeShortenedSingle = toSnakeCase(pascalShortenedSingle);
    const snakeShortenedPlural = toSnakeCase(pascalShortenedPlural);
    const blockShortenedSingle = snakeShortenedSingle.toUpperCase();
    const blockShortenedPlural = snakeShortenedPlural.toUpperCase();

    return (
    {
        pascalSingle,
        pascalPlural,
        camelSingle,
        camelPlural,
        snakeSingle,
        snakePlural,
        blockSingle,
        blockPlural,
        pascalShortenedSingle,
        pascalShortenedPlural,
        camelShortenedSingle,
        camelShortenedPlural,
        snakeShortenedSingle,
        snakeShortenedPlural,
        blockShortenedSingle,
        blockShortenedPlural,
    });
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

export function toSnakeCase(string: string): string
{
    let buffer = "";
    let first = true;
    for (const [match] of wordsFromCasedIdentifier(string))
    {
        if (first)
            first = false;
        else
            buffer += "_";

        buffer += match.toLowerCase();
    }

    return buffer;
}

export function preprocessObject(source: any): DatabaseStructure
{
    const
    {
        ["replacements"]: { ["column"]: replacementColumns },
        ["enums"]: sourceEnums,
        ["tables"]: sourceTables,
    }
    = source;

    const enums = new Map<string, DatabaseEnum>();

    const tables = new Map<string, DatabaseTable>();

    for (const enumName in sourceEnums)
    {
        const sourceEnum = sourceEnums[enumName];

        const sourceFields = sourceEnum["values"];
        const fields = new Map<string, DatabaseEnumField>()

        for (const field in sourceFields)
        {
            const sourceField = sourceFields[field];

            const names = getVariousNamesFromPair(field, guessPluralOfSingle(field), sourceField);

            fields.set(field, names);
        }

        const names = getVariousNamesFromPair(guessSingleOfPlural(enumName), enumName, sourceEnum);

        enums.set(enumName, { ...names, fields });

        const idColumnName = `${guessSingleOfPlural(enumName)}_id`;
        const idColumn: DatabaseColumn =
        {
            ...getVariousNamesFromPair(idColumnName, idColumnName + "s", { "short_single": "id" }),
            csType: typenameMap["TINYINT"].csType,
            csSqlType: typenameMap["TINYINT"].csSqlType,
            csSqlTypeEnum: typenameMap["TINYINT"].csSqlTypeEnum,
            type: "TINYINT",
            size: undefined,
            precision: undefined,
            nullable: false,
            defaultSql: undefined,
        };

        const nameColumnName = `${guessSingleOfPlural(enumName)}_name`;
        const nameColumn: DatabaseColumn =
        {
            ...getVariousNamesFromPair(nameColumnName, nameColumnName + "s", { "short_single": "name" }),
            csType: typenameMap["VARCHAR"].csType,
            csSqlType: typenameMap["VARCHAR"].csSqlType,
            csSqlTypeEnum: typenameMap["VARCHAR"].csSqlTypeEnum,
            type: "VARCHAR",
            size: 255,
            precision: undefined,
            nullable: false,
            defaultSql: undefined,
        };

        tables.set(
            enumName,
            {
                ...names,
                columns: new Map<string, DatabaseColumn>(
                [
                    [idColumnName, idColumn],
                    [nameColumnName, nameColumn],
                ]),
                constraints:
                [
                    {
                        type: "primary",
                        columns: new Map([[idColumnName, idColumn]]),
                        other: undefined,
                        otherColumns: undefined,
                    },
                ],
            });
    }

    for (const tableName in sourceTables)
    {
        const sourceTable = sourceTables[tableName];

        const sourceColumns = sourceTable["columns"];
        const columns = new Map<string, DatabaseColumn>();

        for (const columnName in sourceColumns)
        {
            const unalteredSourceColumn = sourceColumns[columnName];
            let sourceColumn = unalteredSourceColumn;

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

            let source, match;

            source = sourceColumn["type"];
            if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                source = new Function("column", "return " + match[0])(
                    structuredClone(unalteredSourceColumn));
            const type = String(source);

            source = sourceColumn["nullable"];
            if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                source = new Function("column", "return " + match[0])(
                    structuredClone(unalteredSourceColumn));
            const nullable = Boolean(source ?? false);

            source = sourceColumn["default"];
            if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                source = new Function("column", "return " + match[0])(
                    structuredClone(unalteredSourceColumn));
            const defaultSql = source == null ? undefined : String(source);

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
                    source = sourceColumn["size"];
                    if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                        source = new Function("column", "return " + match[0])(
                            structuredClone(unalteredSourceColumn));
                    size = Math.max(0, source | 0);

                    source = sourceColumn["precision"];
                    if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                        source = new Function("column", "return " + match[0])(
                            structuredClone(unalteredSourceColumn));
                    precision = Math.max(0, source | 0);

                    break;
                }
                case "VARCHAR":
                case "CHAR":
                case "VARBINARY":
                case "BINARY":
                {
                    source = sourceColumn["size"];
                    if ((match = /(?<=^\s*=\s*)\S.*$/s.exec(source)) !== null)
                        source = new Function("column", "return " + match[0])(
                            structuredClone(unalteredSourceColumn));

                    switch (String(source).toUpperCase())
                    {
                        case "MAX": size = "MAX"; break;
                        default: size = Math.max(0, source | 0); break;
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
                columnName,
                {
                    ...getVariousNamesFromPair(columnName, guessPluralOfSingle(columnName), sourceColumn),
                    csType: typenameMap[type].csType as any,
                    csSqlType: typenameMap[type].csSqlType as any,
                    csSqlTypeEnum: typenameMap[type].csSqlTypeEnum as any,
                    type,
                    size,
                    precision,
                    nullable,
                    defaultSql,
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
                                    Iterator.from(sourceConstraint[sourceType]),
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
                                    Iterator.from(first),
                                    (x) => [String(x), null as any])),
                            other,
                            otherColumns: new Map(
                                (Iterator.prototype.map<[string, DatabaseColumn]>).call(
                                    Iterator.from(second),
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
            tableName,
            {
                ...getVariousNamesFromPair(guessSingleOfPlural(tableName), tableName, sourceTable),
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
                        `Unknown table referenced by ${tableName}: ${constraint.other}`);

                for (const columnName of constraint.otherColumns.keys())
                {
                    const column = table.columns.get(columnName);
                    if (column === undefined)
                        throw new SyntaxError(
                            `Unknown column in ${constraint.other} referenced by ${tableName}: ${columnName}`);

                    constraint.otherColumns.set(columnName, column);
                }
            }
        }
    }

    return { tables, enums };
}