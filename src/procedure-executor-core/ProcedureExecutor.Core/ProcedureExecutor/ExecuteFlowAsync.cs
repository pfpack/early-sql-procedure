#nullable enable

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public IAsyncEnumerable<DbDataItem> ExecuteFlowAsync(
            ProcedureRequest procedureRequest,
            CancellationToken cancellationToken = default)
            =>
            Pipeline.Pipe(
                procedureRequest ?? throw new ArgumentNullException(nameof(procedureRequest)))
            .Pipe(
                _ => ValidateNotDisposed())
            .Pipe(
                _ => InternalExecuteFlowAsync(procedureRequest, cancellationToken));

        private async IAsyncEnumerable<DbDataItem> InternalExecuteFlowAsync(
            ProcedureRequest procedureRequest,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var dbCommand = await InternalCreateDbCommandAsync(procedureRequest).ConfigureAwait(false);
            using var dbDataReader = await dbCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);

            while(true)
            {
                if(cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                if(await dbDataReader.ReadAsync(cancellationToken).ConfigureAwait(false) is false)
                {
                    break;
                }

                yield return ReadItemOut(dbDataReader);
            }
        }

        private static DbDataItem ReadItemOut(
            DbDataReader dbDataReader)
            =>
            Enumerable.Range(
                0, dbDataReader.FieldCount)
            .ToDictionary<int, string, object?>(
                dbDataReader.GetName,
                dbDataReader.GetValue)
            .Pipe(
                dataSet => new DbDataItem(dataSet));
    }
}