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
    public partial class TongBanUI : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
        CultureInfo vn = new CultureInfo("vi-VN");
        public TongBanUI()
        {
            InitializeComponent();
        }

        private void TongBanUI_Load(object sender, EventArgs e)
        {
            //  Đặt định dạng hiển thị cho DateTimePicker 
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            //  Gán giá trị mặc định: 7 ngày gần nhất 
            dtpDenNgay.Value = DateTime.Today;
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);

            //  Tự động load dữ liệu ban đầu 
            LoadTongBan(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
        }

        private void cbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }


        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadTongBan(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
        }

        private void LoadTongBan(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_TongBanTheoNgay", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTongBan.DataSource = dt;

                    // --- Định dạng cột ngày lập ---
                    if (dgvTongBan.Columns.Contains("Ngày lập"))
                    {
                        dgvTongBan.Columns["Ngày lập"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvTongBan.Columns["Ngày lập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // --- Định dạng VNĐ ---
                    if (dgvTongBan.Columns.Contains("Đơn giá bán"))
                    {
                        dgvTongBan.Columns["Đơn giá bán"].DefaultCellStyle.Format = "c0";
                        dgvTongBan.Columns["Đơn giá bán"].DefaultCellStyle.FormatProvider = vn;
                        dgvTongBan.Columns["Đơn giá bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dgvTongBan.Columns.Contains("Thành tiền bán"))
                    {
                        dgvTongBan.Columns["Thành tiền bán"].DefaultCellStyle.Format = "c0";
                        dgvTongBan.Columns["Thành tiền bán"].DefaultCellStyle.FormatProvider = vn;
                        dgvTongBan.Columns["Thành tiền bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // --- Cấu hình DataGridView ---
                    dgvTongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTongBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvTongBan.MultiSelect = false;
                    dgvTongBan.ReadOnly = true;
                    dgvTongBan.RowHeadersVisible = false;

                    // --- Chọn dòng đầu tiên ---
                    if (dgvTongBan.Rows.Count > 0)
                    {
                        dgvTongBan.ClearSelection();
                        dgvTongBan.Rows[0].Selected = true;
                        dgvTongBan.CurrentCell = dgvTongBan.Rows[0].Cells[0];
                    }

                    // --- Tính tổng tiền ---
                    decimal tongTien = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Thành tiền bán"] != DBNull.Value)
                            tongTien += Convert.ToDecimal(row["Thành tiền bán"]);
                    }

                    lblTongTien.Text = "Tổng doanh thu: " + tongTien.ToString("N0", vn) + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string XuatTongBanPDF(DateTime tuNgay, DateTime denNgay, DataTable data)
        {
            string filePath = Path.Combine(Application.StartupPath, $"TongBan_{tuNgay:ddMMyyyy}_{denNgay:ddMMyyyy}.pdf");

            Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // --- Font tiếng Việt ---
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            var fTitle = new iTextSharp.text.Font(bf, 16f, iTextSharp.text.Font.BOLD);
            var fHeader = new iTextSharp.text.Font(bf, 11f, iTextSharp.text.Font.BOLD);
            var fText = new iTextSharp.text.Font(bf, 10f, iTextSharp.text.Font.NORMAL);
            var fItalic = new iTextSharp.text.Font(bf, 9f, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);

            // --- Tiêu đề ---
            Paragraph title = new Paragraph($"BÁO CÁO TỔNG DOANH THU\n\n", fTitle);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            Paragraph dateRange = new Paragraph($"Từ ngày {tuNgay:dd/MM/yyyy} đến ngày {denNgay:dd/MM/yyyy}\n\n", fText);
            dateRange.Alignment = Element.ALIGN_CENTER;
            doc.Add(dateRange);

            // --- Bảng dữ liệu ---
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 15, 15, 25, 10, 15, 20 });

            string[] headers = { "Ngày lập", "Mã giày", "Tên giày", "SL bán", "Đơn giá (VNĐ)", "Thành tiền bán (VNĐ)" };
            foreach (var h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, fHeader))
                {
                    BackgroundColor = new BaseColor(230, 230, 250),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5
                };
                table.AddCell(cell);
            }

            var vn = new CultureInfo("vi-VN");
            foreach (DataRow row in data.Rows)
            {
                string ngayText = row["Ngày lập"].ToString();
                string ngayHienThi = ngayText;

                // Cố gắng parse chính xác theo định dạng dd/MM/yyyy hoặc yyyy-MM-dd
                DateTime ngayValue;
                if (DateTime.TryParseExact(ngayText,
                                           new[] { "dd/MM/yyyy", "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss" },
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out ngayValue))
                {
                    ngayHienThi = ngayValue.ToString("dd/MM/yyyy");
                }

                table.AddCell(new Phrase(ngayHienThi, fText));
                table.AddCell(new Phrase(row["Mã giày"].ToString(), fText));
                table.AddCell(new Phrase(row["Tên giày"].ToString(), fText));
                table.AddCell(new Phrase(row["Số lượng bán"].ToString(), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", row["Đơn giá bán"]), fText));
                table.AddCell(new Phrase(string.Format(vn, "{0:c0}", row["Thành tiền bán"]), fText));
            }

            doc.Add(table);

            // --- Tổng doanh thu ---
            decimal tong = 0;
            foreach (DataRow row in data.Rows)
                tong += Convert.ToDecimal(row["Thành tiền bán"]);

            Paragraph total = new Paragraph($"\nTỔNG DOANH THU: {tong.ToString("c0", vn)}\n\n", fHeader);
            total.Alignment = Element.ALIGN_RIGHT;
            doc.Add(total);

            // --- Footer ---
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER,
                new Phrase($"Thời gian in: {DateTime.Now:HH:mm:ss dd/MM/yyyy}", fItalic),
                doc.PageSize.Width / 2, 30, 0);

            doc.Close();
            return filePath;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvTongBan.DataSource is DataTable data && data.Rows.Count > 0)
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string pdfPath = XuatTongBanPDF(tuNgay, denNgay, data);

                if (File.Exists(pdfPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = pdfPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Không thể mở file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvTongBan.DataSource is DataTable data && data.Rows.Count > 0)
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string pdfPath = XuatTongBanPDF(tuNgay, denNgay, data);

                if (File.Exists(pdfPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = pdfPath,
                        UseShellExecute = true,
                        Verb = "print"
                    });
                }
                else
                {
                    MessageBox.Show("Không thể in file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
