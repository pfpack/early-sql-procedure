#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator bool(
            DbDataValue dbDataValue)
            =>
            dbDataValue.CastNotNull<bool>();
    }
}