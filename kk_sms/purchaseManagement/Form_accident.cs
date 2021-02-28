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
    public partial class Form_accident : Form
    {

        private bool isOrdernoDontExist = true;
        private bool isRepInvalid = true;
        private bool isSupplierInvalid = true;
        private bool isProductInvalid = true;
        private bool isGradeInvalid = true;
        private bool isClassInvalid = true;
        private bool isPackingInvalid = true;

        public Form_accident()
        {
            InitializeComponent();
        }

        private void Form_accident_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_slipNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_repCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_repCode.Text;
            if (inputValue == "-")
            {
                var form_selectRep = new kk_sms.purchaseManagement.Form_accident_selectRep(this);
                form_selectRep.ShowDialog(this);
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
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
                        isRepInvalid = false;
                    }
                    else
                    {
                        textBox_rep.Text = "";
                        isRepInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_rep.Text = "";
                    isRepInvalid = true;
                }
            }
        }

        public void change_rep(string code, string name)
        {
            textBox_repCode.Text = code;
            textBox_rep.Text = name;
        }

        private void textBox_supplierCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_supplierCode.Text;
            if (inputValue == "-")
            {
                var form_selectSupplier = new kk_sms.purchaseManagement.Form_accident_selectSupplier(this);
                form_selectSupplier.ShowDialog(this);
            }
            else
            {
                try
                {
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
                        isSupplierInvalid = false;
                    }
                    else
                    {
                        textBox_supplier.Text = "";
                        isSupplierInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_supplier.Text = "";
                    isSupplierInvalid = true;
                }
            }
        }

        public void change_supplier(string code, string name)
        {
            textBox_supplierCode.Text = code;
            textBox_supplier.Text = name;
        }

        private void textBox_productCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_productCode.Text;
            if (inputValue == "-")
            {
                var form_selectProduct = new kk_sms.purchaseManagement.Form_accident_selectProduct(this);
                form_selectProduct.ShowDialog(this);
            }
            else
            {
                try
                {
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
                        isProductInvalid = false;
                    }
                    else
                    {
                        textBox_productName.Text = "";
                        isProductInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_productName.Text = "";
                    isProductInvalid = true;
                }
            }
        }

        public void change_product(string code, string name)
        {
            textBox_productCode.Text = code;
            textBox_productName.Text = name;
        }

        private void textBox_gradeCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_gradeCode.Text;
            if (inputValue == "-")
            {
                var form_selectGrade = new kk_sms.purchaseManagement.Form_accident_selectGrade(this);
                form_selectGrade.ShowDialog(this);
            }
            else
            {
                try
                {
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
                        isGradeInvalid = false;
                    }
                    else
                    {
                        textBox_grade.Text = "";
                        isGradeInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_grade.Text = "";
                    isGradeInvalid = true;
                }
            }
        }

        public void change_grade(string code, string name)
        {
            textBox_gradeCode.Text = code;
            textBox_grade.Text = name;
        }

        private void textBox_classCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_classCode.Text;
            if (inputValue == "-")
            {
                var form_selectClass = new kk_sms.purchaseManagement.Form_accident_selectClass(this);
                form_selectClass.ShowDialog(this);
            }
            else
            {
                try
                {
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
                        isClassInvalid = false;
                    }
                    else
                    {
                        textBox_class.Text = "";
                        isClassInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_class.Text = "";
                    isClassInvalid = true;
                }
            }
        }

        public void change_class(string code, string name)
        {
            textBox_classCode.Text = code;
            textBox_class.Text = name;
        }

        private void textBox_accidentCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_accidentCode.Text;
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                if (!inputValue.All(char.IsDigit))
                {
                    button_correction.Focus();
                }
                var mysqlConnection = new MySqlConnection(mysqlConf);
                mysqlConnection.Open();
                string query = "SELECT kmubunname FROM m_nyukokbn WHERE kubunno = " + inputValue;
                MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                var result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    textBox_accident.Text = result.ToString();
                    isRepInvalid = false;
                }
                else
                {
                    textBox_accident.Text = "";
                    isRepInvalid = true;
                }
                mysqlConnection.Close();
            }
            catch (Exception ex)
            {
                textBox_accident.Text = "";
                isRepInvalid = true;
            }
        }

        private void textBox_purchaseQuantity_TextChanged(object sender, EventArgs e)
        {
            float temp_float;
            float temp_float2;
            try
            {
                var inputValue = textBox_purchaseQuantity.Text;
                if (!float.TryParse(inputValue, out temp_float))
                {
                    button_correction.Focus();
                }
                else if (float.TryParse(textBox_unitPrice.Text, out temp_float2))
                {
                    textBox_amount.Text = (temp_float * temp_float2).ToString();
                }
            }
            catch (Exception ex)
            {
                textBox_amount.Text = "";
            }
        }

        private void textBox_unitPrice_TextChanged(object sender, EventArgs e)
        {
            float temp_float;
            float temp_float2;
            try
            {
                var inputValue = textBox_unitPrice.Text;
                if (!float.TryParse(inputValue, out temp_float))
                {
                    button_correction.Focus();
                }
                else if (float.TryParse(textBox_purchaseQuantity.Text, out temp_float2))
                {
                    textBox_amount.Text = (temp_float * temp_float2).ToString();
                }
            }
            catch (Exception ex)
            {
                textBox_amount.Text = "";
            }
        }

        private void textBox_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {

        }

        private void button_correction_Click(object sender, EventArgs e)
        {
            textBox_slipNo.Focus();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
