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

namespace kk_sms.salesManagement
{
    public partial class Form_salesSlipInput : Form
    {
        public Form_salesSlipInput()
        {
            InitializeComponent();
        }

        private void Form_salesSlipInput_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            label_date.Text = today;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text=="-")
            {
                var form_search1 = new kk_sms.salesManagement.Form_slipInputSearch(this);
                form_search1.Show();
            }
            else
            {
                
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

            private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox7_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox10_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox13_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox13_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox16_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox19_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }
        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox22_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }
        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_GotFocus(object sender, EventArgs e)
        {
            label48.Text = "[-]でー覧入力できます，[/]でOKボタン，[.]で終了ボタンへ";
        }

        private void textBox25_LostFocus(object sender, EventArgs e)
        {
            label48.Text = "得意先番号が入力さわませんでした";
        }
    }
}
