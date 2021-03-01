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
    public partial class Form_slipInputSearch : Form
    {
        private Form_salesSlipInput parentForm;

        public Form_slipInputSearch(Form_salesSlipInput parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_slipInputSearch_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM tbl_nyuko";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                query = "SELECT N.orderno, N.nyukoday, N.syainno, N.syainname, H.tokuisakino, H.tokuisakiname, H.hinban, H.hinmei, N.toukyuno, N.toukyuname, N.kaikyuno, N.kaikyuname, N.irisu, N.siiresu, N.nisugatano, N.nisugataname, N.zaikosu, N.souurisu, N.tanka, N.kingaku, N.kuban, N.nyuukokubun, N.zaikoadjust1, N.zaikoadjust2, N.zaikoadjust3, N.adjustCumulative1, N.adjustCumulative2, N.adjustCumulative3 FROM tbl_nyuko AS N INNER JOIN tbl_hanbai AS H WHERE N.orderno = H.orderno AND N.orderno != '0' ORDER BY N.orderno;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        for (int i = 0; i < 28; i++)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string param = "";
                var current_row = dataGridView1.CurrentCell.RowIndex;
                param = dataGridView1[0, current_row].Value.ToString();
                parentForm.textChange(param);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputValue = textBox1.Text;
            var rows = dataGridView1.Rows.Count;
            if (inputValue == "")
            {
                label3.Text = "伝票番号が入力さわませんでした";
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
                }
            }
        }
    }
}
