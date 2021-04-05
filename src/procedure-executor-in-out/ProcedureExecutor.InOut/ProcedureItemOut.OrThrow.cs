#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    partial class ProcedureItemOut
    {
        public T GetNotNullOrThrow<T>(
            [AllowNull] string fieldName)
            where T : notnull
            =>
            fieldName.OrEmpty().Pipe(InternalGetNotNullOrThrow<T>);

        private T InternalGetNotNullOrThrow<T>(
            string fieldName)
            where T : notnull
            =>
            Pipeline.Pipe(
                fieldName)
            .Pipe(
                InternalGetNotNullOrAbsent<T>)
            .OrThrow(
                () => CreateFieldValueMustBeNotNullException(fieldName));
    }
}