#nullable enable

using System;
using Microsoft.Data.SqlClient;

namespace PrimeFuncPack.Data
{
    partial class SqlClientParamInMapper
    {
        private const string ParamNamePrefix = "@";

        public object Invoke(
            ProcedureParamIn paramIn)
            =>
            Pipeline.Pipe(
                paramIn ?? throw new ArgumentNullException(nameof(paramIn)))
            .Pipe(
                p => new SqlParameter(
                    parameterName: ParamNamePrefix + p.Name,
                    value: p.Value));
    }
}