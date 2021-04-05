#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public T CastNotNull<T>()
            where T : notnull
            =>
            sourceValue switch
            {
                T value => value,
                null => throw CreateMustBeNotNullException(),
                _ => throw CreateInvalidCastException(expectedType: typeof(T), actualType: sourceValue.GetType())
            };
    }
}