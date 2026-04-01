using System.Data.SqlTypes;

namespace DataDriven;

public static class SqlValueExtensions
{
    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static byte? CheckedValue(this SqlByte value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>xception cref="InvalidOperationException"></exception>
    public static byte StrictValue(this SqlByte value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static short? CheckedValue(this SqlInt16 value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static short StrictValue(this SqlInt16 value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static int? CheckedValue(this SqlInt32 value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static int StrictValue(this SqlInt32 value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static long? CheckedValue(this SqlInt64 value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static long StrictValue(this SqlInt64 value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static decimal? CheckedValue(this SqlDecimal value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static decimal StrictValue(this SqlDecimal value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static double? CheckedValue(this SqlDouble value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double StrictValue(this SqlDouble value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static float? CheckedValue(this SqlSingle value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static float StrictValue(this SqlSingle value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static bool? CheckedValue(this SqlBoolean value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool StrictValue(this SqlBoolean value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static DateTime? CheckedValue(this SqlDateTime value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static DateTime StrictValue(this SqlDateTime value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;

    /// <summary>
    /// Converts a Sql type to a nullable type, returning <c>null</c> if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? null : value.Value</c></returns>
    public static string? CheckedValue(this SqlString value)
        => value.IsNull ? null : value.Value;

    /// <summary>
    /// Converts a Sql type to a non-nullable type, throwing an exception if the Sql value is null.
    /// </summary>
    /// <returns><c>value.IsNull ? throw : value.Value</c></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string StrictValue(this SqlString value) => value.IsNull
        ? throw new InvalidOperationException("Sql value is null")
        : value.Value;
}