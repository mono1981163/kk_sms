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
    public partial class rep_list : Form
    {
        private payment_delete parentForm;

        public rep_list(payment_delete parent)
        {
            InitializeComponent();
            parentForm = parent;
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            var searchValue = textBox_search.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            try
            {
                var no = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    no = no + 1;
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        dataGridView1.ClearSelection();
                        row.Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, row.Index];
                        //row.DefaultCellStyle.BackColor = Color.Blue;
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
            try
            {
                var current_row = dataGridView1.CurrentCell.RowIndex;
                var code = dataGridView1[1, current_row].Value.ToString();
                var name = dataGridView1[2, current_row].Value.ToString();
                parentForm.change_rep(code, name);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rep_list_Load(object sender, EventArgs e)
        {
            textBox_search.Select();
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
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

        private void search_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var searchValue = textBox_search.Text;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
                try
                {
                    var no = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        no = no + 1;
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            dataGridView1.ClearSelection();
                            row.Selected = true;
                            dataGridView1.CurrentCell = dataGridView1[1, row.Index];
                            //row.DefaultCellStyle.BackColor = Color.Blue;
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}
