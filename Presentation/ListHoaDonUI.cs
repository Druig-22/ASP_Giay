using BUS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentation
{
    public partial class ListHoaDonUI : Form
    {
        HoaDonBUS hoaDonBus = new HoaDonBUS();
        CTHoaDonBUS ctBus = new CTHoaDonBUS();
        CultureInfo vn = new CultureInfo("vi-VN");
        public ListHoaDonUI()
        {
            InitializeComponent();
        }

        private void ListHoaDonUI_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }

        private void LoadDanhSachHoaDon()
        {
            dgvHoaDon.DataSource = hoaDonBus.GetAll();

            // Ẩn toàn bộ cột trước
            foreach (DataGridViewColumn col in dgvHoaDon.Columns)
                col.Visible = false;

            // Hiển thị các cột cần thiết
            if (dgvHoaDon.Columns.Contains("MaHD"))
            {
                dgvHoaDon.Columns["MaHD"].Visible = true;
                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            }

            if (dgvHoaDon.Columns.Contains("NgayLap"))
            {
                dgvHoaDon.Columns["NgayLap"].Visible = true;
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvHoaDon.Columns.Contains("TenNV"))
            {
                dgvHoaDon.Columns["TenNV"].Visible = true;
                dgvHoaDon.Columns["TenNV"].HeaderText = "Tên nhân viên";
            }

            if (dgvHoaDon.Columns.Contains("TenKH"))
            {
                dgvHoaDon.Columns["TenKH"].Visible = true;
                dgvHoaDon.Columns["TenKH"].HeaderText = "Tên khách hàng";
            }

            if (dgvHoaDon.Columns.Contains("TongTien"))
            {
                dgvHoaDon.Columns["TongTien"].Visible = true;
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền trước giảm (VNĐ)";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "c0";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.FormatProvider = vn;
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("GiamGia"))
            {
                dgvHoaDon.Columns["GiamGia"].Visible = true;
                dgvHoaDon.Columns["GiamGia"].HeaderText = "Giảm giá (%)";
                dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Format = "P0"; // Hiển thị 5% thay vì 0.05
                dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("ThanhTienSauGiam"))
            {
                dgvHoaDon.Columns["ThanhTienSauGiam"].Visible = true;
                dgvHoaDon.Columns["ThanhTienSauGiam"].HeaderText = "Thành tiền sau giảm (VNĐ)";
                dgvHoaDon.Columns["ThanhTienSauGiam"].DefaultCellStyle.Format = "c0";
                dgvHoaDon.Columns["ThanhTienSauGiam"].DefaultCellStyle.FormatProvider = vn;
                dgvHoaDon.Columns["ThanhTienSauGiam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("ThanhTien"))
            {
                dgvHoaDon.Columns["ThanhTien"].Visible = true;
                dgvHoaDon.Columns["ThanhTien"].HeaderText = "Tổng tiền sau giảm (VNĐ)";
                dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "c0";
                dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.FormatProvider = vn;
                dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Cấu hình giao diện
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.RowHeadersVisible = false;

            // Gán sự kiện click
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maHD = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                LoadChiTiet(maHD);
            }
        }



        private void LoadChiTiet(string maHD)
        {
            dgvCTHoaDon.DataSource = ctBus.GetByMaHD(maHD);

            // Ẩn toàn bộ cột trước
            foreach (DataGridViewColumn col in dgvCTHoaDon.Columns)
                col.Visible = false;

            // Hiển thị các cột cần thiết
            if (dgvCTHoaDon.Columns.Contains("MaGiay"))
            {
                dgvCTHoaDon.Columns["MaGiay"].Visible = true;
                dgvCTHoaDon.Columns["MaGiay"].HeaderText = "Mã hàng hóa";
            }

            if (dgvCTHoaDon.Columns.Contains("TenGiay"))
            {
                dgvCTHoaDon.Columns["TenGiay"].Visible = true;
                dgvCTHoaDon.Columns["TenGiay"].HeaderText = "Tên hàng hóa";
            }

            if (dgvCTHoaDon.Columns.Contains("SoLuongBan"))
            {
                dgvCTHoaDon.Columns["SoLuongBan"].Visible = true;
                dgvCTHoaDon.Columns["SoLuongBan"].HeaderText = "Số lượng";
                dgvCTHoaDon.Columns["SoLuongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvCTHoaDon.Columns.Contains("DonGiaBan"))
            {
                dgvCTHoaDon.Columns["DonGiaBan"].Visible = true;
                dgvCTHoaDon.Columns["DonGiaBan"].HeaderText = "Đơn giá (VNĐ)";
                dgvCTHoaDon.Columns["DonGiaBan"].DefaultCellStyle.Format = "c0";
                dgvCTHoaDon.Columns["DonGiaBan"].DefaultCellStyle.FormatProvider = vn;
                dgvCTHoaDon.Columns["DonGiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCTHoaDon.Columns.Contains("TienGiam"))
            {
                dgvCTHoaDon.Columns["TienGiam"].Visible = true;
                dgvCTHoaDon.Columns["TienGiam"].HeaderText = "Tiền giảm (VNĐ)";
                dgvCTHoaDon.Columns["TienGiam"].DefaultCellStyle.Format = "c0";
                dgvCTHoaDon.Columns["TienGiam"].DefaultCellStyle.FormatProvider = vn;
                dgvCTHoaDon.Columns["TienGiam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCTHoaDon.Columns.Contains("ThanhTienBan"))
            {
                dgvCTHoaDon.Columns["ThanhTienBan"].Visible = true;
                dgvCTHoaDon.Columns["ThanhTienBan"].HeaderText = "Thành tiền sau giảm (VNĐ)";
                dgvCTHoaDon.Columns["ThanhTienBan"].DefaultCellStyle.Format = "c0";
                dgvCTHoaDon.Columns["ThanhTienBan"].DefaultCellStyle.FormatProvider = vn;
                dgvCTHoaDon.Columns["ThanhTienBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Giao diện DataGridView
            dgvCTHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCTHoaDon.ReadOnly = true;
            dgvCTHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTHoaDon.RowHeadersVisible = false;
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maHD = dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString();
            string pdfPath = XuatHoaDonPDF(maHD);

            if (pdfPath != null && File.Exists(pdfPath))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true // mở bằng app PDF mặc định
                };
                Process.Start(psi);
            }
            else
            {
                MessageBox.Show("Không thể mở file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string XuatHoaDonPDF(string maHD)
        {
            DataTable dt = GetChiTietHoaDon(maHD);
            if (dt.Rows.Count == 0) return null;

            string filePath = Path.Combine(Application.StartupPath, $"HoaDon_{maHD}.pdf");
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Font Unicode 
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var fTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
            var fHeader = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
            var fText = new iTextSharp.text.Font(bf, 10);
            var fBold = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            var fItalic = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);

            //  KHUNG VIỀN 
            iTextSharp.text.Rectangle border = new iTextSharp.text.Rectangle(doc.PageSize);
            border.Left += doc.LeftMargin - 15;
            border.Right -= doc.RightMargin - 15;
            border.Top -= doc.TopMargin - 10;
            border.Bottom += doc.BottomMargin - 10;
            border.BorderWidth = 1f;
            border.BorderColor = BaseColor.LIGHT_GRAY;
            border.Border = iTextSharp.text.Rectangle.BOX;
            writer.DirectContentUnder.Rectangle(border);

            // THÊM LOGO CĂN GIỮA 
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "Logo_shop.png"); // tên file logo
                if (File.Exists(logoPath))
                {
                    byte[] imgBytes = File.ReadAllBytes(logoPath);
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imgBytes);

                    // ---- Căn giữa và chỉnh kích thước logo ----
                    logo.Alignment = Element.ALIGN_CENTER;  // căn giữa
                    logo.ScaleAbsolute(80, 80);             // kích thước logo (80x80 px)
                    logo.SpacingAfter = 10;                 // khoảng cách dưới logo

                    doc.Add(logo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chèn logo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Paragraph shopName = new Paragraph("LUXURY SHOP\n", new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD));
            shopName.Alignment = Element.ALIGN_CENTER;
            doc.Add(shopName);

            Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG\n\n", fTitle);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            DataRow info = dt.Rows[0];
            Paragraph date = new Paragraph($"Ngày {Convert.ToDateTime(info["NgayLap"]).Day} tháng {Convert.ToDateTime(info["NgayLap"]).Month} năm {Convert.ToDateTime(info["NgayLap"]).Year}\n\n", fText);
            date.Alignment = Element.ALIGN_CENTER;
            doc.Add(date);

            // THÔNG TIN NGƯỜI BÁN / NGƯỜI MUA — TRÁI & PHẢI 
            PdfPTable infoTable = new PdfPTable(2);
            infoTable.WidthPercentage = 100;
            infoTable.SetWidths(new float[] { 50, 50 });

            //  BÊN TRÁI: NGƯỜI BÁN 
            PdfPCell leftCell = new PdfPCell();
            leftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            leftCell.HorizontalAlignment = Element.ALIGN_LEFT;

            leftCell.AddElement(new Phrase("Đơn vị bán hàng: LUXURY SHOP", fBold));
            leftCell.AddElement(new Phrase("Địa chỉ: 65 Nguyễn Văn Linh, phường Tân Thuận, TP.HCM", fText));
            leftCell.AddElement(new Phrase("Điện thoại: 0909 123 456", fText));
            leftCell.AddElement(new Phrase("Người bán hàng: " + info["NhanVien"].ToString(), fText));

            //  BÊN PHẢI: NGƯỜI MUA 
            PdfPCell rightCell = new PdfPCell();
            rightCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            rightCell.HorizontalAlignment = Element.ALIGN_RIGHT; //  canh phải

            rightCell.AddElement(new Phrase("Người mua hàng: " + info["KhachHang"].ToString(), fBold));
            rightCell.AddElement(new Phrase("Hình thức thanh toán: TM/CK", fText));
            rightCell.AddElement(new Phrase("Mã hóa đơn: " + info["MaHD"].ToString(), fText));

            infoTable.AddCell(leftCell);
            infoTable.AddCell(rightCell);

            infoTable.SpacingAfter = 10;
            doc.Add(infoTable);

            //  BẢNG CHI TIẾT 
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 6, 30, 10, 15, 10, 15 });

            string[] headers = { "STT", "Tên giày", "SL", "Đơn giá", "Giảm giá", "Thành tiền" };
            foreach (string h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, fHeader))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5,
                    BackgroundColor = new BaseColor(230, 230, 250)
                };
                table.AddCell(cell);
            }

            int stt = 1;
            foreach (DataRow row in dt.Rows)
            {
                table.AddCell(new PdfPCell(new Phrase(stt.ToString(), fText)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(row["TenGiay"].ToString(), fText)));
                table.AddCell(new PdfPCell(new Phrase(row["SoLuongBan"].ToString(), fText)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(string.Format("{0:#,##0}", row["DonGiaBan"]), fText)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(string.Format("{0:P0}", row["GiamGia"]), fText)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(string.Format("{0:#,##0}", row["ThanhTien"]), fText)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                stt++;
            }
            doc.Add(table);

            //  TỔNG CỘNG 
            decimal tong = dt.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
            PdfPTable total = new PdfPTable(2);
            total.WidthPercentage = 60;
            total.HorizontalAlignment = Element.ALIGN_RIGHT;
            total.SpacingBefore = 5;
            total.SetWidths(new float[] { 50, 50 });

            total.AddCell(new PdfPCell(new Phrase("Tổng cộng thanh toán:", fBold))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER
            });
            total.AddCell(new PdfPCell(new Phrase($"{tong:#,##0 VNĐ}", fBold))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });
            doc.Add(total);

            //  SỐ TIỀN BẰNG CHỮ 
            Paragraph byText = new Paragraph($"\nSố tiền viết bằng chữ: {NumberToText((long)tong)} đồng.\n\n", fItalic);
            byText.Alignment = Element.ALIGN_LEFT;
            doc.Add(byText);

            //  CHỮ KÝ 
            PdfPTable sign = new PdfPTable(2);
            sign.WidthPercentage = 100;
            sign.SpacingBefore = 30;
            sign.SetWidths(new float[] { 50, 50 });

            sign.AddCell(new PdfPCell(new Phrase("Người mua hàng\n\n(Ký, ghi rõ họ tên)", fText))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 25
            });
            sign.AddCell(new PdfPCell(new Phrase("Người bán hàng\n\n(Ký, ghi rõ họ tên)", fText))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 25
            });
            doc.Add(sign);
            //  FOOTER CỐ ĐỊNH Ở CUỐI TRANG 
            PdfContentByte cb = writer.DirectContent;
            ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER,
                new Phrase("(Cần kiểm tra, đối chiếu trước khi lập, giao, nhận hóa đơn)", fItalic),
                doc.PageSize.Width / 2, 60, 0); // y = 60 là khoảng cách từ đáy trang

            ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER,
                new Phrase("Cảm ơn quý khách đã tin tưởng và ủng hộ shop!", fItalic),
                doc.PageSize.Width / 2, 45, 0);

            ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER,
                new Phrase($"Thời gian in: {DateTime.Now:HH:mm:ss - dd/MM/yyyy}", fItalic),
                doc.PageSize.Width / 2, 30, 0);
            doc.Close();
            return filePath;
        }

        //  CHUYỂN SỐ THÀNH CHỮ 
        private string NumberToText(long number)
        {
            if (number == 0) return "Không";
            string[] dv = { "", "nghìn", "triệu", "tỷ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string s = number.ToString();
            string result = "";
            int i = 0;
            while (s.Length > 0)
            {
                int donvi = int.Parse(s.Substring(Math.Max(0, s.Length - 3)));
                s = s.Substring(0, Math.Max(0, s.Length - 3));
                string block = "";
                int tram = donvi / 100;
                int chuc = (donvi / 10) % 10;
                int dvi = donvi % 10;
                if (donvi > 0)
                {
                    if (tram > 0) block += cs[tram] + " trăm ";
                    if (chuc > 1)
                    {
                        block += cs[chuc] + " mươi ";
                        if (dvi == 1) block += "mốt ";
                        else if (dvi == 5) block += "lăm ";
                        else if (dvi > 0) block += cs[dvi] + " ";
                    }
                    else if (chuc == 1)
                    {
                        block += "mười ";
                        if (dvi == 1) block += "một ";
                        else if (dvi == 5) block += "lăm ";
                        else if (dvi > 0) block += cs[dvi] + " ";
                    }
                    else if (chuc == 0 && dvi > 0)
                    {
                        if (tram > 0) block += "linh ";
                        block += cs[dvi] + " ";
                    }
                    block += dv[i] + " ";
                }
                result = block + result;
                i++;
            }
            return char.ToUpper(result[0]) + result.Substring(1).Trim();
        }

        private DataTable GetChiTietHoaDon(string maHD)
        {
            string query = "SELECT * FROM v_HoaDonChiTiet WHERE MaHD = @MaHD";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maHD = dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString();
            string pdfPath = XuatHoaDonPDF(maHD);

            if (pdfPath != null && File.Exists(pdfPath))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true,
                    Verb = "print"
                };
                Process.Start(psi);
            }
            else
            {
                MessageBox.Show("Không thể in file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
