#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    public interface IProcedureExecutor : IProcedureNonQueryExecutor, IProcedureNotNullExecutor, IProcedureScalarExecutor, IProcedureFlowExecutor, IDisposable, IAsyncDisposable
    {
    }
}