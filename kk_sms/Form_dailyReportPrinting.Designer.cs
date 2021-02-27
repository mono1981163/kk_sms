
namespace kk_sms
{
    partial class Form_dailyReportPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_dailyReportPrinting));
            this.label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(29, 19);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(402, 60);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "日報印字出力";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(29, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 179);
            this.panel1.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(210, 125);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(175, 35);
            this.button6.TabIndex = 5;
            this.button6.Text = "在庫チェックリスト ( &Z )";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(210, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(175, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "担当者別売上集計表 ( &H )";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(210, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "仕入先別仕入一覧表 ( &L )";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "仕入先別仕入明細表 ( &S )";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "現金取引先売上一覧表 ( &G )";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "代払別売上一覧表 ( &D )";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(109, 291);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(240, 35);
            this.button7.TabIndex = 2;
            this.button7.Text = "終了 ・ 戻る ( &E )";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(29, 343);
            this.label_description.Name = "label_description";
            this.label_description.Padding = new System.Windows.Forms.Padding(2);
            this.label_description.Size = new System.Drawing.Size(402, 17);
            this.label_description.TabIndex = 3;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_dailyReportPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 376);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_dailyReportPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日報出力";
            this.Load += new System.EventHandler(this.Form_dailyReportPrinting_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label_description;
    }
}