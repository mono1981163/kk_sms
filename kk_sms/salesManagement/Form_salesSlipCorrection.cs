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
    public partial class Form_salesSlipCorrection : Form
    {
        public Form_salesSlipCorrection()
        {
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            m_saleamount = 0;
            m_saleamount1 = 0;
            m_stock = 0;
            m_totalsale = 0;
            m_price = 0;
        }

        private void clear()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            label10.Text = "";
            label12.Text = "";
            label14.Text = "";
            label16.Text = "";
            label5.Text = "";
            label18.Text = "";
            label19.Text = "";
            label21.Text = "";
            label24.Text = "";
            label8.Text = "";
            textBox3.Text = "";
            label30.Text = "";
        }

        private void Form_salesSlipCorrection_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            this.label_date.Text = today;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox1.Text;
            if (slipNo == "-")
            {
                var form_dialog = new kk_sms.salesManagement.Form_slipCorrectionSearch(this);
                form_dialog.ShowDialog();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button2.Focus();
            }
            else if (slipNo == "")
            {
                initData();
                clear();
            }
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]入力でー覧表から伝票を抽出してください";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.All(char.IsDigit))
            {
                textBox1.Focus();
                label48.Text = "番号を直接入力しないでください";
            }
        }

        public void textChange(string[] param)
        {
            m_stock = int.Parse(param[9]);
            m_totalsale = int.Parse(param[5]);
            m_saleamount1 = int.Parse(param[11]);
            m_price = int.Parse(param[12]);
            m_totalprice = int.Parse(param[13]);
            textBox1.Text = param[0];
            label10.Text = param[1];
            label12.Text = param[2];
            label14.Text = param[3];
            label16.Text = param[4];
            label5.Text = param[5];
            label18.Text = param[6];
            label19.Text = param[7];
            label21.Text = param[8];
            label24.Text = param[9];
            label8.Text = param[10];
            textBox2.Text = param[11];
            textBox3.Text = param[12];
            label30.Text = param[13];
            this.ActiveControl = textBox2;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox2.Text == "")
            {
                m_saleamount = 0;
            }
            else if (textBox2.Text.All(char.IsDigit))
            {
                try
                {
                    m_saleamount = int.Parse(textBox2.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount = 0;
            }
            if (m_stock + m_saleamount1 - m_saleamount < 0)
            {
                m_saleamount = m_saleamount1;
                textBox2.Text = m_saleamount.ToString();
            }
            
            label5.Text = (m_totalsale + m_saleamount - m_saleamount1).ToString();
            label24.Text = (m_stock + m_saleamount1 - m_saleamount).ToString();
            label30.Text = (m_saleamount * m_price).ToString();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                m_price = 0;
            }
            else if (textBox3.Text.All(char.IsDigit))
            {
                try
                {
                    m_price = int.Parse(textBox3.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                m_saleamount = 0;
            }
            label30.Text = (m_saleamount * m_price).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text !="" && textBox1.Text != "" && textBox3.Text !="")
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "UPDATE tbl_nyuko SET zaikosu = '" + (m_stock + m_saleamount1).ToString() + "', souurisu = '" + (m_totalsale - m_saleamount1).ToString() + "' WHERE orderno = '" + textBox1.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result1 = sqlCommand.ExecuteScalar();
                    mysqlConnection.Close();
                    mysqlConnection.Open();
                    query = "DELETE FROM tbl_hanbai WHERE orderno='"+ textBox1.Text +"' AND tokuisakiname = '" + label8.Text + "' AND kingaku = '" + m_totalprice.ToString() + "';";
                    sqlCommand = new MySqlCommand(query, mysqlConnection);
                    result1 = sqlCommand.ExecuteScalar();
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                initData();
                clear();
                label48.Text = "データがセーブされました";
            }
            else
            {
                label48.Text = "入力したデータが正しくありません。";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text !="" && textBox3.Text !="")
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";

                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "UPDATE tbl_nyuko SET zaikosu = '" + (m_stock - m_saleamount1).ToString() + "', souurisu = '" + (m_totalsale + m_saleamount1).ToString() + "' WHERE orderno = '" + textBox1.Text + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result1 = sqlCommand.ExecuteScalar();
                    mysqlConnection.Close();
                    mysqlConnection.Open();
                    query = "UPDATE tbl_hanbai SET hanbaisu = '" + m_saleamount.ToString() + "', tanka = '" + m_price.ToString() + "', kingaku = '" + label30.Text + "' WHERE orderno='" + textBox1.Text + "' AND tokuisakiname = '" + label8.Text + "' AND kingaku = '" + m_totalprice.ToString() + "';";
                    sqlCommand = new MySqlCommand(query, mysqlConnection);
                    result1 = sqlCommand.ExecuteScalar();
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                initData();
                clear();
                label48.Text = "データがセーブされました";
            }
            else
            {
                label48.Text = "入力したデータが正しくありません。";
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
                this.ActiveControl = button1;
            }
        }
    }
}
