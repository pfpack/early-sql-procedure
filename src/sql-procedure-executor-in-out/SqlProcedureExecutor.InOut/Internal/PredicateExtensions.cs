#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    internal static class PredicateExtensions
    {
        private const string ValueMustBeNotEmptyMessage = "Value must be not empty string.";

        public static string NotEmptyOrThrow(
            this string source,
            string paramName)
            =>
            source switch
            {
                "" => throw new ArgumentException(message: ValueMustBeNotEmptyMessage, paramName: paramName),
                null => throw new ArgumentNullException(paramName),
                _ => source
            };
    }
}