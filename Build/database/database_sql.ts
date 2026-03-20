
export function sqlDatabaseFromYaml(yaml: any): string
{
    const tables = yaml.tables;

    let sql = `--- This file was auto-generated based on ./Build/database/database_structure.yaml

START TRANSACTION;

`;

    for (const name in tables)
    {
        const table = tables[name];
        const columns = table.columns;

        sql += `CREATE TABLE `;
        sql += name;
        sql += ` (
`;

        let first = true;
        for (const column of columns)
        {
            if (first)
                first = false;
            else
                sql += `,
`;
            sql += `    `;
            sql += column["name"];
            sql += ` `;
            sql += column["type"];

            if (column["size"] != null)
            {
                sql += `(`;
                sql += column["size"];
                sql += `)`;
            }

            if ("signed" in column)
                sql += column["signed"] ? " SIGNED" : " UNSIGNED";

            sql += column["nullable"] ? " NULL" : " NOT NULL";
        }

        sql += `);

`;
    }

    for (const name in tables)
    {
        const table = tables[name];
        const constraints = table.constraints;

        sql += `ALTER TABLE `;
        sql += name;
        sql += `
`;

        let first = true;
        for (const constraint of constraints)
        {
            if ("primary" in constraint)
            {
                if (first)
                    first = false;
                else
                    sql += `,
`;

                sql += `    ADD PRIMARY KEY (`;

                let firstColumn = true;
                for (const column of constraint["primary"])
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `, `;

                    sql += column;
                }

                sql += `)`;
            }
            else if ("unique" in constraint)
            {
                if (first)
                    first = false;
                else
                    sql += `,
    `;

                sql += `    ADD UNIQUE KEY `;

                let firstColumn = true;
                for (const column of constraint["unique"])
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `_and_`;

                    sql += column;
                }

                sql += ` (`;

                firstColumn = true;
                for (const column of constraint["unique"])
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `, `;

                    sql += column;
                }

                sql += `)`;
            }
            else if ("foreign" in constraint)
            {
                const foreign = constraint["foreign"];

                if (first)
                    first = false;
                else
                    sql += `,
`;

                sql += `    ADD KEY `;

                let firstColumn = true;
                for (const column of foreign.from)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `_and_`;

                    sql += column;
                }

                sql += ` (`;

                firstColumn = true;
                for (const column of foreign.from)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `, `;

                    sql += column;
                }

                sql += `)`;
            }
        }

        sql += `;

`;
    }

    for (const name in tables)
    {
        const table = tables[name];
        const constraints = table.constraints;

        sql += `ALTER TABLE `;
        sql += name;
        sql += `
`;

        let first = true;
        for (const constraint of constraints)
        {
            if ("foreign" in constraint)
            {
                const foreign = constraint["foreign"];

                if (first)
                    first = false;
                else
                    sql += `,
`;

                sql += `    ADD CONSTRAINT `;

                let firstColumn = true;
                for (const column of foreign.from)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `_and_`;

                    sql += column;
                }

                sql += `_to_`;

                firstColumn = true;
                for (const column of foreign.to)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `_and_`;

                    sql += column;
                }

                sql += `_in_`;
                sql += foreign.toTable;
                sql += ` FOREIGN KEY (`;

                firstColumn = true;
                for (const column of foreign.from)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `, `;

                    sql += column;
                }

                sql += `) REFERENCES `;
                sql += foreign.toTable;
                sql += ` (`;

                firstColumn = true;
                for (const column of foreign.to)
                {
                    if (firstColumn)
                        firstColumn = false;
                    else
                        sql += `, `;

                    sql += column;
                }

                sql += `)`;
            }
        }

        sql += `;

`;
    }

    sql += `COMMIT;`;

    sql = sql.replaceAll(/\n\nALTER TABLE \w+\n;/g, "");

    return sql;
}