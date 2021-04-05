#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public ValueTask<int> ExecuteNonQueryAsync(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken = default)
            =>
            Pipeline.Pipe(
                procedureRequest ?? throw new ArgumentNullException(nameof(procedureRequest)))
            .Pipe(
                _ => ValidateNotDisposed())
            .Pipe(
                _ => InternalExecuteNonQueryAsync(procedureRequest, cancellationToken));

        private async ValueTask<int> InternalExecuteNonQueryAsync(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
        {
            using var dbCommand = await InternalCreateDbCommandAsync(procedureRequest).ConfigureAwait(false);
            return await dbCommand.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}