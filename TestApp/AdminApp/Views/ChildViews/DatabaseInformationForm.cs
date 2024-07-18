using Shared.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Views.ChildViews
{
	public partial class DatabaseInformationForm : Form
	{
		private AdminConnector _connector;

		private Dictionary<string, string> tableMapping = new Dictionary<string, string>();

		public DatabaseInformationForm(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void infor_cbb_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadData();
		}

		public void LoadData()
		{
			DataTable dataTable = _connector.GetVTableData(tableMapping[infor_cbb.Text]);
			if(infor_cbb.Text == "PROCESS")
			{
				ConvertHexColumnToChar(dataTable);
			}
			information_dtgv.DataSource = dataTable;
		}

		private void ConvertHexColumnToChar(DataTable table)
		{
			if (table != null && table.Rows.Count > 0 && table.Columns.Count > 0)
			{
				DataColumn charColumn = new DataColumn("CharColumn", typeof(char));
				table.Columns.Add(charColumn);

				foreach (DataRow row in table.Rows)
				{
					if (row[0] != DBNull.Value)
					{
						string hexValue = row[0].ToString();
						int intValue;
						if (int.TryParse(hexValue, System.Globalization.NumberStyles.HexNumber, null, out intValue))
						{
							char charValue = (char)intValue;
							row[charColumn] = charValue;
						}
						else
						{
							row[charColumn] = '\0';
						}
					}
					else
					{
						row[charColumn] = '\0';
					}
				}
				var name = table.Columns[0].ColumnName;
				table.Columns.Remove(table.Columns[0]);
				charColumn.ColumnName = name;
			}
		}


		private void DatabaseInformationForm_Load(object sender, EventArgs e)
		{
			tableMapping.Add("SGA", "v$sgainfo");
			tableMapping.Add("PGA", "v$pgastat");
			tableMapping.Add("PROCESS", "v$process");
			tableMapping.Add("INSTANCE", "v$instance");
			tableMapping.Add("DATABASE", "v$database");
			tableMapping.Add("DATAFILE", "v$datafile");
			tableMapping.Add("CONTROL FILE", "v$controlfile");
			tableMapping.Add("SPFILE", "v$parameter");
		}
	}
}
