#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed partial class DbDataItem
    {
        private readonly IReadOnlyDictionary<string, object?> dataSet;

        public DbDataItem(
            [AllowNull] IReadOnlyDictionary<string, object?> dataSet)
            =>
            this.dataSet = dataSet ?? EmptyDataSet.Value;

        private static class EmptyDataSet
        {
            public static readonly IReadOnlyDictionary<string, object?> Value = new Dictionary<string, object?>();
        } 
    }
}