#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PrimeFuncPack.Data
{
    public sealed partial class ProcedureItemOut
    {
        private readonly IReadOnlyDictionary<string, object?> dataSet;

        public ProcedureItemOut(
            [AllowNull] IReadOnlyDictionary<string, object?> dataSet)
            =>
            this.dataSet = dataSet ?? EmptyDataSet.Value;

        private Optional<T> InternalGetNotNullOrAbsent<T>(
            string fieldName)
            =>
            Pipeline.Pipe(
                fieldName)
            .Pipe(
                dataSet.GetValueOrAbsent)
            .OrThrow(
                () => CreateFieldNotFoundException(fieldName))
            .Pipe(
                Optional.PresentOrElse)
            .Filter(
                dbValue => DBNull.Value.Equals(dbValue) is false)
            .Map(
                value => (T)value);

        private static KeyNotFoundException CreateFieldNotFoundException(
            string fieldName)
            =>
            new KeyNotFoundException($"A field '{fieldName}' was not found in the data set.");

        private static InvalidOperationException CreateFieldValueMustBeNotNullException(
            string fieldName)
            =>
            new InvalidOperationException($"The field '{fieldName}' value is expected to be not null.");

        private static class EmptyDataSet
        {
            public static readonly IReadOnlyDictionary<string, object?> Value = new Dictionary<string, object?>();
        } 
    }
}