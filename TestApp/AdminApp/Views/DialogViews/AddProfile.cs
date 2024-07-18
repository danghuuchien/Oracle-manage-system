using AdminApp.Views.ChildViews;
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
    public partial class AddProfile : Form
    {
        private readonly AdminConnector _connector;
        private readonly ShowAndCreateProfile _showAndCreateProfile;
        public AddProfile(AdminConnector connector, ShowAndCreateProfile showAndCreateProfile)
        {
            InitializeComponent();
            _connector = connector;
            _showAndCreateProfile = showAndCreateProfile;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string profileName = txtProfileName.Text.Trim();
                int passwordLifeTime = string.IsNullOrEmpty(txtPasswordLifeTime.Text) ? 90 : int.Parse(txtPasswordLifeTime.Text);
                int passwordGraceTime = string.IsNullOrEmpty(txtPasswordGraceTime.Text) ? 7 : int.Parse(txtPasswordGraceTime.Text);
                int passwordReuseMax = string.IsNullOrEmpty(txtPasswordReuseMax.Text) ? 5 : int.Parse(txtPasswordReuseMax.Text);
                int passwordReuseTime = string.IsNullOrEmpty(txtPasswordReuseTime.Text) ? 365 : int.Parse(txtPasswordReuseTime.Text);
                int failedLoginAttempts = string.IsNullOrEmpty(txtFailedLoginAttempts.Text) ? 10 : int.Parse(txtFailedLoginAttempts.Text);
                int passwordLockTime = string.IsNullOrEmpty(txtPasswordLockTime.Text) ? 1 : int.Parse(txtPasswordLockTime.Text);

                // Kiểm tra tên profile không được null hoặc trống
                if (string.IsNullOrEmpty(profileName))
                {
                    MessageBox.Show("Profile name khong duoc de trong");
                    return;
                }

                // Gọi phương thức AddNewProfile từ AdminConnector
                bool success = _connector.AddNewProfile(profileName, passwordLifeTime, passwordGraceTime, passwordReuseMax, passwordReuseTime, failedLoginAttempts, passwordLockTime);

                if (success)
                {
                    MessageBox.Show("Profile added successfully.");
                   _showAndCreateProfile.LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to add profile.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void AddProfile_Load(object sender, EventArgs e)
        {

            txtPasswordLifeTime.KeyPress += txtNumber_KeyPress;
            txtPasswordGraceTime.KeyPress += txtNumber_KeyPress;
            txtPasswordReuseMax.KeyPress += txtNumber_KeyPress;
            txtPasswordReuseTime.KeyPress += txtNumber_KeyPress;
            txtFailedLoginAttempts.KeyPress += txtNumber_KeyPress;
            txtPasswordLockTime.KeyPress += txtNumber_KeyPress;
        }
    }
    
}
