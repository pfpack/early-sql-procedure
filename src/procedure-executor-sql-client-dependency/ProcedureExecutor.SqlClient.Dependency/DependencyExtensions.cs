#nullable enable

using System;
using Microsoft.Data.SqlClient;
using PrimeFuncPack.Data;

namespace PrimeFuncPack
{
    public static class SqlClientProcedureExecutorDependencyExtensions
    {
        private const string SqlConnectionProviderMustBeSpecifiedMessage = "SqlConnectionProvider from the dependency must be specified";

        public static Dependency<IFunc<IProcedureExecutor>> ToSqlClientProcedureExecutor(
            this Dependency<IFunc<SqlConnection>> sourceDependency)
            =>
            Pipeline.Pipe(
                sourceDependency ?? throw new ArgumentNullException(nameof(sourceDependency)))
            .Map(
                sqlConnectionProvider => InternalCreateExecutorProvider(
                    sqlConnectionProvider ?? throw new InvalidOperationException(SqlConnectionProviderMustBeSpecifiedMessage)));

        private static IFunc<IProcedureExecutor> InternalCreateExecutorProvider(
            IFunc<SqlConnection> sqlConnectionProvider)
            =>
            Func.From(
                () => SqlClientProcedureExecutor.Create(sqlConnectionProvider));
    }
}