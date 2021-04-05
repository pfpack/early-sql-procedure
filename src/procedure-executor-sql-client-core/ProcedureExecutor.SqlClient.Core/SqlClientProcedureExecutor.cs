#nullable enable

using System;
using Microsoft.Data.SqlClient;

namespace PrimeFuncPack.Data
{
    public static class SqlClientProcedureExecutor
    {
        public static ProcedureExecutor Create(
            IFunc<SqlConnection> sqlConnectionProvider)
            =>
            Pipeline.Pipe(
                sqlConnectionProvider ?? throw new ArgumentNullException(nameof(sqlConnectionProvider)))
            .Pipe(
                provider => ProcedureExecutor.Create(provider, SqlClientParamInMapper.Instance));
    }
}