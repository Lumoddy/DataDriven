import type { DatabaseColumn, DatabaseStructure } from "./preprocess.ts";

export function csFileFrom(structure: DatabaseStructure): string
{
    const tables = structure.tables;

    let cs = "";

    cs += `
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;
`;

    for (const [tableName, table] of tables)
    {
        cs += `
public partial record `;

        cs += table.pascalSingle;
        cs += `(
`;

        let firstColumn = true;
        for (const [columnName, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `    `;
            cs += column.csType;

            if (column.nullable)
                cs += `?`;

            cs += ` `;
            cs += column.pascalShortenedSingle;
        }

        cs += `);

public record Sql`;

        cs += table.pascalSingle;
        cs += `(
`;

        firstColumn = true;
        for (const [, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `    `;
            cs += column.csSqlType;
            cs += ` `;
            cs += column.pascalSingle;
        }

        cs += `)
{
    public const string TABLE = "[`;
            cs += tableName;
            cs += `]";
`;

        for (const [columnName, column] of table.columns)
        {
            cs += `
    public const string `;
            cs += column.blockShortenedSingle;
            cs += ` = "[`;
            cs += columnName;
            cs += `]";

    public const string TABLE_`;
            cs += column.blockShortenedSingle;
            cs += ` = $"[`;
            cs += tableName;
            cs += `].[`;
            cs += columnName;
            cs += `]";
`;
        }

        cs += `
    public `;
        cs += table.pascalSingle;
        cs += ` Value => new(
`;

        firstColumn = true;
        for (const [, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `        `;
            cs += column.pascalSingle;
            cs += `.Value`;
        }

        cs += `);

    public Sql`;

        cs += table.pascalSingle;
        cs += `(`;
        cs += table.pascalSingle;
        cs += ` data) : this(
`;

        firstColumn = true;
        for (const [, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `        data.`;
            cs += column.pascalShortenedSingle;

            if (column.nullable)
            {
                cs += ` ?? `;
                cs += column.csSqlType;
                cs += `.Null`;
            }
        }

        cs += `) { }

    public static explicit operator `;

        cs += table.pascalSingle;
        cs += `(Sql`;
        cs += table.pascalSingle;
        cs += ` value) => value.Value;
    public static implicit operator Sql`;

        cs += table.pascalSingle;
        cs += `(`;
        cs += table.pascalSingle;
        cs += ` value) => new(value);
}
`;
    }

    cs += `
public class SqlDataDrivenDataAccess(
    SqlConnection source,
    bool sourceConsumed = true): IAsyncDisposable, IDisposable
{
    private const int VARCHAR_MAX_LENGTH = `;

    cs += (2 ** 31) - 1;
    cs += `;

    public SqlConnection Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }
`;

    for (const [tableName, table] of tables)
    {
        for (const constraint of table.constraints)
        {
            switch (constraint.type)
            {
                default:
                    continue;
                case "primary":
                case "unique":
            }

            cs += `
    private SqlCommand SelectUniqueSql`;

            cs += table.pascalSingle;
            cs += `Command(
`;

            let firstColumn = true;
            for (const [, column] of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `        `;
                cs += column.csSqlType;
                cs += ` `;
                cs += column.camelSingle;
            }

            cs += `)
    {
        var command = new SqlCommand(
            "SELECT `;

            firstColumn = true;
            for (const [columnName, ] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `, `;

                cs += `[`;
                cs += columnName;
                cs += `]`;
            }

            cs += ` FROM [`;
            cs += tableName;
            cs += `] WHERE `;

            firstColumn = true;
            for (const columnName of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += ` AND `;

                cs += `[`;
                cs += columnName;
                cs += `] = @`;
                cs += columnName;
            }

            cs += `",
            source);

`;

            for (const [columnName, column] of constraint.columns)
            {
                cs += `        command.Parameters.Add("`;
                cs += columnName;
                cs += `", SqlDbType.`;
                cs += column.csSqlTypeEnum;
                cs += `).SqlValue = `;
                cs += column.camelSingle;
                cs += `;
`;
            }

            cs += `
        return command;
    }

    public Sql`;

            cs += table.pascalSingle;
            cs += `? SelectUniqueSql`;
            cs += table.pascalSingle;
            cs += `(
`;
            firstColumn = true;
            for (const [, column] of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `        `;
                cs += column.csSqlType;
                cs += ` `;
                cs += column.camelSingle;
            }

            cs += `)
    {
        var command = SelectUniqueSql`;
            cs += table.pascalSingle;
            cs += `Command(
`;
            firstColumn = true;
            for (const [, column] of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `            `;
                cs += column.camelSingle;
            }

            cs += `);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
            return null;

        return new(
`;

            let i = 0;
            for (const [, column] of table.columns)
            {
                if (i !== 0)
                    cs += `,
`;

                cs += `            `;
                cs += column.pascalSingle;
                cs += `: reader.Get`;
                cs += column.csSqlType;
                cs += `(`;
                cs += i;
                cs += `)`;

                i += 1;
            }

            cs += `);
    }

    public Task<Sql`;

            cs += table.pascalSingle;
            cs += `?> SelectUniqueSql`;
            cs += table.pascalSingle;
            cs += `Async(
`;
            firstColumn = true;
            for (const [, column] of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `        `;
                cs += column.csSqlType;
                cs += ` `;
                cs += column.camelSingle;
            }

            cs += `)
    {
        return SelectUniqueSql`;
            cs += table.pascalSingle;
            cs += `Async(
`;
            for (const [, column] of constraint.columns)
            {
                cs += `            `;
                cs += column.camelSingle;
                cs += `,
`;
            }

            cs += `            CancellationToken.None);
    }

    public async Task<Sql`;

            cs += table.pascalSingle;
            cs += `?> SelectUniqueSql`;
            cs += table.pascalShortenedSingle;
            cs += `Async(
`;
            for (const [, column] of constraint.columns)
            {
                cs += `        `;
                cs += column.csSqlType;
                cs += ` `;
                cs += column.camelSingle;
                cs += `,
`;
            }

            cs += `        CancellationToken cancellationToken)
    {
        var command = SelectUniqueSql`;
            cs += table.pascalSingle;
            cs += `Command(
`;
            firstColumn = true;
            for (const [, column] of constraint.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `            `;
                cs += column.camelSingle;
            }

            cs += `);

        var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return new(
`;

            i = 0;
            for (const [, column] of table.columns)
            {
                if (i !== 0)
                    cs += `,
`;

                cs += `            `;
                cs += column.pascalSingle;
                cs += `: reader.Get`;
                cs += column.csSqlType;
                cs += `(`;
                cs += i;
                cs += `)`;

                i += 1;
            }

            cs += `);
    }

    private SqlCommand InsertSql`;
            cs += table.pascalSingle;
            cs += `Command(
`;
            firstColumn = true;
            for (const [, column] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `        `;
                cs += column.csSqlType;
                cs += ` `;
                cs += column.camelSingle;
            }

            cs += `)
    {
        var command = new SqlCommand(
            "INSERT INTO [`;
            cs += tableName;
            cs += `] (`;

            firstColumn = true;
            for (const [columnName, ] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `, `;

                cs += `[`;
                cs += columnName;
                cs += `]`;
            }

            cs += `) VALUES (`;

            firstColumn = true;
            for (const [columnName, ] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `, `;

                cs += `@`;
                cs += columnName;
            }

            cs += `)",
            source);

`;

            for (const [columnName, column] of table.columns)
            {
                cs += `        command.Parameters.Add("`;
                cs += columnName;
                cs += `", SqlDbType.`;
                cs += column.csSqlTypeEnum;

                const size = column.size;
                if (size === "MAX")
                {
                    cs += `, VARCHAR_MAX_LENGTH`;
                }
                else if (size !== undefined)
                {
                    cs += `, `;
                    cs += size;
                }

                cs += `).SqlValue = `;
                cs += column.camelSingle;
                cs += `;
`;
            }

            cs += `
        return command;
    }

    public void InsertSql`;
            cs += table.pascalSingle;
            cs += `(Sql`;
            cs += table.pascalSingle;
            cs += ` `;
            cs += table.camelSingle;
            cs += `)
    {
        var command = InsertSql`;
            cs += table.pascalSingle;
            cs += `Command(
`;
            firstColumn = true;
            for (const [, column] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `            `;
                cs += table.camelSingle;
                cs += `.`;
                cs += column.pascalSingle;
            }

            cs += `);

        command.ExecuteNonQuery();
    }

    public Task InsertSql`;
            cs += table.pascalSingle;
            cs += `Async(Sql`;
            cs += table.pascalSingle;
            cs += ` `;
            cs += table.camelSingle;
            cs += `)
        => InsertSql`;
            cs += table.pascalSingle;
            cs += `Async(`;
            cs += table.camelSingle;
            cs += `, CancellationToken.None);

    public Task InsertSql`;
            cs += table.pascalSingle;
            cs += `Async(
        Sql`;
            cs += table.pascalSingle;
            cs += ` `;
            cs += table.camelSingle;
            cs += `,
        CancellationToken cancellationToken)
    {
        var command = InsertSql`;
            cs += table.pascalSingle;
            cs += `Command(
`;
            firstColumn = true;
            for (const [, column] of table.columns)
            {
                if (firstColumn)
                    firstColumn = false;
                else
                    cs += `,
`;

                cs += `            `;
                cs += table.camelSingle;
                cs += `.`;
                cs += column.pascalSingle;
            }

            cs += `);

        return command.ExecuteNonQueryAsync(cancellationToken);
    }
`;
        }
    }

    cs += `
    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}
`;

    for (const [, table] of tables)
    {
        cs += `
public class Sql`;

        cs += table.pascalSingle;
        cs += `Reader(
    SqlDataReader source,
`;

        for (const [, column] of table.columns)
        {
            cs += `    int `;
            cs += column.camelSingle;
            cs += `ColumnIndex,
`;
        }

        cs += `    bool sourceConsumed = true) : IAsyncEnumerator<Sql`;
        cs += table.pascalSingle;
        cs += `>, IEnumerator<Sql`;
        cs += table.pascalSingle;
        cs += `>
{
    public SqlDataReader Source { get => source; }

    /// <summary>
    /// The call to <c>Dispose()</c> will be relayed to the source if this is <c>true</c>.
    /// </summary>
    public bool SourceConsumed { get => sourceConsumed; set => sourceConsumed = value; }

    public Sql`;
        cs += table.pascalSingle;
        cs += ` Current
    {
        get => new(
`;

        let firstColumn = true;
        for (const [, column] of table.columns)
        {
            if (firstColumn)
                firstColumn = false;
            else
                cs += `,
`;

            cs += `            `;
            cs += column.pascalSingle;
            cs += `: source.Get`;
            cs += column.csSqlType;
            cs += `(`;
            cs += column.camelSingle;
            cs += `ColumnIndex)`;
        }

        cs += `);
    }

    object IEnumerator.Current => Current;

    Sql`;
        cs += table.pascalSingle;
        cs += ` IAsyncEnumerator<Sql`;
        cs += table.pascalSingle;
        cs += `>.Current => Current;

    public async ValueTask<bool> MoveNextAsync() => await source.ReadAsync();

    public ValueTask DisposeAsync() => sourceConsumed ? source.DisposeAsync() : ValueTask.CompletedTask;

    public bool MoveNext() => source.Read();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset() => throw new InvalidOperationException();

    public void Dispose()
    {
        if (sourceConsumed)
            source.Dispose();
    }
}
`;
    }

    return cs;
}