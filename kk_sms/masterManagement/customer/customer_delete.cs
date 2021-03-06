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
using System.Configuration;
using IniParser;
using IniParser.Model;

namespace kk_sms.masterManagement.customer
{
    public partial class customer_delete : Form
    {
        public customer_delete()
        {
            InitializeComponent();
        }
        private void button_delete_Click(object sender, EventArgs e)
        {

            string customer_no = rep_no.Text;
            bool flag = true;
            try
            {
                if (String.IsNullOrEmpty(customer_no))
                {
                    MessageBox.Show("番号を入力してください。");
                    flag = false;
                }
                if (flag)
                {
                    if (MessageBox.Show("削除してよろしいですか", "削除―確認", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    {
                        var iniparser = new FileIniDataParser();
                        IniData inidata = iniparser.ReadFile("kk_sms.ini");
                        string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                        var mysqlConnection = new MySqlConnection(mysqlConf);
                        mysqlConnection.Open();
                        string query = "DELETE FROM m_tokuisaki WHERE tokuisakino='" + customer_no + "'";
                        MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                        MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                        mysqlConnection.Close();
                        this.Close();
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

        private void supplier_delete_Load(object sender, EventArgs e)
        {
            label_description.Text = "[ - ] で一覧入力できます、[ . ] で終了ボタンへ";
        }

        private void textBox_supplier_no_TextChanged(object sender, EventArgs e)
        {
            var inputValue = rep_no.Text;
            if (inputValue.EndsWith("。") || inputValue.EndsWith("．") || inputValue.EndsWith("."))
            {
                button_cancel.Focus();
            }
            if (inputValue == "-")
            {
                label_description.Text = "Enter件を押してください。";
            }
            else
            {
                label_description.Text = "";
            }
        }

        public void change_rep(string code, string name)
        {
            rep_no.Text = code;
            rep_content.Text = name;
        }

        private void no_keypress(object sender, KeyPressEventArgs e)
        {
            var inputValue = rep_no.Text;
            if (e.KeyChar == (char)Keys.Enter && inputValue == "-")
            {
                var form_selectRep = new kk_sms.masterManagement.customer.rep_list(this);
                form_selectRep.ShowDialog(this);
            } 
            else if(e.KeyChar == (char)Keys.Enter && inputValue != "-")
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                    if (!inputValue.All(char.IsDigit))
                    {
                        label_description.Text = "番号を入力してください。";
                    }
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname FROM m_tokuisaki WHERE tokuisakino = " + inputValue;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        rep_content.Text = result.ToString();
                    } 
                    else
                    {
                        label_description.Text = "入力内容が存在しません。";
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    rep_content.Text = ""; 
                }
            }
        }
    }
}
