using AdminApp.Views.DialogViews;
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
	public partial class TableViewerForm : Form
	{
		private readonly AdminConnector _connector;

		public TableViewerForm(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void TableViewerForm_Load(object sender, EventArgs e)
		{
			List<String> tables = _connector.GetTables();
			foreach (var table in tables)
			{
				tables_cbb.Items.Add(table);
			}
		}

		private void tables_cbb_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedTable = tables_cbb.SelectedItem.ToString();
			string tableName = selectedTable.Substring(0, selectedTable.IndexOf(" ("));

			LoadTableStructure(tableName);
			LoadTableData(tableName);

		}

		private void LoadTableStructure(string tableName)
		{
			List<string[]> tableColumnInfo = _connector.GetTableColumnInfo(tableName);
			
			tableStructure_dtgv.Rows.Clear();
			table_dtgv.Columns.Clear();
			table_dtgv.Rows.Clear();

			foreach (var column in tableColumnInfo)
			{
				tableStructure_dtgv.Rows.Add(column);
				table_dtgv.Columns.Add(column[0], column[0]);
			}
		}

		private void LoadTableData(string tableName)
		{
			List<string[]> data = _connector.GetTableData(tableName);
			table_dtgv.Rows.Clear();
			foreach (var row in data)
			{
				table_dtgv.Rows.Add(row);
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			//AddProfile addProfile = new AddProfile(_connector, this);
			FormTest form = new FormTest(_connector);
			form.ShowDialog();
            //addProfile.ShowDialog();
        }
    }
}
