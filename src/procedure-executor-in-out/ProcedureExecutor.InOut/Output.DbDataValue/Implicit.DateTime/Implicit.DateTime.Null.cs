#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator DateTime?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<DateTime?>();
    }
}