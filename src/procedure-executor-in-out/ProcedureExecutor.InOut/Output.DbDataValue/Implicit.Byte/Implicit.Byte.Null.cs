#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static implicit operator byte?(
            DbDataValue dbDataValue)
            =>
            dbDataValue.Cast<byte?>();
    }
}