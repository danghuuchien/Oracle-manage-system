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
using Oracle.ManagedDataAccess.Client;

namespace AdminApp.Views.ChildViews
{
    
    public partial class ShowAndCreateProfile : Form
    {
        private AdminConnector _connector;

        public ShowAndCreateProfile(AdminConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            LoadData();
            LoadProfiles();
            LoadProfiles1();
        }
        public void LoadData()
        {
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn Xoaprofile = new DataGridViewButtonColumn
            {
                HeaderText = "Xoa profile",
                Name = "Xoaprofile",
                Text = "Xoa profile",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(Xoaprofile);

           

            DataTable dataTable = _connector.GetProfileInfo();
            dataGridView1.DataSource = dataTable;

            // Giải phóng tài nguyên sau khi sử dụng
            dataTable.Dispose();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AddProfile addProfile = new AddProfile(_connector, this);
          
            addProfile.ShowDialog();
            //LoadData();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddUserwithProfile addUserwithProfile = new AddUserwithProfile(_connector);
            addUserwithProfile.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Xoaprofile")
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Cells["PROFILE"].Value != null)
                {
                    string profileName = selectedRow.Cells["PROFILE"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa profile '{profileName}' không?", "Xác nhận xóa profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool success = _connector.DeleteProfile(profileName);

                        if (success)
                        {
                            LoadData();
                            MessageBox.Show($"Đã xóa profile '{profileName}' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Không thể xóa profile '{profileName}'. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xác định profile cần xóa. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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


        private void LoadProfiles1()
        {
            try
            {

                
                OracleDataReader reader = _connector.ThongTinProfile();

                // Đọc dữ liệu từ OracleDataReader và thêm vào ComboBox
                while (reader.Read())
                {
                    cbo2.Items.Add(reader["resource_name"].ToString());
                }

                // Đóng OracleDataReader sau khi sử dụng xong
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profiles: " + ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if (comboBoxProfiles.SelectedItem != null && cbo2.SelectedItem != null && !string.IsNullOrEmpty(txt1.Text))
            {
                string profileName = comboBoxProfiles.SelectedItem.ToString();
                string attributeName = cbo2.SelectedItem.ToString();
                string newValue = txt1.Text;

                // Thực hiện thay đổi thuộc tính profile
                bool success = _connector.ChangeProfileAttribute(profileName, attributeName, newValue);

                if (success)
                {
                    MessageBox.Show("Thuộc tính của profile đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();


                }
                else
                {
                    MessageBox.Show("Không thể thay đổi thuộc tính profile.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn profile và thuộc tính, cũng như nhập giá trị mới trước khi thay đổi thuộc tính profile.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
