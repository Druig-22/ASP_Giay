namespace Presentation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar5 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.bthdnhap = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar8 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar7 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.btnDanhSachHangHoa = new DevComponents.DotNetBar.ButtonItem();
            this.btnLoaiHang_Click = new DevComponents.DotNetBar.ButtonItem();
            this.tabHoaDon = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.tabMain = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabGioiThieu = new DevComponents.DotNetBar.TabItem(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ctmnMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đóngTrangNàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.ctmnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabHoaDon,
            this.ribbonTabItem2});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(1087, 154);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar5);
            this.ribbonPanel1.Controls.Add(this.ribbonBar4);
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1087, 98);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar5
            // 
            this.ribbonBar5.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar5.ContainerControlProcessDialogKey = true;
            this.ribbonBar5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar5.DragDropSupport = true;
            this.ribbonBar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem9});
            this.ribbonBar5.Location = new System.Drawing.Point(645, 0);
            this.ribbonBar5.Name = "ribbonBar5";
            this.ribbonBar5.Size = new System.Drawing.Size(100, 95);
            this.ribbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar5.TabIndex = 5;
            this.ribbonBar5.Text = "Tổng Lợi Nhuận";
            // 
            // 
            // 
            this.ribbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem9
            // 
            this.buttonItem9.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem9.HoverImage")));
            this.buttonItem9.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.SubItemsExpandWidth = 14;
            this.buttonItem9.Text = "<div width=\"80\" align=\"center\">Tổng Lợi Nhuận\r\n <br/> </div>";
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem8});
            this.ribbonBar4.Location = new System.Drawing.Point(545, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(100, 95);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 4;
            this.ribbonBar4.Text = "Tổng Chi Phí";
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem8
            // 
            this.buttonItem8.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem8.HoverImage")));
            this.buttonItem8.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.SubItemsExpandWidth = 14;
            this.buttonItem8.Text = "<div width=\"80\" align=\"center\">Tổng Chi Tiết  <br/> </div>";
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem6,
            this.buttonItem7});
            this.ribbonBar3.Location = new System.Drawing.Point(365, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(180, 95);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 3;
            this.ribbonBar3.Text = "Tổng Nhập Bán";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem6
            // 
            this.buttonItem6.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem6.HoverImage")));
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.SubItemsExpandWidth = 14;
            this.buttonItem6.Text = "<div width=\"80\" align=\"center\">Tổng Nhập <br/> </div>";
            // 
            // buttonItem7
            // 
            this.buttonItem7.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem7.HoverImage")));
            this.buttonItem7.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem7.Image")));
            this.buttonItem7.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Text = "<div width=\"80\" align=\"center\">Tổng Bán  <br/> </div>";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem4,
            this.buttonItem5});
            this.ribbonBar2.Location = new System.Drawing.Point(179, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(186, 95);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 2;
            this.ribbonBar2.Text = "Danh Sách Phiếu";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem4
            // 
            this.buttonItem4.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem4.HoverImage")));
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.TopLeft;
            this.buttonItem4.SubItemsExpandWidth = 14;
            this.buttonItem4.Text = "<div width=\"80\" align=\"center\">Danh Sách Phiếu Nhập Hàng <br/> </div>";
            // 
            // buttonItem5
            // 
            this.buttonItem5.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem5.HoverImage")));
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.SubItemsExpandWidth = 14;
            this.buttonItem5.Text = "<div width=\"80\" align=\"center\">Danh Sách Phiếu Bán Hàng <br/> </div>";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.bthdnhap,
            this.buttonItem2});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(176, 95);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Hoá Đơn Nhập";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // bthdnhap
            // 
            this.bthdnhap.HoverImage = ((System.Drawing.Image)(resources.GetObject("bthdnhap.HoverImage")));
            this.bthdnhap.Image = ((System.Drawing.Image)(resources.GetObject("bthdnhap.Image")));
            this.bthdnhap.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.bthdnhap.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.bthdnhap.Name = "bthdnhap";
            this.bthdnhap.SubItemsExpandWidth = 14;
            this.bthdnhap.Text = "<div width=\"80\" align=\"center\"> Hoá Đơn Nhập Hàng <br/> </div>";
            // 
            // buttonItem2
            // 
            this.buttonItem2.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem2.HoverImage")));
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "<div width=\"80\" align=\"center\"> Hoá Đơn Bán Hàng <br/> </div>";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar8);
            this.ribbonPanel2.Controls.Add(this.ribbonBar7);
            this.ribbonPanel2.Controls.Add(this.ribbonBar6);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1087, 98);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar8
            // 
            this.ribbonBar8.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar8.ContainerControlProcessDialogKey = true;
            this.ribbonBar8.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar8.DragDropSupport = true;
            this.ribbonBar8.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem12});
            this.ribbonBar8.Location = new System.Drawing.Point(496, 0);
            this.ribbonBar8.Name = "ribbonBar8";
            this.ribbonBar8.Size = new System.Drawing.Size(114, 95);
            this.ribbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar8.TabIndex = 2;
            this.ribbonBar8.Text = "Quản Lý Nhân Viên";
            // 
            // 
            // 
            this.ribbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem12
            // 
            this.buttonItem12.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem12.HoverImage")));
            this.buttonItem12.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem12.Image")));
            this.buttonItem12.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonItem12.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.SubItemsExpandWidth = 14;
            this.buttonItem12.Text = "<div width=\"90\" align=\"center\"> Nhân Viên </div>";
            // 
            // ribbonBar7
            // 
            this.ribbonBar7.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar7.ContainerControlProcessDialogKey = true;
            this.ribbonBar7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar7.DragDropSupport = true;
            this.ribbonBar7.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem3,
            this.buttonItem10,
            this.buttonItem11});
            this.ribbonBar7.Location = new System.Drawing.Point(179, 0);
            this.ribbonBar7.Name = "ribbonBar7";
            this.ribbonBar7.Size = new System.Drawing.Size(317, 95);
            this.ribbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar7.TabIndex = 1;
            this.ribbonBar7.Text = "Nhà Cung Cấp";
            // 
            // 
            // 
            this.ribbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem3
            // 
            this.buttonItem3.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem3.HoverImage")));
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Text = "<div width=\"90\" align=\"center\"> Nhà Cung Cấp </div>";
            // 
            // buttonItem10
            // 
            this.buttonItem10.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem10.HoverImage")));
            this.buttonItem10.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem10.Image")));
            this.buttonItem10.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonItem10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.SubItemsExpandWidth = 14;
            this.buttonItem10.Text = "<div width=\"90\" align=\"center\"> Các Loại Khách Hàng</div>";
            // 
            // buttonItem11
            // 
            this.buttonItem11.HoverImage = ((System.Drawing.Image)(resources.GetObject("buttonItem11.HoverImage")));
            this.buttonItem11.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem11.Image")));
            this.buttonItem11.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonItem11.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem11.Name = "buttonItem11";
            this.buttonItem11.SubItemsExpandWidth = 14;
            this.buttonItem11.Text = "<div width=\"90\" align=\"center\"> Danh Sách Khách Hàng </div>";
            // 
            // ribbonBar6
            // 
            this.ribbonBar6.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar6.ContainerControlProcessDialogKey = true;
            this.ribbonBar6.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar6.DragDropSupport = true;
            this.ribbonBar6.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDanhSachHangHoa,
            this.btnLoaiHang_Click});
            this.ribbonBar6.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(176, 95);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 0;
            this.ribbonBar6.Text = "Hàng Hoá";
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnDanhSachHangHoa
            // 
            this.btnDanhSachHangHoa.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnDanhSachHangHoa.HoverImage")));
            this.btnDanhSachHangHoa.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachHangHoa.Image")));
            this.btnDanhSachHangHoa.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnDanhSachHangHoa.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDanhSachHangHoa.Name = "btnDanhSachHangHoa";
            this.btnDanhSachHangHoa.SubItemsExpandWidth = 14;
            this.btnDanhSachHangHoa.Text = "<div width=\"80\" align=\"center\">Danh Sách Sản Phẩm <br/> </div>";
            this.btnDanhSachHangHoa.Click += new System.EventHandler(this.btnDanhSachHangHoa_Click_1);
            // 
            // btnLoaiHang_Click
            // 
            this.btnLoaiHang_Click.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnLoaiHang_Click.HoverImage")));
            this.btnLoaiHang_Click.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiHang_Click.Image")));
            this.btnLoaiHang_Click.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.btnLoaiHang_Click.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLoaiHang_Click.Name = "btnLoaiHang_Click";
            this.btnLoaiHang_Click.SubItemsExpandWidth = 14;
            this.btnLoaiHang_Click.Text = "<div width=\"80\" align=\"center\">Các Loại Sản Phâm<br/> </div>";
            this.btnLoaiHang_Click.Click += new System.EventHandler(this.buttonItem9_Click);
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Checked = true;
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Panel = this.ribbonPanel1;
            this.tabHoaDon.Text = "Hoá Đơn";
            this.tabHoaDon.Click += new System.EventHandler(this.tabHoaDon_Click);
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "Danh Mục";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Quản Lý Giày";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.tabMain.CanReorderTabs = true;
            this.tabMain.CloseButtonOnTabsVisible = true;
            this.tabMain.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabMain.Controls.Add(this.tabControlPanel1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(5, 155);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabFont = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1087, 356);
            this.tabMain.TabIndex = 1;
            this.tabMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabMain.Tabs.Add(this.tabGioiThieu);
            this.tabMain.Text = "tabControl1";
            this.tabMain.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabMain_TabItemClose);
            this.tabMain.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1087, 330);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabGioiThieu;
            this.tabControlPanel1.Click += new System.EventHandler(this.tabControlPanel1_Click);
            // 
            // tabGioiThieu
            // 
            this.tabGioiThieu.AttachedControl = this.tabControlPanel1;
            this.tabGioiThieu.Name = "tabGioiThieu";
            this.tabGioiThieu.Text = "Giới thiệu";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // ctmnMain
            // 
            this.ctmnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đóngTrangNàyToolStripMenuItem,
            this.mnCloseOther,
            this.mnCloseAll});
            this.ctmnMain.Name = "ctmnMain";
            this.ctmnMain.Size = new System.Drawing.Size(213, 82);
            this.ctmnMain.Opening += new System.ComponentModel.CancelEventHandler(this.ctmnMain_Opening);
            // 
            // đóngTrangNàyToolStripMenuItem
            // 
            this.đóngTrangNàyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đóngTrangNàyToolStripMenuItem.Image")));
            this.đóngTrangNàyToolStripMenuItem.Name = "đóngTrangNàyToolStripMenuItem";
            this.đóngTrangNàyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.đóngTrangNàyToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.đóngTrangNàyToolStripMenuItem.Text = "Đóng trang này";
            this.đóngTrangNàyToolStripMenuItem.Click += new System.EventHandler(this.đóngTrangNàyToolStripMenuItem_Click);
            // 
            // mnCloseOther
            // 
            this.mnCloseOther.Image = ((System.Drawing.Image)(resources.GetObject("mnCloseOther.Image")));
            this.mnCloseOther.Name = "mnCloseOther";
            this.mnCloseOther.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mnCloseOther.Size = new System.Drawing.Size(212, 26);
            this.mnCloseOther.Text = "Đóng các trang khác";
            this.mnCloseOther.Click += new System.EventHandler(this.mnCloseOther_Click);
            // 
            // mnCloseAll
            // 
            this.mnCloseAll.Image = ((System.Drawing.Image)(resources.GetObject("mnCloseAll.Image")));
            this.mnCloseAll.Name = "mnCloseAll";
            this.mnCloseAll.Size = new System.Drawing.Size(212, 26);
            this.mnCloseAll.Text = "Đóng tất cả";
            this.mnCloseAll.Click += new System.EventHandler(this.mnCloseAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 513);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.t_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ctmnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem tabHoaDon;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.ButtonItem bthdnhap;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.TabControl tabMain;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabGioiThieu;
        private DevComponents.DotNetBar.RibbonBar ribbonBar5;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.RibbonBar ribbonBar8;
        private DevComponents.DotNetBar.RibbonBar ribbonBar7;
        private DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.ButtonItem btnDanhSachHangHoa;
        private DevComponents.DotNetBar.ButtonItem btnLoaiHang_Click;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private DevComponents.DotNetBar.ButtonItem buttonItem11;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ContextMenuStrip ctmnMain;
        private System.Windows.Forms.ToolStripMenuItem đóngTrangNàyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnCloseOther;
        private System.Windows.Forms.ToolStripMenuItem mnCloseAll;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
    }
}