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
    public partial class FormTest : Form
    {
        private AdminConnector _connector;
        public FormTest(AdminConnector connector)
        {
            InitializeComponent();
            _connector = connector;

        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void LoadData()
        {

            dataGridView1.Columns.Clear();
            DataTable dataTable = _connector.GetBaiThiInfo();
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
            }
            else
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maBaiThi;
            if (!int.TryParse(txtMa.Text, out maBaiThi))
            {
                MessageBox.Show("Mã bài thi phải là số nguyên.");
                return;
            }

            string tenBaiThi = txtTen.Text;
            string moTa = txtMota.Text;
            int thoiGianLamBai;
            if (!int.TryParse(txtThoigian.Text, out thoiGianLamBai))
            {
                MessageBox.Show("Thời gian làm bài phải là số nguyên.");
                return;
            }
            string nguoiTao = txtNguoiTao.Text;
            DateTime ngayTao = dateTimePicker1.Value;

            // Kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(tenBaiThi) || string.IsNullOrEmpty(moTa) ||
                string.IsNullOrEmpty(nguoiTao) || string.IsNullOrEmpty(txtThoigian.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra mã bài thi không trùng
            if (!_connector.IsMaBaiThiUnique(maBaiThi))
            {
                MessageBox.Show("Mã bài thi đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }

            try
            {
                // Thêm bài thi mới
                bool success = _connector.AddBaiThi(maBaiThi, tenBaiThi, moTa, thoiGianLamBai, nguoiTao, ngayTao);
                if (success)
                {
                    MessageBox.Show("Bài thi đã được thêm thành công.");
                    // Tải lại danh sách bài thi
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm bài thi thất bại.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("trigger")) // Kiểm tra lỗi từ trigger
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int mabaithi = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["mabaithi"].Value);

                try
                {
                    // Call your method to delete the baithi
                    bool success = _connector.XoaBaiThi(mabaithi);

                    if (success)
                    {
                        MessageBox.Show("Bài thi đã được xóa thành công.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa bài thi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài thi để xóa.");
            }
        }
    }
}
