import type { DatabaseStructure } from "./preprocess.ts";

export function csShapeFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;

    let cs = `
using System.Data.SqlTypes;

namespace DataDriven.Data;
`;

    for (const [tableName, table] of tables)
    {
        cs += `
public record Sql`;

        cs += table.pascalShortenedSingle;
        cs += `(
`;

        let firstColumn = true;
        for (const [, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `    `;
            cs += column.csSqlType;
            cs += ` `;
            cs += column.pascalShortenedSingle;
        }

        cs += `)
{
    public const string TABLE = "[`;
        cs += tableName;
        cs += `]";
`;

        for (const [columnName, column] of table.columns)
        {
            cs += `
    public const string `;
            cs += column.blockShortenedSingle;
            cs += ` = $"[`;
            cs += tableName;
            cs += `].[`;
            cs += columnName;
            cs += `]";
`;
        }

        cs += `}
`;
    }

    return cs;
}