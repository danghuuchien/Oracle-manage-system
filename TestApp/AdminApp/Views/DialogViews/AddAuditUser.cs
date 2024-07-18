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

namespace AdminApp.Views.DialogViews
{
	public partial class AddAuditUser : Form
	{
		private AdminConnector _connector;

		public AddAuditUser(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string username = username_cbb.SelectedItem as string;
			string table = table_cbb.SelectedItem as string;
		}

		private void AddAuditUser_Load(object sender, EventArgs e)
		{
			_connector.GetUsers().ForEach(u=>username_cbb.Items.Add(u));
			_connector.GetTables().ForEach(t => table_cbb.Items.Add(t));
		}
	}
}
