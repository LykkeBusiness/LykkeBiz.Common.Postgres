using JetBrains.Annotations;

namespace OpenVASP.PostgreSql
{
    [PublicAPI]
    public interface IDbContextFactory<out T>
    {
        T CreateDataContext();

        T CreateDataContext(TransactionContext transactionContext);
    }
}