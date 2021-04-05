#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public ValueTask<Optional<DbDataValue>> ExecuteScalarAsync(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
            =>
            Pipeline.Pipe(
                procedureRequest ?? throw new ArgumentNullException(nameof(procedureRequest)))
            .Pipe(
                _ => ValidateNotDisposed())
            .Pipe(
                _ => InternalExecuteScalarAsync(procedureRequest, cancellationToken));

        private async ValueTask<Optional<DbDataValue>> InternalExecuteScalarAsync(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken)
        {
            using var dbCommand = await InternalCreateDbCommandAsync(procedureRequest).ConfigureAwait(false);
            using var dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

            if(await dbDataReader.ReadAsync(cancellationToken).ConfigureAwait(false) is false)
            {
                return Optional.Absent<DbDataValue>();
            }

            var dbValue = new DbDataValue(dbDataReader.GetValue(0));
            return Optional.Present(dbValue);
        }
    }
}