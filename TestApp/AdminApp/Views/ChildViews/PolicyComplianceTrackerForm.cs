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
using AdminApp.Views.DialogViews;

namespace AdminApp.Views.ChildViews
{
	public partial class PolicyComplianceTrackerForm : Form
	{
		private readonly AdminConnector _connector;

		public PolicyComplianceTrackerForm(AdminConnector connector)
		{
			InitializeComponent();
			this._connector = connector;
		}

		private void PolicyComplianceTrackerForm_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = _connector.GetPolicies();
			user_cbb.Items.Add("All");
			_connector.GetUsers().ForEach(u => { user_cbb.Items.Add(u); });
			table_cbb.Items.Add("All");
			_connector.GetTables().ForEach(t => { table_cbb.Items.Add(t); });


			user_cbb.SelectedIndex = 0;
			table_cbb.SelectedIndex = 0;
		}

		private void UpdateAuditTable()
		{
			dataGridView2.DataSource = _connector.GetAllAuditTrail();
			//String username = user_cbb.SelectedItem as String;
			//String table = table_cbb.SelectedItem as String;
			
			//if (username != null)
			//{
			//	if(username == "All" && table == "All")
			//	{

			//	} else if(username == "All" && table != "All")
			//	{

			//	} else if(username != "All" && table == "All")
			//	{

			//	} else
			//	{

			//	}
			//}
		}

		private void user_cbb_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateAuditTable();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AddAuditUser f = new AddAuditUser(_connector);
			f.ShowDialog();
		}
	}
}
