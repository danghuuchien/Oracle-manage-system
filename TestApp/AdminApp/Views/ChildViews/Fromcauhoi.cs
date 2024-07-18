using Shared.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace AdminApp.Views.ChildViews
{
    public partial class Fromcauhoi : Form
    {
        private AdminConnector _connector;
        public Fromcauhoi(AdminConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            txtMaCauHoi.KeyPress += new KeyPressEventHandler(txtNumber_KeyPress);
        }
        public void LoadData()
        {

            dataGridView1.Columns.Clear();
            DataTable dataTable = _connector.GetCauHoiInfo();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
                dataGridView1.CellClick += dataGridView1_CellClick;
                dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;

            }
            else
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Fromcauhoi_Load(object sender, EventArgs e)
        {
            LoadData();


        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã click vào dòng hợp lệ không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy dữ liệu của cột "hinhanh" từ dòng đã click
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["hinhanh"].Value;

                // Kiểm tra xem dữ liệu hình ảnh có tồn tại không
                if (imageData != null && imageData.Length > 0)
                {
                    // Tạo MemoryStream từ dữ liệu hình ảnh
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        // Hiển thị hình ảnh trong PictureBox
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Nếu không có hình ảnh, thông báo cho người dùng
                    MessageBox.Show("Không có hình ảnh để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu của cột "hinhanh" từ dòng đã click
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["hinhanh"].Value;

                // Kiểm tra xem dữ liệu hình ảnh có tồn tại không
                if (imageData != null && imageData.Length > 0)
                {
                    // Tạo MemoryStream từ dữ liệu hình ảnh
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        // Hiển thị hình ảnh trong PictureBox
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Nếu không có hình ảnh, thông báo cho người dùng
                    MessageBox.Show("Không có hình ảnh để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Thiết lập các thuộc tính cho OpenFileDialog
                openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                // Hiển thị hộp thoại chọn tệp
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đầy đủ của tệp hình ảnh
                    string imagePath = openFileDialog1.FileName;

                    // Hiển thị đường dẫn tệp hình ảnh (tùy chọn)
                    txtImagePath.Text = imagePath;

                    // Đọc hình ảnh từ tệp và hiển thị lên PictureBox
                    Image image = Image.FromFile(imagePath);
                    pictureBox2.Image = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int maCauHoi = int.Parse(txtMaCauHoi.Text);
                string noiDung = txtNoiDung.Text;
                string dapAnDung = txtDapAnDung.Text;
                string dapAnSai1 = txtDapAnSai1.Text;
                string dapAnSai2 = txtDapAnSai2.Text;
                string dapAnSai3 = txtDapAnSai3.Text;
                string hinhAnhPath = txtImagePath.Text; // Đường dẫn tuyệt đối của hình ảnh

                // Kiểm tra xem người dùng đã chọn hình ảnh chưa
                if (!string.IsNullOrEmpty(hinhAnhPath))
                {
                    // Gọi phương thức để thêm câu hỏi với hình ảnh vào CSDL Oracle
                    bool success = _connector.AddCauHoi(maCauHoi, noiDung, Path.GetFileName(hinhAnhPath), dapAnDung, dapAnSai1, dapAnSai2, dapAnSai3);

                    if (success)
                    {
                        MessageBox.Show("Thêm câu hỏi thành công.");
                        LoadData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Thêm câu hỏi thất bại.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        // Hàm kiểm tra mã câu hỏi có trùng lặp hay không
        private bool IsMaCauHoiDuplicate(int maCauHoi)
        {
            DataTable dataTable = _connector.GetCauHoiInfo();
            foreach (DataRow row in dataTable.Rows)
            {
                if (int.Parse(row["macauhoi"].ToString()) == maCauHoi)
                {
                    return true; // Nếu tìm thấy mã câu hỏi trùng lặp, trả về true
                }
            }
            return false; 
        }
        private void ClearTextBoxes()
        {
            txtMaCauHoi.Text = "";
            txtNoiDung.Text = "";
            txtDapAnDung.Text = "";
            txtDapAnSai1.Text = "";
            txtDapAnSai2.Text = "";
            txtDapAnSai3.Text = "";
            txtImagePath.Text = "";
            pictureBox2.Image = null;
        }

    }
}