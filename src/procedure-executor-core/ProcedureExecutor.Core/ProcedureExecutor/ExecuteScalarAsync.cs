#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public ValueTask<Optional<T>> ExecuteScalarAsync<T>(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
            =>
            Pipeline.Pipe(
                procedureRequest ?? throw new ArgumentNullException(nameof(procedureRequest)))
            .Pipe(
                _ => ValidateNotDisposed())
            .Pipe(
                _ => InternalExecuteScalarAsync<T>(procedureRequest, cancellationToken));

        private async ValueTask<Optional<T>> InternalExecuteScalarAsync<T>(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
        {
            using var dbCommand = await InternalCreateDbCommandAsync(procedureRequest).ConfigureAwait(false);
            using var dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

            if(await dbDataReader.ReadAsync(cancellationToken).ConfigureAwait(false) is false)
            {
                return Optional.Absent<T>();
            }

            var dbValue = (T)dbDataReader.InternalGetValueOrNull(0)!;
            return Optional.Present(dbValue);
        }
    }
}