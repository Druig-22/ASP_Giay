    using iTextSharp.text; // font, paragraph, document...
    using iTextSharp.text.pdf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;

    namespace Presentation
    {
        public partial class TongLoiNhuanUI : Form
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            CultureInfo vn = new CultureInfo("vi-VN");
            public TongLoiNhuanUI()
            {
            
            InitializeComponent();
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        }
            private void TongLoiNhuan_Load(object sender, EventArgs e)
            {
                var format = new CultureInfo("vi-VN");
                format.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                format.DateTimeFormat.LongDatePattern = "dd/MM/yyyy";
                System.Threading.Thread.CurrentThread.CurrentCulture = format;
                System.Threading.Thread.CurrentThread.CurrentUICulture = format;

                dtpTuNgay.Format = DateTimePickerFormat.Custom;
                dtpTuNgay.CustomFormat = "dd/MM/yyyy";

                dtpDenNgay.Format = DateTimePickerFormat.Custom;
                dtpDenNgay.CustomFormat = "dd/MM/yyyy";

                dtpDenNgay.Value = DateTime.Today;
                dtpTuNgay.Value = DateTime.Today.AddDays(-7);

                LoadBaoCao(dtpTuNgay.Value, dtpDenNgay.Value);
             }

            private void LoadBaoCao(DateTime value1, DateTime value2)
            {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                    NgayLap AS [Ngày lập],
                    MaGiay AS [Mã giày],
                    TenGiay AS [Tên giày],
                    DoanhThu AS [Doanh thu],
                    ChiPhi AS [Chi phí],
                    (DoanhThu - ChiPhi) AS [Lợi nhuận]
                FROM v_BaoCaoDoanhThuTheoChiPhi
                    WHERE NgayLap >= @TuNgay AND NgayLap < DATEADD(DAY, 1, @DenNgay)
                    ORDER BY NgayLap DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                //  Sửa đúng cách truyền tham số
                da.SelectCommand.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = value1.Date;
                da.SelectCommand.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = value2.Date;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLoiNhuan.DataSource = dt;

                //  Định dạng cột ngày
                if (dgvLoiNhuan.Columns.Contains("Ngày lập"))
                {
                    dgvLoiNhuan.Columns["Ngày lập"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvLoiNhuan.Columns["Ngày lập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //  Định dạng cột tiền
                string[] colsTien = { "Đơn giá nhập", "Đơn giá bán", "Doanh thu", "Chi phí", "Lợi nhuận" };
                foreach (string col in colsTien)
                {
                    if (dgvLoiNhuan.Columns.Contains(col))
                    {
                        dgvLoiNhuan.Columns[col].DefaultCellStyle.Format = "c0";
                        dgvLoiNhuan.Columns[col].DefaultCellStyle.FormatProvider = vn;
                        dgvLoiNhuan.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                dgvLoiNhuan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLoiNhuan.ReadOnly = true;
                dgvLoiNhuan.RowHeadersVisible = false;
                dgvLoiNhuan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //  Tổng lợi nhuận
                decimal tongLoiNhuan = 0;
                foreach (DataRow row in dt.Rows)
                    tongLoiNhuan += Convert.ToDecimal(row["Lợi nhuận"]);

                lblLoiNhuan.Text = "Tổng lợi nhuận: " + tongLoiNhuan.ToString("N0", vn) + " VNĐ";
            }
        }
            private string XuatBaoCaoPDF(DateTime tuNgay, DateTime denNgay, DataTable data)
            {
                string filePath = Path.Combine(Application.StartupPath, $"BaoCaoLoiNhuan_{tuNgay:ddMMyyyy}_{denNgay:ddMMyyyy}.pdf");

                Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Font Unicode (Arial hỗ trợ tiếng Việt)
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var fTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                var fHeader = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                var fText = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                // Tiêu đề
                Paragraph title = new Paragraph("BÁO CÁO LỢI NHUẬN\n\n", fTitle);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph range = new Paragraph($"Từ ngày {tuNgay:dd/MM/yyyy} đến ngày {denNgay:dd/MM/yyyy}\n\n", fText);
                range.Alignment = Element.ALIGN_CENTER;
                doc.Add(range);

            // Tạo bảng dữ liệu
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 15, 15, 25, 15, 15, 15 });
            string[] headers = { "Ngày lập", "Mã giày", "Tên giày", "Doanh thu", "Chi phí", "Lợi nhuận" };

            foreach (string h in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(h, fHeader))
                    {
                        BackgroundColor = new BaseColor(230, 230, 250),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    table.AddCell(cell);
                }

                foreach (DataRow r in data.Rows)
                {
                table.AddCell(new Phrase(Convert.ToDateTime(r["Ngày lập"]).ToString("dd/MM/yyyy"), fText));
                table.AddCell(new Phrase(r["Mã giày"].ToString(), fText));
                table.AddCell(new Phrase(r["Tên giày"].ToString(), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", r["Doanh thu"]), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", r["Chi phí"]), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", r["Lợi nhuận"]), fText));

            }

            doc.Add(table);

                //  Chỉ tổng lợi nhuận
                decimal tongLoiNhuan = data.AsEnumerable().Sum(r => r.Field<decimal>("Lợi nhuận"));
                Paragraph total = new Paragraph($"\nTổng lợi nhuận: {tongLoiNhuan.ToString("N0", vn)} VNĐ", fHeader);
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                // Footer
                Paragraph footer = new Paragraph($"\nThời gian in: {DateTime.Now:HH:mm:ss dd/MM/yyyy}",
                    new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC, BaseColor.GRAY));
                footer.Alignment = Element.ALIGN_CENTER;
                doc.Add(footer);

                doc.Close();
                return filePath;
            }

            private void btnLoc_Click(object sender, EventArgs e)
            {
                LoadBaoCao(dtpTuNgay.Value, dtpDenNgay.Value);
            }

            private void btnIn_Click(object sender, EventArgs e)
            {
                if (dgvLoiNhuan.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    string pdf = XuatBaoCaoPDF(dtpTuNgay.Value, dtpDenNgay.Value, dt);
                    Process.Start(new ProcessStartInfo { FileName = pdf, UseShellExecute = true, Verb = "print" });
                }
            }

            private void btnXem_Click(object sender, EventArgs e)
            {
                if (dgvLoiNhuan.DataSource is DataTable dt && dt.Rows.Count > 0)
                {
                    string pdf = XuatBaoCaoPDF(dtpTuNgay.Value, dtpDenNgay.Value, dt);
                    Process.Start(new ProcessStartInfo { FileName = pdf, UseShellExecute = true });
                }
            }

            private void TongLoiNhuan_Load_1(object sender, EventArgs e)
            {

            }
        }
    }
