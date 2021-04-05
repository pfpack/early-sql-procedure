#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator string?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<string?>();
    }
}