#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    public interface IProcedureExecutor :
        IProcedureNonQueryExecutor,
        IProcedureScalarExecutor,
        IProcedureFlowExecutor,
        IDisposable,
        IAsyncDisposable
    {
    }
}