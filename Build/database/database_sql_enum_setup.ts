import type { DatabaseStructure, DatabaseTable } from "./preprocess.ts";

export function sqlEnumSetupFileFrom(structure: DatabaseStructure): Map<string, string>
{
    const tables = structure.tables;
    const enums = structure.enums;

    let result = new Map<string, string>();

    for (const [enumName, table] of enums)
    {
        let sql = `
CREATE OR ALTER PROCEDURE [`;

        sql += table.snakeSingle;
        sql += `_fields] (
`;

        let firstField = true;
        for (const [, field] of table.fields)
        {
            if (firstField)
                firstField = false;
            else
                sql += `,
`;

            sql += `    @`;
            sql += field.snakeSingle;
            sql += ` TINYINT OUTPUT`;
        }

        sql += `
) AS
BEGIN
`;

        for (const [fieldName, field] of table.fields)
        {
            sql += `
    SET @`;
            const tableColumns = (tables.get(enumName) as DatabaseTable).columns;
            const idColumnName = tableColumns.keys().find((x) => x.endsWith("_id")) as string;
            const nameColumnName = tableColumns.keys().find((x) => x.endsWith("_name")) as string;

            sql += field.snakeShortenedSingle;
            sql += ` = (
        SELECT [`;

            sql += enumName;
            sql += `].[`;

            sql += idColumnName;
            sql += `]
        FROM [`;

            sql += enumName;
            sql += `]
        WHERE [`;

            sql += enumName;
            sql += `].[`;

            sql += nameColumnName;
            sql += `] = '`;

            sql += fieldName;
            sql += `');

    IF (@`;

            sql += field.snakeShortenedSingle;
            sql += ` IS NULL)
        THROW 50000, 'Database does not contain an entry for ''`;

            sql += fieldName;
            sql += `'' in the ''`;

            sql += enumName;
            sql += `'' enum.', 1;
`;
        }

    sql += `
END
`;

        result.set(table.snakeShortenedSingle, sql);
    }

    return result;
}