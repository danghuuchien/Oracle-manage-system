using System;
using System.Windows.Forms;
using Shared.Connection;

namespace AdminApp.Views
{
	public partial class LoginForm : Form
	{
		private static LoginForm instance = null;

		private LoginForm()
		{
			InitializeComponent();
		}

		public static LoginForm Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LoginForm();
				}
				return instance;
			}
		}

		private void login_btn_Click(object sender, EventArgs e)
		{
			try
			{
				string username = username_txt.Texts;
				string password = password_txt.Texts;
				AdminConnector connector = new AdminConnector(username, password);
				
				if (connector != null )
				{
					username_txt.Texts = "";
					password_txt.Texts = "";
					connector.KillOtherSession();
					LoginForm.Instance.Hide();
					Home home = new Home(connector);
					home.Show();
				}
				else
				{
					MessageBox.Show("Invalid username or password");
				}
			} catch(Oracle.ManagedDataAccess.Client.OracleException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void username_txt__TextChanged(object sender, EventArgs e)
		{

		}

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
