#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    public interface IProcedureScalarExecutor : IDisposable, IAsyncDisposable
    {
        ValueTask<Optional<DbDataValue>> ExecuteScalarAsync(ProcedureRequest procedureRequest, CancellationToken cancellationToken);
    }
}