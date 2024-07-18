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
    public partial class AddUserwithProfile : Form
    {
        private readonly AdminConnector _connector;
        public AddUserwithProfile(AdminConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            LoadProfiles();
        }
        private void LoadProfiles()
        {

            comboBoxProfiles.Items.Clear();


            DataTable dataTable = _connector.GetProfileInfo();

            // Add profile names to the ComboBox
            foreach (DataRow row in dataTable.Rows)
            {
                comboBoxProfiles.Items.Add(row["PROFILE"].ToString());
            }
        }


        private void AddUserwithProfile_Load(object sender, EventArgs e)
        {
            LoadProfiles();
            LoadUsersWithProfiles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPass.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            txtUser.Focus();
        }
        private void LoadUsersWithProfiles()
        {
            try
            {
                DataTable dataTable = _connector.GetUsersWithProfiles();
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string profile = comboBoxProfiles.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(profile))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }

            try
            {
                bool success = _connector.CreateUserWithProfile(username, password, profile);
                if (success)
                {
                    MessageBox.Show("User created successfully.");
                    LoadUsersWithProfiles();
                }
                else
                {
                    MessageBox.Show("Failed to add user.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "User already exists.")
                {
                    MessageBox.Show("User already exists. Please choose a different username.");
                }
                else if (ex.Message == "Cannot create user on Sunday.")
                {
                    MessageBox.Show("Cannot create user on Sunday.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy thông tin từ hàng đã chọn
                string username = selectedRow.Cells["USERNAME"].Value.ToString();
                string profile = selectedRow.Cells["PROFILE"].Value.ToString();
                string defaultTablespace = selectedRow.Cells["DEFAULT_TABLESPACE"].Value.ToString();
                string temporaryTablespace = selectedRow.Cells["TEMPORARY_TABLESPACE"].Value.ToString();

               
                txtUser.Text = username;
                comboBoxProfiles.Text = profile;
            
                if (comboBoxProfiles.Items.Contains(profile))
                {
                    comboBoxProfiles.SelectedItem = profile;
                }
                else
                {
                    MessageBox.Show("Profile '" + profile + "' is not available in the list.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string profile = comboBoxProfiles.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(profile))
            {
                MessageBox.Show("Please enter all fields.");
                return;
            }

            try
            {
                bool success = _connector.UpdateUserWithProfile(username, password, profile);
                if (success)
                {
                    MessageBox.Show("User updated successfully.");
                    LoadUsersWithProfiles(); 
                }
                else
                {
                    MessageBox.Show("Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                string username = dataGridView1.SelectedRows[0].Cells["USERNAME"].Value.ToString();

                try
                {
                    
                    bool success = _connector.DeleteUser(username);
                    if (success)
                    {
                        MessageBox.Show("User deleted successfully.");
                        LoadUsersWithProfiles(); 
                        txtPass.Text = string.Empty;
                        txtUser.Text = string.Empty;
                        comboBoxProfiles.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
    }
}
