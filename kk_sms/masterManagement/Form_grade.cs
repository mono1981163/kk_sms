﻿using System;
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
    public partial class Form_grade : Form
    {
        public Form_grade()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.grade.grade_add();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.grade.grade_delete();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            var form = new kk_sms.masterManagement.grade.grade_list();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
