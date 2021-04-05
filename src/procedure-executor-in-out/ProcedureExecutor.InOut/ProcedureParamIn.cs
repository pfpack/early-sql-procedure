#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed record ProcedureParamIn
    {
        public ProcedureParamIn(
            [AllowNull] string name,
            object? value)
        {
            Name = name.OrEmpty();
            Value = value;
        }

        public string Name { get; }

        public object? Value { get; }
    }
}