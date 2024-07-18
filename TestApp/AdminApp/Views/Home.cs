using Oracle.ManagedDataAccess.Client;
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
using AdminApp.Views.ChildViews;
using AdminApp.Views.DialogViews;

namespace AdminApp.Views
{
	public partial class Home : Form
	{
		private readonly AdminConnector _connector;

		private Button currentButton;
		private Form activeForm;

		public Home(AdminConnector connection)
		{
			InitializeComponent();
			this._connector = connection;
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				SysConnector sysConnector = new SysConnector();
				sysConnector.KillSession(_connector.GetCurrentSessionInfo());
				this.Hide();
				LoginForm.Instance.Show();
			}
		}

		private void OpenChildForm(Form childForm, object btnSender)
		{
			if (activeForm != null)
			{
				activeForm.Close();
			}
			activeForm = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			this.panelDesktopPane.Controls.Add(childForm);
			this.panelDesktopPane.Tag = childForm;
			childForm.BringToFront();
			ActivateButton(btnSender);
			childForm.Show();
		}

		private void ActivateButton(object btnSender)
		{
			DisableButtonsInMenu();
			if (btnSender != null)
			{
				if (currentButton != (Button)btnSender)
				{
					currentButton = (Button)btnSender;
					currentButton.Font = new Font(currentButton.Font.FontFamily, 10f, FontStyle.Bold);
					currentButton.Enabled = false;
					lblTitle.Text = currentButton.Text.ToUpper();
				}
			}
		}

		private void DisableButtonsInMenu()
		{
			foreach (Control ctrl in panelMenu.Controls)
			{
				if (ctrl != null && ctrl.GetType() == typeof(Button))
				{
					ctrl.BackColor = Color.FromArgb(51, 51, 76);
					ctrl.Font = new Font(currentButton.Font.FontFamily, 10f);
					ctrl.Enabled = true;
				}
			}
		}

		private void tableViewer_btn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new TableViewerForm(_connector), sender);
		}

		private void databaseInformation_btn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new DatabaseInformationForm(_connector), sender);
		}

		private void sessionManagement_btn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new SessionManagerForm(_connector), sender);
		}

		private void tablespaceManagement_btn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new TablespaceManagement(_connector), sender);
		}

		private void Home_Load(object sender, EventArgs e)
		{
			username_lbl.Text = _connector.Username;
			currentButton = tableViewer_btn;
			lastLogin_lbl.Text = _connector.GetLastLogin(_connector.Username);
			OpenChildForm(new TableViewerForm(_connector), currentButton);
			currentButton.Font = new Font(currentButton.Font.FontFamily, 10f, FontStyle.Bold);
			currentButton.Enabled = false;
		}

		private void buttonDisablePaint(object sender, PaintEventArgs e)
		{
			Button button = (Button)sender;

			if (!button.Enabled)
			{
				using (Brush textBrush = new SolidBrush(Color.White))
				using (Brush backBrush = new SolidBrush(Color.FromArgb(125, 125, 161)))
				{
					SizeF textSize = e.Graphics.MeasureString(button.Text, button.Font);
					float x = (button.Width - textSize.Width) / 2;
					float y = (button.Height - textSize.Height) / 2;

					e.Graphics.FillRectangle(backBrush, new Rectangle(0, 0, button.Width, button.Height));
					e.Graphics.DrawString(button.Text, button.Font, textBrush, new PointF(x, y));
				}
			}
		}

		private void username_lbl_Click(object sender, EventArgs e)
		{
			UserInfor f = new UserInfor(_connector.Username, _connector);
			f.ShowDialog();
		}

		private void policyComplianceTracker_btn_Click(object sender, EventArgs e)
		{
			OpenChildForm(new PolicyComplianceTrackerForm(_connector), sender);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ShowAndCreateProfile(_connector), sender);
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butonhienanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromcauhoi(_connector), sender);
        }
    }
}
