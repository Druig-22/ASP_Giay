using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class HoaDonUI : Form
    {
        ProductBUS productBus = new ProductBUS();
        HoaDonBUS hoaDonBus = new HoaDonBUS();
        CTHoaDonBUS chiTietBus = new CTHoaDonBUS();
        public static string currentUser;   
        public static string currentMaNV;   

        public HoaDonUI()
        {
            InitializeComponent();
        }

        private void HoaDonUI_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            InitChiTiet();
            LoadLoaiKhachHang();
            txtNhanVien.Text = LoginUI.currentTenNV;
            txtSoHoaDon.Text = GenerateMaHD();
            string maNV = LoginUI.currentMaNV;      

        }

        private void LoadLoaiKhachHang()
        {
            cbLoaiKH.Items.Clear();
            cbLoaiKH.Items.AddRange(new string[] { "Thường", "VIP", "Đại lý" });
            cbLoaiKH.SelectedIndex = 0;
        }

        private void InitChiTiet()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("MaGiay", "Mã giày");
            dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");
        }

        private void LoadSanPham()
        {
            dgvSanPham.DataSource = productBus.GetData();
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSanPham.Text = dgvSanPham.Rows[e.RowIndex].Cells["MaGiay"].Value.ToString();
                txtDonGia.Text = dgvSanPham.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSanPham.Text)) return;

            int sl = (int)numSoLuong.Value;
            decimal dg = decimal.Parse(txtDonGia.Text);
            decimal tt = sl * dg;
            dgvChiTiet.Rows.Add(txtSanPham.Text, sl, dg, tt);
            TinhTien();
        }

        private void TinhTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow r in dgvChiTiet.Rows)
                tong += Convert.ToDecimal(r.Cells["ThanhTien"].Value);

            txtTongTien.Text = tong.ToString("N0");

            decimal giam = 0;
            if (cbLoaiKH.Text == "VIP") giam = tong * 0.1m;
            else if (cbLoaiKH.Text == "Đại lý") giam = tong * 0.15m;

            txtGiamGia.Text = giam.ToString("N0");
            txtPhaiThu.Text = (tong - giam).ToString("N0");
        }
        private string GenerateMaHD()
        {
            string newID = "HD0001";
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            string sql = "SELECT TOP 1 MaHD FROM HOADON ORDER BY MaHD DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastID = result.ToString(); 
                    int number = int.Parse(lastID.Substring(2)) + 1; 
                    newID = "HD" + number.ToString("D4"); 
                }
            }

            return newID;
        }



        private string GenerateMaKH()
        {
            string newID = "KH0001";
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            string sql = "SELECT TOP 1 MaKH FROM KHACHHANG ORDER BY MaKH DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastID = result.ToString(); 
                    int number = int.Parse(lastID.Substring(2)) + 1;
                    newID = "KH" + number.ToString("D4"); 
                }
            }
            return newID;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
 
                string maHD = txtSoHoaDon.Text;
                string maNV = LoginUI.currentMaNV; 
                decimal tongTien = decimal.Parse(txtPhaiThu.Text);


                string maKH = GenerateMaKH();
                string sqlInsertKH = "INSERT INTO KHACHHANG (MaKH, HoTen, GioiTinh, DienThoai, DiaChi, NgayDangKy) " +
                                     "VALUES (@MaKH, N'', 1, '', '', GETDATE())";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlInsertKH, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                }

                // 3️⃣ Lưu hóa đơn
                HoaDon hd = new HoaDon(maHD, DateTime.Now, maNV, maKH, tongTien);
                if (hoaDonBus.Insert(hd))
                {
                    // 4️⃣ Lưu chi tiết hóa đơn
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string maGiay = row.Cells["MaGiay"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                        var cthd = new CTHoaDon(maHD, maGiay, soLuong, donGia, 0);
                        chiTietBus.Insert(cthd);

                        // 5️⃣ Trừ tồn kho
                        string sqlUpdateTon = "UPDATE GIAY SET SoLuongTon = SoLuongTon - @SL WHERE MaGiay = @MaGiay";
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(sqlUpdateTon, conn);
                            cmd.Parameters.AddWithValue("@SL", soLuong);
                            cmd.Parameters.AddWithValue("@MaGiay", maGiay);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(" Thanh toán và lưu hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoHoaDon.Text = GenerateMaHD(); // Sinh mã HD mới
                    dgvChiTiet.Rows.Clear(); // Xóa chi tiết cũ
                    txtTongTien.Clear();
                    txtGiamGia.Clear();
                    txtPhaiThu.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
