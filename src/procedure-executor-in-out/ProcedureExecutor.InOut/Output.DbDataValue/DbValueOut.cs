#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    public readonly partial struct DbDataValue : IEquatable<DbDataValue>
    {
        private readonly object? sourceValue;

        private readonly CastExceptionFactory? invalidCastExceptionFactory;

        private readonly Func<Exception>? mustBeNotNullExceptionFactory;

        public DbDataValue(
            object? sourceValue)
        {
            this.sourceValue = TransformDBNullToNull(sourceValue);
            invalidCastExceptionFactory = null;
            mustBeNotNullExceptionFactory = null;
        }

        internal DbDataValue(
            object? sourceValue,
            CastExceptionFactory invalidCastExceptionFactory,
            Func<Exception> mustBeNotNullExceptionFactory)
        {
            this.sourceValue = TransformDBNullToNull(sourceValue);
            this.invalidCastExceptionFactory = invalidCastExceptionFactory;
            this.mustBeNotNullExceptionFactory = mustBeNotNullExceptionFactory;
        }

        private static object? TransformDBNullToNull(
            object? value)
            =>
            DBNull.Value.Equals(value) ? null : value;

        private Exception CreateMustBeNotNullException()
            =>
            mustBeNotNullExceptionFactory is not null
                ? mustBeNotNullExceptionFactory.Invoke()
                : new InvalidOperationException("The value is expected to be not null.");

        private InvalidCastException CreateInvalidCastException(
            Type expectedType, Type? actualType)
            =>
            invalidCastExceptionFactory is not null
                ? invalidCastExceptionFactory.Invoke(expectedType: expectedType, actualType: actualType)
                : new InvalidCastException($"The value is expected to be {expectedType} but it is {actualType}.");
    }
}