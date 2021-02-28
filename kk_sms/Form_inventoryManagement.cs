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
    public partial class Form_inventoryManagement : Form
    {
        public Form_inventoryManagement()
        {
            InitializeComponent();
        }

        private void Form_inventoryManagement_Load(object sender, EventArgs e)
        {

        }
        private void button_input_GotFocus(object sender, EventArgs e)
        {
            label_description.Text = "在庫品仕入担当変更に移ります";
        }

        private void button_printTable_GotFocus(object sender, EventArgs e)
        {
            label_description.Text = "";
        }

        private void button_changePurchaser_GotFocus(object sender, EventArgs e)
        {
            label_description.Text = "在庫調整数入力に移ります";
        }


        private void button_exit_GotFocus(object sender, EventArgs e)
        {
            label_description.Text = "";
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.inventoryManagement.Form_SelectPerson();
            form.Show();
        }

        private void button_printTable_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.inventoryManagement.Form_ProductPrinting();
            form.Show();
        }

        private void button_changePurchaser_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.inventoryManagement.Form_ChangePurchaser();
            form.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
