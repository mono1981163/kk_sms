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
    public partial class Form_correct : Form
    {
        private bool isOrdernoDontExist = true;
        private bool isRepInvalid = true;
        private bool isSupplierInvalid = true;
        private bool isProductInvalid = true;
        private bool isGradeInvalid = true;
        private bool isClassInvalid = true;
        private bool isPackingInvalid = true;

        public Form_correct()
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
            else if (slipNo == "-")
            {
                var form_selectOrder = new kk_sms.purchaseManagement.Form_correct_selectOrder(this);
                form_selectOrder.ShowDialog(this);
            }
            else if (!slipNo.All(char.IsDigit))
            {
                label_description.Text = "伝票番号は数字でなければなりません。";
                button_correction.Focus();
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                    var inputValue = textBox_slipNo.Text;
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT * FROM tbl_nyuko WHERE orderno = " + inputValue;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        result.Read();
                        textBox_date.Text = result.GetValue(2).ToString();
                        textBox_slipNo.Text = result.GetValue(1).ToString();
                        textBox_repCode.Text = result.GetValue(3).ToString();
                        textBox_rep.Text = result.GetValue(4).ToString();
                        textBox_supplierCode.Text = result.GetValue(5).ToString();
                        textBox_supplier.Text = result.GetValue(6).ToString();
                        textBox_productCode.Text = result.GetValue(7).ToString();
                        textBox_productName.Text = result.GetValue(8).ToString();
                        textBox_gradeCode.Text = result.GetValue(9).ToString();
                        textBox_grade.Text = result.GetValue(10).ToString();
                        textBox_classCode.Text = result.GetValue(11).ToString();
                        textBox_class.Text = result.GetValue(12).ToString();
                        textBox_quantity.Text = result.GetValue(13).ToString();
                        textBox_packingCode.Text = result.GetValue(15).ToString();
                        textBox_packing.Text = result.GetValue(16).ToString();
                        textBox_purchaseQuantity.Text = result.GetValue(14).ToString();
                        textBox_unitPrice.Text = result.GetValue(19).ToString();
                        textBox_amount.Text = result.GetValue(20).ToString();
                        label_description.Text = "";
                        isOrdernoDontExist = false;
                        isRepInvalid = false;
                        isSupplierInvalid = false;
                        isProductInvalid = false;
                        isGradeInvalid = false;
                        isClassInvalid = false;
                        isPackingInvalid = false;
                    }
                    else
                    {
                        label_description.Text = "そのようなデータはありません";
                        textBox_date.Text = "";
                        textBox_repCode.Text = "";
                        textBox_rep.Text = "";
                        textBox_supplierCode.Text = "";
                        textBox_supplier.Text = "";
                        textBox_productCode.Text = "";
                        textBox_productName.Text = "";
                        textBox_gradeCode.Text = "";
                        textBox_grade.Text = "";
                        textBox_classCode.Text = "";
                        textBox_class.Text = "";
                        textBox_quantity.Text = "";
                        textBox_packingCode.Text = "";
                        textBox_packing.Text = "";
                        textBox_purchaseQuantity.Text = "";
                        textBox_unitPrice.Text = "";
                        textBox_amount.Text = "";
                        isOrdernoDontExist = true;
                        isRepInvalid = true;
                        isSupplierInvalid = true;
                        isProductInvalid = true;
                        isGradeInvalid = true;
                        isClassInvalid = true;
                        isPackingInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    label_description.Text = "";
                }
            }
        }

        public void changeData(string[] param)
        {
            textBox_date.Text = param[1];
            textBox_slipNo.Text = param[0];
            textBox_repCode.Text = param[2];
            textBox_rep.Text = param[3];
            textBox_supplierCode.Text = param[4];
            textBox_supplier.Text = param[5];
            textBox_productCode.Text = param[6];
            textBox_productName.Text = param[7];
            textBox_gradeCode.Text = param[8];
            textBox_grade.Text = param[9];
            textBox_classCode.Text = param[10];
            textBox_class.Text = param[11];
            textBox_quantity.Text = param[12];
            textBox_packingCode.Text = param[14];
            textBox_packing.Text = param[15];
            textBox_purchaseQuantity.Text = param[13];
            textBox_unitPrice.Text = param[18];
            textBox_amount.Text = param[19];
        }

        private void TextBox_repCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_repCode.Text;
            if (inputValue == "-")
            {
                var form_selectRep = new kk_sms.purchaseManagement.Form_correct_selectRep(this);
                form_selectRep.ShowDialog(this);
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
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

        private void TextBox_supplierCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_supplierCode.Text;
            if (inputValue == "-")
            {
                var form_selectSupplier = new kk_sms.purchaseManagement.Form_correct_selectSupplier(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
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

        private void TextBox_productCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_productCode.Text;
            if (inputValue == "-")
            {
                var form_selectProduct = new kk_sms.purchaseManagement.Form_correct_selectProduct(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
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

        private void TextBox_gradeCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_gradeCode.Text;
            if (inputValue == "-")
            {
                var form_selectGrade = new kk_sms.purchaseManagement.Form_correct_selectGrade(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
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

        private void TextBox_classCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_classCode.Text;
            if (inputValue == "-")
            {
                var form_selectClass = new kk_sms.purchaseManagement.Form_correct_selectClass(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
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
            var inputValue = textBox_packingCode.Text;
            if (inputValue == "-")
            {
                var form_selectPacking = new kk_sms.purchaseManagement.Form_correct_selectPacking(this);
                form_selectPacking.ShowDialog(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT nisugataname FROM m_nisugata WHERE nisugatano = " + inputValue;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        textBox_packing.Text = result.ToString();
                        isPackingInvalid = false;
                    }
                    else
                    {
                        textBox_packing.Text = "";
                        isPackingInvalid = true;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    textBox_packing.Text = "";
                    isPackingInvalid = true;
                }
            }
        }
        public void change_packing(string code, string name)
        {
            textBox_packingCode.Text = code;
            textBox_packing.Text = name;
        }

        private void TextBox_purchaseQuantity_TextChanged(object sender, EventArgs e)
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

        private void TextBox_unitPrice_TextChanged(object sender, EventArgs e)
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

        private void Button_ok_Click(object sender, EventArgs e)
        {
            string orderno = textBox_slipNo.Text;
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
            string irisu = textBox_quantity.Text;
            string siiresu = textBox_purchaseQuantity.Text;
            string nisugatano = textBox_packingCode.Text;
            string nisugataname = textBox_packing.Text;
            string tanka = textBox_unitPrice.Text;
            string kingaku = textBox_amount.Text;

            string query = "UPDATE tbl_nyuko SET";
            query += " syainno = '" + syainno;
            query += "', syainname = '" + syainname;
            query += "', siireno = '" + siireno;
            query += "', siirename = '" + siirename;
            query += "', hinban = '" + hinban;
            query += "', hinmaei = '" + hinmaei;
            query += "', toukyuno = '" + toukyuno;
            query += "', toukyuname = '" + toukyuname;
            query += "', kaikyuno = '" + kaikyuno;
            query += "', kaikyuname = '" + kaikyuname;
            query += "', irisu = '" + irisu;
            query += "', siiresu = '" + siiresu;
            query += "', nisugatano = '" + nisugatano;
            query += "', nisugataname = '" + nisugataname;
            query += "', tanka = '" + tanka;
            query += "', kingaku = '" + kingaku;
            query += "' WHERE orderno = '" + orderno + "';";
            float temp_float;

            if (orderno == "")
            {
                label_description.Text = "伝票番号を入力してください";
                button_correction.Focus();
            }
            else if (!orderno.All(char.IsDigit))
            {
                label_description.Text = "伝票番号は数字でなければなりません";
                button_correction.Focus();
            }    
            else if (isOrdernoDontExist)
            {
                label_description.Text = "そのようなデータはありません";
                button_correction.Focus();
            }
            else if (isRepInvalid)
            {
                label_description.Text = "担当者コードが無効です";
                button_correction.Focus();
            }
            else if (isSupplierInvalid)
            {
                label_description.Text = "仕入先コードが無効です";
                button_correction.Focus();
            }
            else if (isProductInvalid)
            {
                label_description.Text = "商品コードが無効です";
                button_correction.Focus();
            }
            else if (isGradeInvalid)
            {
                label_description.Text = "等級コードが無効です";
                button_correction.Focus();
            }
            else if (isClassInvalid)
            {
                label_description.Text = "階級コードが無効です";
                button_correction.Focus();
            }
            else if (!irisu.All(char.IsDigit))
            {
                label_description.Text = "入数は数字でなければなりません";
                button_correction.Focus();
            }
            else if (isPackingInvalid)
            {
                label_description.Text = "荷姿コードが無効です";
                button_correction.Focus();
            }
            else if (!float.TryParse(siiresu, out temp_float))
            {
                label_description.Text = "仕入数量が無効です";
                button_correction.Focus();
            }
            else if (temp_float <= 0)
            {
                label_description.Text = "仕入数量は0より大きくなければなりません";
                button_correction.Focus();
            }
            else if (!float.TryParse(siiresu, out temp_float))
            {
                label_description.Text = "単価が無効です";
                button_correction.Focus();
            }
            else if (temp_float <= 0)
            {
                label_description.Text = "単価は0より大きくなければなりません";
                button_correction.Focus();
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    mysqlConnection.Close();
                    form_init();
                    label_description.Text = "正常に変更されました";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void slipNo_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_repCode;
            }
        }

        private void repCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_supplierCode;
            }
        }

        private void supplierCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_productCode;
            }
        }

        private void productCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_gradeCode;
            }
        }

        private void gradeCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_classCode;
            }
        }

        private void classCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_quantity;
            }
        }

        private void quantity_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_packingCode;
            }
        }

        private void packingCode_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_purchaseQuantity;
            }
        }

        private void purchaseQuantity_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = textBox_unitPrice;
            }
        }

        private void unitprice_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = button_ok;
            }
        }
        private void label_explain01(object sender, EventArgs e)
        {
            label_description.Text = "[-]で一覧入力できます,[.]で終了ボタンへ";
        }

        private void label_clear(object sender, EventArgs e)
        {
            label_description.Text = "";
        }

        private void form_init()
        {
            textBox_slipNo.Text = "";
            textBox_repCode.Text = "";
            textBox_rep.Text = "";
            textBox_supplierCode.Text = "";
            textBox_supplier.Text = "";
            textBox_productCode.Text = "";
            textBox_productName.Text = "";
            textBox_gradeCode.Text = "";
            textBox_grade.Text = "";
            textBox_classCode.Text = "";
            textBox_class.Text = "";
            textBox_quantity.Text = "";
            textBox_packingCode.Text = "";
            textBox_packing.Text = "";
            textBox_purchaseQuantity.Text = "";
            textBox_unitPrice.Text = "";
            textBox_amount.Text = "";
        }
    }
}
