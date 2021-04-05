#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    partial class DbDataItem
    {
        public DbDataValue Get(
            [AllowNull] string fieldName)
            =>
            InternalGet(
                fieldName ?? string.Empty);

        private DbDataValue InternalGet(
            string fieldName)
            =>
            dataSet.TryGetValue(fieldName, out var fieldValue)
                ? CreateFieldValue(fieldName, fieldValue)
                : throw CreateFieldNotFoundException(fieldName);

        private static DbDataValue CreateFieldValue(
            string fieldName, object? fieldValue)
            =>
            new(
                sourceValue: fieldValue,
                (expType, actType) => CreateUnexpectedFieldTypeException(fieldName, expected: expType, actual: actType),
                () => CreateFieldValueMustBeNotNullException(fieldName));

        private static KeyNotFoundException CreateFieldNotFoundException(
            string fieldName)
            =>
            new($"A field '{fieldName}' was not found in the data set.");

        private static InvalidOperationException CreateFieldValueMustBeNotNullException(
            string fieldName)
            =>
            new($"The field '{fieldName}' value is expected to be not null.");

        private static InvalidCastException CreateUnexpectedFieldTypeException(
            string fieldName, Type? expected, Type? actual)
            =>
            new($"The field '{fieldName}' value is expected to be {expected} but it is {actual}.");
    }
}