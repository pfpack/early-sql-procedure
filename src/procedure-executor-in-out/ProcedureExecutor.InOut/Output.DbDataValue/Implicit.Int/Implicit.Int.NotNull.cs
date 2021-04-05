#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator int?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<int?>();
    }
}