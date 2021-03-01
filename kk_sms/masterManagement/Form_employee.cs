using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk_sms.masterManagement
{
    public partial class Form_employee : Form
    {
        public Form_employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.employee.employee_add();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.employee.employee_delete();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.employee.employee_list();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
