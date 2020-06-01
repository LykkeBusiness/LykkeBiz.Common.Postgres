using System.Data.Common;

namespace LykkeBiz.Common.Postgres
{
    public class TransactionContext
    {
        internal DbConnection DbConnection { get; }

        public TransactionContext(DbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }
    }
}
