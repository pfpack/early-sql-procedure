#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed record ProcedureRequest
    {
        public ProcedureRequest(
            [DisallowNull] string procedureName)
            : this(
                procedureName: procedureName,
                paramsIn: Array.Empty<ProcedureParamIn>())
            {
            }

        public ProcedureRequest(
            [DisallowNull] string procedureName,
            [AllowNull] IReadOnlyCollection<ProcedureParamIn> paramsIn)
            {
                ProcedureName = procedureName.NotEmptyOrThrow(nameof(procedureName));
                ParamsIn = paramsIn ?? Array.Empty<ProcedureParamIn>();
            }

        public string ProcedureName { get; }

        public IReadOnlyCollection<ProcedureParamIn> ParamsIn { get; }
    }
}