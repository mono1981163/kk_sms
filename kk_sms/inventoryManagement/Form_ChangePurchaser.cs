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
    public partial class Form_ChangePurchaser : Form
    {
        public Form_ChangePurchaser()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            var slipnumber = Snumval.Text;
            var employeenumber = EmNoval.Text;

            if (slipnumber == "")
            {
                statusLabel.Text = "伝票番号を入力してください";
            }
            else
            {
                if(employeenumber=="")
                {
                    statusLabel.Text = "担当者番号を入力してください";
                }
                else
                {
                    while (employeenumber.Length < 3)
                    {
                        employeenumber = "0" + employeenumber;
                    }
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT login_name FROM m_user WHERE user_id='" + employeenumber + "';";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var name = sqlCommand.ExecuteScalar().ToString();
                    if(name=="")
                    {
                        statusLabel.Text = "担当者番号が正しくありません";
                    }
                    else
                    {
                        query = "UPDATE tbl_nyuko SET syainno = '" + employeenumber + "', syainname = '" + name + "' WHERE orderno='" + slipnumber + "';";
                        sqlCommand = new MySqlCommand(query, mysqlConnection);
                        try
                        {
                            var result = sqlCommand.ExecuteReader();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }                        
                    }
                    mysqlConnection.Close();
                    onload();
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            var searchId = Snumval.Text;
            if(searchId=="")
            {
                statusLabel.Text = "伝票番号を入力してください";
            }
            else
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchId))
                    {
                        rowIndex = row.Index;
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                    }
                    else
                    {
                        row.Cells[0].Style.BackColor = System.Drawing.SystemColors.ButtonFace;
                    }
                }
            }           
        }


        private void Form_ChangePurchaser_Load(object sender, EventArgs e)
        {
            onload();
        }


        private void onload()
        {
            statusLabel.Text = "担当者を変更する伝票番号を入力して[検索ボタン]を押してください。";
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM tbl_nyuko";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 233, 233, 233);
                DateTime today = DateTime.Today;
                var datetimestring = today.ToString("yyyy-MM-dd");
                query = "SELECT orderno, hinmaei, N.syainno, syainname, S.siirename, nyukoday FROM tbl_nyuko AS N INNER JOIN m_siire AS S ON N.siireno = S.siireno WHERE nyukoday='" + datetimestring + "' ORDER BY orderno;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            if (i != 5)
                            {
                                dataGridView1[i, row_no].Value = result.GetString(i);
                            }
                            else
                            {
                                dataGridView1[i, row_no].Value = result.GetDateTime(i).ToString("yyyy/MM/dd");
                            }
                        }
                        row_no++;
                    }
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Snumval_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Snumval.Text, "[^0-9]"))
            {
                Snumval.Text = Snumval.Text.Remove(Snumval.Text.Length - 1);
            }
            if (Snumval.Text.Length > 4)
            {
                Snumval.Text = Snumval.Text.Remove(Snumval.Text.Length - 1);
            }
        }

        private void EmNoval_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(EmNoval.Text, "[^0-9]"))
            {
                EmNoval.Text = EmNoval.Text.Remove(EmNoval.Text.Length - 1);
            }
            if (Snumval.Text.Length > 3)
            {
                EmNoval.Text = EmNoval.Text.Remove(EmNoval.Text.Length - 1);
            }
        }
    }
}
