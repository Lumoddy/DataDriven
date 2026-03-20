import * as fs from "node:fs/promises";
import { log } from "./logging.ts";
import * as YAML from "yaml";
import { sqlFileFrom } from "./database/database_sql.ts";
import { preprocessObject } from "./database/preprocess.ts";
import { exec } from "node:child_process";
import { csFileFrom } from "./database/database_cs.ts";

// ASP.NET has custom build options that are capable of running this but it
// shows its own errors that I don't want to deal with.
// 
// Run this command instead:
// node ./Build/build.ts

log("success", "Build Started.");

(async () =>
{
    let file;
    try { file = YAML.parse(await fs.readFile("./Build/database/database_structure.yaml", "utf-8")) }
    catch (e)
    {
        log("error", e instanceof Error ? e.message : e);
        return;
    }

    try
    {
        await Promise.all(
        [
            fs.writeFile(
                "./Build/database/database_structure.sql",
                `--- This file was auto-generated based on ./Build/database/database_structure.yaml
` + sqlFileFrom(preprocessObject(file)),
                "utf-8")
                .then(() => log("success", "Converted database structure to SQL file.")),

            fs.writeFile(
                "./Models/DatabaseStructure.cs",
                `// This file was auto-generated based on ./Build/database/database_structure.yaml
` + csFileFrom(preprocessObject(file)),
                "utf-8")
                .then(() => log("success", "Converted database structure to C# accessors.")),

            new Promise<void>((resolve, reject) => exec("npx tsc", {}, (error) =>
            {
                if (error !== null)
                {
                    log("error", error.message);
                    reject(error);
                }
                else
                {
                    log("success", "Transpiled TypeScript.");
                    resolve();
                }
            })),
        ]);

        log("success", "Build Completed.");
    }
    catch (e)
    {
        log("error", e instanceof Error ? e.message : e);
        return;
    }
})();