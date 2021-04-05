#nullable enable

using System;
using System.Data.Common;
using System.Threading;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public static ProcedureExecutor Create(
            IFunc<DbConnection> dbConnectionProvider,
            IFunc<ProcedureParamIn, object> paramInMapper)
            =>
            InternalCreate(
                dbConnectionProvider ?? throw new ArgumentNullException(nameof(dbConnectionProvider)),
                paramInMapper ?? throw new ArgumentNullException(nameof(paramInMapper)));

        private static ProcedureExecutor InternalCreate(
            IFunc<DbConnection> dbConnectionProvider,
            IFunc<ProcedureParamIn, object> paramInMapper)
            =>
            new(
                lazyDbConnection: new(
                    valueFactory: () => InternalGetOpenedDbConnection(dbConnectionProvider),
                    mode: LazyThreadSafetyMode.ExecutionAndPublication),
                paramInMapper: paramInMapper);

        private static DbConnection InternalGetOpenedDbConnection(
            IFunc<DbConnection> dbConnectionProvider)
        {
            var dbConnection = dbConnectionProvider.Invoke();
            dbConnection.Open();
            
            return dbConnection;
        }
    }
}
