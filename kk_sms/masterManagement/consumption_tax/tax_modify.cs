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

namespace kk_sms.masterManagement.consumption_tax
{
    public partial class tax_modify : Form
    {
        public tax_modify()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var year = textBox_year.Text;
            var month = textBox_month.Text;
            var day = textBox_day.Text;
            var interest_rate = textBox_interest_rate.Text;
            var flag = true;
            if (String.IsNullOrEmpty(interest_rate))
            {
                description_label.Text = "利子率を入力してください。";
                flag = false;
            }
            if (String.IsNullOrEmpty(year) || String.IsNullOrEmpty(month) || String.IsNullOrEmpty(day))
            {
                description_label.Text = "開始日付を入力してください。";
                flag = false;
            }
            else
            {
                var int_year = Convert.ToInt32(year);
                var int_month = Convert.ToInt32(month);
                var int_day = Convert.ToInt32(day);
                if (!interest_rate.All(char.IsDigit))
                {
                    description_label.Text = "利子率を正確に入力してください。";
                    flag = false;

                }
                if (!year.All(char.IsDigit) || year.Length != 4 || int_year < DateTime.Now.Year)
                {
                    description_label.Text = "年度を正確に入力してください。";
                    flag = false;

                }
                if (!month.All(char.IsDigit) || month.Length > 2 || int_month > 12)
                {
                    description_label.Text = "月を正しく入力してください。";
                    flag = false;

                }
                if (int_year == DateTime.Now.Year && int_month < DateTime.Now.Month)
                {
                    description_label.Text = "月を正しく入力してください。";
                    flag = false;

                }
                if (!day.All(char.IsDigit) || day.Length > 2 || int_day > 31)
                {
                    description_label.Text = "日を正しく入力してください。";
                    flag = false;

                }
                if (flag)
                {
                    var start_date_string = month + "/" + day + "/" + year;
                    var start_date = DateTime.Parse(start_date_string).ToString("yyyy-MM-dd");
                    var today = DateTime.Now.ToString("yyyy-MM-dd");
                    var end_date = DateTime.Parse(start_date_string).AddDays(-1).ToString("yyyy-MM-dd");
                    try
                    {
                        var iniparser = new FileIniDataParser();
                        IniData inidata = iniparser.ReadFile("kk_sms.ini");
                        string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                        var mysqlConnection = new MySqlConnection(mysqlConf);
                        mysqlConnection.Open();
                        var getSecondId = "SELECT uid FROM (SELECT uid FROM m_zei ORDER BY uid DESC LIMIT 2) updatetable ORDER BY uid LIMIT 1";
                        MySqlCommand sqlCommand1 = new MySqlCommand(getSecondId, mysqlConnection);
                        var second_id = sqlCommand1.ExecuteScalar();
                        string updatequery = "UPDATE m_zei SET createday ='" + end_date + "'  WHERE uid = '" + second_id + "'";
                        MySqlCommand sqlCommand2 = new MySqlCommand(updatequery, mysqlConnection);
                        sqlCommand2.ExecuteScalar();
                        string query = "UPDATE m_zei SET zei ='" + interest_rate + "', startday ='" + start_date + "' ORDER BY uid desc limit 1";
                        MySqlCommand sqlCommand3 = new MySqlCommand(query, mysqlConnection);
                        var result = sqlCommand3.ExecuteReader();
                        //var result = sqlorder.ExecuteReader();
                        if (result.RecordsAffected > 0)
                        {
                            description_label.Text = "利率が変更されました。";
                        }
                        else
                        {
                            description_label.Text = "エラーが発生しました。";
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

        private void button_end_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_interest_rate_TextChanged(object sender, EventArgs e)
        {
            var interest_rate = textBox_interest_rate.Text;
        }

        private void textBox_year_TextChanged(object sender, EventArgs e)
        {
            var year = textBox_year.Text;
        }

        private void textBox_month_TextChanged(object sender, EventArgs e)
        {
            var month = textBox_month.Text;
            var year = textBox_year.Text;
        }

        private void textBox_day_TextChanged(object sender, EventArgs e)
        {
            var day = textBox_day.Text;
        }

        private void tax_modify_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT zei FROM m_zei ORDER BY uid DESC Limit 1";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                while (result.Read())
                {
                    string column = result[0].ToString();
                    textBox_current_tax.Text = column;
                    break;
                }
                mysqlConnection.Close();
            }
            catch
            {

            }
        }

        private void rate_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_year;
            }
        }

        private void year_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_month;
            }
        }

        private void month_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_day;
            }
        }

        private void day_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = button_ok;
            }
        }
    }
}
