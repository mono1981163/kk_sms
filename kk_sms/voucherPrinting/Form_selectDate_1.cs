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

namespace kk_sms.voucherPrinting

{
    public partial class Form_selectDate_1 : Form
    {
        public object Border { get; private set; }

        public Form_selectDate_1()
        {
            InitializeComponent();
        }

        private void Form_selectDate_1_Load(object sender, EventArgs e)
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
                saveFileDialog_savePdf.FileName = "売渡明細書表__" + date;
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

                    // Database Connection
                    string mysqlConf = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                    var mysqlConnection = new MySqlConnection(mysqlConf);
                    mysqlConnection.Open();
                    string query = "SELECT tokuisakiname , tokuisakino FROM tbl_hanbai WHERE hday LIKE '" + date + "%' GROUP BY tokuisakiname";
                    MySqlCommand sqlCommand = new MySqlCommand(query, mysqlConnection);
                    var result = sqlCommand.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            String tokuisakiname, tokuisakino;

                            tokuisakiname = result.GetString(0);
                            tokuisakino = result.GetString(1);

                            paragraph = new Paragraph("売渡明細書表")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(16);
                            document.Add(paragraph);

                            paragraph = new Paragraph(tokuisakiname + "殿")
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetFontSize(14);
                            document.Add(paragraph);

                            Paragraph p = new Paragraph("得意先コード:" + " " + tokuisakino);
                            p.Add(new Tab());
                            p.AddTabStops(new TabStop(500, iText.Layout.Properties.TabAlignment.RIGHT));
                            p.Add(this.dateTimePicker1.Value.ToString("yyyy年 MM月 dd日"));
                            document.Add(p);

                            // Database Connection
                            string mysqlConf_sec = "server=" + inidata["Mysql"]["server"] + ";user=" + inidata["Mysql"]["user"] + ";database=" + inidata["Mysql"]["database"] + ";port=" + inidata["Mysql"]["port"] + ";password=" + inidata["Mysql"]["password"] + ";";
                            var mysqlConnection_sec = new MySqlConnection(mysqlConf_sec);
                            mysqlConnection_sec.Open();
                            string query_sec = "SELECT hinban ,  hinmei , toukyuname , kaikyuname , nisugataname,  hanbaisu , tanka , kingaku FROM tbl_hanbai WHERE hday LIKE '" + date;
                            query_sec += "%' AND tokuisakiname='" + tokuisakiname + "' AND tokuisakino='" + tokuisakino +"' ";
                            MySqlCommand sqlCommand_sec = new MySqlCommand(query_sec, mysqlConnection_sec);
                            var result_sec = sqlCommand_sec.ExecuteReader();

                            // Add table
                            Table table = new Table(7, false);
                            table.SetFontSize(12);
                            table.SetWidth(UnitValue.CreatePercentValue(100));
                            Cell cell;
                            String temp;

                            cell = new Cell(1, 1)
                               .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                               .SetTextAlignment(TextAlignment.CENTER)
                               .Add(new Paragraph("商品コード"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                               .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                               .SetTextAlignment(TextAlignment.CENTER)
                               .Add(new Paragraph("品名"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                               .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                               .SetTextAlignment(TextAlignment.CENTER)
                               .Add(new Paragraph("等階級"));
                            table.AddCell(cell);

                            cell = new Cell(1, 1)
                               .SetBackgroundColor(WebColors.GetRGBColor("#dddddd"))
                               .SetTextAlignment(TextAlignment.CENTER)
                               .Add(new Paragraph("数 量"));
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
                               .Add(new Paragraph("摘要"));
                            table.AddCell(cell);

                            if (result_sec.HasRows)
                            {
                                while (result_sec.Read())
                                {
                                    for (int i = 0; i < 8; i++)
                                    {
                                        temp = result_sec.GetString(i);
                                        if(i == 2 || i == 3)
                                        {

                                        }
                                        else if(i == 4)
                                        {
                                            cell = new Cell(1, 1)
                                                .SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(result_sec.GetString(2) + " / " + result_sec.GetString(3) + temp));
                                            table.AddCell(cell);
                                        }
                                        else
                                        {
                                            cell = new Cell(1, 1)
                                                .SetTextAlignment(TextAlignment.LEFT)
                                                .Add(new Paragraph(temp));
                                            table.AddCell(cell);
                                        }
                                    }
                                    cell = new Cell(1, 1)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .Add(new Paragraph(" "));
                                    table.AddCell(cell);

                                }

                            }
                            else
                            {
                                cell = new Cell(1, 7)
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
                        paragraph = new Paragraph("データが存在しません")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(16);
                        document.Add(paragraph);
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
