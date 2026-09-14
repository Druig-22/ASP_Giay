using DevComponents.DotNetBar;
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
    public partial class Form1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            buttonItem7.Click += btnTongBan_Click; // Gắn sự kiện click
            buttonItem8.Click += btnChiPhi_Click; // Gắn sự kiện click
            buttonItem9.Click += btnLoiNhuan_Click; // Gắn sự kiện click
        }

        private void btnLoiNhuan_Click(object sender, EventArgs e)
        {
            TongLoiNhuanUI frm = new TongLoiNhuanUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            TabItem tab = tabMain.CreateTab("Tổng lợi nhuận");
            tab.AttachedControl.Controls.Add(frm);
            frm.Show();
        }

        private void btnChiPhi_Click(object sender, EventArgs e)
        {
            TongChiPhiUI frm = new TongChiPhiUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            TabItem tab = tabMain.CreateTab("Tổng chi phí");
            tab.AttachedControl.Controls.Add(frm);
            frm.Show();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            // Khởi tạo TabControl
            tabMain = new DevComponents.DotNetBar.TabControl();
            tabMain.Dock = DockStyle.Fill;
            tabMain.CanReorderTabs = true;
            tabMain.CloseButtonOnTabsVisible = true; 
            tabMain.Style = eTabStripStyle.Office2007Document;

            // Thêm vào form
            this.Controls.Add(tabMain);
        }

        private void tabHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void t_Load(object sender, EventArgs e)
        {
            tabMain.ContextMenuStrip = ctmnMain;

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
        }

        private void btnDanhSachHangHoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra nếu tab đã mở
            foreach (DevComponents.DotNetBar.TabItem tab in tabMain.Tabs)
            {
                if (tab.Text == "Danh Sách Sản Phẩm")
                {
                    tabMain.SelectedTab = tab;
                    return;
                }
            }

            // Tạo form ProductUI
            ProductUI frm = new ProductUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            // Tạo panel và tab item
            DevComponents.DotNetBar.TabControlPanel panel = new DevComponents.DotNetBar.TabControlPanel();
            DevComponents.DotNetBar.TabItem tabItem = new DevComponents.DotNetBar.TabItem(); 

            panel.Dock = DockStyle.Fill;
            panel.TabItem = tabItem;
            panel.Controls.Add(frm);

            tabItem.AttachedControl = panel;
            tabItem.Text = "Danh Sách Sản Phẩm";

            // Thêm vào TabControl
            tabMain.Controls.Add(panel);
            tabMain.Tabs.Add(tabItem);
            tabMain.SelectedTab = tabItem;
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tab đã tồn tại chưa (tránh mở trùng)
            foreach (DevComponents.DotNetBar.TabItem tab in tabMain.Tabs)
            {
                if (tab.Text == "Các Loại Sản Phẩm")
                {
                    tabMain.SelectedTab = tab; // Chuyển đến tab đó
                    return;
                }
            }

            // Tạo form con
            CategoryUI frm = new CategoryUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            // Tạo panel container cho form
            DevComponents.DotNetBar.TabControlPanel panel = new DevComponents.DotNetBar.TabControlPanel();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(frm);

            // Tạo tab mới
            DevComponents.DotNetBar.TabItem tabItem = new DevComponents.DotNetBar.TabItem();
            tabItem.Text = "Các Loại Sản Phẩm";
            tabItem.AttachedControl = panel;

            // Gắn tab và panel vào SuperTabControl
            tabMain.Controls.Add(panel);
            tabMain.Tabs.Add(tabItem);

            // Chuyển sang tab mới
            tabMain.SelectedTab = tabItem;
        }

       
        

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tab đã mở chưa
            foreach (DevComponents.DotNetBar.TabItem tab in tabMain.Tabs)
            {
                if (tab.Text == "Hóa đơn bán hàng")
                {
                    tabMain.SelectedTab = tab; // Chuyển sang tab đó
                    return;
                }
            }

            // Tạo form con
            HoaDonUI frm = new HoaDonUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            // Tạo panel chứa form
            DevComponents.DotNetBar.TabControlPanel panel = new DevComponents.DotNetBar.TabControlPanel();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(frm);

            // Tạo tab mới
            DevComponents.DotNetBar.TabItem tabItem = new DevComponents.DotNetBar.TabItem();
            tabItem.Text = "Hóa Đơn Bán Hàng";
            tabItem.AttachedControl = panel;

            // Gắn panel và tab vào SuperTabControl
            tabMain.Controls.Add(panel);
            tabMain.Tabs.Add(tabItem);

            // Hiển thị tab mới
            tabMain.SelectedTab = tabItem;
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu tab đã mở rồi thì chỉ cần chọn lại
            foreach (DevComponents.DotNetBar.TabItem tab in tabMain.Tabs)
            {
                if (tab.Text == "Danh sách phiếu bán hàng")
                {
                    tabMain.SelectedTab = tab;
                    return;
                }
            }

            // Tạo form con
            ListHoaDonUI frm = new ListHoaDonUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            // Tạo panel chứa form
            DevComponents.DotNetBar.TabControlPanel panel = new DevComponents.DotNetBar.TabControlPanel();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(frm);

            // Tạo tab mới
            DevComponents.DotNetBar.TabItem tabItem = new DevComponents.DotNetBar.TabItem();
            tabItem.Text = "Danh Sách Phiếu Bán Hàng";
            tabItem.AttachedControl = panel;

            // Gắn tab và panel vào SuperTabControl
            tabMain.Controls.Add(panel);
            tabMain.Tabs.Add(tabItem);

            // Hiển thị tab vừa thêm
            tabMain.SelectedTab = tabItem;
        }

        private void CloseThis()
        {
            TabItem selectedTab = tabMain.SelectedTab;
            if (MessageBox.Show("Bạn có muốn xoá trang này không: \"" + selectedTab.Text + "\"?",
             "Xác nhận!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.Yes)
                //if (tabMain.SelectedTabIndex != 0) 
                if (selectedTab.Name != tabGioiThieu.Name)
                    tabMain.Tabs.Remove(selectedTab);
        }
        private void đóngTrangNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseThis();
        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            CloseThis();
        }

        private void ctmnMain_Opening(object sender, CancelEventArgs e)
        {
            bool isShow = (tabMain.SelectedTabIndex == 0) ? false : true;
            đóngTrangNàyToolStripMenuItem.Enabled = isShow;
        }

        private void mnCloseOther_Click(object sender, EventArgs e)
        {
            TabItem selectedTab = tabMain.SelectedTab;
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                if (index != i)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void mnCloseAll_Click(object sender, EventArgs e)
        {
            TabItem selectedTab = tabMain.SelectedTab;
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }
        private void btnTongBan_Click(object sender, EventArgs e)
        {
            TongBanUI frm = new TongBanUI();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            TabItem tab = tabMain.CreateTab("Tổng doanh thu");
            tab.AttachedControl.Controls.Add(frm);
            frm.Show();
        }
    }
}
