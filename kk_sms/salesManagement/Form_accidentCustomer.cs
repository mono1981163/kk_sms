﻿using System;
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
    public partial class Form_accidentCustomer : Form
    {
        private Form_accidentInput parentForm;

        public Form_accidentCustomer(Form_accidentInput parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void Form_accidentCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM m_tokuisaki";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                dataGridView1.RowCount = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                query = "SELECT tokuisakino, tokuisakiname FROM m_tokuisaki;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            dataGridView1[i, row_no].Value = result.GetValue(i).ToString();
                        }
                        row_no++;
                    }
                }
                mysqlConnection.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputValue = textBox1.Text;
            var rows = dataGridView1.Rows.Count;

            if (inputValue.All(char.IsDigit))
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string param = "";
                var current_row = dataGridView1.CurrentCell.RowIndex;
                param = dataGridView1[0, current_row].Value.ToString();
                parentForm.textChange9(param);
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
