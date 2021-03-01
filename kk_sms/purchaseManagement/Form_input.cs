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
        private bool isOrdernoExist = true;
        private bool isRepInvalid = true;
        private bool isSupplierInvalid = true;
        private bool isProductInvalid = true;
        private bool isGradeInvalid = true;
        private bool isClassInvalid = true;
        private bool isPackingInvalid = true;

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
                label_description.Text = "伝票番号は数字でなければなりません。";
                button_correction.Focus();
            }
            else if (slipNo != "" && Int32.Parse(slipNo) >= 800)
            {
                label_description.Text = "伝票番号に（800）以上の数値が入力されました!";
            }
            else
            {
                try
                {
                    var iniparser = new FileIniDataParser();
                    IniData inidata = iniparser.ReadFile("kk_sms.ini");
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var inputValue = textBox_slipNo.Text;
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT uid FROM tbl_nyuko WHERE orderno = " + inputValue;
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        label_description.Text = "入力された伝票番号は既にあります";
                        isOrdernoExist = true;
                    }
                    else
                    {
                        label_description.Text = "";
                        isOrdernoExist = false;
                    }
                    mysqlConnection.Close();
                }
                catch (Exception ex)
                {
                    label_description.Text = "";
                }
            }
        }

        private void TextBox_repCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_repCode.Text;
            if (inputValue == "-")
            {
                var form_selectRep = new kk_sms.purchaseManagement.Form_input_selectRep(this);
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
            isRepInvalid = false;
        }

        private void TextBox_supplierCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_supplierCode.Text;
            if (inputValue == "-")
            {
                var form_selectSupplier = new kk_sms.purchaseManagement.Form_input_selectSupplier(this);
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

        private void TextBox_productCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_productCode.Text;
            if (inputValue == "-")
            {
                var form_selectProduct = new kk_sms.purchaseManagement.Form_input_selectProduct(this);
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

        private void TextBox_gradeCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_gradeCode.Text;
            if (inputValue == "-")
            {
                var form_selectGrade = new kk_sms.purchaseManagement.Form_input_selectGrade(this);
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

        private void TextBox_classCode_TextChanged(object sender, EventArgs e)
        {
            var inputValue = textBox_classCode.Text;
            if (inputValue == "-")
            {
                var form_selectClass = new kk_sms.purchaseManagement.Form_input_selectClass(this);
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
                var form_selectPacking = new kk_sms.purchaseManagement.Form_input_selectPacking(this);
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
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
            string irisu = textBox_quantity.Text;
            string siiresu = textBox_purchaseQuantity.Text;
            string nisugatano = textBox_packingCode.Text;
            string nisugataname = textBox_packing.Text;
            string zaikosu = siiresu;
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
            else if (orderno != "" && Int32.Parse(orderno) >= 800)
            {
                label_description.Text = "伝票番号に（800）以上の数値が入力されました!";
            }
            else if (isOrdernoExist)
            {
                label_description.Text = "入力された伝票番号は既にあります";
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
            else if (!float.TryParse(tanka, out temp_float))
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
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "INSERT INTO tbl_nyuko(orderno, nyukoday, syainno, syainname, siireno, siirename, hinban, hinmaei, toukyuno, toukyuname, kaikyuno, kaikyuname, irisu, siiresu, nisugatano, nisugataname, zaikosu, souurisu, tanka, kingaku, kuban, nyuukokubun, zaikoadjust1, zaikoadjust2, zaikoadjust3, adjustCumulative1, adjustCumulative2, adjustCumulative3) VALUES('" + orderno + "','" + nyukoday + "','" + syainno + "','" + syainname + "','" + siireno + "','" + siirename + "','" + hinban + "','" + hinmaei + "','" + toukyuno + "','" + toukyuname + "','" + kaikyuno + "','" + kaikyuname + "','" + irisu + "','" + siiresu + "','" + nisugatano + "','" + nisugataname + "','" + zaikosu + "','" + souurisu + "','" + tanka + "','" + kingaku + "','" + kuban + "','" + nyuukokubun + "','" + zaikoadjust1 + "','" + zaikoadjust2 + "','" + zaikoadjust3 + "','" + adjustCumulative1 + "','" + adjustCumulative2 + "','" + adjustCumulative3 + "')";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    MySqlDataReader mySqlDataReader = sqlCommand.ExecuteReader();
                    mysqlConnection.Close();
                    label_description.Text = "入力データが正常に登録されました";
                    isOrdernoExist = true;
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
    }
}
