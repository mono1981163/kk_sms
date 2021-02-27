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
    public partial class Form_mainmenu : Form
    {
        public Form_mainmenu()
        {
            InitializeComponent();
        }

        private void Form_mainmenu_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            label_date.Text = date;
            this.ActiveControl = button_dailyPretreatment;
        }

        private void Button_dailyPretreatment_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "日時更新メニューへ移ります";
        }

        private void Button_purchaseManagement_Click(object sender, EventArgs e)
        {
            var form = new Form_purchaseManagement();
            form.Show();
        }

        private void Button_purchaseManagement_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "仕入管理メニューへ移ります";
        }

        private void Button_salesManagement_Click(object sender, EventArgs e)
        {
            var form = new Form_salesManagement();
            form.Show();
        }
        private void Button_salesManagement_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "売上管理メニューへ移ります";
        }


        private void Button_inventoryManagement_Click(object sender, EventArgs e)
        {
            var form = new Form_inventoryManagement();
            form.Show();
        }

        private void Button_inventoryManagement_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "在庫管理メニューへ移ります";
        }

        private void Button_dailyReportPrinting_Click(object sender, EventArgs e)
        {
            var form = new Form_dailyReportPrinting();
            form.Show();
        }

        private void Button_dailyReportPrinting_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "日報印刷メニューへ移ります";
        }

        private void Button_voucherPrinting_Click(object sender, EventArgs e)
        {
            var form = new Form_voucherPrinting();
            form.Show();
        }

        private void Button_voucherPrinting_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "伝票印刷メニューへ移ります";
        }

        private void Button_monthlyProcessing_Click(object sender, EventArgs e)
        {
            var form = new Form_monthlyProcessing();
            form.Show();
        }

        private void Button_monthlyProcessing_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "月次処理メニューへ移ります";
        }

        private void Button_masterManagement_Click(object sender, EventArgs e)
        {
            var form = new Form_masterManagement();
            form.Show();
        }

        private void Button_masterManagement_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "データベース管理メニューへ移ります";
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Button_exit_GotFocus(object sender, EventArgs e)
        {
            label_currentButton.Text = "本システムを終了します";
        }

    }
}
