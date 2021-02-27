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
    public partial class Form_input : Form
    {
        public Form_input()
        {
            InitializeComponent();
        }

        private void Form_input_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            textBox_date.Text = date;
        }

        private void TextBox_slipNo_TextChanged(object sender, EventArgs e)
        {
            var slipNo = textBox_slipNo.Text;
            if (slipNo.EndsWith("。") || slipNo.EndsWith("．") || slipNo.EndsWith("."))
            {
                button_exit.Focus();
            }
            else if (!slipNo.All(char.IsDigit))
            {
                button_correction.Focus();
            }
        }

        private void TextBox_repCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var inputValue = textBox_repCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT login_name FROM m_user WHERE user_id = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_rep.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_rep.Text = "";
            }

        }

        private void TextBox_supplierCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_supplierCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT siirename FROM m_siire WHERE siireno = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null) 
                {
                    textBox_supplier.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_supplier.Text = "";
            }
        }

        private void TextBox_productCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_productCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT hinmei FROM m_hinban WHERE hinban = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_productName.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_productName.Text = "";
            }
        }

        private void TextBox_gradeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_gradeCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT toukyuname FROM m_tokyu WHERE toukyuno = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_grade.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_grade.Text = "";
            }
        }

        private void TextBox_classCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_classCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT kaikyuname FROM m_kaikyu WHERE kaikyuno = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_class.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_class.Text = "";
            }
        }

        private void TextBox_quantity_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_quantity.Text;
            if (!inputValue.All(char.IsDigit))
            {
                button_correction.Focus();
            }
        }

        private void TextBox_packingCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_packingCode.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT nisugataname FROM m_nisugata WHERE nisugatano = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_packing.Text = result.ToString();
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_packing.Text = "";
            }
        }

        private void TextBox_purchaseQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_unitPrice.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var amount = Convert.ToInt64(textBox_purchaseQuantity.Text) * Convert.ToInt64(textBox_unitPrice.Text);
                textBox_amount.Text = amount.ToString();
            }
            catch (Exception ex)
            {
                textBox_amount.Text = "";
            }
        }

        private void TextBox_unitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var inputValue = textBox_unitPrice.Text;
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var amount = Convert.ToInt64(textBox_purchaseQuantity.Text) * Convert.ToInt64(textBox_unitPrice.Text);
                textBox_amount.Text = amount.ToString();
            }
            catch (Exception ex)
            {
                textBox_amount.Text = "";
            }
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            string orderno = textBox_slipNo.Text;
            string nyukoday = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string syainno = textBox_repCode.Text;
            string syainname = textBox_rep.Text;
            string siireno = textBox_supplierCode.Text;
            string siirename = textBox_supplier.Text;
            string hinban = textBox_productCode.Text;
            string hinmaei = textBox_productName.Text;
            string toukyuno = textBox_gradeCode.Text;
            string toukyuname = textBox_grade.Text;
            string kaikyuno = textBox_classCode.Text;
            string kaikyuname = textBox_class.Text;
            string irisu = "0";
            string siiresu = textBox_purchaseQuantity.Text;
            string nisugatano = textBox_packingCode.Text;
            string nisugataname = textBox_packing.Text;
            string zaikosu = textBox_quantity.Text;
            //string souurisu = (Convert.ToInt64(siiresu) - Convert.ToInt64(zaikosu)).ToString();
            string souurisu = "";

            string tanka = textBox_unitPrice.Text;
            string kingaku = textBox_amount.Text;
            string kuban = "0";
            string nyuukokubun = "";
            string zaikoadjust1 = "0";
            string zaikoadjust2 = "0";
            string zaikoadjust3 = "0";
            string adjustCumulative1 = "0";
            string adjustCumulative2 = "0";
            string adjustCumulative3 = "0";

            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "INSERT INTO tbl_nyuko(orderno, nyukoday, syainno, syainname, siireno, siirename, hinban, hinmaei, toukyuno, toukyuname, kaikyuno, kaikyuname, irisu, siiresu, nisugatano, nisugataname, zaikosu, souurisu, tanka, kingaku, kuban, nyuukokubun, zaikoadjust1, zaikoadjust2, zaikoadjust3, adjustCumulative1, adjustCumulative2, adjustCumulative3) VALUES('" + orderno + "','" + nyukoday + "','" + syainno + "','" + syainname + "','" + siireno + "','" + siirename + "','" + hinban + "','" + hinmaei + "','" + toukyuno + "','" + toukyuname + "','" + kaikyuno + "','" + kaikyuname + "','" + irisu + "','" + siiresu + "','" + nisugatano + "','" + nisugataname + "','" + zaikosu + "','" + souurisu + "','" + tanka + "','" + kingaku + "','" + kuban + "','" + nyuukokubun + "','" + zaikoadjust1 + "','" + zaikoadjust2 + "','" + zaikoadjust3 + "','" + adjustCumulative1 + "','" + adjustCumulative2 + "','" + adjustCumulative3 + "')";
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_correction_Click(object sender, EventArgs e)
        {
            textBox_slipNo.Focus();
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
