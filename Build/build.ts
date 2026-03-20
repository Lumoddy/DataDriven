import * as fs from "node:fs/promises";
import { log } from "./logging.ts";
import * as YAML from "yaml";
import { sqlDatabaseFromYaml } from "./database/database_sql.ts";

log("success", "Initialized.");

(async () =>
{
    let file;
    try { file = YAML.parse(await fs.readFile("./Build/database/database_structure.yaml", "utf-8")) }
    catch (e)
    {
        log("error", e instanceof Error ? e.message : e);
        return;
    }

    const replacements = file.replacements;
    const tables = file.tables;

    for (const name in tables)
    {
        const table = tables[name];

        const columns = table.columns;
        for (let i = 0; i < columns.length; i += 1)
        {
            toNext: for (const [from, to] of replacements)
            {
                const column = columns[i];

                for (const key in from)
                {
                    if (String.prototype.toUpperCase.call(column[key]) !==
                        String.prototype.toUpperCase.call(from[key]))
                        continue toNext;
                }

                columns[i] = { ...column, ...to };
            }
        }

        const constraints = table.constraints;
        for (const constraint of constraints)
        {
            if ("foreign" in constraint)
            {
                let from, to, toTable;
                const foreign = constraint["foreign"];
                for (const part in foreign)
                {
                    if (part === "from")
                        from = foreign["from"];
                    else
                        to = foreign[toTable = part];
                }

                constraint["foreign"] = { from, to, toTable };
            }
        }
    }

    try
    {
        await Promise.all(
        [
            fs.writeFile("./Build/database/database_structure.sql", sqlDatabaseFromYaml(file), "utf-8"),
        ]);
    }
    catch (e)
    {
        log("error", e instanceof Error ? e.message : e);
        return;
    }
})();