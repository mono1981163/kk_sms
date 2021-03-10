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

namespace kk_sms.masterManagement.grade
{
    public partial class grade_add : Form
    {
        public grade_add()
        {
            InitializeComponent();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string grade_no = textBox_grade_no.Text;
            string grade_name = textBox_grade_name.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(grade_no))
                {
                    //MessageBox.Show("番号を入力してください。");
                    label_description.Text = "番号を入力してください。";
                    flag = false;
                }
                else if (!grade_no.All(char.IsDigit))
                {
                    label_description.Text = "番号を入力してください。";
                }
                if (String.IsNullOrEmpty(grade_name))
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
                    string query = "SELECT toukyuname FROM m_tokyu WHERE toukyuno = " + grade_no;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "この番号のデータは既　保存済みです。";
                    }
                    else
                    {
                        string que = "INSERT INTO m_tokyu(toukyuno, toukyuname) VALUES('" + grade_no + "','" + grade_name + "')";
                        MySqlCommand sqlorder = new MySqlCommand(que, mysqlConnection);
                        var res = sqlorder.ExecuteReader();
                        if (res.RecordsAffected > 0)
                        {
                            label_description.Text = "正常に保存されました。";
                            textBox_grade_no.Clear();
                            textBox_grade_name.Clear();
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
                this.ActiveControl = textBox_grade_name;
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
