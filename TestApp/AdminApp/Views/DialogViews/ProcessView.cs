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
	public partial class ProcessView : Form
	{
		private AdminConnector _connector;
		private int _sid;
		private int _serial;


		public ProcessView(int sid, int serial, AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
			_sid = sid;
			_serial = serial;
		}

		private void ProcessView_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = _connector.GetSessionProcesses(_sid, _serial);
		}
	}
}
