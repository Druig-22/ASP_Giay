using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy form Login trước
            LoginUI login = new LoginUI();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1()); // Mở form chính sau khi login thành công
            }
        }
    }
}
