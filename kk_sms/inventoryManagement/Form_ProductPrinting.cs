using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using Color = iText.Kernel.Colors.Color;
using MySql.Data.MySqlClient;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Diagnostics;
namespace kk_sms.inventoryManagement
{
    public partial class Form_ProductPrinting : Form
    {
        public Form_ProductPrinting()
        {
            InitializeComponent();
        }

        private void Form_ProductPrinting_Load(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var date = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Close();
            try
            {
                var iniparser = new FileIniDataParser();
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                saveFileDialog_savePdf.InitialDirectory = inidata["Pdf"]["path"];
                saveFileDialog_savePdf.RestoreDirectory = true;
                saveFileDialog_savePdf.FileName = "在庫商品一覧表印刷__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = inidata["Pdf"]["path"];
                    var filePathName = inidata["Pdf"]["path"] + "在庫商品一覧表印刷__" + date + ".pdf";
                    string filename = saveFileDialog_savePdf.FileName;
                    PdfWriter writer = new PdfWriter(filename);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("在庫商品一覧表印刷")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16);
                    document.Add(paragraph);
                    

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT syainname FROM tbl_nyuko  GROUP BY syainname";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    // Add table
                    
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            String syainname;
                            syainname= result.GetString(0);
                            Table table = new Table(13, false);
                            table.SetFontSize(9);
                            table.SetWidth(UnitValue.CreatePercentValue(100));
                            Cell cell;
                            String temp;
                            Paragraph p = new Paragraph("担当 : " + syainname);
                            p.Add(new Tab());
                            p.AddTabStops(new TabStop(1000,iText.Layout.Properties.TabAlignment.RIGHT));
                            p.Add(this.dateTimePicker1.Value.ToString("yyyy年 MM月 dd日"));
                            document.Add(p);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("番号"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("仕入先"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("品	名"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("等級"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("階級"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("仕入数"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("阪克数"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("損品"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("盗難"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("他"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("在庫数"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("日付"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                            .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("社員"));
                            table.AddCell(cell);

                            // Database Connection
                            string mysqlConf_sec = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                            var mysqlConnection_sec = new MySqlConnection(mysqlConf_sec);
                            mysqlConnection_sec.Open();
                            string query_sec = "SELECT orderno , syainno  , hinmaei , toukyuname ,  kaikyuname , siiresu , souurisu ,'0' AS z1,'0' AS z2,'0' AS z3, zaikosu , nyukoday , syainno FROM tbl_nyuko WHERE nyukoday='" + date + "' AND syainname='" + syainname + "'";
                            MySqlCommand sqlCommand_sec = new MySqlCommand(query_sec, mysqlConnection_sec);
                            var result_sec = sqlCommand_sec.ExecuteReader();
                            if (result_sec.HasRows)
                            {
                                while (result_sec.Read())
                                {
                                    for (int i = 0; i < 13; i++)
                                    {
                                        temp = result_sec.GetString(i);
                                        cell = new Cell(1, 1)
                                            .SetTextAlignment(TextAlignment.LEFT)
                                            .Add(new Paragraph(temp));
                                        table.AddCell(cell);
                                    }
                                }
                            }
                            else
                            {
                                cell = new Cell(1, 13)
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .Add(new Paragraph("データが存在しません"));
                                table.AddCell(cell);
                            }
                            mysqlConnection_sec.Close();
                            document.Add(table);
                        }
                    }
                    else
                    {
                        Table table = new Table(13, false);
                        table.SetFontSize(9);
                        table.SetWidth(UnitValue.CreatePercentValue(100));
                        Cell cell;
                        cell = new Cell(1, 13)
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .Add(new Paragraph("データが存在しません"));
                        table.AddCell(cell);
                    }
                    
                    mysqlConnection.Close();
                    document.Close();
                    if (Directory.Exists(folderPath))
                    {
                        string windir = Environment.GetEnvironmentVariable("windir");
                        if (string.IsNullOrEmpty(windir.Trim()))
                        {
                            windir = "C:\\Windows\\";
                        }
                        if (!windir.EndsWith("\\"))
                        {
                            windir += "\\";
                        }
                        FileInfo fileToLocate = null;
                        fileToLocate = new FileInfo(filePathName);

                        ProcessStartInfo pi = new ProcessStartInfo(windir + "explorer.exe");
                        pi.Arguments = "/select, \"" + fileToLocate.FullName + "\"";
                        pi.WindowStyle = ProcessWindowStyle.Normal;
                        pi.WorkingDirectory = folderPath;

                        //Start Process
                        Process.Start(pi);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("{0} ディレクトリが存在しません!", folderPath));
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
