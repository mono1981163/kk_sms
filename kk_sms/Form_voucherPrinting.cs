using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk_sms
{
    public partial class Form_voucherPrinting : Form
    {
        public Form_voucherPrinting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.voucherPrinting.Form_selectDate_1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.voucherPrinting.Form_selectDate_2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.voucherPrinting.Form_selectDate_3();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
