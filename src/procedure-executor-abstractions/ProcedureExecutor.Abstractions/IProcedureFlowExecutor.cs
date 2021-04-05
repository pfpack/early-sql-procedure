#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;

namespace PrimeFuncPack.Data
{
    public interface IProcedureFlowExecutor : IDisposable, IAsyncDisposable
    {
        IAsyncEnumerable<ProcedureItemOut> ExecuteFlowAsync(ProcedureRequest procedureRequest, CancellationToken cancellationToken = default);
    }
}