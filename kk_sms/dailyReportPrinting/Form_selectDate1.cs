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
using System.Configuration;
using MySql.Data.MySqlClient;

namespace kk_sms.dailyReportPrinting
{
    public partial class Form_selectDate1 : Form
    {
        public Form_selectDate1()
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
                saveFileDialog_savePdf.FileName = "代払別売上一覧表__" + date;
                if (saveFileDialog_savePdf.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog_savePdf.FileName;
                    PdfWriter writer = new PdfWriter(filename);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    PdfFont myfont = PdfFontFactory.CreateFont("HeiseiMin-W3", "UniJIS-UCS2-H");
                    document.SetFont(myfont);
                    Paragraph paragraph;
                    paragraph = new Paragraph("代払別売上一覧表")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(16);
                    document.Add(paragraph);
                    paragraph = new Paragraph(DateTime.Now.ToString("yyyy年 MM月 dd日"))
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
                    string mysqlConf = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
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
                    MessageBox.Show("PDFファイルが正常に作成されました。");
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
