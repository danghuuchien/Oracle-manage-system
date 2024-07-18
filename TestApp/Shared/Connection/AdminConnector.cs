using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Shared.Connection
{
	public class AdminConnector : ConnectorBase
	{
		public AdminConnector(string username, string password) : base(username, password)
		{

		}


		public bool IsValid()
		{
			try
			{
				var connection = GetConnection();
				string sql = "SELECT admin1.is_admin(:username) from dual";
				using (var command = new OracleCommand(sql, connection))
				{

					command.Parameters.Add("username", OracleDbType.Varchar2).Value = this.Username;
					var result = command.ExecuteScalar();

					return result.ToString() == "1";
				}
			}
			catch (OracleException ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		public void KillOtherSession()
		{
			try
			{
				var connection = GetConnection();
				{
					using (var command = new OracleCommand("admin1.KillOtherSession", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = this.Username;
						command.Parameters.Add("p_application", OracleDbType.Varchar2).Value = "AdminApp.exe";
						command.ExecuteNonQuery();
					}
				}
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
			}
		}

		public List<string> GetTables()
		{
			try
			{
				List<string> tables = new List<string>();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.GetTablesByOwner", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_owner", OracleDbType.Varchar2).Value = "ADMIN1";
					command.Parameters.Add("p_tables", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							tables.Add(reader.GetString(0) + " (" + reader.GetString(1) + ")");
						}
					}
				}
				return tables;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new List<string>();
			}
		}

		public List<string[]> GetTableColumnInfo(string tableName)
		{
			try
			{
				List<string[]> columns = new List<string[]>();
				var connection = GetConnection();

				using (var command = new OracleCommand("admin1.GetTableColumnInfo", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = tableName;
					command.Parameters.Add("p_owner", OracleDbType.Varchar2).Value = "ADMIN1";
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							string[] columnInfo = new string[2];
							columnInfo[0] = reader.GetString(0);
							columnInfo[1] = reader.GetString(1);
							columns.Add(columnInfo);
						}
					}
				}
				return columns;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new List<string[]>();
			}
		}

		public List<string[]> GetTableData(string tableName)
		{
			try
			{
				List<string[]> data = new List<string[]>();
				var connection = GetConnection();
				var command = new OracleCommand("admin1.GetTableData", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = tableName;
				command.Parameters.Add("p_owner", OracleDbType.Varchar2).Value = "ADMIN1";
				command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string[] rowData = new string[reader.FieldCount];
						for (int i = 0; i < reader.FieldCount; i++)
						{
							rowData[i] = reader.GetValue(i).ToString();
						}
						data.Add(rowData);
					}
				}
				return data;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new List<string[]>();
			}
		}

		public DataTable GetVTableData(string tableName)
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				var command = new OracleCommand(tableName, connection);
				command.CommandType = CommandType.TableDirect;
				using (OracleDataReader reader = command.ExecuteReader())
				{
					dataTable.Load(reader);
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}

		public DataTable GetSessionInfo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				var command = new OracleCommand("admin1.GetSessionInfo", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

				using (OracleDataReader reader = command.ExecuteReader())
				{
					dataTable.Load(reader);
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}
		public DataTable GetProfileInfo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				var command = new OracleCommand("admin1.GetProfileInfo", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

				using (OracleDataReader reader = command.ExecuteReader())
				{
					dataTable.Load(reader);
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}

		public DataTable GetSessionProcesses(int sid, int serial)
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.GetSessionProcesses", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.Add("p_sid", OracleDbType.Int32).Value = sid;
					command.Parameters.Add("p_serial", OracleDbType.Int32).Value = serial;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}


		public string GetCurrentSessionInfo()
		{
			string result = string.Empty;
			try
			{
				var connection = GetConnection();
				string sessionIdQuery = "SELECT SYS_CONTEXT('USERENV', 'SESSIONID') FROM DUAL";
				OracleCommand sessionIdCommand = new OracleCommand(sessionIdQuery, connection);
				string sessionId = sessionIdCommand.ExecuteScalar().ToString();

				string sql = "SELECT SID, SERIAL# FROM V$SESSION WHERE AUDSID = :sessionId";
				using (var command = new OracleCommand(sql, connection))
				{
					command.Parameters.Add("sessionId", OracleDbType.Varchar2).Value = sessionId;

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							result = string.Format("'{0}, {1}'", reader.GetInt32(0), reader.GetInt32(1));
						}
					}
				}
				return result;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return result;
			}
		}

		public bool KillSession(string sessionInfor)
		{
			try
			{
				var connection = GetConnection();
				using (var command = new OracleCommand())
				{
					string sql = "ALTER SYSTEM KILL SESSION " + sessionInfor + "IMMEDIATE";
					command.CommandText = sql;
					command.Connection = connection;

					command.ExecuteNonQuery();
					return true;
				}

			}
			catch (OracleException ex)
			{
				try
				{
					HandleConnectionError(ex);
				}
				catch (OracleException)
				{
					Console.WriteLine(ex.Message);
					MessageBox.Show(ex.Message);
				}
				return false;

			}
		}

		public List<string> GetUsers()
		{
			try
			{
				List<string> users = new List<string>();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.GetAllUsers", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							users.Add(reader.GetString(0));
						}
					}
				}
				return users;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new List<string>();
			}
		}

		public DataTable GetUserTablespaces(string username)
		{
			try
			{
				var connection = GetConnection();
				DataTable dataTable = new DataTable();
				using (var command = new OracleCommand("admin1.get_user_tablespaces", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = (username != "All") ? (object)username : DBNull.Value;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}
		public DataTable GetDatafileInfo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.get_datafile_info", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}




		public bool CreateTablespace(string tablespaceName, DatafileOption[] datafiles)
		{
			try
			{
				var connection = GetConnection();
				MessageBox.Show(BuildCreateTablespaceSql(tablespaceName, datafiles));
				using (var command = new OracleCommand(BuildCreateTablespaceSql(tablespaceName, datafiles), connection))
				{
					command.ExecuteNonQuery();
					return true;
				}
			}
			catch (OracleException ex)
			{
				try
				{
					HandleConnectionError(ex);
				}
				catch (OracleException ex2)
				{
					Console.WriteLine(ex2.Message);
				}
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error creating tablespace: " + ex.Message);
				Console.WriteLine("Error creating tablespace: " + ex.Message);
				return false;
			}
		}


		private string BuildCreateTablespaceSql(string tablespaceName, DatafileOption[] datafiles)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("CREATE TABLESPACE " + tablespaceName + " ");

			foreach (var datafile in datafiles)
			{
				string fullPath = string.IsNullOrEmpty(datafile.DatafilePath) ? datafile.DatafileName : datafile.DatafilePath + "/" + datafile.DatafileName;
				sb.Append("DATAFILE '" + fullPath + "' ");

				if (!string.IsNullOrEmpty(datafile.DatafileSize))
				{
					string dataSize = datafile.DatafileSize.ToUpper().EndsWith("M") ? datafile.DatafileSize : datafile.DatafileSize + "M";
					sb.Append("SIZE " + dataSize + " ");
				}

				if (!string.IsNullOrEmpty(datafile.Autoextend))
				{
					sb.Append("AUTOEXTEND " + datafile.Autoextend + " ");

					if (!string.IsNullOrEmpty(datafile.AutoextendSize))
					{
						string autoextendSize = datafile.AutoextendSize.ToUpper().EndsWith("M") ? datafile.AutoextendSize : datafile.AutoextendSize + "M";
						sb.Append("NEXT " + autoextendSize + " ");
					}

					if (!string.IsNullOrEmpty(datafile.Maxsize))
					{
						string maxsize = datafile.Maxsize.ToUpper().EndsWith("M") ? datafile.Maxsize : datafile.Maxsize + "M";
						sb.Append("MAXSIZE " + maxsize + " ");
					}
				}

				sb.Append(",");
			}

			sb.Remove(sb.Length - 1, 1);

			return sb.ToString();
		}

		public List<string> GetTablespaces()
		{
			try
			{
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.get_tablespaces", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

					using (var reader = command.ExecuteReader())
					{
						List<string> tablespaces = new List<string>();
						while (reader.Read())
						{
							tablespaces.Add(reader.GetString(0));
						}
						return tablespaces;
					}
				}
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new List<string>();
			}
		}

		public bool AddDatafile(string tablespaceName, DatafileOption datafile)
		{
			try
			{
				var connection = GetConnection();

				using (var command = new OracleCommand(CreateAddDatafileSql(tablespaceName, datafile), connection))
				{
					command.ExecuteNonQuery();
					return true;
				}
			}
			catch (OracleException ex)
			{
				try
				{
					HandleConnectionError(ex);
				}
				catch (OracleException)
				{
					Console.WriteLine(ex.Message);
				}
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error creating tablespace: " + ex.Message);
				Console.WriteLine("Error creating tablespace: " + ex.Message);
				return false;
			}
		}

		private string CreateAddDatafileSql(string tablespaceName, DatafileOption datafile)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ALTER TABLESPACE " + tablespaceName + " ADD ");
			string fullPath = string.IsNullOrEmpty(datafile.DatafilePath) ? datafile.DatafileName : datafile.DatafilePath + "/" + datafile.DatafileName;
			sb.Append("DATAFILE '" + fullPath + "' ");

			if (!string.IsNullOrEmpty(datafile.DatafileSize))
			{
				string dataSize = datafile.DatafileSize.ToUpper().EndsWith("M") ? datafile.DatafileSize : datafile.DatafileSize + "M";
				sb.Append("SIZE " + dataSize + " ");
			}

			if (!string.IsNullOrEmpty(datafile.Autoextend))
			{
				sb.Append("AUTOEXTEND " + datafile.Autoextend + " ");

				if (!string.IsNullOrEmpty(datafile.AutoextendSize))
				{
					string autoextendSize = datafile.AutoextendSize.ToUpper().EndsWith("M") ? datafile.AutoextendSize : datafile.AutoextendSize + "M";
					sb.Append("NEXT " + autoextendSize + " ");
				}

				if (!string.IsNullOrEmpty(datafile.Maxsize))
				{
					string maxsize = datafile.Maxsize.ToUpper().EndsWith("M") ? datafile.Maxsize : datafile.Maxsize + "M";
					sb.Append("MAXSIZE " + maxsize + " ");
				}
			}
			return sb.ToString();
		}

		public DataTable GetUserInfo(string username)
		{
			try
			{
				var connection = GetConnection();
				DataTable dataTable = new DataTable();
				using (var command = new OracleCommand("admin1.get_user_info", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}

		public string GetLastLogin(string username)
		{
			try
			{
				string lastLogin = string.Empty;
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.get_last_login", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
					command.Parameters.Add("p_last_login", OracleDbType.Date, ParameterDirection.Output);

					command.ExecuteNonQuery();

					OracleDate lastLoginDate = (OracleDate)command.Parameters["p_last_login"].Value;
					lastLogin = lastLoginDate.Value.ToString("dd/MM/yyyy HH:mm");
				}
				return lastLogin;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return string.Empty;
			}
		}

		public DataTable GetPolicies()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.get_policies", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}


		public DataTable GetAllAuditTrail()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				using (var command = new OracleCommand("admin1.get_all_audit_trail", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

					using (OracleDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}
		}

        //public bool CreateUserWithProfile(string username, string password, string profile)
        //{
        //	try
        //	{
        //		var connection = GetConnection();

        //		using (var command = new OracleCommand("admin1.CreateUserWithProfile", connection))
        //		{
        //			command.CommandType = CommandType.StoredProcedure;
        //			command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
        //			command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = password;
        //			command.Parameters.Add("p_profile", OracleDbType.Varchar2).Value = profile;
        //			command.ExecuteNonQuery();
        //		}

        //		return true;
        //	}
        //	catch (OracleException ex)
        //	{
        //		if (ex.Number == 1920) 
        //		{
        //			Console.WriteLine("User already exists.");
        //			throw new Exception("User already exists."); // Ném ngoại lệ để xử lý bên ngoài
        //		}
        //		else
        //		{
        //			HandleConnectionError(ex);
        //			return false;
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		// Xử lý các ngoại lệ khác nếu cần
        //		Console.WriteLine("Error: " + ex.Message);
        //		return false;
        //	}
        //}

        public bool CreateUserWithProfile(string username, string password, string profile)
        {
            try
            {
                var connection = GetConnection();

                using (var command = new OracleCommand("admin1.create_user_safely", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
                    command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = password;
                    command.Parameters.Add("p_profile", OracleDbType.Varchar2).Value = profile;

                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (OracleException ex)
            {
                if (ex.Number == 20003) // Custom error number for Sunday restriction
                {
                    Console.WriteLine("Cannot create user on Sunday.");
                    throw new Exception("Cannot create user on Sunday.");
                }
                else if (ex.Number == 1920) // User already exists
                {
                    Console.WriteLine("User already exists.");
                    throw new Exception("User already exists.");
                }
                else
                {
                    HandleConnectionError(ex);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public DataTable GetUsersWithProfiles()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection(); // Phương thức này sẽ trả về kết nối Oracle
				var command = new OracleCommand("admin1.GetUsersWithProfiles", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

				using (OracleDataReader reader = command.ExecuteReader())
				{
					// Add columns to the DataTable
					dataTable.Columns.Add("USERNAME");
					dataTable.Columns.Add("PROFILE");
					dataTable.Columns.Add("DEFAULT_TABLESPACE");
					dataTable.Columns.Add("TEMPORARY_TABLESPACE");
					dataTable.Columns.Add("PASSWORD"); // Thêm cột PASSWORD vào DataTable

					// Read data from the reader and populate the DataTable
					while (reader.Read())
					{
						DataRow row = dataTable.NewRow();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							row[i] = reader[i];
						}
						dataTable.Rows.Add(row);
					}
				}

				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex); // Phương thức xử lý lỗi kết nối
				return new DataTable();
			}
		}


		public bool DeleteProfile(string profileName)
		{
			try
			{
				var connection = GetConnection();

				using (var command = new OracleCommand("admin1.DeleteProfile", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_profile_name", OracleDbType.Varchar2).Value = profileName;
					command.ExecuteNonQuery();
				}

				return true;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return false;
			}
			catch (Exception ex)
			{
				// Xử lý các ngoại lệ khác nếu cần
				Console.WriteLine("Error: " + ex.Message);
				return false;
			}
		}
		public bool AddNewProfile(string profileName, int passwordLifeTime, int passwordGraceTime, int passwordReuseMax, int passwordReuseTime, int failedLoginAttempts, int passwordLockTime)
		{
			try
			{
				var connection = GetConnection();


				using (var command = new OracleCommand("admin1.AddNewProfile", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_profile_name", OracleDbType.Varchar2).Value = profileName;
					command.Parameters.Add("p_password_life_time", OracleDbType.Int32).Value = passwordLifeTime;
					command.Parameters.Add("p_password_grace_time", OracleDbType.Int32).Value = passwordGraceTime;
					command.Parameters.Add("p_password_reuse_max", OracleDbType.Int32).Value = passwordReuseMax;
					command.Parameters.Add("p_password_reuse_time", OracleDbType.Int32).Value = passwordReuseTime;
					command.Parameters.Add("p_failed_login_attempts", OracleDbType.Int32).Value = failedLoginAttempts;
					command.Parameters.Add("p_password_lock_time", OracleDbType.Int32).Value = passwordLockTime;

					command.ExecuteNonQuery();
				}


				return true;
			}
			catch (OracleException ex)
			{
				if (ex.Number == 955) // ORA-00955: name is already used by an existing object
				{
					MessageBox.Show("Profile already exists.");
				}
				else
				{
					HandleConnectionError(ex);
				}
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				return false;
			}
		}


		public bool UpdateUserWithProfile(string username, string password, string profile)
		{
			try
			{
				var connection = GetConnection();

				using (var command = new OracleCommand("admin1.UpdateUserWithProfile", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
					command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = password;
					command.Parameters.Add("p_profile", OracleDbType.Varchar2).Value = profile;


					command.ExecuteNonQuery();
				}

				return true;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return false;
			}
		}
		public bool DeleteUser(string username)
		{
			try
			{
				var connection = GetConnection();

				using (var command = new OracleCommand("admin1.DeleteUser", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = username;
					command.ExecuteNonQuery();
				}

				return true;
			}
			catch (OracleException ex)
			{

				HandleConnectionError(ex);
				return false;
			}
		}

		public DataTable GetCauHoiInfo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				var connection = GetConnection();
				var command = new OracleCommand("admin1. GetCauHoiInfo", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
				using (OracleDataReader reader = command.ExecuteReader())
				{
					dataTable.Load(reader);
				}
				return dataTable;
			}
			catch (OracleException ex)
			{
				HandleConnectionError(ex);
				return new DataTable();
			}

		}

        public bool AddCauHoi(int maCauHoi, string noiDung, string hinhAnhPath, string dapAnDung, string dapAnSai1, string dapAnSai2, string dapAnSai3)
        {
            try
            {
                var connection = GetConnection();
                using (var command = new OracleCommand("admin1.AddCauHoi", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_macauhoi", OracleDbType.Int32).Value = maCauHoi;
                    command.Parameters.Add("p_noidung", OracleDbType.NVarchar2).Value = noiDung;
                    command.Parameters.Add("p_hinhanh_filename", OracleDbType.Varchar2).Value = Path.GetFileName(hinhAnhPath);
                    command.Parameters.Add("p_dapandung", OracleDbType.NVarchar2).Value = dapAnDung;
                    command.Parameters.Add("p_dapansai1", OracleDbType.NVarchar2).Value = dapAnSai1;
                    command.Parameters.Add("p_dapansai2", OracleDbType.NVarchar2).Value = dapAnSai2;
                    command.Parameters.Add("p_dapansai3", OracleDbType.NVarchar2).Value = dapAnSai3;

                    
                    command.ExecuteNonQuery();
                }

                // Sau khi thêm câu hỏi vào CSDL thành công, thêm hình ảnh vào thư mục IMAGES
               // string destinationPath = @"D:\images\" + Path.GetFileName(hinhAnhPath);
                //File.Copy(hinhAnhPath, destinationPath);

                return true;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Oracle Error Code: " + ex.ErrorCode);
                Console.WriteLine("Oracle Error Message: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public OracleDataReader ThongTinProfile()
        {
            OracleDataReader reader = null;
            try
            {
                var connection = GetConnection();
                var command = new OracleCommand("admin1.ThongTinProfile", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error: " + ex.Message);
            }

            return reader; // Trả về OracleDataReader để lớp gọi có thể xử lý kết quả
        }

        public bool ChangeProfileAttribute(string profileName, string attributeName, string newValue)
        {
            try
            {
				var connection = GetConnection();
               
                    using (var command = new OracleCommand("admin1.ChangeProfileAttribute", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Định nghĩa các tham số đầu vào của procedure
                        command.Parameters.Add("p_profile_name", OracleDbType.Varchar2).Value = profileName;
                        command.Parameters.Add("p_attribute_name", OracleDbType.Varchar2).Value = attributeName;
                        command.Parameters.Add("p_new_value", OracleDbType.Varchar2).Value = newValue;

                        // Thực thi procedure
                        command.ExecuteNonQuery();

                       
                    }
                

                return true;
            }
            catch (OracleException ex)
            {
                HandleConnectionError(ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public DataTable GetBaiThiInfo()
        {
            try
            {
                DataTable dataTable = new DataTable();
                var connection = GetConnection();
                var command = new OracleCommand("admin1.GetBaiThiInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                return dataTable;
            }
            catch (OracleException ex)
            {
                HandleConnectionError(ex);
                return new DataTable();
            }
        }
        public bool IsMaBaiThiUnique(int maBaiThi)
        {
            try
            {
				var connection = GetConnection();
                
                    var command = new OracleCommand("SELECT COUNT(*) FROM baithi WHERE mabaithi = :maBaiThi", connection);
                    command.Parameters.Add(":maBaiThi", OracleDbType.Int32).Value = maBaiThi;

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0; // Trả về true nếu mã bài thi không tồn tại (duy nhất)
                
            }
            catch (OracleException ex)
            {
                HandleConnectionError(ex);
                return false;
            }
        }


        public bool AddBaiThi(int maBaiThi, string tenBaiThi, string moTa, int thoiGianLamBai, string nguoiTao, DateTime ngayTao)
        {
            try
            {
				var connection = GetConnection();
                {
                    using (var command = new OracleCommand("admin1.AddBaiThi", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_mabaithi", OracleDbType.Int32).Value = maBaiThi;
                        command.Parameters.Add("p_tenbaithi", OracleDbType.NVarchar2).Value = tenBaiThi;
                        command.Parameters.Add("p_mota", OracleDbType.NVarchar2).Value = moTa;
                        command.Parameters.Add("p_thoigianlambai", OracleDbType.Int32).Value = thoiGianLamBai;
                        command.Parameters.Add("p_nguoitao", OracleDbType.Varchar2).Value = nguoiTao;
                        command.Parameters.Add("p_ngaytao", OracleDbType.Date).Value = ngayTao;

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (OracleException ex)
            {
                if (ex.Number == 20001) // Kiểm tra lỗi từ trigger
                {
                    throw new Exception("Lỗi từ trigger: " + ex.Message);
                }
                else
                {
                    throw;
                }
            }
        }
        public bool XoaBaiThi(int mabaithi)
        {
            try
            {
                var connection = GetConnection();

				var command = new OracleCommand("admin1.XoaBaiThi", connection);
                
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào stored procedure
                    command.Parameters.Add("p_mabaithi", OracleDbType.Int32).Value = mabaithi;

                    // Thực thi stored procedure
                    command.ExecuteNonQuery();
                

                return true; // Trả về true nếu thành công
            }
            catch (OracleException ex)
            {
                HandleConnectionError(ex); // Xử lý lỗi kết nối
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Xử lý các lỗi khác nếu có
                return false;
            }
        }



    }
}
