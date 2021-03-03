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
            initData();
        }

        private void initData()
        {
            m_price = 0;
            m_saleamount = 0;
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            label6.Text = "";
            label9.Text = "";
            label10.Text = "";
            label13.Text = "";
            label22.Text = "";
            label23.Text = "";
            label29.Text = "";
        }

        private void Form_accidentInput_Load(object sender, EventArgs e)
        {

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
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "-" && (int.Parse(textBox1.Text) < 900 || int.Parse(textBox1.Text) > 999))
            {
                label48.Text = "伝票番号900以上の数値を入力しないでください！";
                textBox1.Focus();
            }
            else if (textBox1.Text.All(char.IsDigit))
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
                    else
                    {
                        label48.Text = "";
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

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            if(textBox2.Text =="")
            {
                label48.Text = "[-]でー覧入力できます，[.]で終了ボタンへ";

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

        private void textBox3_GotFocus(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                label48.Text = "[-]でー覧入力できます，[.]で終了ボタンへ";

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

        private void textBox4_GotFocus(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                label48.Text = "[-]でー覧入力できます，[.]で終了ボタンへ";

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

        private void textBox5_GotFocus(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                label48.Text = "[-]でー覧入力できます，[.]で終了ボタンへ";

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

        private void textBox9_GotFocus(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                label48.Text = "[-]でー覧入力できます，[.]で終了ボタンへ";

            }
        }

        public void textChange9(string param)
        {
            textBox9.Text = param;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "1")
            {
                label23.Text = "売上";
            }
            else if (textBox10.Text == "2")
            {
                label23.Text = "値引";
            }
            else if (textBox2.Text == "")
            {
                label23.Text = "";
            }
            else
            {
                label23.Text = "";
                label48.Text = "区分コードには[1]または[2]を入力してくださ";
            }
        }

        private void textBox10_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "区分コード [1]：売上 [2]：返品";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                m_saleamount = 0;
            }
            else if (!textBox11.Text.All(char.IsDigit))
            {
                button2.Focus();
                m_saleamount = 0;
            }
            else
            {
                m_saleamount = int.Parse(textBox11.Text);
            }

            label29.Text = (m_saleamount * m_price).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                m_price = 0;
            }
            else if (!textBox12.Text.All(char.IsDigit))
            {
                button2.Focus();
                m_price = 0;
            }
            else
            {
                m_price = int.Parse(textBox12.Text);
            }

            label29.Text = (m_saleamount * m_price).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int irisu = 0;
            string nisugataname = "";
            int serialno = 0;
            bool fff = false;
            if (textBox1.Text != "")
            {
                fff = true;
            }
            if (textBox2.Text != "")
            {
                fff = true;
            }
            if (textBox3.Text != "")
            {
                fff = true;
            }
            if (textBox4.Text != "")
            {
                fff = true;
            }
            if (textBox5.Text != "")
            {
                fff = true;
            }
            if (textBox6.Text != "")
            {
                fff = true;
            }
            if (textBox7.Text != "")
            {
                fff = true;
            }
            if (textBox8.Text != "")
            {
                fff = true;
            }
            if (textBox9.Text != "")
            {
                fff = true;
            }
            if (textBox10.Text != "")
            {
                fff = true;
            }
            if (textBox11.Text != "")
            {
                fff = true;
            }
            if (textBox12.Text != "")
            {
                fff = true;
            }
            if (fff == true)
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT irisu, nisugataname FROM tbl_nyuko WHERE hinban = '" + textBox2.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            irisu = result.GetInt32(0);
                            nisugataname = result.GetString(1);
                        }
                    }
                    mysqlConnection.Close();
                    mysqlConnection.Open();
                    query = "SELECT MAX(serialno)+1 FROM tbl_hanbai";
                    sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result1 = sqlCommand.ExecuteScalar();
                    if (result1 != null)
                    {
                        serialno = int.Parse(result1.ToString());
                    }
                    mysqlConnection.Close();
                    mysqlConnection.Open();
                    query = "INSERT INTO tbl_hanbai (orderno, hday, syainno, tokuisakino, tokuisakiname, hinban, hinmei, toukyuno, toukyuname, kaikyuno, kaikyuname, irisu, nisugataname, hanbaisu, tanka, kingaku, kubun, saleskubun, accrualdate, serialno, ipflag) VALUES ('";
                    query = query + textBox1.Text + "', '";
                    query = query + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '";
                    query = query + textBox5.Text + "', '";
                    query = query + textBox9.Text + "', '";
                    query = query + label22.Text + "', '";
                    query = query + textBox2.Text + "', '";
                    query = query + label6.Text + "', '";
                    query = query + textBox3.Text + "', '";
                    query = query + label9.Text + "', '";
                    query = query + textBox4.Text + "', '";
                    query = query + label10.Text + "', '";
                    query = query + irisu + "', '";
                    query = query + nisugataname + "', '";
                    query = query + m_saleamount + "', '";
                    query = query + m_price + "', '";
                    query = query + label29.Text + "', '";
                    query = query + textBox10.Text + "', '";
                    query = query + "', '";
                    query = query + textBox6.Text + "-" + textBox7.Text + "-" + textBox8.Text + " 00:00:00" +"', '";
                    query = query + serialno + "', '";
                    query = query + "');";
                    sqlCommand = new MySqlCommand(query, mysqlConnection);
                    result1 = sqlCommand.ExecuteScalar();
                    mysqlConnection.Close();
                    initData();
                    clear();
                    label48.Text = "データがセーブされました";
                }
                catch
                {

                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_LostFocus(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                
            }
            else if (!textBox6.Text.All(char.IsDigit))
            {
                label48.Text = "年の値が正しくありません";
                textBox6.Focus();
            }
            else
            {
                if (int.Parse(textBox6.Text) < 2000)
                {
                    label48.Text = "年の値が正しくありません";
                    textBox6.Focus();
                }
                else
                {
                    label48.Text = "";
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_GotFocus(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Focus();
            }
        }

        private void textBox7_LostFocus(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {

            }
            else if (!textBox7.Text.All(char.IsDigit))
            {
                label48.Text = "月の値が正しくありません";
                textBox7.Focus();
            }
            else
            {
                if (int.Parse(textBox7.Text) < 1 || int.Parse(textBox7.Text) > 12)
                {
                    label48.Text = "月の値が正しくありません";
                    textBox7.Focus();
                }
                else
                {
                    label48.Text = "";
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_GotFocus(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Focus();
            }
        }

        private void textBox8_LostFocus(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {

            }
            else if (!textBox8.Text.All(char.IsDigit))
            {
                label48.Text = "日の値が正しくありません";
                textBox8.Focus();
            }
            else
            {
                int month = int.Parse(textBox7.Text);
                switch (month)
                {
                    case 1:
                        if(int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 2:
                        if (int.Parse(textBox6.Text) % 4 == 0)
                        {
                            if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 29)
                            {
                                label48.Text = "日の値が正しくありません";
                                textBox8.Focus();
                            }
                            else
                            {
                                label48.Text = "";
                            }
                        }
                        else
                        {
                            if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 28)
                            {
                                label48.Text = "日の値が正しくありません";
                                textBox8.Focus();
                            }
                            else
                            {
                                label48.Text = "";
                            }
                        }
                        break;
                    case 3:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 4:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 30)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 5:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 6:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 30)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 7:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 8:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 9:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 30)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 10:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 11:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 30)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                    case 12:
                        if (int.Parse(textBox8.Text) < 1 || int.Parse(textBox8.Text) > 31)
                        {
                            label48.Text = "日の値が正しくありません";
                            textBox8.Focus();
                        }
                        else
                        {
                            label48.Text = "";
                        }
                        break;
                }
            }
        }

        private void textBox1_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox2;
            }
        }

        private void textBox2_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox3;
            }
        }

        private void textBox3_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox4;
            }
        }

        private void textBox4_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox5;
            }
        }

        private void textBox5_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox6;
            }
        }

        private void textBox6_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox7;
            }
        }

        private void textBox7_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox8;
            }
        }

        private void textBox8_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox9;
            }
        }

        private void textBox9_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox10;
            }
        }

        private void textBox10_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox11;
            }
        }

        private void textBox11_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox12;
            }
        }

        private void textBox12_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = button1;
            }
        }
    }
}
