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
namespace kk_sms.purchaseManagement
{
    public partial class Form_printPurchase : Form
    {
        public Form_printPurchase()
        {
            InitializeComponent();
        }

        private void Form_selectDate1_Load(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var date = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Close();
            try
            {
                var iniparser = new FileIniDataParser();
                var folderPath = "";
                IniData inidata = iniparser.ReadFile("kk_sms.ini");
                saveFileDialog_savePdf.InitialDirectory = inidata["Pdf"]["path"];

                saveFileDialog_savePdf.RestoreDirectory = true;
                saveFileDialog_savePdf.FileName = "仕入先別仕入一覧表__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    folderPath = inidata["Pdf"]["path"];
                    string filename = saveFileDialog_savePdf.FileName;
                    string tempfile = "temp.pdf";
                    PdfWriter writer = new PdfWriter(tempfile);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("仕入先別仕入一覧表")
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
                    string temp;

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
                    .Add(new Paragraph("当日仕入"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("当日税"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("当日返品"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("返品税"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("当月仕入"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("当月税"));
                    table.AddCell(cell);

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";convert zero datetime=True" + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT n.siireno, n.siirename, IFNULL((CASE WHEN n.kuban = 0 THEN SUM(n.kingaku) END), '0'), IFNULL((CASE WHEN n.kuban = 0 THEN SUM(n.kingaku) * (z.zei / 100) END), '0'), IFNULL((CASE WHEN n.kuban = 2 THEN SUM(n.kingaku) END), '0'), IFNULL((CASE WHEN n.kuban = 2 THEN SUM(n.kingaku) * (z.zei / 100) END), '0') FROM tbl_nyuko AS n, m_zei AS z WHERE nyukoday LIKE '" + date + "%' GROUP BY siireno";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            string siireno = "";
                            for (int i = 0; i < 6; i++)
                            {
                                temp = result.GetValue(i).ToString();
                                if (i == 0)
                                {
                                    siireno = temp;
                                }
                                cell = new Cell(1, 1)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .Add(new Paragraph(temp));
                                table.AddCell(cell);
                            }
                            var mysqlConnection1 = new MySqlConnection(mysqlConf);
                            mysqlConnection1.Open();
                            string query1 = "SELECT SUM(n.kingaku), SUM(n.kingaku) * (z.zei/100) FROM tbl_nyuko n,m_zei z  WHERE nyukoday LIKE '" + dateTimePicker1.Value.ToString("yyyy-MM") + "%' AND siireno = '" + siireno + "'";
                            MySqlCommand sqlCommand1 = new MySqlCommand(query1, mysqlConnection1);
                            var result1 = sqlCommand1.ExecuteReader();
                            result1.Read();
                            cell = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(result1.GetValue(0).ToString()));
                            table.AddCell(cell);
                            cell = new Cell(1, 1)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .Add(new Paragraph(result1.GetValue(1).ToString()));
                            table.AddCell(cell);
                            mysqlConnection1.Close();
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
                    PdfDocument pdfDoc = new PdfDocument(new PdfReader(tempfile), new PdfWriter(filename));
                    Document doc = new Document(pdfDoc);
                    int numberOfPages = pdfDoc.GetNumberOfPages();
                    for (int i = 1; i <= numberOfPages; i++)
                    {

                        // Write aligned text to the specified by parameters point
                        doc.ShowTextAligned(new Paragraph("Page " + i),
                                559, 826, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                    }

                    doc.Close();
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
                        fileToLocate = new FileInfo(filename);

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

        private void saveFileDialog_savePdf_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
