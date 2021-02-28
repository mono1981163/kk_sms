using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk_sms.salesManagement
{
    public partial class Form_salesSlipCorrection : Form
    {
        public Form_salesSlipCorrection()
        {
            InitializeComponent();
        }

        private void Form_salesSlipCorrection_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            this.label_date.Text = today;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
