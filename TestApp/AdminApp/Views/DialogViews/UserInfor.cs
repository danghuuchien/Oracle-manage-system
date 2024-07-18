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
	public partial class UserInfor : Form
	{
		private readonly AdminConnector _connector;
		private readonly string _username;


		public UserInfor(String username, AdminConnector connector)
		{
			InitializeComponent();
			this._connector = connector;
			this._username = username;
		}

		private void UserInfor_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = _connector.GetUserInfo(_username);
		}
	}
}
