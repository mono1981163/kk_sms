
namespace kk_sms.purchaseManagement
{
    partial class Form_correct_selectOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_correct_selectOrder));
            this.label_title = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orderno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyukoday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syainno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syainname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siireno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siirename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinmaei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toukyuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toukyuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaikyuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaikyuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siiresu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nisugatano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nisugataname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaikosu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.souurisu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kingaku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nyuukokubun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaikoadjust1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaikoadjust2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaikoadjust3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjustCumulative1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjustCumulative2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjustCumulative3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.DarkGreen;
            this.label_title.Font = new System.Drawing.Font("Meiryo", 16F);
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(86, 22);
            this.label_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(284, 52);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "仕入データー覽";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderno,
            this.nyukoday,
            this.syainno,
            this.syainname,
            this.siireno,
            this.siirename,
            this.hinban,
            this.hinmaei,
            this.toukyuno,
            this.toukyuname,
            this.kaikyuno,
            this.kaikyuname,
            this.irisu,
            this.siiresu,
            this.nisugatano,
            this.nisugataname,
            this.zaikosu,
            this.souurisu,
            this.tanka,
            this.kingaku,
            this.kuban,
            this.nyuukokubun,
            this.zaikoadjust1,
            this.zaikoadjust2,
            this.zaikoadjust3,
            this.adjustCumulative1,
            this.adjustCumulative2,
            this.adjustCumulative3});
            this.dataGridView1.Location = new System.Drawing.Point(21, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(419, 194);
            this.dataGridView1.TabIndex = 2;
            // 
            // orderno
            // 
            this.orderno.HeaderText = "伝票番号";
            this.orderno.Name = "orderno";
            this.orderno.ReadOnly = true;
            this.orderno.Width = 77;
            // 
            // nyukoday
            // 
            this.nyukoday.HeaderText = "日付";
            this.nyukoday.Name = "nyukoday";
            this.nyukoday.ReadOnly = true;
            this.nyukoday.Width = 55;
            // 
            // syainno
            // 
            this.syainno.HeaderText = "社員番号";
            this.syainno.Name = "syainno";
            this.syainno.ReadOnly = true;
            this.syainno.Width = 77;
            // 
            // syainname
            // 
            this.syainname.HeaderText = "氏名";
            this.syainname.Name = "syainname";
            this.syainname.ReadOnly = true;
            this.syainname.Width = 55;
            // 
            // siireno
            // 
            this.siireno.HeaderText = "仕番";
            this.siireno.Name = "siireno";
            this.siireno.ReadOnly = true;
            this.siireno.Width = 55;
            // 
            // siirename
            // 
            this.siirename.HeaderText = "仕入先";
            this.siirename.Name = "siirename";
            this.siirename.ReadOnly = true;
            this.siirename.Width = 66;
            // 
            // hinban
            // 
            this.hinban.HeaderText = "品番";
            this.hinban.Name = "hinban";
            this.hinban.ReadOnly = true;
            this.hinban.Width = 55;
            // 
            // hinmaei
            // 
            this.hinmaei.HeaderText = "品名";
            this.hinmaei.Name = "hinmaei";
            this.hinmaei.ReadOnly = true;
            this.hinmaei.Width = 55;
            // 
            // toukyuno
            // 
            this.toukyuno.HeaderText = "等番";
            this.toukyuno.Name = "toukyuno";
            this.toukyuno.ReadOnly = true;
            this.toukyuno.Width = 55;
            // 
            // toukyuname
            // 
            this.toukyuname.HeaderText = "等級";
            this.toukyuname.Name = "toukyuname";
            this.toukyuname.ReadOnly = true;
            this.toukyuname.Width = 55;
            // 
            // kaikyuno
            // 
            this.kaikyuno.HeaderText = "階番";
            this.kaikyuno.Name = "kaikyuno";
            this.kaikyuno.ReadOnly = true;
            this.kaikyuno.Width = 55;
            // 
            // kaikyuname
            // 
            this.kaikyuname.HeaderText = "階級";
            this.kaikyuname.Name = "kaikyuname";
            this.kaikyuname.ReadOnly = true;
            this.kaikyuname.Width = 55;
            // 
            // irisu
            // 
            this.irisu.HeaderText = "入数";
            this.irisu.Name = "irisu";
            this.irisu.ReadOnly = true;
            this.irisu.Width = 55;
            // 
            // siiresu
            // 
            this.siiresu.HeaderText = "仕入数";
            this.siiresu.Name = "siiresu";
            this.siiresu.ReadOnly = true;
            this.siiresu.Width = 66;
            // 
            // nisugatano
            // 
            this.nisugatano.HeaderText = "荷番";
            this.nisugatano.Name = "nisugatano";
            this.nisugatano.ReadOnly = true;
            this.nisugatano.Width = 55;
            // 
            // nisugataname
            // 
            this.nisugataname.HeaderText = "荷姿";
            this.nisugataname.Name = "nisugataname";
            this.nisugataname.ReadOnly = true;
            this.nisugataname.Width = 55;
            // 
            // zaikosu
            // 
            this.zaikosu.HeaderText = "在庫数";
            this.zaikosu.Name = "zaikosu";
            this.zaikosu.ReadOnly = true;
            this.zaikosu.Width = 66;
            // 
            // souurisu
            // 
            this.souurisu.HeaderText = "総売数";
            this.souurisu.Name = "souurisu";
            this.souurisu.ReadOnly = true;
            this.souurisu.Width = 66;
            // 
            // tanka
            // 
            this.tanka.HeaderText = "単価";
            this.tanka.Name = "tanka";
            this.tanka.ReadOnly = true;
            this.tanka.Width = 55;
            // 
            // kingaku
            // 
            this.kingaku.HeaderText = "金額";
            this.kingaku.Name = "kingaku";
            this.kingaku.ReadOnly = true;
            this.kingaku.Width = 55;
            // 
            // kuban
            // 
            this.kuban.HeaderText = "区番";
            this.kuban.Name = "kuban";
            this.kuban.ReadOnly = true;
            this.kuban.Width = 55;
            // 
            // nyuukokubun
            // 
            this.nyuukokubun.HeaderText = "入庫区分";
            this.nyuukokubun.Name = "nyuukokubun";
            this.nyuukokubun.ReadOnly = true;
            this.nyuukokubun.Width = 77;
            // 
            // zaikoadjust1
            // 
            this.zaikoadjust1.HeaderText = "在庫調整1";
            this.zaikoadjust1.Name = "zaikoadjust1";
            this.zaikoadjust1.ReadOnly = true;
            this.zaikoadjust1.Width = 84;
            // 
            // zaikoadjust2
            // 
            this.zaikoadjust2.HeaderText = "在庫調整2";
            this.zaikoadjust2.Name = "zaikoadjust2";
            this.zaikoadjust2.ReadOnly = true;
            this.zaikoadjust2.Width = 84;
            // 
            // zaikoadjust3
            // 
            this.zaikoadjust3.HeaderText = "在庫調整3";
            this.zaikoadjust3.Name = "zaikoadjust3";
            this.zaikoadjust3.ReadOnly = true;
            this.zaikoadjust3.Width = 84;
            // 
            // adjustCumulative1
            // 
            this.adjustCumulative1.HeaderText = "調整累計1";
            this.adjustCumulative1.Name = "adjustCumulative1";
            this.adjustCumulative1.ReadOnly = true;
            this.adjustCumulative1.Width = 84;
            // 
            // adjustCumulative2
            // 
            this.adjustCumulative2.HeaderText = "調整累計2";
            this.adjustCumulative2.Name = "adjustCumulative2";
            this.adjustCumulative2.ReadOnly = true;
            this.adjustCumulative2.Width = 84;
            // 
            // adjustCumulative3
            // 
            this.adjustCumulative3.HeaderText = "調整累計3";
            this.adjustCumulative3.Name = "adjustCumulative3";
            this.adjustCumulative3.ReadOnly = true;
            this.adjustCumulative3.Width = 84;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(25, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "検索番号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(97, 297);
            this.textBox_search.MaximumSize = new System.Drawing.Size(400, 21);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(68, 24);
            this.textBox_search.TabIndex = 5;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(132, 337);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(102, 30);
            this.button_search.TabIndex = 6;
            this.button_search.Text = "検索 ( &S )";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(246, 337);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(102, 30);
            this.button_ok.TabIndex = 7;
            this.button_ok.Text = "OK ( &O )";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // Form_correct_selectOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 387);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Form_correct_selectOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入ー覽";
            this.Load += new System.EventHandler(this.Form_selectRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyukoday;
        private System.Windows.Forms.DataGridViewTextBoxColumn syainno;
        private System.Windows.Forms.DataGridViewTextBoxColumn syainname;
        private System.Windows.Forms.DataGridViewTextBoxColumn siireno;
        private System.Windows.Forms.DataGridViewTextBoxColumn siirename;
        private System.Windows.Forms.DataGridViewTextBoxColumn hinban;
        private System.Windows.Forms.DataGridViewTextBoxColumn hinmaei;
        private System.Windows.Forms.DataGridViewTextBoxColumn toukyuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn toukyuname;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaikyuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn kaikyuname;
        private System.Windows.Forms.DataGridViewTextBoxColumn irisu;
        private System.Windows.Forms.DataGridViewTextBoxColumn siiresu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nisugatano;
        private System.Windows.Forms.DataGridViewTextBoxColumn nisugataname;
        private System.Windows.Forms.DataGridViewTextBoxColumn zaikosu;
        private System.Windows.Forms.DataGridViewTextBoxColumn souurisu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanka;
        private System.Windows.Forms.DataGridViewTextBoxColumn kingaku;
        private System.Windows.Forms.DataGridViewTextBoxColumn kuban;
        private System.Windows.Forms.DataGridViewTextBoxColumn nyuukokubun;
        private System.Windows.Forms.DataGridViewTextBoxColumn zaikoadjust1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zaikoadjust2;
        private System.Windows.Forms.DataGridViewTextBoxColumn zaikoadjust3;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjustCumulative1;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjustCumulative2;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjustCumulative3;
    }
}