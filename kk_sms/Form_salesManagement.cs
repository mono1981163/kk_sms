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
    public partial class Form_salesManagement : Form
    {
        public Form_salesManagement()
        {
            InitializeComponent();
        }

        private void Form_salesManagement_Load(object sender, EventArgs e)
        {

        }

        private void button_input_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.salesManagement.Form_salesSlipInput();
            form.Show();
            this.Close();
        }

        private void button_correct_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.salesManagement.Form_salesSlipCorrection();
            form.Show();
            this.Close();
        }

        private void button_inputAccident_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.salesManagement.Form_accidentInput();
            form.Show();
            this.Close();
        }

        private void button_correctAccident_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.salesManagement.Form_accidentCorrection();
            form.Show();
            this.Close();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
