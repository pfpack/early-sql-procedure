#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator Guid(
            DbDataValue dbDataValue)
            =>
            dbDataValue.CastNotNull<Guid>();
    }
}