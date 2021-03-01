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

namespace kk_sms.masterManagement.payment
{
    public partial class payment_list : Form
    {
        public payment_list()
        {
            InitializeComponent();
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            var searchValue = textBox_search.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
                        row.DefaultCellStyle.BackColor = Color.Blue;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplier_list_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM tbl_daibarai";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 233, 233, 233);
                query = "SELECT daino, dainame FROM tbl_daibarai;";
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
                            dataGridView1[i + 1, row_no].Value = result.GetString(i);
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
    }
}
