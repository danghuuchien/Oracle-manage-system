using Shared.Connection;
using System;
using System.Data;
using System.Windows.Forms;
using AdminApp.Views.DialogViews;

namespace AdminApp.Views.ChildViews
{
	public partial class SessionManagerForm : Form
	{
		private AdminConnector _connector;

		public SessionManagerForm(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void SessionManagerForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			dataGridView1.Columns.Clear();
			DataTable dataTable = _connector.GetSessionInfo();

			DataGridViewButtonColumn killSessionColumn = new DataGridViewButtonColumn
			{
				HeaderText = "Kill Session",
				Name = "KillSessionColumn",
				Text = "Kill Session",
				UseColumnTextForButtonValue = true
			};
			dataGridView1.Columns.Add(killSessionColumn);

			DataGridViewButtonColumn viewProcessColumn = new DataGridViewButtonColumn
			{
				HeaderText = "View Process",
				Name = "ViewProcessColumn",
				Text = "View Process",
				UseColumnTextForButtonValue = true
			};
			dataGridView1.Columns.Add(viewProcessColumn);

			dataGridView1.DataSource = dataTable;
			dataGridView1.CellContentClick += DataGridView1_CellContentClick;
		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
			{
				if (dataGridView1.Columns[e.ColumnIndex].Name == "KillSessionColumn")
				{
					string sid = dataGridView1.Rows[e.RowIndex].Cells["SID"].Value.ToString();
					string serial = dataGridView1.Rows[e.RowIndex].Cells["Serial#"].Value.ToString();
					string sessionInfo = $"'{sid}, {serial}'";

					if (_connector.KillSession(sessionInfo))
					{
						MessageBox.Show($"Succesful");
						LoadData();
					}
					else
					{
						MessageBox.Show("Fail");
					}
				}
				else if (dataGridView1.Columns[e.ColumnIndex].Name == "ViewProcessColumn")
				{
					int sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["SID"].Value.ToString());
					int serial = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Serial#"].Value.ToString());

					ProcessView processView = new ProcessView(sid, serial, _connector);
					processView.ShowDialog();
				}
			}
		}

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
