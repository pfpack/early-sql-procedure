#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    public interface IProcedureNonQueryExecutor : IDisposable, IAsyncDisposable
    {
        ValueTask<int> ExecuteNonQueryAsync(ProcedureRequest procedureRequest, CancellationToken cancellationToken = default);
    }
}