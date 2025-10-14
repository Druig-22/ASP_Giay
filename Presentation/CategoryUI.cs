using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class CategoryUI : Form
    {
        CategoryBUS bus = new CategoryBUS();
        bool isAdd = false;
        public CategoryUI()
        {
            InitializeComponent();
        }

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);

            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.MultiSelect = false;
            dgvCategory.ReadOnly = true;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvCategory.DefaultCellStyle.SelectionForeColor = Color.Black;

        }

        private void SetControlState(bool editing)
        {
            txtMaLoaiGiay.Enabled = editing;
            txtTenLoaiGiay.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;

            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }

        private void LoadData()
        {
            dgvCategory.DataSource = bus.GetData();

            if (dgvCategory.Rows.Count > 0)
            {
                dgvCategory.ClearSelection();
                dgvCategory.Rows[0].Selected = true;
                txtMaLoaiGiay.Text = dgvCategory.Rows[0].Cells["MaLoaiGiay"].Value.ToString();
                txtTenLoaiGiay.Text = dgvCategory.Rows[0].Cells["TenLoaiGiay"].Value.ToString();
            }
            else
            {
                txtMaLoaiGiay.Clear();
                txtTenLoaiGiay.Clear();
            }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // chọn toàn dòng
                dgvCategory.ClearSelection();
                dgvCategory.Rows[e.RowIndex].Selected = true;
                dgvCategory.CurrentCell = dgvCategory.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // lấy dữ liệu hiển thị sang textbox
                txtMaLoaiGiay.Text = dgvCategory.Rows[e.RowIndex].Cells["MaLoaiGiay"].Value.ToString();
                txtTenLoaiGiay.Text = dgvCategory.Rows[e.RowIndex].Cells["TenLoaiGiay"].Value.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtMaLoaiGiay.Clear();
            txtTenLoaiGiay.Clear();
            SetControlState(true);
            txtMaLoaiGiay.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoaiGiay.Text))
            {
                MessageBox.Show("Vui lòng chọn loại giày cần sửa!");
                return;
            }

            isAdd = false;
            SetControlState(true);
            txtMaLoaiGiay.Enabled = false; // không cho sửa mã
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoaiGiay.Text))
            {
                MessageBox.Show("Vui lòng chọn loại giày cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại giày này không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (bus.Delete(txtMaLoaiGiay.Text))
                {
                    MessageBox.Show("Đã xóa thành công!");
                    LoadData();
                    txtMaLoaiGiay.Clear();
                    txtTenLoaiGiay.Clear();
                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập thiếu
            if (string.IsNullOrEmpty(txtMaLoaiGiay.Text) || string.IsNullOrEmpty(txtTenLoaiGiay.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category c = new Category(txtMaLoaiGiay.Text.Trim(), txtTenLoaiGiay.Text.Trim());

            if (isAdd)
            {
                // ✅ Kiểm tra trùng mã trước khi thêm
                if (bus.Exists(c.MaLoaiGiay))
                {
                    MessageBox.Show("Mã loại giày này đã tồn tại, vui lòng nhập mã khác!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaLoaiGiay.Focus();
                    return;
                }

                // Nếu mã chưa trùng → thêm
                if (bus.Insert(c))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (bus.Update(c))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SetControlState(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            txtMaLoaiGiay.Clear();
            txtTenLoaiGiay.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
