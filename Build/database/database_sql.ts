import type { DatabaseStructure } from "./preprocess.ts";

export function sqlFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;

    let sql = `
BEGIN TRANSACTION;
`;

    for (const [tableName, table] of tables)
    {
        if (table.columns.size !== 0)
        {
            sql += `
CREATE TABLE [`;
            sql += tableName;
            sql += `] (
`;

            let firstColumn = true;
            for (const [columnName, column] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    sql += `,
`;

                sql += `    [`;
                sql += columnName;
                sql += `] `;
                sql += column.type;

                if (column.size !== undefined)
                {
                    sql += `(`;
                    sql += column.size;

                    if (column.precision !== undefined)
                    {
                        sql += `, `;
                        sql += column.precision;
                    }

                    sql += `)`;
                }

                sql += column.nullable ? ` NULL` : ` NOT NULL`;
            }

            sql += `);
`;
        }
    }

    for (const [tableName, table] of tables)
    {
        let constraintCounter = 0;

        for (const constraint of table.constraints)
        {
            switch (constraint.type)
            {
                case "primary":
                {
                    sql += `
ALTER TABLE [`;

                    sql += tableName;
                    sql += `]
    ADD CONSTRAINT [unique_`;

                    sql += tableName;
                    sql += `_`;

                    constraintCounter += 1;
                    sql += constraintCounter;
                    sql += `] PRIMARY KEY (
`;

                    let columnFirst = true;
                    for (const [columnName, ] of constraint.columns)
                    {
                        if (columnFirst)
                            columnFirst = false;
                        else
                            sql += `,
`;

                        sql += `        [`;
                        sql += columnName;
                        sql += `]`;
                    }

                    sql += `);
`;

                    break;
                }
                case "unique":
                {
                    sql += `
ALTER TABLE [`;

                    sql += tableName;
                    sql += `]
    ADD CONSTRAINT [unique_`;

                    sql += tableName;
                    sql += `_`;

                    constraintCounter += 1;
                    sql += constraintCounter;
                    sql += `] UNIQUE (
`;

                    let columnFirst = true;
                    for (const [columnName, ] of constraint.columns)
                    {
                        if (columnFirst)
                            columnFirst = false;
                        else
                            sql += `,
`;

                        sql += `        [`;
                        sql += columnName;
                        sql += `]`;
                    }

                    sql += `);
`;

                    break;
                }
            }
        }
    }

    for (const [tableName, table] of tables)
    {
        let constraintCounter = 0;

        for (const constraint of table.constraints)
        {
            switch (constraint.type)
            {
                case "foreign":
                {
                    sql += `
ALTER TABLE [`;

                    sql += tableName;
                    sql += `]
    ADD CONSTRAINT [fk_`;

                    sql += tableName;
                    sql += `_to_`;
                    sql += constraint.other;
                    sql += `_`;

                    constraintCounter += 1;
                    sql += constraintCounter;
                    sql += `]
        FOREIGN KEY (
`;

                    let columnFirst = true;
                    for (const [columnName, ] of constraint.columns)
                    {
                        if (columnFirst)
                            columnFirst = false;
                        else
                            sql += `,
`;

                        sql += `            [`;
                        sql += columnName;
                        sql += `]`;
                    }

                    sql += `)
        REFERENCES [`;

                    sql += constraint.other;
                    sql += `] (
`;

                    columnFirst = true;
                    for (const [columnName, ] of constraint.otherColumns)
                    {
                        if (columnFirst)
                            columnFirst = false;
                        else
                            sql += `,
`;

                        sql += `            [`;
                        sql += columnName;
                        sql += `]`;
                    }

                    sql += `);
`;

                    break;
                }
            }
        }
    }

    sql += `
COMMIT TRANSACTION;
`;

    return sql;
}