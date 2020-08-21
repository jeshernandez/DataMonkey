using Oracle.ManagedDataAccess.Client; 
using System.Data;


namespace DataMonkey
{
    class OracleDatabase : Database
    {
        public override IDbCommand CreateCommand()
        {
            return new OracleCommand(); 
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.Text;

            return command; 
        }

        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(connectionString); 
        }

        public override IDbConnection CreateOpenConnection()
        {
            OracleConnection connection = (OracleConnection)CreateConnection();
            connection.Open();

            return connection; 
        }

        public override IDbDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new OracleParameter(parameterName, parameterValue); 
        }
        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command; 
        }

    }
}
