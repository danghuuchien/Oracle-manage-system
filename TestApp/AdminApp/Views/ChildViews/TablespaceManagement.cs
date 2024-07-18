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
	public partial class TablespaceManagement : Form
	{
		private readonly AdminConnector _connector;

		public TablespaceManagement(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void TablespaceManagement_Load(object sender, EventArgs e)
		{
			comboBox1.Items.Add("All");
			List<string> user = _connector.GetUsers();
			foreach(string u in user)
			{
				comboBox1.Items.Add(u);
			}
			dataGridView2.DataSource = _connector.GetDatafileInfo();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string username = comboBox1.SelectedItem.ToString();
			if(username == "All")
			{
				username = "";
			}
			dataGridView1.DataSource = _connector.GetUserTablespaces(username);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CreateTablespaceViews createTablespaceViews = new CreateTablespaceViews(_connector);
			createTablespaceViews.ShowDialog();
			dataGridView1.DataSource = _connector.GetUserTablespaces("");
			dataGridView2.DataSource = _connector.GetDatafileInfo();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AddDatafile f = new AddDatafile(_connector);
			f.ShowDialog();
		}

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
