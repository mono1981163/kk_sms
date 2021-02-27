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
using System.Configuration;

namespace kk_sms.masterManagement.supplier
{
    public partial class supplier_add : Form
    {
        public supplier_add()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string supplier_no = textBox_supplier_no.Text;
            string supplier_name = textBox_supplier_name.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(supplier_no))
                {
                    MessageBox.Show("番号を入力してください。");
                    flag = false;
                }
                if (String.IsNullOrEmpty(supplier_name))
                {
                    MessageBox.Show("名前を入力します。");
                    flag = false;

                }
                if (flag)
                {
                    string mysqlConf = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "INSERT INTO m_siire(siireno, siirename, createday) VALUES('" + supplier_no + "','" + supplier_name + "', '" + DateTime.Now + "')";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    mysqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
