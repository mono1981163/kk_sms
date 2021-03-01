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
    public partial class Form_salesSlipInput : Form
    {
        public Form_salesSlipInput()
        {
            initData();
            InitializeComponent();
        }
        
        private void initData()
        {
            this.m_orderno = "";
            this.m_clientno = new int[8];
            this.m_clientname = new string[8];
            this.m_price = new int[8];
            this.m_totalprice = new int[8];
            this.m_saleamount = new int[8];
            this.m_stock = 0;
            this.m_totalsale = 0;
            this.m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                this.m_clientno[i] = 0;
                this.m_clientname[i] = "";
                this.m_price[i] = 0;
                this.m_totalprice[i] = 0;
                this.m_saleamount[i] = 0;
            }
        }

        private void Form_salesSlipInput_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            label_date.Text = today;
        }

        public void textChange(string param)
        {
            textBox1.Text = param;
        }

        public void textClientChange(string param)
        {
            if (textBox2.Text == "-")
            {
                textBox2.Text = param;
            }
            else if (textBox7.Text == "-")
            {
                textBox7.Text = param;
            }
            else if (textBox10.Text == "-")
            {
                textBox10.Text = param;
            }
            else if (textBox13.Text == "-")
            {
                textBox13.Text = param;
            }
            else if (textBox16.Text == "-")
            {
                textBox16.Text = param;
            }
            else if (textBox19.Text == "-")
            {
                textBox19.Text = param;
            }
            else if (textBox22.Text == "-")
            {
                textBox22.Text = param;
            }
            else if (textBox25.Text == "-")
            {
                textBox25.Text = param;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox1.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputSearch(this);
                form_dialog.Show();
            }
            else if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button3.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo=="")
            {
                label6.Text = "";
                label8.Text = "";
                label10.Text = "";
                label12.Text = "";
                label14.Text = "";
                label16.Text = "";
                label18.Text = "";
                label19.Text = "";
                label21.Text = "";
                label24.Text = "";
                label26.Text = "";
            }
            else
            {
                try
                {
                    m_orderno = slipNo;
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT H.tokuisakiname, N.syainname, N.hinmaei, N.toukyuname, N.kaikyuname, N.irisu, N.siiresu,N.nisugataname, N.tanka, N.zaikosu, N.souurisu FROM tbl_nyuko AS N INNER JOIN tbl_hanbai AS H ON N.orderno=H.orderno WHERE N.orderno = '" + m_orderno +  "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            label6.Text = result.GetString(0);
                            label8.Text = result.GetString(1);
                            label10.Text = result.GetString(2);
                            label12.Text = result.GetString(3);
                            label14.Text = result.GetString(4);
                            label16.Text = result.GetString(5);
                            label18.Text = result.GetString(6);
                            label19.Text = result.GetString(7);
                            label21.Text = result.GetString(8);
                            label24.Text = result.GetString(9);
                            label26.Text = result.GetString(10);
                            m_stock = result.GetInt32(9);
                            m_totalsale = result.GetInt32(10);
                        }
                    }
                    else
                    {
                        label6.Text = "";
                        label8.Text = "";
                        label10.Text = "";
                        label12.Text = "";
                        label14.Text = "";
                        label16.Text = "";
                        label18.Text = "";
                        label19.Text = "";
                        label21.Text = "";
                        label24.Text = "";
                        label26.Text = "";
                    }
                    mysqlConnection.Close();
                }
                catch
                {

                }
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

            private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox2.Text.EndsWith("。") || textBox2.Text.EndsWith("．") || textBox2.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox2.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox2.Text=="")
            {
                label32.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[0] = int.Parse(textBox2.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino ="+ m_clientno[0] +";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label32.Text = result.ToString();
                    }
                    else
                    {
                        label32.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label32.Text=="" && textBox2.Text != "")
            {
                textBox2.Text = "-";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox7.Text.EndsWith("。") || textBox7.Text.EndsWith("．") || textBox7.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox7.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox7.Text == "")
            {
                label35.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[1] = int.Parse(textBox7.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[1] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label35.Text = result.ToString();
                    }
                    else
                    {
                        label35.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox7_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox7_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label35.Text == "" && textBox7.Text != "")
            {
                textBox7.Text = "-";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox10.Text.EndsWith("。") || textBox10.Text.EndsWith("．") || textBox10.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox10.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox10.Text == "")
            {
                label37.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[2] = int.Parse(textBox10.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[2] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label37.Text = result.ToString();
                    }
                    else
                    {
                        label37.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox10_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox10_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label37.Text == "" && textBox10.Text != "")
            {
                textBox10.Text = "-";
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox13.Text.EndsWith("。") || textBox13.Text.EndsWith("．") || textBox13.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox13.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox13.Text == "")
            {
                label39.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[3] = int.Parse(textBox13.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[3] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label39.Text = result.ToString();
                    }
                    else
                    {
                        label39.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void textBox13_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox13_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label39.Text == "" && textBox13.Text != "")
            {
                textBox13.Text = "-";
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox16.Text.EndsWith("。") || textBox16.Text.EndsWith("．") || textBox16.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox16.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox16.Text == "")
            {
                label41.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[4] = int.Parse(textBox16.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[4] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label41.Text = result.ToString();
                    }
                    else
                    {
                        label41.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox16_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox16_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label41.Text == "" && textBox16.Text != "")
            {
                textBox16.Text = "-";
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox19.Text.EndsWith("。") || textBox19.Text.EndsWith("．") || textBox19.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox19.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox19.Text == "")
            {
                label43.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[5] = int.Parse(textBox19.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[5] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label43.Text = result.ToString();
                    }
                    else
                    {
                        label43.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox19_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox19_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label43.Text == "" && textBox19.Text != "")
            {
                textBox19.Text = "-";
            }
        }
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (textBox22.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox22.Text.EndsWith("。") || textBox22.Text.EndsWith("．") || textBox22.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox22.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox22.Text == "")
            {
                label45.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[6] = int.Parse(textBox22.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[6] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label45.Text = result.ToString();
                    }
                    else
                    {
                        label45.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox22_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox22_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label45.Text == "" && textBox22.Text != "")
            {
                textBox22.Text = "-";
            }
        }
        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            if (textBox25.Text == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipInputClient(this);
                form_dialog.Show();
                form_dialog.WindowState = FormWindowState.Normal;
                form_dialog.BringToFront();
                form_dialog.TopMost = true;
                form_dialog.Focus();
            }
            else if (textBox25.Text.EndsWith("。") || textBox25.Text.EndsWith("．") || textBox25.Text.EndsWith("."))
            {
                button3.Focus();
            }
            else if (textBox25.Text.EndsWith("/"))
            {
                button1.Focus();
            }
            else if (textBox25.Text == "")
            {
                label47.Text = "";
            }
            else
            {
                try
                {
                    m_clientno[7] = int.Parse(textBox25.Text);
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino =" + m_clientno[7] + ";";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label47.Text = result.ToString();
                    }
                    else
                    {
                        label47.Text = "";
                    }
                    mysqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox25_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox25_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
            if (label47.Text == "" && textBox25.Text != "")
            {
                textBox25.Text = "-";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                m_saleamount[0] = 0;
            }
            else if (textBox3.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[0] = int.Parse(textBox3.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[0] = 0;
            }
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[0];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox3.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                m_saleamount[1] = 0;
            }
            else if (textBox6.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[1] = int.Parse(textBox6.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[1] = 0;
            }
        }

        private void textBox6_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[1];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox6.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                m_saleamount[2] = 0;
            }
            else if (textBox9.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[2] = int.Parse(textBox9.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[2] = 0;
            }
        }

        private void textBox9_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[2];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox9.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                m_saleamount[3] = 0;
            }
            else if (textBox12.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[3] = int.Parse(textBox12.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[3] = 0;
            }
        }

        private void textBox12_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[3];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox12.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                m_saleamount[4] = 0;
            }
            else if (textBox15.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[4] = int.Parse(textBox15.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[4] = 0;
            }
        }
        private void textBox15_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[4];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox15.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                m_saleamount[5] = 0;
            }
            else if (textBox18.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[5] = int.Parse(textBox18.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[5] = 0;
            }
        }

        private void textBox18_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[5];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox18.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                m_saleamount[6] = 0;
            }
            else if (textBox21.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[6] = int.Parse(textBox21.Text);
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[6] = 0;
            }
        }

        private void textBox21_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[6];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox21.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text == "")
            {
                m_saleamount[7] = 0;
            }
            else if (textBox3.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount[7] = int.Parse(textBox24.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount[7] = 0;
            }
        }

        private void textBox24_LostFocus(object sender, EventArgs e)
        {
            m_salechange = 0;
            for (int i = 0; i < 8; i++)
            {
                m_salechange += m_saleamount[i];
            }
            if (label24.Text != "")
            {
                if (m_stock >= m_salechange)
                {
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                }
                else
                {
                    m_salechange -= m_saleamount[7];
                    label24.Text = (m_stock - m_salechange).ToString();
                    label26.Text = (m_totalsale + m_salechange).ToString();
                    textBox24.Text = "";
                    label48.Text = "在庫数が負になります。";
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                m_price[0] = 0;
            }
            else if (textBox4.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[0] = int.Parse(textBox4.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[0] = 0;
            }
        }

        private void textBox4_LostFocus(object sender, EventArgs e)
        {
            label33.Text = (m_saleamount[0] * m_price[0]).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                m_price[1] = 0;
            }
            else if (textBox5.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[1] = int.Parse(textBox5.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[1] = 0;
            }
        }

        private void textBox5_LostFocus(object sender, EventArgs e)
        {
            label34.Text = (m_saleamount[1] * m_price[1]).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                m_price[2] = 0;
            }
            else if (textBox8.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[2] = int.Parse(textBox8.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[2] = 0;
            }
        }

        private void textBox8_LostFocus(object sender, EventArgs e)
        {
            label36.Text = (m_saleamount[2] * m_price[2]).ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                m_price[3] = 0;
            }
            else if (textBox11.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[3] = int.Parse(textBox11.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[3] = 0;
            }
        }

        private void textBox11_LostFocus(object sender, EventArgs e)
        {
            label38.Text = (m_saleamount[3] * m_price[3]).ToString();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                m_price[4] = 0;
            }
            else if (textBox4.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[4] = int.Parse(textBox14.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[4] = 0;
            }
        }

        private void textBox14_LostFocus(object sender, EventArgs e)
        {
            label40.Text = (m_saleamount[4] * m_price[4]).ToString();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                m_price[5] = 0;
            }
            else if (textBox4.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[5] = int.Parse(textBox17.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[5] = 0;
            }
        }

        private void textBox17_LostFocus(object sender, EventArgs e)
        {
            label42.Text = (m_saleamount[5] * m_price[5]).ToString();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                m_price[6] = 0;
            }
            else if (textBox20.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[6] = int.Parse(textBox20.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[6] = 0;
            }
        }

        private void textBox20_LostFocus(object sender, EventArgs e)
        {
            label44.Text = (m_saleamount[6] * m_price[6]).ToString();
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                m_price[7] = 0;
            }
            else if (textBox23.Text.All(char.IsDigit))
            {
                try
                {
                    m_price[7] = int.Parse(textBox23.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_price[7] = 0;
            }
        }

        private void textBox23_LostFocus(object sender, EventArgs e)
        {
            label46.Text = (m_saleamount[7] * m_price[7]).ToString();
        }
    }
}
