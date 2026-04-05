import type { DatabaseStructure, DatabaseTable } from "./preprocess.ts";

export function sqlFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;
    const enums = structure.enums;

    let sql = `
BEGIN TRANSACTION;
`;

    for (const [tableName, table] of tables)
    {
        sql += `
CREATE TABLE [`;
        sql += tableName;
        sql += `] (
`;

        let firstColumn = true;
        let constraintCounter = 0;
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

            if (column.defaultSql !== undefined)
            {
                sql += ` CONSTRAINT [default_`;
                sql += tableName;
                sql += `_`;
                constraintCounter += 1;
                sql += constraintCounter;
                sql += `] DEFAULT `;
                sql += column.defaultSql;
            }
        }

        sql += `);
`;
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

    for (const [enumName, table] of enums)
    {
        sql += `
INSERT INTO [`;
        sql += enumName;
        sql += `] (`;

        let firstColumn = true;
        for (const [columnName, ] of (tables.get(enumName) as DatabaseTable).columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                sql += `, `;

            sql += `[`;
            sql += columnName;
            sql += `]`;
        }

        sql += `) VALUES
`;

        for (const [i, [fieldName, field]] of table.fields.entries().map((x, i) => [i, x] as const))
        {
            if (i !== 0)
                sql += `,
`;

            sql += `    (`;
            sql += i;
            sql += `, '`;
            sql += fieldName;
            sql += `')`;
        }

        sql += `;
`;
    }

    sql += `
COMMIT TRANSACTION;
`;

    return sql;
}