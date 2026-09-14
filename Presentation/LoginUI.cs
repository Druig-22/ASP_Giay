using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class LoginUI : Form
    {

        public static string currentMaNV = "";
        public static string currentTenNV = "";


        UserBUS userBus = new UserBUS();
        public LoginUI()
        {
            InitializeComponent();
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            var result = userBus.Login(username, password);

            if (result != null)
            {
                currentMaNV = result.Value.MaNV;
                currentTenNV = result.Value.HoTen;

                // Mở form chính
                this.Hide();
                Form1 main = new Form1();
                main.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
