#nullable enable

using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    public sealed partial class ProcedureExecutor : IProcedureExecutor, IDisposable, IAsyncDisposable
    {
        private readonly Lazy<DbConnection> lazyDbConnection;

        private readonly IFunc<ProcedureParamIn, object> paramInMapper;

        private bool disposed;

        private ProcedureExecutor(
            Lazy<DbConnection> lazyDbConnection,
            IFunc<ProcedureParamIn, object> paramInMapper)
        {
            this.lazyDbConnection = lazyDbConnection;
            this.paramInMapper = paramInMapper;
        }

        private Unit ValidateNotDisposed()
            =>
            disposed
                ? throw new ObjectDisposedException("The procedure executor is already disposed.")
                : default;

        private async Task<DbCommand> InternalCreateDbCommandAsync(
            ProcedureRequest procedureRequest)
        {
            _ = ValidateNotDisposed();

            await Task.Yield();
            var dbCommand = lazyDbConnection.Value.CreateCommand();

            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = procedureRequest.ProcedureName;

            foreach(var dbParamIn in procedureRequest.ParamsIn.Select(paramInMapper.Invoke))
            {
                _ = dbCommand.Parameters.Add(dbParamIn);
            }

            return dbCommand;
        }
    }
}
