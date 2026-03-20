import { type DatabaseStructure } from "./preprocess.ts";

export function csFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;

    let cs = "";

    cs += `
namespace DataDriven.Data;

// TODO`;

    return cs;
}