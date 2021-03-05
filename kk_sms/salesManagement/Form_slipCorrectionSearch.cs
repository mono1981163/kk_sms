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
    public partial class Form_slipCorrectionSearch : Form
    {
        private Form_salesSlipCorrection parentForm;

        public Form_slipCorrectionSearch(Form_salesSlipCorrection parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_slipCorrectionSearch_Load(object sender, EventArgs e)
        {
            try
            { 
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(orderno) FROM tbl_hanbai WHERE (orderno>999 OR orderno<900)";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                query = "SELECT orderno, tokuisakino, tokuisakiname, hinmei, hanbaisu, tanka, kingaku FROM tbl_hanbai WHERE (orderno>999 OR orderno<900);";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        for (int i = 0; i <7; i++)
                        {
                            dataGridView1[i, row_no].Value = result.GetValue(i).ToString();
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
            this.ActiveControl = textBox1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputValue = textBox1.Text;
            var rows = dataGridView1.Rows.Count;
            if (inputValue == "")
            {
                label5.Text = "伝票番号が入力さわませんでした";
            }
            else if (inputValue.All(char.IsDigit))
            {
                for (int i = 0; i < rows; i++)
                {
                    if (dataGridView1[0, i].Value.ToString() == inputValue)
                    {
                        dataGridView1.CurrentCell = this.dataGridView1[0, i];
                        break;
                    }
                    else if (i == rows - 1)
                    {
                        label5.Text = "入力さわた伝票番号はあらません！再入力してください";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var param = new string[14];
            try
            {
                var current_row = dataGridView1.CurrentCell.RowIndex;
                var orderno = dataGridView1[0, current_row].Value.ToString();
                var tokuisakino = dataGridView1[1, current_row].Value.ToString();
                var kingaku = dataGridView1[6, current_row].Value.ToString();

                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                var query = "SELECT H.orderno, H.hinmei, H.toukyuname, H.kaikyuname, H.irisu, N.souurisu, N.siiresu, N.nisugataname, N.tanka, N.zaikosu, H.tokuisakiname, H.hanbaisu, H.tanka, H.kingaku FROM tbl_hanbai AS H INNER JOIN tbl_nyuko AS N ON H.orderno = N.orderno WHERE H.orderno = '" + orderno + "' AND H.tokuisakino = '" + tokuisakino + "' AND H.kingaku = '" + kingaku + "';";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            param[i] = result.GetValue(i).ToString();
                        }
                    }

                }
                mysqlConnection.Close();
                parentForm.textChange(param);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
