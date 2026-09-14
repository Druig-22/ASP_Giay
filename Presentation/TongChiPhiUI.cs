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
    public partial class TongChiPhiUI : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
        CultureInfo vn = new CultureInfo("vi-VN");
        public TongChiPhiUI()
        {
            InitializeComponent();
        }

        private void TongChiPhiUI_Load(object sender, EventArgs e)
        {
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
                DonGiaNhap AS [Đơn giá nhập],
                SoLuongBan AS [Số lượng bán],
                ChiPhi AS [Chi phí]
            FROM v_BaoCaoDoanhThuTheoChiPhi
            WHERE NgayLap >= @TuNgay AND NgayLap < DATEADD(DAY, 1, @DenNgay)
            ORDER BY NgayLap DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = value1.Date;
                da.SelectCommand.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = value2.Date;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiPhi.DataSource = dt;

                //  Format ngày lập
                if (dgvChiPhi.Columns.Contains("Ngày lập"))
                {
                    dgvChiPhi.Columns["Ngày lập"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvChiPhi.Columns["Ngày lập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //  Format tiền tệ VNĐ cho đơn giá & chi phí
                string[] colsTien = { "Đơn giá nhập", "Chi phí" };
                foreach (string col in colsTien)
                {
                    if (dgvChiPhi.Columns.Contains(col))
                    {
                        dgvChiPhi.Columns[col].DefaultCellStyle.Format = "c0";
                        dgvChiPhi.Columns[col].DefaultCellStyle.FormatProvider = vn;
                        dgvChiPhi.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                // Cấu hình hiển thị
                dgvChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvChiPhi.ReadOnly = true;
                dgvChiPhi.RowHeadersVisible = false;
                dgvChiPhi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //  Tính tổng chi phí (nếu bạn vẫn muốn hiển thị)
                decimal tongChiPhi = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongChiPhi += Convert.ToDecimal(row["Chi phí"]);
                }
                lblTongChiPhi.Text = "Tổng chi phí: " + tongChiPhi.ToString("N0", vn) + " VNĐ";

            }
        }
        private string XuatBaoCaoPDF(DateTime tuNgay, DateTime denNgay, DataTable data)
        {
            string filePath = Path.Combine(Application.StartupPath, $"BaoCaoChiPhi_{tuNgay:ddMMyyyy}_{denNgay:ddMMyyyy}.pdf");

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
            Paragraph title = new Paragraph("BÁO CÁO TỔNG CHI PHÍ\n\n", fTitle);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            Paragraph range = new Paragraph($"Từ ngày {tuNgay:dd/MM/yyyy} đến ngày {denNgay:dd/MM/yyyy}\n\n", fText);
            range.Alignment = Element.ALIGN_CENTER;
            doc.Add(range);

            // Bảng dữ liệu (6 cột)
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 13, 13, 22, 10, 15, 15 });

            string[] headers = { "Ngày lập", "Mã giày", "Tên giày", "Số lượng", "Đơn giá nhập", "Chi phí" };
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

            // Dữ liệu
            foreach (DataRow r in data.Rows)
            {
                table.AddCell(new Phrase(Convert.ToDateTime(r["Ngày lập"]).ToString("dd/MM/yyyy"), fText));
                table.AddCell(new Phrase(r["Mã giày"].ToString(), fText));
                table.AddCell(new Phrase(r["Tên giày"].ToString(), fText));
                table.AddCell(new Phrase(r["Số lượng bán"].ToString(), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", r["Đơn giá nhập"]), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", r["Chi phí"]), fText));
            }

            doc.Add(table);

            // Tổng chi phí
            decimal tongChiPhi = data.AsEnumerable().Sum(r => r.Field<decimal>("Chi phí"));
            Paragraph total = new Paragraph($"\nTổng chi phí: {tongChiPhi.ToString("N0", vn)} VNĐ", fHeader);
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
            if (dgvChiPhi.DataSource is DataTable dt && dt.Rows.Count > 0)
            {
                string pdf = XuatBaoCaoPDF(dtpTuNgay.Value, dtpDenNgay.Value, dt);
                Process.Start(new ProcessStartInfo { FileName = pdf, UseShellExecute = true, Verb = "print" });
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvChiPhi.DataSource is DataTable dt && dt.Rows.Count > 0)
            {
                string pdf = XuatBaoCaoPDF(dtpTuNgay.Value, dtpDenNgay.Value, dt);
                Process.Start(new ProcessStartInfo { FileName = pdf, UseShellExecute = true });
            }
        }
    }
}
