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
    public partial class Form_selectDate2 : Form
    {
        public Form_selectDate2()
        {
            InitializeComponent();
        }

        private void Form_selectDate2_Load(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var date = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Close();
            var iniparser = new FileIniDataParser();
            IniData inidata = iniparser.ReadFile("kk_sms.ini");
            saveFileDialog_savePdf.InitialDirectory = inidata["Pdf"]["path"];
            saveFileDialog_savePdf.RestoreDirectory = true;
            saveFileDialog_savePdf.FileName = "現金取引先売上一覧表__" + date;
            if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
            {
                var folderPath = inidata["Pdf"]["path"];

            string filename = saveFileDialog_savePdf.FileName;
            PdfWriter writer = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            
            PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
            document.SetFont(myfont);
            Paragraph paragraph;
            paragraph = new Paragraph("現金取引先売上一覧表")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(16);
            document.Add(paragraph);
            paragraph = new Paragraph(this.dateTimePicker1.Value.ToString("yyyy年 MM月 dd日"))
               .SetTextAlignment(TextAlignment.RIGHT)
               .SetFontSize(14);
            document.Add(paragraph);

            // Add table
            Table table = new Table(9, false);
            table.SetFontSize(12);
            table.SetWidth(UnitValue.CreatePercentValue(100));
            Cell cell;
            String temp;
            // Database Connection
            string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
            var mysqlConnection = new MySqlConnection(mysqlConf);
            mysqlConnection.Open();
                try
                {


                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("番号"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("得意先名"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("売上日額"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当日税"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当日売上"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("利益率(%)"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("売上月額"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当月税"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("当月売上"));
                    table.AddCell(cell);


                    string query = "SELECT h.tokuisakino , h.tokuisakiname , IFNULL(SUM(CASE WHEN hday = '" + date + "' THEN h.kingaku END),''),IFNULL(SUM(CASE WHEN hday = '" + date + "' THEN h.kingaku END) *  m.zei,'') ,IFNULL(SUM(CASE WHEN hday = '" + date + "' THEN h.kingaku END),''),IFNULL(SUM(CASE WHEN hday = '" + date + "' THEN h.kingaku END)  - ( (SELECT SUM(kingaku) FROM tbl_nyuko WHERE nyukoday = '" + date + "') / SUM(CASE WHEN hday = '" + date + "' THEN h.kingaku END)  ),'') ,IFNULL(SUM(CASE WHEN hday BETWEEN  '" + date + "' AND '" + date + "'  THEN h.kingaku END),'') ,IFNULL(SUM(CASE WHEN hday BETWEEN  '" + date + "' AND '" + date + "'  THEN h.kingaku END) * m.zei,''), IFNULL(SUM(CASE WHEN hday BETWEEN  '" + date + "' AND '" + date + "'  THEN h.kingaku END),'') FROM tbl_hanbai h , m_zei m GROUP BY h.tokuisakino,h.tokuisakiname";
                    //string query = "SELECT daino, dainame, daysales, discount, netsales, monthsales, daytax, monthtax FROM tbl_daibarai WHERE dday LIKE '" + date + "%' ORDER BY daino";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();

                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            for (int i = 0; i < 9; i++)
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
                        cell = new Cell(1, 9)
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
                catch (Exception ex)
                {
                   
                      MessageBox.Show(ex.Message);
                   
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
