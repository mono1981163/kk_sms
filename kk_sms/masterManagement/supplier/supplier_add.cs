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
                    //MessageBox.Show("番号を入力してください。");
                    label_description.Text = "番号を入力してください。";
                    flag = false;
                }
                else if (!supplier_no.All(char.IsDigit))
                {
                    label_description.Text = "番号を入力してください。";
                }
                if (String.IsNullOrEmpty(supplier_name))
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
                    string query = "SELECT siirename FROM m_siire WHERE siireno = " + supplier_no;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "この番号のデータは既　保存済みです。";
                    } else
                    {
                        string que = "INSERT INTO m_siire(siireno, siirename, createday) VALUES('" + supplier_no + "','" + supplier_name + "', '" + DateTime.Now + "')";
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
                this.ActiveControl = textBox_supplier_name;
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
