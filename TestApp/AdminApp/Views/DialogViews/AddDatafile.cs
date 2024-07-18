using Shared.Connection;
using Shared.Models;
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
	public partial class AddDatafile : Form
	{
		private readonly AdminConnector _connector;
		public AddDatafile(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DatafileOption datafileOption = new DatafileOption
			{
				DatafileName = textBox1.Text,
				DatafileSize = textBox5.Text,
				Autoextend = textBox2.Text,
				AutoextendSize = textBox3.Text,
				Maxsize = textBox4.Text
			};
			if (_connector.AddDatafile(comboBox1.SelectedItem.ToString(), datafileOption))
			{
				MessageBox.Show("Add datafile successfully");
			}
			else
			{
				MessageBox.Show("Add datafile failed");
			}
		}

		private void AddDatafile_Load(object sender, EventArgs e)
		{
			List<string> tablespace = _connector.GetTablespaces();
			foreach (string t in tablespace)
			{
				comboBox1.Items.Add(t);
			}
		}
	}
}
