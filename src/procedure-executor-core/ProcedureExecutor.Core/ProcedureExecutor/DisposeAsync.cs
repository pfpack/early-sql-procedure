#nullable enable

using System.Threading.Tasks;

namespace PrimeFuncPack.Data
{
    partial class ProcedureExecutor
    {
        public async ValueTask DisposeAsync()
        {
            if(disposed)
            {
                return;
            }

            if(lazyDbConnection.IsValueCreated)
            {
                await lazyDbConnection.Value.DisposeAsync().ConfigureAwait(false);
            }
            disposed = true;
        }
    }
}
