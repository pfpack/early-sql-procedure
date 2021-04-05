#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    partial class ProcedureItemOut
    {
        public Optional<T> GetNotNullOrAbsent<T>(
            [AllowNull] string fieldName)
            =>
            fieldName.OrEmpty().Pipe(InternalGetNotNullOrAbsent<T>);
    }
}