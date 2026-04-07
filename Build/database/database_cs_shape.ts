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
/// <summary>
/// Stored in the database as:
/// <code>
/// TABLE [`;
        cs += tableName;
        cs += `] (
/// `;

        let firstColumn = true;
        let constraintCounter = 0;
        for (const [columnName, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
/// `;

            cs += `    [`;
            cs += columnName;
            cs += `] `;
            cs += column.type;

            if (column.size !== undefined)
            {
                cs += `(`;
                cs += column.size;

                if (column.precision !== undefined)
                {
                    cs += `, `;
                    cs += column.precision;
                }

                cs += `)`;
            }

            cs += column.nullable ? ` NULL` : ` NOT NULL`;

            if (column.defaultSql !== undefined)
            {
                cs += ` CONSTRAINT [default_`;
                cs += tableName;
                cs += `_`;
                constraintCounter += 1;
                cs += constraintCounter;
                cs += `] DEFAULT `;
                cs += column.defaultSql;
            }
        }

        cs += `);
/// </code>
/// </summary>`;

        for (const [columnName, column] of table.columns)
        {
            cs += `
/// <param name="`;

            cs += column.pascalShortenedSingle
            cs += `">
/// Stored in the database as:
/// <code>
/// `;
            cs += `[`;
            cs += columnName;
            cs += `] `;
            cs += column.type;

            if (column.size !== undefined)
            {
                cs += `(`;
                cs += column.size;

                if (column.precision !== undefined)
                {
                    cs += `, `;
                    cs += column.precision;
                }

                cs += `)`;
            }

            cs += column.nullable ? ` NULL` : ` NOT NULL`;

            if (column.defaultSql !== undefined)
            {
                cs += ` CONSTRAINT [default_`;
                cs += tableName;
                cs += `_`;
                constraintCounter += 1;
                cs += constraintCounter;
                cs += `] DEFAULT `;
                cs += column.defaultSql;
            }

            cs += `
/// </code>
/// </param>`;
        }

        cs += `
public partial record Sql`;

        cs += table.pascalShortenedSingle;
        cs += `(
`;

        firstColumn = true;
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
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// TABLE [`;
        cs += tableName;
        cs += `] (
    /// `;

        firstColumn = true;
        constraintCounter = 0;
        for (const [columnName, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
    /// `;

            cs += `    [`;
            cs += columnName;
            cs += `] `;
            cs += column.type;

            if (column.size !== undefined)
            {
                cs += `(`;
                cs += column.size;

                if (column.precision !== undefined)
                {
                    cs += `, `;
                    cs += column.precision;
                }

                cs += `)`;
            }

            cs += column.nullable ? ` NULL` : ` NOT NULL`;

            if (column.defaultSql !== undefined)
            {
                cs += ` CONSTRAINT [default_`;
                cs += tableName;
                cs += `_`;
                constraintCounter += 1;
                cs += constraintCounter;
                cs += `] DEFAULT `;
                cs += column.defaultSql;
            }
        }

        cs += `);
    /// </code>
    /// </summary>
    public const string TABLE = "[`;
        cs += tableName;
        cs += `]";
`;

        for (const [columnName, column] of table.columns)
        {
            cs += `
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// `;
            cs += `[`;
            cs += columnName;
            cs += `] `;
            cs += column.type;

            if (column.size !== undefined)
            {
                cs += `(`;
                cs += column.size;

                if (column.precision !== undefined)
                {
                    cs += `, `;
                    cs += column.precision;
                }

                cs += `)`;
            }

            cs += column.nullable ? ` NULL` : ` NOT NULL`;

            if (column.defaultSql !== undefined)
            {
                cs += ` CONSTRAINT [default_`;
                cs += tableName;
                cs += `_`;
                constraintCounter += 1;
                cs += constraintCounter;
                cs += `] DEFAULT `;
                cs += column.defaultSql;
            }

            cs += `
    /// </code>
    /// </summary>
    public const string TABLE_`;
            cs += column.blockShortenedSingle;
            cs += ` = "[`;
            cs += tableName;
            cs += `].[`;
            cs += columnName;
            cs += `]";
`;
        }

        for (const [columnName, column] of table.columns)
        {
            cs += `
    /// <summary>
    /// Stored in the database as:
    /// <code>
    /// `;
            cs += `[`;
            cs += columnName;
            cs += `] `;
            cs += column.type;

            if (column.size !== undefined)
            {
                cs += `(`;
                cs += column.size;

                if (column.precision !== undefined)
                {
                    cs += `, `;
                    cs += column.precision;
                }

                cs += `)`;
            }

            cs += column.nullable ? ` NULL` : ` NOT NULL`;

            if (column.defaultSql !== undefined)
            {
                cs += ` CONSTRAINT [default_`;
                cs += tableName;
                cs += `_`;
                constraintCounter += 1;
                cs += constraintCounter;
                cs += `] DEFAULT `;
                cs += column.defaultSql;
            }

            cs += `
    /// </code>
    /// </summary>
    public const string `;
            cs += column.blockShortenedSingle;
            cs += ` = "[`;
            cs += columnName;
            cs += `]";
`;
        }

        cs += `}
`;
    }

    return cs;
}