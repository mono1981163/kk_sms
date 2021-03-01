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
using System.IO;
using System.Diagnostics;
namespace kk_sms.dailyReportPrinting
{
    public partial class Form_selectDate3 : Form
    {
        public Form_selectDate3()
        {
            InitializeComponent();
        }

        private void Form_selectDate3_Load(object sender, EventArgs e)
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
                saveFileDialog_savePdf.FileName = "仕入先別仕入明細書__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    var folderPath = inidata["Pdf"]["path"];
                    var filePathName = inidata["Pdf"]["path"] + "仕入先別仕入明細書__" + date + ".pdf";
                    string filename = saveFileDialog_savePdf.FileName;
                    PdfWriter writer = new PdfWriter(filename);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("仕入先別仕入明細書")
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
                    .Add(new Paragraph("伝票番号"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("商 品 名"));
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
                    .Add(new Paragraph("数量"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("単価"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("金額"));
                    table.AddCell(cell);

                    cell = new Cell(1, 1)
                    .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("担当者"));
                    table.AddCell(cell);

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                   string query = "SELECT orderno,siirename,toukyuname,kaikyuname,siiresu,tanka,kingaku,syainname FROM tbl_nyuko WHERE nyukoday LIKE '" + date + "%' ORDER BY orderno";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            for (int i = 0; i < 8; i++)
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