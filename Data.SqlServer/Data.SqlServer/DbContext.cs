using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;

namespace Data.SqlServer
{
	public class DbContext : IDbContext
	{
		private readonly IDictionary<string, SqlConnection> _connections;
		private readonly string _sqlConnection;

		[InjectionConstructor]
		public DbContext()
		{
			_sqlConnection = ConfigurationManager.ConnectionStrings["UserDb"].ConnectionString;
			_connections = new Dictionary<string, SqlConnection>();
		}

		public IDbCommand CreateCommand(string connectionString, string commandText = "", params IDbDataParameter[] args)
		{
			return CreateDbCommand(CreateConnection(connectionString), commandText, args);
		}

		public IDbCommand CreateCommand(string connectionString, int commandTimeOut, string commandText = "", params IDbDataParameter[] args)
		{
			var command = CreateNewCommand(connectionString, commandText, args);
			command.CommandTimeout = commandTimeOut;
			return command;
		}

		public IDbCommand CreateNewCommand(string connectionString, string commandText = "", params IDbDataParameter[] args)
		{
			var connection = GetConnection(_sqlConnection);
			return CreateDbCommand(connection, commandText, args);
		}

		public IDbCommand CreateNewCommand(string connectionString, int commandTimeOut, string commandText = "", params IDbDataParameter[] args)
		{
			var command = CreateCommand(connectionString, commandText, args);
			command.CommandTimeout = commandTimeOut;
			return command;
		}

		public void Dispose()
		{
			foreach (var sqlConnection in _connections)
			{
				//TODO: add open checks...
				sqlConnection.Value.Dispose();
			}
		}

		private IDbConnection CreateConnection(string connectionString)
		{
			var connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}

		private IDbCommand CreateDbCommand(IDbConnection connection, string commandText = "", params IDbDataParameter[] args)
		{
			var command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = commandText;

			foreach (var sqlParameter in args)
			{
				command.Parameters.Add(sqlParameter);
			}

			return command;
		}

		private IDbConnection GetConnection(string source)
		{
			SqlConnection connection;

			if (!_connections.TryGetValue(source, out connection))
			{
				connection = new SqlConnection(_sqlConnection);
				connection.Open();
				_connections.Add(source, connection);
			}
			return connection;
		}
	}
}