#nullable enable

using System;
using System.Data.Common;

namespace PrimeFuncPack.Data
{
    internal static class DbExtensions
    {
        internal static object? InternalGetValueOrNull(
            this DbDataReader dbDataReader,
            int ordinal)
            =>
            Pipeline.Pipe(
                ordinal)
            .Pipe(
                dbDataReader.GetValue)
            .Pipe(
                dbValue => DBNull.Value.Equals(dbValue) ? null : dbValue);
    }
}