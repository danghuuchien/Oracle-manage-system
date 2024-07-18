using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace Shared.Connection
{
	// Connect to Oracle database
	public abstract class ConnectorBase
	{
		private const string PORT = "1521";
		private const string HOST = "localhost";
		private const string SID = "test";

		protected string _connectionString;
		public string Username { get; set; }

		private OracleConnection _connection;

		public ConnectorBase(string username, string password)
		{
			this.Username = username;
			_connectionString = CreateConnectionString(username, password);
			_connection = new OracleConnection(_connectionString)
			{
				AutoCommit = true
			};
			_connection.Open();
		}
		public ConnectorBase()
		{

		}

		private static string CreateConnectionString(string username, string password)
		{
			return $"User Id={username};Password={password};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={HOST})(PORT={PORT}))(CONNECT_DATA=(SID={SID})));";
		}

		public OracleConnection GetConnection()
		{
			return _connection;
			
		}

		protected void CheckConnection()
		{
			using (var connection = GetConnection())
			{
				try
				{
					connection.Open();
				}
				catch (OracleException ex)
				{
					HandleConnectionError(ex);
				}
			}
		}

		protected void HandleConnectionError(OracleException ex)
		{
			if (ex.Number == 3113 || ex.Number == 28 || ex.Number == 1033 || ex.Number == 1089 || ex.Number == 12571)
			{
				MessageBox.Show("Connection is not valid", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			else
			{
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}
	}
}
