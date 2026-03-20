import { type DatabaseStructure } from "./preprocess.ts";

export function sqlFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;

    let sql = "";

    for (const [name, table] of tables)
    {
        if (table.columns.size !== 0)
        {
            sql += `
CREATE TABLE `;
            sql += name;
            sql += ` (
`;

            let firstColumn = true;
            for (const [name, column] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    sql += `,
`;

                sql += `    `;
                sql += name;
                sql += ` `;
                sql += column.type;

                if (column.size !== undefined)
                {
                    sql += `(`;
                    sql += column.size;
                    sql += `)`;
                }

                sql += column.nullable ? ` NULL` : ` NOT NULL`;
            }

            sql += `);
`;
        }
    }

    for (const [name, table] of tables)
    {
        for (const constraint of table.constraints)
        {
            switch (constraint.type)
            {
                case "primary":
                {
                    sql += `
ALTER TABLE `;

                    sql += name;
                    sql += `
    ADD CONSTRAINT unique_`;

                    sql += constraint.columns.join("_and_");
                    sql += ` PRIMARY KEY (
        `;

                    sql += constraint.columns.join(`,
        `);

                    sql += `);
`;

                    break;
                }
                case "unique":
                {
                    sql += `
ALTER TABLE `;

                    sql += name;
                    sql += `
    ADD CONSTRAINT unique_`;

                    sql += constraint.columns.join("_and_");
                    sql += ` UNIQUE (
        `;

                    sql += constraint.columns.join(`,
        `);

                    sql += `);
`;

                    break;
                }
            }
        }
    }

    for (const [name, table] of tables)
    {
        for (const constraint of table.constraints)
        {
            switch (constraint.type)
            {
                case "foreign":
                {
                    sql += `
ALTER TABLE `;

                    sql += name;
                    sql += `
    ADD CONSTRAINT `;

                    sql += constraint.otherColumns.join("_and_");
                    sql += `_in_`;
                    sql += constraint.other;
                    sql += `
        FOREIGN KEY (
            `;

                    sql += constraint.columns.join(`,
            `);

                    sql += `)
        REFERENCES `;

                    sql += constraint.other;
                    sql += ` (
            `;

                    sql += constraint.otherColumns.join(`,
            `);

                    sql += `);
`;

                    break;
                }
            }
        }
    }

    return sql;
}