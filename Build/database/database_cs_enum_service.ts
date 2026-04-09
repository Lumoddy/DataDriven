import type { DatabaseColumn, DatabaseStructure, DatabaseTable } from "./preprocess.ts";

export function csEnumServiceFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;
    const enums = structure.enums;

    let cs = `
using System.Collections;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;
`;

    for (const [, table] of enums)
    {
        cs += `
public enum `;

        cs += table.pascalShortenedSingle;
        cs += ` : byte
{
`;

        for (const [, field] of table.fields)
        {
            cs += `    `;
            cs += field.pascalShortenedSingle;
            cs += `,
`;
        }

        cs += `}
`;
    }

    for (const [, table] of enums)
    {
        cs += `
public class `;

        cs += table.pascalShortenedSingle;
        cs += `Map(
`;

        let firstField = true;
        for (const [, field] of table.fields)
        {
            if (firstField)
                firstField = false;
            else
                cs += `,
`;

            cs += `    byte `;
            cs += field.camelShortenedSingle;
            cs += `EnumId`;
        }

        cs += `)
    : IReadOnlyDictionary<byte, `;
        cs += table.pascalShortenedSingle;
        cs += `>,
    IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>
{
    public `;
        cs += table.pascalShortenedSingle;
        cs += ` this[byte key] => key switch
    {
`;

        for (const [, field] of table.fields)
        {
            cs += `        var x when x == `;
            cs += field.camelShortenedSingle;
            cs += `EnumId => `;
            cs += table.pascalShortenedSingle;
            cs += `.`;
            cs += field.pascalShortenedSingle;
            cs += `,
`;
        }

        cs += `        var x => throw new KeyNotFoundException($"Key {x} not found in `;
        cs += table.pascalShortenedSingle;
        cs += `Map.")
    };

    public byte this[`;
        cs += table.pascalShortenedSingle;
        cs += ` key] => key switch
    {
`;

        for (const [, field] of table.fields)
        {
            cs += `        `;
            cs += table.pascalShortenedSingle;
            cs += `.`;
            cs += field.pascalShortenedSingle;
            cs += ` => `;
            cs += field.camelShortenedSingle;
            cs += `EnumId,
`;
        }

        cs += `        _ => throw new KeyNotFoundException($"Invalid key given to `;
        cs += table.pascalShortenedSingle;
        cs += `Map.")
    };

    public IEnumerable<byte> Keys
    {
        get
        {
`;

        for (const [, field] of table.fields)
        {
            cs += `            yield return `;
            cs += field.camelShortenedSingle;
            cs += `EnumId;
`;
        }

        cs += `        }
    }

    public IEnumerable<`;

        cs += table.pascalShortenedSingle;
        cs += `> Values => Enum.GetValues<`;
        cs += table.pascalShortenedSingle;
        cs += `>();

    IEnumerable<`;

        cs += table.pascalShortenedSingle;
        cs += `> IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>.Keys => Values;

    IEnumerable<byte> IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>.Values => Keys;

    public int Count => `;

        cs += table.fields.size;
        cs += `;

    public bool ContainsKey(byte key)
        => `;

        firstField = true;
        for (const [, field] of table.fields)
        {
            if (firstField)
                firstField = false;
            else
                cs += ` ||
            `;

            cs += `key == `;
            cs += field.camelShortenedSingle;
            cs += `EnumId`;
        }

        cs += `;

    bool IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>.ContainsKey(`;
        cs += table.pascalShortenedSingle;
        cs += ` key) => Enum.IsDefined(key);

    public IEnumerator<KeyValuePair<byte, `;
        cs += table.pascalShortenedSingle;
        cs += `>> GetEnumerator()
    {
`;

        for (const [, field] of table.fields)
        {
            cs += `        yield return new(`;
            cs += field.camelShortenedSingle;
            cs += `EnumId, `;
            cs += table.pascalShortenedSingle;
            cs += `.`;
            cs += field.pascalShortenedPlural;
            cs += `);
`;
        }

        cs += `    }

    IEnumerator<KeyValuePair<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>> IEnumerable<KeyValuePair<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>>.GetEnumerator()
    {
`;

        for (const [, field] of table.fields)
        {
            cs += `        yield return new(`;
            cs += table.pascalShortenedSingle;
            cs += `.`;
            cs += field.pascalShortenedPlural;
            cs += `, `;
            cs += field.camelShortenedSingle;
            cs += `EnumId`;
            cs += `);
`;
        }

        cs += `    }

    public bool TryGetValue(byte key, out `;
        cs += table.pascalShortenedSingle;
        cs += ` value)
    {
        if (ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    bool IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>.TryGetValue(`;
        cs += table.pascalShortenedSingle;
        cs += ` key, out byte value)
    {
        if (((IReadOnlyDictionary<`;
        cs += table.pascalShortenedSingle;
        cs += `, byte>)this).ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
`;
    }

    cs += `
public interface IDatabaseEnumService
{`;

    for (const [, table] of enums)
    {
        cs += `
    public `;
        cs += table.pascalShortenedSingle;
        cs += `Map `;
        cs += table.pascalShortenedSingle;
        cs += `Map { get; }
`;
    }

    cs += `}

public class DatabaseEnumService : IDatabaseEnumService
{`;

    for (const [, table] of enums)
    {
        cs += `
    private readonly `;
        cs += table.pascalShortenedSingle;
        cs += `Map `;
        cs += table.camelShortenedSingle;
        cs += `Map;
`;
    }

    cs += `
    public DatabaseEnumService(IConfiguration configuration)
    {
        using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        connection.Open();

        using SqlCommand command = new(
            $"""`;

    let firstField = true;
    for (const [enumName, table] of enums)
    {
        for (const [fieldName, field] of table.fields)
        {
            if (firstField)
                firstField = false;
            else
                cs += `
            IF @@ROWCOUNT = 0
                RETURN;
`;

            const tableColumns = (tables.get(enumName) as DatabaseTable).columns;
            const idColumnName = tableColumns.keys().find((x) => x.endsWith("_id")) as string;
            const nameColumnName = tableColumns.keys().find((x) => x.endsWith("_name")) as string;

            cs += `
            SELECT [`;

            cs += idColumnName;
            cs += `]
            FROM [`;

            cs += enumName;
            cs += `]
            WHERE [`;

            cs += nameColumnName;
            cs += `] = '`;
            cs += fieldName;
            cs += `';
`;
        }
    }

    cs += `            """,
            connection);

        using SqlDataReader reader = command.ExecuteReader();
`;

    firstField = true;
    for (const [enumName, table] of enums)
    {
        for (const [fieldName, field] of table.fields)
        {
            if (firstField)
                firstField = false;
            else
                cs += `
        reader.NextResult();
`;

            cs += `
        if (!reader.Read())
            throw new InvalidOperationException(
                "Database does not contain an entry for '`;
            cs += fieldName;
            cs += `' in the '`;
            cs += enumName;
            cs += `' enum.");

        byte `;
            cs += table.camelSingle;
            cs += field.pascalPlural;
            cs += ` = reader.GetSqlByte(0).StrictValue();
`;
        }

        cs += `
        `;
        cs += table.camelShortenedSingle;
        cs += `Map = new(
`;

        let firstFieldInNew = true;
        for (const [fieldName, field] of table.fields)
        {
            if (firstFieldInNew)
                firstFieldInNew = false;
            else
                cs += `,
`;

            cs += `            `;
            cs += table.camelSingle;
            cs += field.pascalPlural;
        }

        cs += `);
`;
    }

    cs += `    }
`;

    for (const [, table] of enums)
    {
        cs += `
    public `;
        cs += table.pascalShortenedSingle;
        cs += `Map `;
        cs += table.pascalShortenedSingle;
        cs += `Map
        => `;

        cs += table.camelShortenedSingle;
        cs += `Map;
`;
    }

    cs += `}
`;

    return cs;
}