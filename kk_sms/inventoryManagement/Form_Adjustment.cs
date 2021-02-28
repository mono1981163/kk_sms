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


namespace kk_sms.inventoryManagement
{
    public partial class Form_Adjustment : Form
    {
        public Form_Adjustment(string index)
        {
            this.m_userid = index;
            this.m_totalRecord = 0;
            this.m_currentPage = 0;
            this.m_pageCount = 0;
            this.m_currentpagecount = 0;
            this.m_display = true;
            this.m_lost = new int[13];
            this.m_others = new int[13];
            this.m_theft = new int[13];
            this.m_lostnew = new int[13];
            this.m_othersnew = new int[13];
            this.m_theftnew = new int[13];
            this.m_orderids = new int[13];
            this.m_quantitys = new int[13];
           
            this.m_quantitysdisplay = new int[13];
            for (int i=0; i<13; i++)
            {
                m_lost[i] = 0;
                m_quantitys[i] = 0;
                m_others[i] = 0;
                m_theft[i] = 0;
                m_quantitysdisplay[i] = 0;
                m_lostnew[i] = 0;
                m_othersnew[i] = 0;
                m_theftnew[i] = 0;

            }
        InitializeComponent();
        }

        private void Form_Adjustment_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(m_userid);
            label_title.Text = "在庫蜩整 担当者 " + id;
            display.Text = "一筧表示 (&L)";
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM tbl_nyuko WHERE syainno='" + id + "'";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                m_totalRecord = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                m_pageCount =(int)Math.Ceiling((double)m_totalRecord / 13);
                query = "SELECT login_name FROM m_user WHERE user_id='" + m_userid + "'";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                name_text.Text = sqlCommand.ExecuteScalar().ToString();
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void display_Click(object sender, EventArgs e)
        {
            if(m_currentPage == m_pageCount)
            {
                statuslabel.Text = "ファイルの絡端です";
            }
            else
            {
                if(m_display)
                {
                    display.Text = "保存 (&S)";
                    m_currentPage += 1;
                    int id = Int32.Parse(m_userid);
                    try
                    {
                        var iniparser = new FileIniDataParser();
                        IniData inidata = iniparser.ReadFile("kk_sms.ini");
                        string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True";
                        var mysqlConnection = new MySqlConnection(mysqlConf);
                        mysqlConnection.Open();
                        string query = "SELECT orderno, hinmaei, toukyuname, kaikyuname, siiresu, souurisu, zaikosu, zaikoadjust1, zaikoadjust2, zaikoadjust3, adjustCumulative1, adjustCumulative2, adjustCumulative3  FROM tbl_nyuko WHERE syainno='" + id + "'  ORDER BY orderno LIMIT 13 OFFSET " + (m_currentPage - 1) * 13 + ";";
                        MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                        var result = sqlCommand.ExecuteReader();
                        if (result.HasRows)
                        {
                            var row_no = 1;
                            while (result.Read())
                            {
                                TextBox tbxordertext = this.Controls.Find("ordertext" + row_no, true).FirstOrDefault() as TextBox;
                                TextBox tbxproduct = this.Controls.Find("product" + row_no, true).FirstOrDefault() as TextBox;
                                TextBox tbxgrade = this.Controls.Find("grade" + row_no, true).FirstOrDefault() as TextBox;
                                TextBox tbxclass = this.Controls.Find("class" + row_no, true).FirstOrDefault() as TextBox;
                                TextBox tbxpurchasenum = this.Controls.Find("purchasenum" + row_no, true).FirstOrDefault() as TextBox;
                                TextBox tbxsalenum = this.Controls.Find("salenum" + row_no, true).FirstOrDefault() as TextBox;
                                tbxordertext.Text = result.GetString(0);
                                tbxproduct.Text = result.GetString(1);
                                tbxgrade.Text = result.GetString(2);
                                tbxclass.Text = result.GetString(3);
                                tbxpurchasenum.Text = result.GetString(4);
                                tbxsalenum.Text = result.GetString(5);
                                m_orderids[row_no-1] =Int32.Parse(result.GetString(0));
                                m_lost[row_no-1] = Int32.Parse(result.GetString(10));
                                m_theft[row_no-1] = Int32.Parse(result.GetString(11));
                                m_others[row_no-1] = Int32.Parse(result.GetString(12));
                                m_quantitys[row_no-1] = Int32.Parse(result.GetString(6));
                                row_no++;
                            }
                            m_currentpagecount = row_no;
                        }
                        mysqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    display.Text = "次のページ (&N)";
                }
                m_display = !m_display;
                
            }
            

        }

        private void lost1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost1.Text, "[^0-9]"))
            {
                lost1.Text = lost1.Text.Remove(lost1.Text.Length - 1);
            }
            int a, b, c;
            a = (lost1.Text == "") ? 0 : Int32.Parse(lost1.Text);
            b = (theft1.Text == "") ? 0 : Int32.Parse(theft1.Text);
            c = (others1.Text == "") ? 0 : Int32.Parse(others1.Text);

            m_quantitysdisplay[0] = m_quantitys[0] - a - b + c;
            quantity1.Text = m_quantitysdisplay[0].ToString();
            m_lostnew[0] = a;
        }

        private void theft1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft1.Text, "[^0-9]"))
            {
                theft1.Text = theft1.Text.Remove(theft1.Text.Length - 1);
            }
            int a, b, c;
            a = (lost1.Text == "") ? 0 : Int32.Parse(lost1.Text);
            b = (theft1.Text == "") ? 0 : Int32.Parse(theft1.Text);
            c = (others1.Text == "") ? 0 : Int32.Parse(others1.Text);

            m_quantitysdisplay[0] = m_quantitys[0] - a - b + c;
            quantity1.Text = m_quantitysdisplay[0].ToString();
            m_theftnew[0] = b;
        }

        private void others1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others1.Text, "[^0-9]"))
            {
                others1.Text = others1.Text.Remove(others1.Text.Length - 1);
            }
            int a, b, c;
            a = (lost1.Text == "") ? 0 : Int32.Parse(lost1.Text);
            b = (theft1.Text == "") ? 0 : Int32.Parse(theft1.Text);
            c = (others1.Text == "") ? 0 : Int32.Parse(others1.Text);
            m_quantitysdisplay[0] = m_quantitys[0] - a - b + c;
            quantity1.Text = m_quantitysdisplay[0].ToString();
            m_othersnew[0] = c;
        }

        private void lost2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost2.Text, "[^0-9]"))
            {
                lost2.Text = lost2.Text.Remove(lost2.Text.Length - 1);
            }
            int a, b, c;
            a = (lost2.Text == "") ? 0 : Int32.Parse(lost2.Text);
            b = (theft2.Text == "") ? 0 : Int32.Parse(theft2.Text);
            c = (others2.Text == "") ? 0 : Int32.Parse(others2.Text);
            m_quantitysdisplay[1] = m_quantitys[1] - a - b + c;
            quantity2.Text = m_quantitysdisplay[1].ToString();
            m_lostnew[1] = a;
        }

        private void theft2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft2.Text, "[^0-9]"))
            {
                theft2.Text = theft2.Text.Remove(theft2.Text.Length - 1);
            }
            int a, b, c;
            a = (lost2.Text == "") ? 0 : Int32.Parse(lost2.Text);
            b = (theft2.Text == "") ? 0 : Int32.Parse(theft2.Text);
            c = (others2.Text == "") ? 0 : Int32.Parse(others2.Text);
            m_quantitysdisplay[1] = m_quantitys[1] - a - b + c;
            quantity2.Text = m_quantitysdisplay[1].ToString();
            m_theftnew[1] = b;
        }

        private void others2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others2.Text, "[^0-9]"))
            {
                others2.Text = others2.Text.Remove(others2.Text.Length - 1);
            }
            int a, b, c;
            a = (lost2.Text == "") ? 0 : Int32.Parse(lost2.Text);
            b = (theft2.Text == "") ? 0 : Int32.Parse(theft2.Text);
            c = (others2.Text == "") ? 0 : Int32.Parse(others2.Text);
            m_quantitysdisplay[1] = m_quantitys[1] - a - b + c;
            quantity2.Text = m_quantitysdisplay[1].ToString();
            m_othersnew[1] = c;
        }

        private void lost3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost3.Text, "[^0-9]"))
            {
                lost3.Text = lost3.Text.Remove(lost3.Text.Length - 1);
            }
            int a, b, c;
            a = (lost3.Text == "") ? 0 : Int32.Parse(lost3.Text);
            b = (theft3.Text == "") ? 0 : Int32.Parse(theft3.Text);
            c = (others3.Text == "") ? 0 : Int32.Parse(others3.Text);
            m_quantitysdisplay[2] = m_quantitys[2] - a - b + c;
            quantity3.Text = m_quantitysdisplay[2].ToString();
            m_lostnew[2] = a;
        }

        private void theft3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft3.Text, "[^0-9]"))
            {
                theft3.Text = theft3.Text.Remove(theft3.Text.Length - 1);
            }
            int a, b, c;
            a = (lost3.Text == "") ? 0 : Int32.Parse(lost3.Text);
            b = (theft3.Text == "") ? 0 : Int32.Parse(theft3.Text);
            c = (others3.Text == "") ? 0 : Int32.Parse(others3.Text);
            m_quantitysdisplay[2] = m_quantitys[2] - a - b + c;
            quantity3.Text = m_quantitysdisplay[2].ToString();
            m_theftnew[2] = b;
        }

        private void others3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others3.Text, "[^0-9]"))
            {
                others3.Text = others3.Text.Remove(others3.Text.Length - 1);
            }
            int a, b, c;
            a = (lost3.Text == "") ? 0 : Int32.Parse(lost3.Text);
            b = (theft3.Text == "") ? 0 : Int32.Parse(theft3.Text);
            c = (others3.Text == "") ? 0 : Int32.Parse(others3.Text);
            m_quantitysdisplay[2] = m_quantitys[2] - a - b + c;
            quantity3.Text = m_quantitysdisplay[2].ToString();
            m_othersnew[2] = c;
        }

        private void lost4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost4.Text, "[^0-9]"))
            {
                lost4.Text = lost4.Text.Remove(lost4.Text.Length - 1);
            }
            int a, b, c;
            a = (lost4.Text == "") ? 0 : Int32.Parse(lost4.Text);
            b = (theft4.Text == "") ? 0 : Int32.Parse(theft4.Text);
            c = (others4.Text == "") ? 0 : Int32.Parse(others4.Text);
            m_quantitysdisplay[3] = m_quantitys[3] - a - b + c;
            quantity4.Text = m_quantitysdisplay[3].ToString();
            m_lostnew[3] = a;
        }

        private void theft4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft4.Text, "[^0-9]"))
            {
                theft4.Text = theft4.Text.Remove(theft4.Text.Length - 1);
            }
            int a, b, c;
            a = (lost4.Text == "") ? 0 : Int32.Parse(lost4.Text);
            b = (theft4.Text == "") ? 0 : Int32.Parse(theft4.Text);
            c = (others4.Text == "") ? 0 : Int32.Parse(others4.Text);
            m_quantitysdisplay[3] = m_quantitys[3] - a - b + c;
            quantity4.Text = m_quantitysdisplay[3].ToString();
            m_theftnew[3] = b;
        }

        private void others4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others4.Text, "[^0-9]"))
            {
                others4.Text = others4.Text.Remove(others4.Text.Length - 1);
            }
            int a, b, c;
            a = (lost4.Text == "") ? 0 : Int32.Parse(lost4.Text);
            b = (theft4.Text == "") ? 0 : Int32.Parse(theft4.Text);
            c = (others4.Text == "") ? 0 : Int32.Parse(others4.Text);
            m_quantitysdisplay[3] = m_quantitys[3] - a - b + c;
            quantity4.Text = m_quantitysdisplay[3].ToString();
            m_othersnew[3] = c;
        }

        private void lost5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost5.Text, "[^0-9]"))
            {
                lost5.Text = lost5.Text.Remove(lost5.Text.Length - 1);
            }
            int a, b, c;
            a = (lost5.Text == "") ? 0 : Int32.Parse(lost5.Text);
            b = (theft5.Text == "") ? 0 : Int32.Parse(theft5.Text);
            c = (others5.Text == "") ? 0 : Int32.Parse(others5.Text);
            m_quantitysdisplay[4] = m_quantitys[4] - a - b + c;
            quantity5.Text = m_quantitysdisplay[4].ToString();
            m_lostnew[4] = a;
        }

        private void theft5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft5.Text, "[^0-9]"))
            {
                theft5.Text = theft5.Text.Remove(theft5.Text.Length - 1);
            }
            int a, b, c;
            a = (lost5.Text == "") ? 0 : Int32.Parse(lost5.Text);
            b = (theft5.Text == "") ? 0 : Int32.Parse(theft5.Text);
            c = (others5.Text == "") ? 0 : Int32.Parse(others5.Text);
            m_quantitysdisplay[4] = m_quantitys[4] - a - b + c;
            quantity5.Text = m_quantitysdisplay[4].ToString();
            m_theftnew[4] = b;
        }

        private void others5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others5.Text, "[^0-9]"))
            {
                others5.Text = others5.Text.Remove(others5.Text.Length - 1);
            }
            int a, b, c;
            a = (lost5.Text == "") ? 0 : Int32.Parse(lost5.Text);
            b = (theft5.Text == "") ? 0 : Int32.Parse(theft5.Text);
            c = (others5.Text == "") ? 0 : Int32.Parse(others5.Text);
            m_quantitysdisplay[4] = m_quantitys[4] - a - b + c;
            quantity5.Text = m_quantitysdisplay[4].ToString();
            m_othersnew[4] = c;
        }

        private void lost6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost6.Text, "[^0-9]"))
            {
                lost6.Text = lost6.Text.Remove(lost6.Text.Length - 1);
            }
            int a, b, c;
            a = (lost6.Text == "") ? 0 : Int32.Parse(lost6.Text);
            b = (theft6.Text == "") ? 0 : Int32.Parse(theft6.Text);
            c = (others6.Text == "") ? 0 : Int32.Parse(others6.Text);
            m_quantitysdisplay[5] = m_quantitys[5] - a - b + c;
            quantity6.Text = m_quantitysdisplay[5].ToString();
            m_lostnew[5] = a;
        }

        private void theft6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft6.Text, "[^0-9]"))
            {
                theft6.Text = theft6.Text.Remove(theft6.Text.Length - 1);
            }
            int a, b, c;
            a = (lost6.Text == "") ? 0 : Int32.Parse(lost6.Text);
            b = (theft6.Text == "") ? 0 : Int32.Parse(theft6.Text);
            c = (others6.Text == "") ? 0 : Int32.Parse(others6.Text);
            m_quantitysdisplay[5] = m_quantitys[5] - a - b + c;
            quantity6.Text = m_quantitysdisplay[5].ToString();
            m_theftnew[5] = b;
        }

        private void others6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others6.Text, "[^0-9]"))
            {
                others6.Text = others6.Text.Remove(others6.Text.Length - 1);
            }
            int a, b, c;
            a = (lost6.Text == "") ? 0 : Int32.Parse(lost6.Text);
            b = (theft6.Text == "") ? 0 : Int32.Parse(theft6.Text);
            c = (others6.Text == "") ? 0 : Int32.Parse(others6.Text);
            m_quantitysdisplay[5] = m_quantitys[5] - a - b + c;
            quantity6.Text = m_quantitysdisplay[5].ToString();
            m_othersnew[5] = c;
        }

        private void lost7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost7.Text, "[^0-9]"))
            {
                lost7.Text = lost7.Text.Remove(lost7.Text.Length - 1);
            }
            int a, b, c;
            a = (lost7.Text == "") ? 0 : Int32.Parse(lost7.Text);
            b = (theft7.Text == "") ? 0 : Int32.Parse(theft7.Text);
            c = (others7.Text == "") ? 0 : Int32.Parse(others7.Text);
            m_quantitysdisplay[6] = m_quantitys[6] - a - b + c;
            quantity7.Text = m_quantitysdisplay[6].ToString();
            m_lostnew[6] = a;
        }

        private void theft7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft7.Text, "[^0-9]"))
            {
                theft7.Text = theft7.Text.Remove(theft7.Text.Length - 1);
            }
            int a, b, c;
            a = (lost7.Text == "") ? 0 : Int32.Parse(lost7.Text);
            b = (theft7.Text == "") ? 0 : Int32.Parse(theft7.Text);
            c = (others7.Text == "") ? 0 : Int32.Parse(others7.Text);
            m_quantitysdisplay[6] = m_quantitys[6] - a - b + c;
            quantity7.Text = m_quantitysdisplay[6].ToString();
            m_theftnew[6] = b;
        }

        private void others7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others7.Text, "[^0-9]"))
            {
                others7.Text = others7.Text.Remove(others7.Text.Length - 1);
            }
            int a, b, c;
            a = (lost7.Text == "") ? 0 : Int32.Parse(lost7.Text);
            b = (theft7.Text == "") ? 0 : Int32.Parse(theft7.Text);
            c = (others7.Text == "") ? 0 : Int32.Parse(others7.Text);
            m_quantitysdisplay[6] = m_quantitys[6] - a - b + c;
            quantity7.Text = m_quantitysdisplay[6].ToString();
            m_othersnew[6] = c;
        }

        private void lost8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost8.Text, "[^0-9]"))
            {
                lost8.Text = lost8.Text.Remove(lost8.Text.Length - 1);
            }
            int a, b, c;
            a = (lost8.Text == "") ? 0 : Int32.Parse(lost8.Text);
            b = (theft8.Text == "") ? 0 : Int32.Parse(theft8.Text);
            c = (others8.Text == "") ? 0 : Int32.Parse(others8.Text);
            m_quantitysdisplay[7] = m_quantitys[7] - a - b + c;
            quantity8.Text = m_quantitysdisplay[7].ToString();
            m_lostnew[7] = a;
        }

        private void theft8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft8.Text, "[^0-9]"))
            {
                theft8.Text = theft8.Text.Remove(theft8.Text.Length - 1);
            }
            int a, b, c;
            a = (lost8.Text == "") ? 0 : Int32.Parse(lost8.Text);
            b = (theft8.Text == "") ? 0 : Int32.Parse(theft8.Text);
            c = (others8.Text == "") ? 0 : Int32.Parse(others8.Text);
            m_quantitysdisplay[7] = m_quantitys[7] - a - b + c;
            quantity8.Text = m_quantitysdisplay[7].ToString();
            m_theftnew[7] = b;
        }

        private void others8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others8.Text, "[^0-9]"))
            {
                others8.Text = others8.Text.Remove(others8.Text.Length - 1);
            }
            int a, b, c;
            a = (lost8.Text == "") ? 0 : Int32.Parse(lost8.Text);
            b = (theft8.Text == "") ? 0 : Int32.Parse(theft8.Text);
            c = (others8.Text == "") ? 0 : Int32.Parse(others8.Text);
            m_quantitysdisplay[7] = m_quantitys[7] - a - b + c;
            quantity8.Text = m_quantitysdisplay[7].ToString();
            m_othersnew[7] = c;
        }

        private void lost9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost9.Text, "[^0-9]"))
            {
                lost9.Text = lost9.Text.Remove(lost9.Text.Length - 1);
            }
            int a, b, c;
            a = (lost9.Text == "") ? 0 : Int32.Parse(lost9.Text);
            b = (theft9.Text == "") ? 0 : Int32.Parse(theft9.Text);
            c = (others9.Text == "") ? 0 : Int32.Parse(others9.Text);
            m_quantitysdisplay[8] = m_quantitys[8] - a - b + c;
            quantity9.Text = m_quantitysdisplay[8].ToString();
            m_lostnew[8] = a;
        }

        private void theft9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft9.Text, "[^0-9]"))
            {
                theft9.Text = theft9.Text.Remove(theft9.Text.Length - 1);
            }
            int a, b, c;
            a = (lost9.Text == "") ? 0 : Int32.Parse(lost9.Text);
            b = (theft9.Text == "") ? 0 : Int32.Parse(theft9.Text);
            c = (others9.Text == "") ? 0 : Int32.Parse(others9.Text);
            m_quantitysdisplay[8] = m_quantitys[8] - a - b + c;
            quantity9.Text = m_quantitysdisplay[8].ToString();
            m_theftnew[8] = b;
        }

        private void others9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others9.Text, "[^0-9]"))
            {
                others9.Text = others9.Text.Remove(others9.Text.Length - 1);
            }
            int a, b, c;
            a = (lost9.Text == "") ? 0 : Int32.Parse(lost9.Text);
            b = (theft9.Text == "") ? 0 : Int32.Parse(theft9.Text);
            c = (others9.Text == "") ? 0 : Int32.Parse(others9.Text);
            m_quantitysdisplay[8] = m_quantitys[8] - a - b + c;
            quantity9.Text = m_quantitysdisplay[8].ToString();
            m_othersnew[8] = c;
        }

        private void lost10_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost10.Text, "[^0-9]"))
            {
                lost10.Text = lost10.Text.Remove(lost10.Text.Length - 1);
            }
            int a, b, c;
            a = (lost10.Text == "") ? 0 : Int32.Parse(lost10.Text);
            b = (theft10.Text == "") ? 0 : Int32.Parse(theft10.Text);
            c = (others10.Text == "") ? 0 : Int32.Parse(others10.Text);
            m_quantitysdisplay[9] = m_quantitys[9] - a - b + c;
            quantity10.Text = m_quantitysdisplay[9].ToString();
            m_lostnew[9] = a;
        }

        private void theft10_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft10.Text, "[^0-9]"))
            {
                theft10.Text = theft10.Text.Remove(theft10.Text.Length - 1);
            }
            int a, b, c;
            a = (lost10.Text == "") ? 0 : Int32.Parse(lost10.Text);
            b = (theft10.Text == "") ? 0 : Int32.Parse(theft10.Text);
            c = (others10.Text == "") ? 0 : Int32.Parse(others10.Text);
            m_quantitysdisplay[9] = m_quantitys[9] - a - b + c;
            quantity10.Text = m_quantitysdisplay[9].ToString();
            m_theftnew[9] = b;
        }

        private void others10_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others10.Text, "[^0-9]"))
            {
                others10.Text = others10.Text.Remove(others10.Text.Length - 1);
            }
            int a, b, c;
            a = (lost10.Text == "") ? 0 : Int32.Parse(lost10.Text);
            b = (theft10.Text == "") ? 0 : Int32.Parse(theft10.Text);
            c = (others10.Text == "") ? 0 : Int32.Parse(others10.Text);
            m_quantitysdisplay[9] = m_quantitys[9] - a - b + c;
            quantity10.Text = m_quantitysdisplay[9].ToString();
            m_othersnew[9] = c;
        }

        private void lost11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost11.Text, "[^0-9]"))
            {
                lost11.Text = lost11.Text.Remove(lost11.Text.Length - 1);
            }
            int a, b, c;
            a = (lost11.Text == "") ? 0 : Int32.Parse(lost11.Text);
            b = (theft11.Text == "") ? 0 : Int32.Parse(theft11.Text);
            c = (others11.Text == "") ? 0 : Int32.Parse(others11.Text);
            m_quantitysdisplay[10] = m_quantitys[10] - a - b + c;
            quantity11.Text = m_quantitysdisplay[10].ToString();
            m_lostnew[10] = a;
        }

        private void theft11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft11.Text, "[^0-9]"))
            {
                theft11.Text = theft11.Text.Remove(theft11.Text.Length - 1);
            }
            int a, b, c;
            a = (lost11.Text == "") ? 0 : Int32.Parse(lost11.Text);
            b = (theft11.Text == "") ? 0 : Int32.Parse(theft11.Text);
            c = (others11.Text == "") ? 0 : Int32.Parse(others11.Text);
            m_quantitysdisplay[10] = m_quantitys[10] - a - b + c;
            quantity11.Text = m_quantitysdisplay[10].ToString();
            m_theftnew[10] = b;
        }

        private void others11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others11.Text, "[^0-9]"))
            {
                others11.Text = others11.Text.Remove(others11.Text.Length - 1);
            }
            int a, b, c;
            a = (lost11.Text == "") ? 0 : Int32.Parse(lost11.Text);
            b = (theft11.Text == "") ? 0 : Int32.Parse(theft11.Text);
            c = (others11.Text == "") ? 0 : Int32.Parse(others11.Text);
            m_quantitysdisplay[10] = m_quantitys[10] - a - b + c;
            quantity11.Text = m_quantitysdisplay[10].ToString();
            m_othersnew[10] = c;
        }

        private void lost12_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost12.Text, "[^0-9]"))
            {
                lost12.Text = lost12.Text.Remove(lost12.Text.Length - 1);
            }
            int a, b, c;
            a = (lost12.Text == "") ? 0 : Int32.Parse(lost12.Text);
            b = (theft12.Text == "") ? 0 : Int32.Parse(theft12.Text);
            c = (others12.Text == "") ? 0 : Int32.Parse(others12.Text);
            m_quantitysdisplay[11] = m_quantitys[11] - a - b + c;
            quantity12.Text = m_quantitysdisplay[11].ToString();
            m_lostnew[11] = a;
        }

        private void theft12_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft12.Text, "[^0-9]"))
            {
                theft12.Text = theft12.Text.Remove(theft12.Text.Length - 1);
            }
            int a, b, c;
            a = (lost12.Text == "") ? 0 : Int32.Parse(lost12.Text);
            b = (theft12.Text == "") ? 0 : Int32.Parse(theft12.Text);
            c = (others12.Text == "") ? 0 : Int32.Parse(others12.Text);
            m_quantitysdisplay[11] = m_quantitys[11] - a - b + c;
            quantity12.Text = m_quantitysdisplay[11].ToString();
            m_theftnew[11] = b;
        }

        private void others12_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others12.Text, "[^0-9]"))
            {
                others12.Text = others12.Text.Remove(others12.Text.Length - 1);
            }
            int a, b, c;
            a = (lost12.Text == "") ? 0 : Int32.Parse(lost12.Text);
            b = (theft12.Text == "") ? 0 : Int32.Parse(theft12.Text);
            c = (others12.Text == "") ? 0 : Int32.Parse(others12.Text);
            m_quantitysdisplay[11] = m_quantitys[11] - a - b + c;
            quantity12.Text = m_quantitysdisplay[11].ToString();
            m_othersnew[11] = c;
        }

        private void lost13_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(lost13.Text, "[^0-9]"))
            {
                lost13.Text = lost13.Text.Remove(lost13.Text.Length - 1);
            }
            int a, b, c;
            a = (lost13.Text == "") ? 0 : Int32.Parse(lost13.Text);
            b = (theft13.Text == "") ? 0 : Int32.Parse(theft13.Text);
            c = (others13.Text == "") ? 0 : Int32.Parse(others13.Text);
            m_quantitysdisplay[12] = m_quantitys[12] - a - b + c;
            quantity13.Text = m_quantitysdisplay[12].ToString();
            m_lostnew[12] = a;
        }

        private void theft13_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(theft13.Text, "[^0-9]"))
            {
                theft13.Text = theft13.Text.Remove(theft13.Text.Length - 1);
            }
            int a, b, c;
            a = (lost13.Text == "") ? 0 : Int32.Parse(lost13.Text);
            b = (theft13.Text == "") ? 0 : Int32.Parse(theft13.Text);
            c = (others13.Text == "") ? 0 : Int32.Parse(others13.Text);
            m_quantitysdisplay[12] = m_quantitys[12] - a - b + c;
            quantity13.Text = m_quantitysdisplay[12].ToString();
            m_theftnew[12] = b;
        }

        private void others13_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(others13.Text, "[^0-9]"))
            {
                others13.Text = others13.Text.Remove(others13.Text.Length - 1);
            }
            int a, b, c;
            a = (lost13.Text == "") ? 0 : Int32.Parse(lost13.Text);
            b = (theft13.Text == "") ? 0 : Int32.Parse(theft13.Text);
            c = (others13.Text == "") ? 0 : Int32.Parse(others13.Text);
            m_quantitysdisplay[12] = m_quantitys[12] - a - b + c;
            quantity13.Text = m_quantitysdisplay[12].ToString();
            m_othersnew[12] = c;
        }
    }
}
