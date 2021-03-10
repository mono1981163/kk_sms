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

namespace kk_sms.masterManagement.group
{
    public partial class group_add : Form
    {
        public group_add()
        {
            InitializeComponent();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string class_no = textBox_class_no.Text;
            string class_name = textBox_class_name.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(class_no))
                {
                    //MessageBox.Show("番号を入力してください。");
                    label_description.Text = "番号を入力してください。";
                    flag = false;
                }
                else if (!class_no.All(char.IsDigit))
                {
                    label_description.Text = "番号を入力してください。";
                }
                if (String.IsNullOrEmpty(class_name))
                {
                    //MessageBox.Show("名前を入力します。");
                    label_description.Text = "名前を入力します。";
                    flag = false;
                }
                if (flag)
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT kaikyuname FROM m_kaikyu WHERE kaikyuno = " + class_no;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "この番号のデータは既　保存済みです。";
                    }
                    else
                    {
                        string que = "INSERT INTO m_kaikyu(kaikyuno, kaikyuname) VALUES('" + class_no + "','" + class_name + "')";
                        MySqlCommand sqlorder = new MySqlCommand(que, mysqlConnection);
                        var res = sqlorder.ExecuteReader();
                        if (res.RecordsAffected > 0)
                        {
                            label_description.Text = "正常に保存されました。";
                            textBox_class_no.Clear();
                            textBox_class_name.Clear();
                        }
                        else
                        {
                            label_description.Text = "エラーが発生しました。";
                        }
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
                this.ActiveControl = textBox_class_name;
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
