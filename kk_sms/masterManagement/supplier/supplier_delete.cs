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
    public partial class supplier_delete : Form
    {
        public supplier_delete()
        {
            InitializeComponent();
        }
        private void button_delete_Click(object sender, EventArgs e)
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
                    MessageBox.Show("削除してよろしいですか", "削除―確認", MessageBoxButtons.OKCancel);
                    if (MessageBox.Show("削除してよろしいですか", "削除―確認", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    {
                        string mysqlConf = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                        var mysqlConnection = new MySqlConnection(mysqlConf);
                        mysqlConnection.Open();
                        string query = "DELETE FROM m_siire WHERE siireno='" + supplier_no + "' AND siirename='" + supplier_name + "'";
                        MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                        MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                        mysqlConnection.Close();
                        this.Close();
                    }
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

        private void supplier_delete_Load(object sender, EventArgs e)
        {
            label_description.Text = "[ - ] で一覧入力できます、[ . ] で終了ボタンへ";
        }
    }
}
