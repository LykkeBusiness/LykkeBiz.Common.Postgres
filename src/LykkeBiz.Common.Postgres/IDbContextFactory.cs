using JetBrains.Annotations;

namespace LykkeBiz.Common.Postgres
{
    [PublicAPI]
    public interface IDbContextFactory<out T>
    {
        T CreateDataContext();

        T CreateDataContext(TransactionContext transactionContext);
    }
}