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

namespace kk_sms.masterManagement.product
{
    public partial class product_add : Form
    {
        public product_add()
        {
            InitializeComponent();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string product_no = textBox_product_no.Text;
            string product_name = textBox_product_name.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(product_no))
                {
                    //MessageBox.Show("番号を入力してください。");
                    label_description.Text = "番号を入力してください。";
                    flag = false;
                }
                else if (!product_no.All(char.IsDigit))
                {
                    label_description.Text = "番号を入力してください。";
                }
                if (String.IsNullOrEmpty(product_name))
                {
                    //MessageBox.Show("名前を入力します。");
                    label_description.Text = "名前を入力します。";
                    flag = false;
                }
                if (flag)
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT hinmei FROM m_hinban WHERE hinban = " + product_no;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "この番号のデータは既　保存済みです。";
                    }
                    else
                    {
                        string que = "INSERT INTO m_hinban(hinban, hinmei) VALUES('" + product_no + "','" + product_name + "')";
                        MySqlCommand sqlorder = new MySqlCommand(que, mysqlConnection);
                        MySqlDataReader mySqlDataReader = sqlorder.ExecuteReader();
                        mysqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}