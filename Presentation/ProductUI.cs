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
        private List<string> GetBrandIDs()
        {
            List<string> brandList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            string sql = "SELECT MaTH FROM THUONGHIEU";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    brandList.Add(dr["MaTH"].ToString());
                }

                dr.Close();
            }

            return brandList;
        }

        private void SetControlState(bool editing)
        {
            txtMaGiay.Enabled = editing;
            txtTenGiay.Enabled = editing;
            cboLoaiGiay.Enabled = editing;
            cboThuongHieu.Enabled = editing;
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
        }

        private void LoadCombos()
        {
            cboLoaiGiay.DataSource = catBus.GetData();
            cboLoaiGiay.DisplayMember = "TenLoaiGiay";
            cboLoaiGiay.ValueMember = "MaLoaiGiay";

            // Thương hiệu – chỉ lấy mã
            cboThuongHieu.DataSource = GetBrandIDs();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var r = dgvProduct.Rows[e.RowIndex];
                txtMaGiay.Text = r.Cells["MaGiay"].Value.ToString();
                txtTenGiay.Text = r.Cells["TenGiay"].Value.ToString();
                cboLoaiGiay.SelectedValue = r.Cells["MaLoaiGiay"].Value.ToString();
                cboThuongHieu.SelectedItem = r.Cells["MaTH"].Value.ToString();
                txtSize.Text = r.Cells["Size"].Value.ToString();
                txtMauSac.Text = r.Cells["MauSac"].Value.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();
                txtSoLuongTon.Text = r.Cells["SoLuongTon"].Value.ToString();

                dgvProduct.ClearSelection();
                dgvProduct.Rows[e.RowIndex].Selected = true;
            }
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
                cboThuongHieu.SelectedItem.ToString(),
                int.Parse(txtSize.Text),
                txtMauSac.Text.Trim(),
                decimal.Parse(txtDonGia.Text),
                int.Parse(txtSoLuongTon.Text)
            );

            if (isAdd)
            {
                if (productBus.Insert(p))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else
                    MessageBox.Show("Thêm thất bại hoặc mã giày đã tồn tại!");
            }
            else
            {
                if (productBus.Update(p))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                else
                    MessageBox.Show("Cập nhật thất bại!");
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
            cboThuongHieu.SelectedIndex = -1;
            txtSize.Clear();
            txtMauSac.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();
        }
    }
}
