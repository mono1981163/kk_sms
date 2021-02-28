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

namespace kk_sms.inventoryManagement
{
    public partial class Form_SelectPerson : Form
    {
        public Form_SelectPerson()
        {
            InitializeComponent();
        }

        private void Form_SelectPerson_Load(object sender, EventArgs e)
        {
            try
            {
                int width = 400;
                int startxpoint = 30;
                int startypoiint = 100;
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT COUNT(uid) FROM m_user";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var usernum = Int32.Parse(sqlCommand.ExecuteScalar().ToString());
                int panelheight = 40 * usernum / 2  +  20;
                var panel1 = new System.Windows.Forms.Panel();
                panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
                panel1.Location = new System.Drawing.Point(startxpoint, startypoiint);
                panel1.Name = "panel1";
                panel1.Size = new System.Drawing.Size(width, panelheight);
                panel1.TabIndex = 1;
                var top = 10;

                query = "SELECT user_id, login_name FROM m_user;";
                sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    var row_no = 0;
                    while (result.Read())
                    {
                        if (row_no % 2 == 0)
                        {
                            Button button = new Button();
                            button.Left = 10;
                            button.Top = top;
                            button.Height = 37;
                            button.Width = 180;
                            button.BackColor = System.Drawing.SystemColors.ControlDark;
                            button.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Name = "person" + row_no;
                            button.Text = "仕入担当者 (" + result.GetString(1) + ") &" + row_no;
                            var id = result.GetString(0);
                            button.UseVisualStyleBackColor = true;
                            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                            button.Click += new System.EventHandler((sender1, e1) => button_Click(sender1, e1, id));
                            panel1.Controls.Add(button);
                        }
                        else
                        {
                            Button button = new Button();
                            button.Left = 210;
                            button.Top = top;
                            button.Height = 37;
                            button.Width = 180;                           
                            button.BackColor = System.Drawing.SystemColors.ControlDark;
                            button.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            button.Name = "person" + row_no;
                            button.Text = "仕入担当者 (" + result.GetString(1) + ") &" + row_no;
                            button.UseVisualStyleBackColor = true;
                            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                            var id = result.GetString(0);
                            button.Click += new System.EventHandler((sender1, e1) => button_Click(sender1, e1, id));
                            panel1.Controls.Add(button);
                            top += button.Height + 3;
                        }
                        row_no++;
                    }
                }
                this.Controls.Add(panel1);
                this.Height = panelheight + 200;
                Button exit_button = new Button();
                exit_button.Left = 130;
                exit_button.Top = panelheight + 115;
                exit_button.Width = 180;
                exit_button.Height = 37;
                exit_button.BackColor = System.Drawing.SystemColors.ControlDark;
                exit_button.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                exit_button.Name = "exit";
                exit_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                exit_button.Text = "終  了 (&E)";
                exit_button.UseVisualStyleBackColor = true;
                exit_button.Click += new System.EventHandler(Exit_Click);
                this.Controls.Add(exit_button);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void button_Click(object sender, EventArgs e, string index)
        {
            var form = new kk_sms.inventoryManagement.Form_Adjustment(index);
            form.Show();
        }
    }
}
