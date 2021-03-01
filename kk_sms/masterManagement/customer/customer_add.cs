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

namespace kk_sms.masterManagement.customer
{
    public partial class customer_add : Form
    {
        public customer_add()
        {
            InitializeComponent();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string customer_no = textBox_customer_no.Text;
            string customer_name = textBox_customer_name.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(customer_no))
                {
                    //MessageBox.Show("番号を入力してください。");
                    label_description.Text = "番号を入力してください。";
                    flag = false;
                }
                else if (!customer_no.All(char.IsDigit))
                {
                    label_description.Text = "番号を入力してください。";
                }
                if (String.IsNullOrEmpty(customer_name))
                {
                    //MessageBox.Show("名前を入力します。");
                    label_description.Text = "名前を入力します。";
                    flag = false;
                }
                if (flag)
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino = " + customer_no;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "この番号のデータは既　保存済みです。";
                    }
                    else
                    {
                        string que = "INSERT INTO m_tokuisaki(tokuisakino, tokuisakiname) VALUES('" + customer_no + "','" + customer_name + "')";
                        MySqlCommand sqlorder = new MySqlCommand(que, mysqlConnection);
                        MySqlDataReader mySqlDataReader = sqlorder.ExecuteReader();
                        mysqlConnection.Close();
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

        private void no_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_customer_name;
            }
        }

        private void name_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = button_save;
            }
        }
    }
}
