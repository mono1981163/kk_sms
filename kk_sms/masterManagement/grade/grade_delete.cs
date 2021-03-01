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

namespace kk_sms.masterManagement.grade
{
    public partial class grade_delete : Form
    {
        public grade_delete()
        {
            InitializeComponent();
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grade_delete_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM m_tokyu";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 233, 233, 233);
                query = "SELECT toukyuno, toukyuname FROM m_tokyu;";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                var current_row = dataGridView1.CurrentCell.RowIndex;
                var grade_no = dataGridView1[1, current_row].Value;
                string query = "DELETE FROM m_tokyu WHERE toukyuno='" + grade_no + "'";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    description_label.Text = "正確に削除されました。";
                }
                else
                {
                    description_label.Text = "大湯が発生しました。";
                }
                mysqlConnection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
