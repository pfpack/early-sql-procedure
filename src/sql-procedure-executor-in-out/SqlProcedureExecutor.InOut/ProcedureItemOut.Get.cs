#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PrimeFuncPack.Data
{
    partial record ProcedureItemOut
    {
        public Optional<T> Get<T>(
            [AllowNull] string fieldName)
            where T : notnull
            =>
            InternalGet<T>(
                fieldName ?? string.Empty);

        private  Optional<T> InternalGet<T>(
            string fieldName)
            where T : notnull
            =>
            dataSet.GetValueOrAbsent(fieldName).OrThrow(() => CreateFieldNotExistException(fieldName)) switch
            {
                T value
                => Optional.Present(value),

                null
                => Optional<T>.Absent,

                object unexpected
                => throw CreateUnexpectedFieldTypeException(fieldName, expectedType: typeof(T), actualType: unexpected.GetType())
            };
    }
}