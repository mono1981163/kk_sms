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
    public partial class Form_accidentCorrection : Form
    {
        public Form_accidentCorrection()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_accidentCorrection_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧表示から選択できます";
        }
    }
}
