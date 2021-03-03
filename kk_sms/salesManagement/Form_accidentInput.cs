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
    public partial class Form_accidentInput : Form
    {
        public Form_accidentInput()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text.EndsWith("。") || textBox1.Text.EndsWith("．") || textBox1.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!textBox1.Text.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (textBox1.Text == "")
            {

            }
            
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && (int.Parse(textBox1.Text) < 900 || int.Parse(textBox1.Text) > 999))
            {
                label48.Text = "伝票番号900以上の数値を入力しないでください！";
                textBox1.Text = "";
                this.ActiveControl = textBox1;
            }
            if (textBox1.Text.All(char.IsDigit))
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT orderno FROM tbl_hanbai WHERE orderno = '" + textBox1.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label48.Text = "入力さわた伝票番号は既にあります";
                        textBox1.Focus();
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox2.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_accidentGoods(this);
                form_dialog.ShowDialog();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                label6.Text = "";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT hinmei FROM m_hinban WHERE hinban = '" + textBox2.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label6.Text = result.ToString();
                    }
                    else
                    {
                        label6.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (label6.Text == "" && textBox2.Text != "")
            {
                textBox2.Text = "-";
            }
        }

        public void textChange2(string param)
        {
            textBox2.Text = param;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox3.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_accidentGrade(this);
                form_dialog.ShowDialog();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                label9.Text = "";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT toukyuname FROM m_tokyu WHERE toukyuno = '" + textBox3.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label9.Text = result.ToString();
                    }
                    else
                    {
                        label9.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            if (label9.Text == "" && textBox3.Text != "")
            {
                textBox3.Text = "-";
            }
        }

        public void textChange3(string param)
        {
            textBox3.Text = param;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox4.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_accidentClass(this);
                form_dialog.ShowDialog();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                label10.Text = "";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT kaikyuname FROM m_kaikyu WHERE kaikyuno = '" + textBox4.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label10.Text = result.ToString();
                    }
                    else
                    {
                        label10.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }
        private void textBox4_LostFocus(object sender, EventArgs e)
        {
            if (label10.Text == "" && textBox4.Text != "")
            {
                textBox4.Text = "-";
            }
        }

        public void textChange4(string param)
        {
            textBox4.Text = param;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox5.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_accidentUser(this);
                form_dialog.ShowDialog();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                label13.Text = "";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT login_name FROM m_user WHERE user_id = '" + textBox5.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label13.Text = result.ToString();
                    }
                    else
                    {
                        label13.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }
        private void textBox5_LostFocus(object sender, EventArgs e)
        {
            if (label13.Text == "" && textBox5.Text != "")
            {
                textBox5.Text = "-";
            }
        }

        public void textChange5(string param)
        {
            textBox5.Text = param;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox9.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_accidentCustomer(this);
                form_dialog.ShowDialog();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                label22.Text = "";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino = '" + textBox9.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label22.Text = result.ToString();
                    }
                    else
                    {
                        label22.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }
        private void textBox9_LostFocus(object sender, EventArgs e)
        {
            if (label22.Text == "" && textBox9.Text != "")
            {
                textBox9.Text = "-";
            }
        }

        public void textChange9(string param)
        {
            textBox9.Text = param;
        }
    }
}
