using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Connection;
using Shared.Models;

namespace AdminApp.Views.DialogViews
{
	public partial class CreateTablespaceViews : Form
	{
		private readonly AdminConnector _connector;

		public CreateTablespaceViews(AdminConnector connector)
		{
			InitializeComponent();
			_connector = connector;
		}

		private void CreateTablespaceViews_Load(object sender, EventArgs e)
		{
			dataGridView1.ColumnCount = 6;
			dataGridView1.Columns[0].Name = "Datafile Name";
			dataGridView1.Columns[1].Name = "Datafile Path";
			dataGridView1.Columns[2].Name = "Datafile Size";
			dataGridView1.Columns[2].HeaderText = "Datafile Size (MB)";
			dataGridView1.Columns[3].Name = "Autoextend";
			dataGridView1.Columns[4].Name = "Autoextend Size";
			dataGridView1.Columns[4].HeaderText = "Autoextend Size (MB)";
			dataGridView1.Columns[5].Name = "Maxsize";
			dataGridView1.Columns[5].HeaderText = "Maxsize (MB)";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			List<DatafileOption> validOptions = new List<DatafileOption>();

			if (CheckDataGridViewParameters(dataGridView1, out validOptions))
			{
				if(_connector.CreateTablespace(textBox1.Text, validOptions.ToArray()))
				{
					MessageBox.Show("Create tablespace successfully");
				} else
				{
					MessageBox.Show("Create tablespace failed");
				}

			}
			else
			{
				MessageBox.Show("Invalid parameters");
			}
		}

		private bool CheckDataGridViewParameters(DataGridView dataGridView, out List<DatafileOption> validOptions)
		{
			validOptions = new List<DatafileOption>();
			if (String.IsNullOrEmpty(textBox1.Text))
			{
				return false;
			}

			for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
			{
				DataGridViewRow row = dataGridView.Rows[i];
				string datafileName = row.Cells["Datafile Name"].Value?.ToString();
				string datafilePath = row.Cells["Datafile Path"].Value?.ToString();
				string datafileSize = row.Cells["Datafile Size"].Value?.ToString();
				string autoextend = row.Cells["Autoextend"].Value?.ToString();
				string autoextendSize = row.Cells["Autoextend Size"].Value?.ToString();
				string maxsize = row.Cells["Maxsize"].Value?.ToString();

				if (!IsPositiveNumber(datafileSize) ||
					(autoextend != "ON" && autoextend != "OFF") ||
					(autoextend == "ON" && !IsPositiveNumber(autoextendSize)) ||
					(autoextend == "ON" && maxsize != "UNLIMITED" && !IsPositiveNumber(maxsize)))
				{
					return false;
				}
				else
				{
					validOptions.Add(new DatafileOption(datafileName, datafilePath, datafileSize, autoextend, autoextendSize, maxsize));
				}
			}

			return true;
		}


		private bool IsPositiveNumber(string value)
		{
			// Kiểm tra xem giá trị có phải là số dương không
			double number;
			return double.TryParse(value, out number) && number > 0;
		}


	}
}
