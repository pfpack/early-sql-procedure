#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        private static Type EqualityContract
            =>
            typeof(DbDataValue);

        private static IEqualityComparer<object?> SourceValueComparer
            =>
            EqualityComparer<object?>.Default;
    }
}