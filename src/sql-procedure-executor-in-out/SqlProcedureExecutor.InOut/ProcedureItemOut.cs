#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed partial record ProcedureItemOut
    {
        private readonly IReadOnlyDictionary<string, object?> dataSet;

        public ProcedureItemOut(
            [AllowNull] IReadOnlyDictionary<string, object?> dataSet)
            =>
            this.dataSet = dataSet ?? new Dictionary<string, object?>();

        private static KeyNotFoundException CreateFieldNotExistException(
            string fieldName)
            =>
            new KeyNotFoundException($"Field '{fieldName}' does not exist in the data set.");

        private static InvalidCastException CreateUnexpectedFieldTypeException(
            string fieldName,
            Type expectedType,
            Type actualType)
            =>
            new InvalidCastException($"Field '{fieldName}' value was expected to be {expectedType} but it was {actualType}.");

        private static InvalidOperationException CreateFieldValueMustBeNotNullException(
            string fieldName)
            =>
            new InvalidOperationException($"Field '{fieldName}' value was expected to be not null but it was null.");
    }
}