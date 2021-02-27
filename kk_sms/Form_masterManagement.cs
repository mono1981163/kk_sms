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
    public partial class Form_masterManagement : Form
    {
        public Form_masterManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_supplier();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_payment();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_customer();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_product();
            form.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_grade();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_class();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_employee();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new kk_sms.masterManagement.Form_consumption_tax();
            form.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {

        }
    }
}
