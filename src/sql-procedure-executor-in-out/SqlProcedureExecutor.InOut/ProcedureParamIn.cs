#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed record ProcedureParamIn
    {
        public ProcedureParamIn(
            [DisallowNull] string name,
            object? value)
            =>
            (Name, Value) = (name.NotEmptyOrThrow(nameof(name)), value);

        public string Name { get; }

        public object? Value { get; }
    }
}