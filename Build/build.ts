import * as fs from "node:fs/promises";
import { log } from "./logging.ts";
import * as YAML from "yaml";
import { sqlFileFrom } from "./database/database_sql.ts";
import { preprocessObject } from "./database/preprocess.ts";
import { exec } from "node:child_process";
import { csShapeFileFrom } from "./database/database_cs_shape.ts";
import { csEnumServiceFileFrom } from "./database/database_cs_enum_service.ts";
import { sqlEnumSetupFileFrom } from "./database/database_sql_enum_setup.ts";

// ASP.NET has custom build options that are capable of running this but it
// shows its own errors that I don't want to deal with.
// 
// Run this command instead:
// node ./Build/build.ts

log("success", "Build Started.");

(async () =>
{
    try
    {
        await Promise.all(
        [
            (async () =>
            {
                const dir = await fs.opendir("./wwwroot/ts");

                try
                {
                    if (await dir.read() !== null)
                        return;
                }
                finally { await dir.close() }

                await new Promise<void>((resolve, reject) => exec("npx tsc", {}, (error) =>
                {
                    if (error !== null)
                        return reject(error);

                    log("success", "Transpiled TypeScript.");
                    resolve();
                }));
            }),

            (async () =>
            {
                let file;
                try { file = YAML.parse(await fs.readFile("./Build/database/database_structure.yaml", "utf-8")) }
                catch (e)
                {
                    log("error", e instanceof Error ? e.stack : e);
                    return;
                }

                const databaseStructure = preprocessObject(file);

                await Promise.all(
                [
                    fs.writeFile(
                        "./Build/database/database_structure.sql",
                        `--- This file was auto-generated based on ./Build/database/database_structure.yaml
` + sqlFileFrom(databaseStructure),
                        "utf-8")
                        .then(() => log("success", "Converted database structure to SQL file.")),

                    fs.writeFile(
                        "./Data/DatabaseTables.cs",
                        `// This file was auto-generated based on ./Build/database/database_structure.yaml
` + csShapeFileFrom(databaseStructure),
                        "utf-8")
                        .then(() => log("success", "Converted database tables to C# records.")),

                    fs.writeFile(
                        "./Data/DatabaseEnums.cs",
                        `// This file was auto-generated based on ./Build/database/database_structure.yaml
` + csEnumServiceFileFrom(databaseStructure),
                        "utf-8")
                        .then(() => log("success", "Converted database enums to ASP.NET enum service.")),

                    Promise.all(
                        sqlEnumSetupFileFrom(databaseStructure)
                            .entries()
                            .map(([name, contents]) => fs.writeFile(
                                `./Build/database/procedures/enum_setup/${name}.sql`,
                                `--- This file was auto-generated based on ./Build/database/database_structure.yaml
` + contents,
                                "utf-8"))
                            .toArray())
                        .then(() => log("success", "Converted database structure to SQL enum setup procedures.")),
                ]);
            })(),
        ]);

        log("success", "Build Completed.");
    }
    catch (e)
    {
        log("error", e instanceof Error ? e.stack : e);
        return;
    }
})();