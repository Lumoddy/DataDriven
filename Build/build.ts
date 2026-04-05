import * as fs from "node:fs/promises";
import { log } from "./logging.ts";
import * as YAML from "yaml";
import { sqlFileFrom } from "./database/database_sql.ts";
import { preprocessObject } from "./database/preprocess.ts";
import { exec } from "node:child_process";
import { csShapeFileFrom } from "./database/database_cs_shape.ts";
import { csEnumServiceFileFrom } from "./database/database_cs_enum_service.ts";

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
            new Promise<void>((resolve, reject) => exec("npx tsc", {}, (error) =>
            {
                if (error !== null)
                    return reject(error);

                log("success", "Transpiled TypeScript.");
                resolve();
            })),

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