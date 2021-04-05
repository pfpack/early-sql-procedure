#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Data
{
    public sealed class ProcedureRequest
    {
        public ProcedureRequest(
            [AllowNull] string procedureName)
        {
            ProcedureName = procedureName.OrEmpty();
            ParamsIn = Array.Empty<ProcedureParamIn>();
        }

        public ProcedureRequest(
            [AllowNull] string procedureName,
            [AllowNull] IReadOnlyCollection<ProcedureParamIn> paramsIn)
        {
            ProcedureName = procedureName.OrEmpty();
            ParamsIn = paramsIn ?? Array.Empty<ProcedureParamIn>();
        }

        public string ProcedureName { get; }

        public IReadOnlyCollection<ProcedureParamIn> ParamsIn { get; }
    }
}