using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IniParser;
using IniParser.Model;

namespace kk_sms.salesManagement
{
    public partial class Form_slipInputSearch : Form
    {
        private Form_salesSlipInput parentForm;

        public Form_slipInputSearch(Form_salesSlipInput parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_slipInputSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
