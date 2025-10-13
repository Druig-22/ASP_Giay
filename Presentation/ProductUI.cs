using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace Presentation
{
    public partial class ProductUI : Form
    {
        ProductBUS bus = new ProductBUS();

        public ProductUI()
        {
            InitializeComponent();
        }

        private void ProductUI_Load(object sender, EventArgs e)
        {
            dgvProduct.DataSource = bus.GetData();
        }
    }
}
