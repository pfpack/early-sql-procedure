#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    public interface IProcedureNotNullExecutor : IDisposable, IAsyncDisposable
    {
        ValueTask<T> ExecuteNotNullAsync<T>(ProcedureRequest procedureRequest, CancellationToken cancellationToken) where T : notnull;
    }
}