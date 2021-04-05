#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public bool Equals(DbDataValue other)
            =>
            SourceValueComparer.Equals(sourceValue, other.sourceValue);
    }
}