using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;

namespace Presentation
{
    public partial class HoaDonUI : Form
    {
        ProductBUS productBus = new ProductBUS();
        HoaDonBUS hoaDonBus = new HoaDonBUS();
        CultureInfo vn = new CultureInfo("vi-VN");


        decimal tongTien = 0;
        public HoaDonUI()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void HoaDonUI_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = vn;
            System.Threading.Thread.CurrentThread.CurrentUICulture = vn;

            LoadSanPham();
            InitChiTiet();
            LoadLoaiKH(); // Dùng bản có DataTable thay vì LoadLoaiKhachHang()

            txtNhanVien.Text = LoginUI.currentTenNV;
            txtSoHoaDon.Text = hoaDonBus.TaoMaHoaDonMoi();
            txtMaKH.Text = hoaDonBus.TaoMaKhachHangMoi();

            cbLoaiKH.SelectedIndex = 0;
            dtNgayBan.Format = DateTimePickerFormat.Custom;
            dtNgayBan.CustomFormat = "dd/MM/yyyy"; // Hiển thị ngày/tháng/năm

        }

        private void InitChiTiet()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("MaGiay", "Mã giày");
            dgvChiTiet.Columns["MaGiay"].Visible = false; // ẩn hoàn toàn
            dgvChiTiet.Columns.Add("TenGiay", "Tên giày");
            dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("TongThanhTien", "Tổng thành tiền");
            dgvChiTiet.Columns.Add("TienGiamGia", "Tiền giảm giá");
            dgvChiTiet.Columns.Add("TongSauGiam", "Tổng sau giảm");

            // Căn phải và format VNĐ
            foreach (string col in new[] { "DonGia", "TongThanhTien", "TienGiamGia", "TongSauGiam" })
            {
                dgvChiTiet.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns[col].DefaultCellStyle.Format = "c0";
                dgvChiTiet.Columns[col].DefaultCellStyle.FormatProvider = vn;
            }

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
        }

        private void SetDefaultUI()
        {
            txtDonGia.ReadOnly = true;
            txtNhanVien.Text = "Phạm Văn Minh"; // giả lập
            txtSoHoaDon.Text = "HD" + DateTime.Now.ToString("yyMMddHHmm");
            dtNgayBan.Value = DateTime.Now;
           
        }

        private void LoadLoaiKH()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoaiKH");
            dt.Columns.Add("TenLoaiKH");
            dt.Columns.Add("GiamGia", typeof(decimal));

            dt.Rows.Add("LKH01", "Khách lẻ", 0);
            dt.Rows.Add("LKH02", "Thường", 0.05m);
            dt.Rows.Add("LKH03", "VIP", 0.10m);

            cbLoaiKH.DataSource = dt;
            cbLoaiKH.DisplayMember = "TenLoaiKH";
            cbLoaiKH.ValueMember = "MaLoaiKH";
        }

        private void LoadSanPham()
        {
            dgvSanPham.DataSource = productBus.GetDataForSale();
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ẩn các cột không cần
            if (dgvSanPham.Columns.Contains("MaGiay"))
                dgvSanPham.Columns["MaGiay"].Visible = false;

            if (dgvSanPham.Columns.Contains("MaLoaiGiay"))
                dgvSanPham.Columns["MaLoaiGiay"].Visible = false;

            if (dgvSanPham.Columns.Contains("MaTH"))
                dgvSanPham.Columns["MaTH"].Visible = false;

            if (dgvSanPham.Columns.Contains("DonGiaNhap"))
                dgvSanPham.Columns["DonGiaNhap"].Visible = false;

            //  Hiển thị các cột cần thiết
            if (dgvSanPham.Columns.Contains("TenGiay"))
                dgvSanPham.Columns["TenGiay"].HeaderText = "Tên giày";

            if (dgvSanPham.Columns.Contains("TenTH"))
                dgvSanPham.Columns["TenTH"].HeaderText = "Thương hiệu";

            if (dgvSanPham.Columns.Contains("Size"))
                dgvSanPham.Columns["Size"].HeaderText = "Kích cỡ";

            if (dgvSanPham.Columns.Contains("MauSac"))
                dgvSanPham.Columns["MauSac"].HeaderText = "Màu sắc";

            if (dgvSanPham.Columns.Contains("DonGiaBan"))
            {
                dgvSanPham.Columns["DonGiaBan"].HeaderText = "Giá bán (VNĐ)";
                dgvSanPham.Columns["DonGiaBan"].DefaultCellStyle.Format = "c0";
                dgvSanPham.Columns["DonGiaBan"].DefaultCellStyle.FormatProvider = vn;
            }

            if (dgvSanPham.Columns.Contains("SoLuongTon"))
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn kho";
        }

     

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSanPham.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenGiay = txtSanPham.Text;
            string maGiay = selectedMaGiay;
            decimal donGia = decimal.Parse(txtDonGia.Text, NumberStyles.Currency, vn);
            int soLuong = (int)numSoLuong.Value;
            decimal tongThanhTien = donGia * soLuong;

            // Giảm giá %
            // Giảm giá %
            decimal phanTramGiam = 0;
            if (!string.IsNullOrEmpty(txtGiamGia.Text))
            {
                // Loại bỏ ký tự % hoặc khoảng trắng trước khi parse
                string text = txtGiamGia.Text.Replace("%", "").Trim();

                if (!string.IsNullOrEmpty(text))
                    phanTramGiam = decimal.Parse(text) / 100;
            }

            decimal tienGiam = tongThanhTien * phanTramGiam;
            decimal tongSauGiam = tongThanhTien - tienGiam;

            // Nếu sản phẩm đã tồn tại thì cộng dồn
            bool daTonTai = false;
            foreach (DataGridViewRow r in dgvChiTiet.Rows)
            {
                if (r.Cells["MaGiay"].Value.ToString() == maGiay)
                {
                    int slCu = Convert.ToInt32(r.Cells["SoLuong"].Value);
                    int slMoi = slCu + soLuong;
                    decimal ttMoi = slMoi * donGia;
                    decimal giamMoi = ttMoi * phanTramGiam;
                    decimal tongSauGiamMoi = ttMoi - giamMoi;

                    r.Cells["SoLuong"].Value = slMoi;
                    r.Cells["TongThanhTien"].Value = string.Format(vn, "{0:C0}", ttMoi);
                    r.Cells["TienGiamGia"].Value = string.Format(vn, "{0:C0}", giamMoi);
                    r.Cells["TongSauGiam"].Value = string.Format(vn, "{0:C0}", tongSauGiamMoi);
                    daTonTai = true;
                    break;
                }
            }

            if (!daTonTai)
            {
                dgvChiTiet.Rows.Add(
                    maGiay,   // cột ẩn, để lưu DB
                    tenGiay,
                    soLuong,
                    string.Format(vn, "{0:C0}", donGia),
                    string.Format(vn, "{0:C0}", tongThanhTien),
                    string.Format(vn, "{0:C0}", tienGiam),
                    string.Format(vn, "{0:C0}", tongSauGiam)
                );

            }

            // Reset nhập liệu
            txtSanPham.Clear();
            txtDonGia.Clear();
            numSoLuong.Value = 1;
        }

       

        private void cbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal giamGia = 0;

            if (cbLoaiKH.Text == "Khách Lẻ")
                giamGia = 0.00m;
            else if (cbLoaiKH.Text == "Thường")
                giamGia = 0.05m;
            else if (cbLoaiKH.Text == "VIP")
                giamGia = 0.10m;

            // Hiển thị ra textbox theo %
            txtGiamGia.Text = (giamGia * 100).ToString("0") + "%";

            // Nếu bạn muốn cập nhật lại toàn bộ lưới (khi đổi loại KH)
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;

                decimal donGia = decimal.Parse(row.Cells["DonGia"].Value.ToString(), NumberStyles.Currency, vn);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal tongThanhTien = donGia * soLuong;
                decimal tienGiam = tongThanhTien * giamGia;
                decimal tongSauGiam = tongThanhTien - tienGiam;

                row.Cells["TienGiamGia"].Value = string.Format(vn, "{0:C0}", tienGiam);
                row.Cells["TongSauGiam"].Value = string.Format(vn, "{0:C0}", tongSauGiam);
            }
        }

        private void CapNhatLaiGiamGia()
        {
            if (dgvChiTiet.Rows.Count == 0) return;

            DataRowView drv = (DataRowView)cbLoaiKH.SelectedItem;
            decimal giamGia = Convert.ToDecimal(drv["GiamGia"]);

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;
                decimal donGia = decimal.Parse(row.Cells["Đơn giá"].Value.ToString(), NumberStyles.Currency, new CultureInfo("vi-VN"));
                int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);
                decimal thanhTien = donGia * soLuong * (1 - giamGia);

                row.Cells["Giảm giá"].Value = (giamGia * 100).ToString("0") + " %";
                row.Cells["Thành tiền"].Value = thanhTien.ToString("c0", new CultureInfo("vi-VN"));
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = hoaDonBus.TaoMaHoaDonMoi();
                string maNV = LoginUI.currentMaNV;
                string maKH = txtMaKH.Text.Trim();

                decimal tongThanhTien = 0; // Tổng tiền gốc (chưa giảm)
                decimal tongSauGiam = 0;   // Tổng tiền sau giảm

                //  Xác định phần trăm giảm theo loại KH
                decimal giamGiaHoaDon = 0;

                if (cbLoaiKH.SelectedItem is DataRowView drv)
                {
                    giamGiaHoaDon = Convert.ToDecimal(drv["GiamGia"]);
                }


                // Tính tổng tiền
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;

                    tongThanhTien += decimal.Parse(row.Cells["TongThanhTien"].Value.ToString(), NumberStyles.Currency, vn);
                    tongSauGiam += decimal.Parse(row.Cells["TongSauGiam"].Value.ToString(), NumberStyles.Currency, vn);
                }

                string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        // Kiểm tra khách hàng tồn tại chưa
                        SqlCommand checkKH = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG WHERE MaKH=@MaKH", conn, tran);
                        checkKH.Parameters.AddWithValue("@MaKH", maKH);
                        int count = (int)checkKH.ExecuteScalar();

                        if (count == 0)
                        {
                            // Nếu chưa có, thêm khách hàng mới
                            SqlCommand insertKH = new SqlCommand(@"
                        INSERT INTO KHACHHANG (MaKH, HoTen, GioiTinh, DienThoai, DiaChi, NgayDangKy, MaLoaiKH, TenLoaiKH)
                        VALUES (@MaKH, @HoTen, 1, '', '', GETDATE(), @MaLoaiKH, @TenLoaiKH)", conn, tran);

                            insertKH.Parameters.AddWithValue("@MaKH", maKH);
                            insertKH.Parameters.AddWithValue("@HoTen", string.IsNullOrEmpty(txtTenKH.Text) ? "Khách lẻ" : txtTenKH.Text);

                            string maLoaiKH = "LKH01";
                            if (cbLoaiKH.Text == "Thường") maLoaiKH = "LKH02";
                            else if (cbLoaiKH.Text == "VIP") maLoaiKH = "LKH03";

                            insertKH.Parameters.AddWithValue("@MaLoaiKH", maLoaiKH);
                            insertKH.Parameters.AddWithValue("@TenLoaiKH", cbLoaiKH.Text);
                            insertKH.ExecuteNonQuery();
                        }

                        //  Thêm HÓA ĐƠN                      
                        SqlCommand cmdHD = new SqlCommand("sp_Insert_HoaDon", conn, tran);
                        cmdHD.CommandType = CommandType.StoredProcedure;
                        cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                        cmdHD.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                        cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                        cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                        cmdHD.Parameters.AddWithValue("@TongTien", tongThanhTien); // tổng gốc
                        cmdHD.Parameters.AddWithValue("@GiamGia", giamGiaHoaDon);   // phần trăm (0.05)
                        cmdHD.Parameters.AddWithValue("@ThanhTien", tongSauGiam);   // tổng sau giảm
                        cmdHD.ExecuteNonQuery();

                        // Thêm CHI TIẾT HÓA ĐƠN
                        foreach (DataGridViewRow row in dgvChiTiet.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string maGiay = row.Cells["MaGiay"].Value.ToString();
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            decimal donGia = decimal.Parse(row.Cells["DonGia"].Value.ToString(), NumberStyles.Currency, vn);
                            decimal tongSauGiamItem = decimal.Parse(row.Cells["TongSauGiam"].Value.ToString(), NumberStyles.Currency, vn);


                            SqlCommand cmdCT = new SqlCommand("sp_Insert_CTHoaDon", conn, tran);
                            cmdCT.CommandType = CommandType.StoredProcedure;
                            cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                            cmdCT.Parameters.AddWithValue("@MaGiay", maGiay);
                            cmdCT.Parameters.AddWithValue("@SoLuongBan", soLuong);
                            cmdCT.Parameters.AddWithValue("@DonGiaBan", donGia);
                            cmdCT.Parameters.AddWithValue("@GiamGia", giamGiaHoaDon); // phần trăm
                            cmdCT.Parameters.AddWithValue("@ThanhTienBan", tongSauGiamItem);
                            cmdCT.ExecuteNonQuery();

                            //  Trừ tồn kho
                            SqlCommand cmdTru = new SqlCommand("UPDATE GIAY SET SoLuongTon = SoLuongTon - @SL WHERE MaGiay = @MaGiay", conn, tran);
                            cmdTru.Parameters.AddWithValue("@SL", soLuong);
                            cmdTru.Parameters.AddWithValue("@MaGiay", maGiay);
                            cmdTru.ExecuteNonQuery();
                        }

                        //  Hoàn tất giao dịch
                        tran.Commit();
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //  Reset form
                        dgvChiTiet.Rows.Clear();
                        txtSanPham.Clear();
                        txtDonGia.Clear();
                        txtTenKH.Clear();
                        txtSoHoaDon.Text = hoaDonBus.TaoMaHoaDonMoi();
                        txtMaKH.Text = hoaDonBus.TaoMaKhachHangMoi();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private string selectedMaGiay = ""; // biến toàn cục ở đầu class
        private void dgvSanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Lưu lại mã giày thật để dùng khi thêm
                selectedMaGiay = row.Cells["MaGiay"].Value.ToString();

                // Hiển thị tên giày xuống textbox
                txtSanPham.Text = row.Cells["TenGiay"].Value.ToString();

                // Hiển thị đơn giá bán
                decimal donGiaBan = Convert.ToDecimal(row.Cells["DonGiaBan"].Value);
                txtDonGia.Text = string.Format(vn, "{0:C0}", donGiaBan);

                numSoLuong.Value = 1;
            }
        }
    }
}
