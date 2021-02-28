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
using System.Diagnostics;
using System.IO;
namespace kk_sms.dailyReportPrinting
{
    public partial class Form_selectDate5 : Form
    {
        public Form_selectDate5()
        {
            InitializeComponent();
        }

        private void Form_selectDate5_Load(object sender, EventArgs e)
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
                saveFileDialog_savePdf.FileName = "担当者別売上集計表__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = inidata["Pdf"]["path"];
                    var fileName = inidata["Pdf"]["path"] + "担当者別売上集計表__" + date + ".pdf";
                    string filename = saveFileDialog_savePdf.FileName;
                    PdfWriter writer = new PdfWriter(filename);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("担当者別売上集計表")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16);
                    document.Add(paragraph);
                    paragraph = new Paragraph(this.dateTimePicker1.Value.ToString("yyyy年 MM月 dd日"))
                       .SetTextAlignment(TextAlignment.RIGHT)
                       .SetFontSize(14);
                    document.Add(paragraph);

                    // Add table
                    Table table = new Table(8, false);
                    table.SetFontSize(12);
                    table.SetWidth(UnitValue.CreatePercentValue(100));
                    Cell cell;
                    String temp;

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("番号"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("代払名"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("売上金額"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("返品・値引"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("純売上"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当月売上累計"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当日消費税"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当月消費税"));
                    table.AddCell(cell);

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT daino, dainame, daysales, discount, netsales, monthsales, daytax, monthtax FROM tbl_daibarai WHERE dday LIKE '" + date + "%' ORDER BY daino";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            for (int i = 0; i < 8; i++ )
                            {
                                temp = result.GetString(i);
                                cell = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(temp));
                                table.AddCell(cell);
                            }
                        }
                    }
                    else
                    {
                        cell = new Cell(1, 8)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph("データが存在しません"));
                        table.AddCell(cell);
                    }
                    mysqlConnection.Close();
                    document.Add(table);
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
                        fileToLocate = new FileInfo(fileName);

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
