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

namespace kk_sms.purchaseManagement
{
    public partial class Form_input_selectPacking : Form
    {
        private Form_input parentForm;

        public Form_input_selectPacking(Form_input parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_selectRep_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM m_nisugata";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 233, 233, 233);
                query = "SELECT nisugatano, nisugataname FROM m_nisugata;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        dataGridView1[0, row_no].Value = row_no + 1;
                        for (int i = 0; i < 2; i++)
                        {
                            dataGridView1[i+1, row_no].Value = result.GetString(i);
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

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                var current_row = dataGridView1.CurrentCell.RowIndex;
                var code = dataGridView1[1, current_row].Value.ToString();
                var name = dataGridView1[2, current_row].Value.ToString();
                parentForm.change_packing(code, name);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
