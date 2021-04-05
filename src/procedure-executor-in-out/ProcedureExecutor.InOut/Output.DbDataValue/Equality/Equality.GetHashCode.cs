#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public override int GetHashCode()
            =>
            sourceValue is not null
                ? InternalGetHashCode(sourceValue)
                : GetDefaultHashCode();

        private static int InternalGetHashCode(
            object value)
            =>
            HashCode.Combine(
                EqualityContract,
                SourceValueComparer.GetHashCode(value));

        private static int GetDefaultHashCode()
            =>
            HashCode.Combine(EqualityContract);
    }
}