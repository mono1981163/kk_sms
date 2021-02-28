using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk_sms.masterManagement
{
    public partial class Form_supplier : Form
    {
        public Form_supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.supplier.supplier_add();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.supplier.supplier_delete();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.supplier.supplier_list();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
