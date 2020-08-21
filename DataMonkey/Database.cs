using System.Data;

namespace DataMonkey
{
    public abstract class Database
    {
        public string connectionString;
        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        public abstract IDbDataParameter CreateParameter(string parameterName, object parameterValue); 

    }
}
