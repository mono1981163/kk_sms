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
    public partial class Form_purchaseManagement : Form
    {
        public Form_purchaseManagement()
        {
            InitializeComponent();
        }

        private void Form_purchaseManagement_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button_input;
        }

        private void Button_input_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.purchaseManagement.Form_input();
            form.Show();
        }

        private void Button_correct_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.purchaseManagement.Form_correct();
            form.Show();
        }

        private void Button_printTable_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.purchaseManagement.Form_printPurchase();
            form.Show();
        }

        private void Button_inputPurchaseSlip_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.purchaseManagement.Form_accident();
            form.Show();
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_exit_GotFocus(object sender, EventArgs e)
        {
            label_description.Text = "仕入メニューを終了します。";
        }

        private void Button_exit_LostFocus(object sender, EventArgs e)
        {
            label_description.Text = "";
        }
    }
}
