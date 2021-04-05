#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator double(
            DbDataValue dbDataValue)
            =>
            dbDataValue.CastNotNull<double>();
    }
}