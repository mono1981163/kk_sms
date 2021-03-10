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
    public partial class Form_correct_selectOrder : Form
    {
        private Form_correct parentForm;

        public Form_correct_selectOrder(Form_correct parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_selectRep_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox_search;
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM tbl_nyuko";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                query = "SELECT * FROM tbl_nyuko;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        for (int i = 0; i < 28; i++)
                        {
                            dataGridView1[i, row_no].Value = result.GetValue(i + 1).ToString();
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
                var param = new string[28];
                var current_row = dataGridView1.CurrentCell.RowIndex;
                for (int i = 0; i < 28; i++)
                {
                    param[i] = dataGridView1[i, current_row].Value.ToString();
                }
                parentForm.changeData(param);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            var inputValue = textBox_search.Text;
            var rows = dataGridView1.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                if (dataGridView1[0, i].Value.ToString() == inputValue)
                {
                    dataGridView1.CurrentCell = this.dataGridView1[0, i];
                    break;
                }
            }
        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var inputValue = textBox_search.Text;
                var rows = dataGridView1.Rows.Count;
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
