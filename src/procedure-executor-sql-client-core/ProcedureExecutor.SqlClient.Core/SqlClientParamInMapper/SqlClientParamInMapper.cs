#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    internal sealed partial class SqlClientParamInMapper : IFunc<ProcedureParamIn, object>
    {
        public static SqlClientParamInMapper Instance { get; }

        static SqlClientParamInMapper()
            =>
            Instance = new();

        private SqlClientParamInMapper()
        {
        }
    }
}