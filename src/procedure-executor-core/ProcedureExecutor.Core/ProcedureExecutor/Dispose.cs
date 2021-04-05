#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public void Dispose()
        {
            if(disposed)
            {
                return;
            }

            if(lazyDbConnection.IsValueCreated)
            {
                lazyDbConnection.Value.Dispose();
            }
            disposed = true;
        }
    }
}
