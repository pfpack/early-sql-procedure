#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    partial record ProcedureItemOut
    {
        public T GetNotNull<T>(
            [AllowNull] string fieldName)
            where T : notnull
            =>
            InternalGetNotNull<T>(
                fieldName ?? string.Empty);

        private T InternalGetNotNull<T>(
            string fieldName)
            where T : notnull
            =>
            InternalGet<T>(fieldName).OrThrow(() => CreateFieldValueMustBeNotNullException(fieldName));
    }
}