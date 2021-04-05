#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    public interface IProcedureScalarExecutor : IDisposable, IAsyncDisposable
    {
        ValueTask<Optional<T>> ExecuteScalarAsync<T>(ProcedureRequest procedureRequest, CancellationToken cancellationToken);
    }
}