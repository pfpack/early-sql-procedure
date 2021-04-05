#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public ValueTask<T> ExecuteNotNullAsync<T>(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
            where T : notnull
            =>
            Pipeline.Pipe(
                procedureRequest ?? throw new ArgumentNullException(nameof(procedureRequest)))
            .Pipe(
                _ => ValidateNotDisposed())
            .Pipe(
                _ => InternalExecuteNotNullAsync<T>(procedureRequest, cancellationToken));

        private async ValueTask<T> InternalExecuteNotNullAsync<T>(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
            where T : notnull
        {
            using var dbCommand = await InternalCreateDbCommandAsync(procedureRequest).ConfigureAwait(false);
            using var dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

            if(await dbDataReader.ReadAsync(cancellationToken).ConfigureAwait(false) is false)
            {
                throw new InvalidOperationException("The response is expected to contain at least one row.");
            }

            var dbValue = dbDataReader.InternalGetValueOrNull(0);
            if(dbValue is null)
            {
                throw new InvalidOperationException("The value is expected to be not null.");
            }

            return (T)dbValue;
        }
    }
}