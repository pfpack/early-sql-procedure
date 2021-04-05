#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator decimal?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<decimal?>();
    }
}