#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator DateTimeOffset?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<DateTimeOffset?>();
    }
}