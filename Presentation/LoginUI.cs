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
        UserBUS bus = new UserBUS();
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

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = bus.Login(username, password);
            if (success)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
    }
}
