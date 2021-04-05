#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public T Cast<T>()
            =>
            sourceValue is T value
            ? value
            : throw CreateInvalidCastException(expectedType: typeof(T), actualType: sourceValue?.GetType());
    }
}