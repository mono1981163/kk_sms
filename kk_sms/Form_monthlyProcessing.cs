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
    public partial class Form_monthlyProcessing : Form
    {
        public Form_monthlyProcessing()
        {
            InitializeComponent();
        }

        private void Form_monthlyProcessing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new kk_sms.monthlyProcessing.Form_selectDate_m_1();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
