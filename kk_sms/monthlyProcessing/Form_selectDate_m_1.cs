﻿using System;
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

namespace kk_sms.monthlyProcessing

{
    public partial class Form_selectDate_m_1 : Form
    {
        public Form_selectDate_m_1()
        {
            InitializeComponent();
        }

        private void Form_selectDate_m_1_Load(object sender, EventArgs e)
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
                saveFileDialog_savePdf.FileName = "代払別完納奨励金印刷表__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = inidata["Pdf"]["path"];
                    string filename = saveFileDialog_savePdf.FileName;
                    string tempfile = "temp.pdf";
                    PdfWriter writer = new PdfWriter(tempfile);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("代払別完納奨励金印刷表")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16);
                    document.Add(paragraph);
                    paragraph = new Paragraph(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"))
                       .SetTextAlignment(TextAlignment.RIGHT)
                       .SetFontSize(14);
                    document.Add(paragraph);

                    // Add table
                    Table table = new Table(4, false);
                    table.SetFontSize(12);
                    table.SetWidth(UnitValue.CreatePercentValue(100));
                    Cell cell;
                    String temp;

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("買参人コード"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("金額（税抜き）"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("消費税額"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                       .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("金額（税込み）"));
                    table.AddCell(cell);

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";Character Set=utf8";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "select t.daino , t.Incentives ,  t.Incentives * (m.zei /100)  , (t.Incentives +  t.Incentives * (m.zei /100))   from m_tokuisaki t,m_zei m where t.Incentives !=0 AND mdate LIKE '" + date + "%' ";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);

                    var result = sqlCommand.ExecuteReader();

                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            for (int i = 0; i < 4; i++ )
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
                        cell = new Cell(1, 4)
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
    }
}
