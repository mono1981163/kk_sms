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
    public partial class Form_dailyReportPrinting : Form
    {
        public Form_dailyReportPrinting()
        {
            InitializeComponent();
        }

        private void Form_dailyReportPrinting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate3();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate4();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate5();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.dailyReportPrinting.Form_selectDate6();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
