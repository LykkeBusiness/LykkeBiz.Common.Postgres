using System.Data.Common;

namespace OpenVASP.PostgreSql
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
