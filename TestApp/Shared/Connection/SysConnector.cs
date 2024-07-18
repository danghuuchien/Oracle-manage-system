using System;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shared.Connection
{
	public class SysConnector
	{
		private const string PORT = "1521";
		private const string HOST = "localhost";
		private const string SID = "Test";

		private OracleConnection _connection;

		public SysConnector()
		{
			string _connectionString = $"User Id=sys;Password=Orcl1234;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={HOST})(PORT={PORT}))(CONNECT_DATA=(SID={SID})));DBA Privilege=SYSDBA;";
			_connection = new OracleConnection(_connectionString)
			{
				AutoCommit = true
			};
			_connection.Open();
		}

		public OracleConnection GetConnection()
		{
			return _connection;
		}

		public void KillSession(string sessionInfor)
		{
			try
			{
				using (var connection = GetConnection())
				using (var command = new OracleCommand())
				{
					string sql = "ALTER SYSTEM KILL SESSION " + sessionInfor;
					command.CommandText = sql;
					command.Connection = connection;
					command.ExecuteNonQuery();
				}

			}
			catch (Oracle.ManagedDataAccess.Client.OracleException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
