using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace Presentation
{
    public partial class ProductUI : Form
    {
        ProductBUS productBus = new ProductBUS();
        CategoryBUS catBus = new CategoryBUS();
        bool isAdd = false;

        public static event Action OnProductAdded;
        public ProductUI()
        {
            InitializeComponent();
        }

        private void ProductUI_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
            SetControlState(false);
        }

        private void SetControlState(bool editing)
        {
            txtMaGiay.Enabled = editing;
            txtTenGiay.Enabled = editing;
            cboLoaiGiay.Enabled = editing;
            txtMaTH.Enabled = editing;
            txtTenTH.Enabled = editing;
            txtSize.Enabled = editing;
            txtMauSac.Enabled = editing;
            txtDonGia.Enabled = editing;
            txtSoLuongTon.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;

            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }

        private void LoadData()
        {
            dgvProduct.DataSource = productBus.GetData();
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.MultiSelect = false;
            dgvProduct.ClearSelection();
            dgvProduct.ReadOnly = true;
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.AllowUserToDeleteRows = false;

            if (dgvProduct.Columns.Contains("MaGiay"))
                dgvProduct.Columns["MaGiay"].HeaderText = "Mã giày";
            if (dgvProduct.Columns.Contains("TenGiay"))
                dgvProduct.Columns["TenGiay"].HeaderText = "Tên giày";
            if (dgvProduct.Columns.Contains("MaLoaiGiay"))
                dgvProduct.Columns["MaLoaiGiay"].HeaderText = "Mã loại giày";
            if (dgvProduct.Columns.Contains("TenLoaiGiay"))
                dgvProduct.Columns["TenLoaiGiay"].HeaderText = "Tên loại giày";
            if (dgvProduct.Columns.Contains("MaTH"))
                dgvProduct.Columns["MaTH"].HeaderText = "Mã thương hiệu";
            if (dgvProduct.Columns.Contains("TenTH"))
                dgvProduct.Columns["TenTH"].HeaderText = "Tên thương hiệu";
            if (dgvProduct.Columns.Contains("Size"))
                dgvProduct.Columns["Size"].HeaderText = "Kích cỡ";
            if (dgvProduct.Columns.Contains("MauSac"))
                dgvProduct.Columns["MauSac"].HeaderText = "Màu sắc";
            if (dgvProduct.Columns.Contains("DonGia"))
            {
                dgvProduct.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";
                dgvProduct.Columns["DonGia"].DefaultCellStyle.Format = "c0";
                dgvProduct.Columns["DonGia"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            }
            if (dgvProduct.Columns.Contains("SoLuongTon"))
                dgvProduct.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
        }

        private void LoadCombos()
        {
            // Chỉ còn combo loại giày
            cboLoaiGiay.DataSource = catBus.GetData();
            cboLoaiGiay.DisplayMember = "MaLoaiGiay";
            cboLoaiGiay.ValueMember = "MaLoaiGiay";
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            ClearInputs();
            SetControlState(true);
            txtMaGiay.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGiay.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            isAdd = false;
            SetControlState(true);
            txtMaGiay.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGiay.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?",
                                             "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (productBus.Delete(txtMaGiay.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearInputs();
                }
                else
                    MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGiay.Text) || string.IsNullOrEmpty(txtTenGiay.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            Product p = new Product(
                txtMaGiay.Text.Trim(),
                txtTenGiay.Text.Trim(),
                cboLoaiGiay.SelectedValue.ToString(),
                txtMaTH.Text.Trim(),
                int.Parse(txtSize.Text),
                txtMauSac.Text.Trim(),
                decimal.Parse(txtDonGia.Text),
                int.Parse(txtSoLuongTon.Text),
                txtTenTH.Text.Trim()
            );

            bool success = false;

            if (isAdd)
            {
                success = productBus.Insert(p);
                if (success)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại hoặc mã giày đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                success = productBus.Update(p);
                if (success)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //  Nếu thao tác thành công → load lại dữ liệu mới nhất
            if (success)
            {
                LoadData();

                //  Giữ lại dòng vừa được thêm/cập nhật
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    if (row.Cells["MaGiay"].Value.ToString() == p.MaGiay)
                    {
                        dgvProduct.ClearSelection();
                        row.Selected = true;
                        dgvProduct.FirstDisplayedScrollingRowIndex = row.Index;

                        // Cập nhật textbox để hiển thị lại dữ liệu mới
                        txtMaGiay.Text = row.Cells["MaGiay"].Value.ToString();
                        txtTenGiay.Text = row.Cells["TenGiay"].Value.ToString();
                        cboLoaiGiay.SelectedValue = row.Cells["MaLoaiGiay"].Value.ToString();
                        txtMaTH.Text = row.Cells["MaTH"].Value.ToString();
                        txtTenTH.Text = row.Cells["TenTH"].Value.ToString();
                        txtSize.Text = row.Cells["Size"].Value.ToString();
                        txtMauSac.Text = row.Cells["MauSac"].Value.ToString();
                        txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                        txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
                        break;
                    }
                }
            }

            SetControlState(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtMaGiay.Clear();
            txtTenGiay.Clear();
            cboLoaiGiay.SelectedIndex = -1;
            txtMaTH.Clear();
            txtTenTH.Clear();
            txtSize.Clear();
            txtMauSac.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var r = dgvProduct.Rows[e.RowIndex];
                txtMaGiay.Text = r.Cells["MaGiay"].Value.ToString();
                txtTenGiay.Text = r.Cells["TenGiay"].Value.ToString();
                cboLoaiGiay.SelectedValue = r.Cells["MaLoaiGiay"].Value.ToString();
                txtMaTH.Text = r.Cells["MaTH"].Value.ToString();
                txtTenTH.Text = r.Cells["TenTH"].Value.ToString();
                txtSize.Text = r.Cells["Size"].Value.ToString();
                txtMauSac.Text = r.Cells["MauSac"].Value.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();
                txtSoLuongTon.Text = r.Cells["SoLuongTon"].Value.ToString();

                dgvProduct.ClearSelection();
                dgvProduct.Rows[e.RowIndex].Selected = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
