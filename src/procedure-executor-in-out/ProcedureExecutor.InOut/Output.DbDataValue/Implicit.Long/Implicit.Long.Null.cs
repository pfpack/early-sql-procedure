#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator long?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<long?>();
    }
}