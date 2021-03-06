﻿
namespace kk_sms.masterManagement.consumption_tax
{
    partial class tax_modify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tax_modify));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_day = new System.Windows.Forms.TextBox();
            this.textBox_month = new System.Windows.Forms.TextBox();
            this.textBox_year = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_interest_rate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_current_tax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Meiryo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "消費税設定変更";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_day);
            this.groupBox1.Controls.Add(this.textBox_month);
            this.groupBox1.Controls.Add(this.textBox_year);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_interest_rate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "税率変更設定";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(270, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "日";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(199, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "月";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(131, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "年";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_day
            // 
            this.textBox_day.Font = new System.Drawing.Font("Meiryo", 6F);
            this.textBox_day.Location = new System.Drawing.Point(229, 62);
            this.textBox_day.Name = "textBox_day";
            this.textBox_day.Size = new System.Drawing.Size(40, 19);
            this.textBox_day.TabIndex = 9;
            this.textBox_day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_day.TextChanged += new System.EventHandler(this.textBox_day_TextChanged);
            this.textBox_day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.day_keypress);
            // 
            // textBox_month
            // 
            this.textBox_month.Font = new System.Drawing.Font("Meiryo", 6F);
            this.textBox_month.Location = new System.Drawing.Point(159, 63);
            this.textBox_month.Name = "textBox_month";
            this.textBox_month.Size = new System.Drawing.Size(40, 19);
            this.textBox_month.TabIndex = 8;
            this.textBox_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_month.TextChanged += new System.EventHandler(this.textBox_month_TextChanged);
            this.textBox_month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.month_keypress);
            // 
            // textBox_year
            // 
            this.textBox_year.Font = new System.Drawing.Font("Meiryo", 6F);
            this.textBox_year.Location = new System.Drawing.Point(91, 62);
            this.textBox_year.Name = "textBox_year";
            this.textBox_year.Size = new System.Drawing.Size(40, 19);
            this.textBox_year.TabIndex = 7;
            this.textBox_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_year.TextChanged += new System.EventHandler(this.textBox_year_TextChanged);
            this.textBox_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_keypress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(148, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_interest_rate
            // 
            this.textBox_interest_rate.Font = new System.Drawing.Font("Meiryo", 6F);
            this.textBox_interest_rate.Location = new System.Drawing.Point(91, 29);
            this.textBox_interest_rate.Name = "textBox_interest_rate";
            this.textBox_interest_rate.Size = new System.Drawing.Size(53, 19);
            this.textBox_interest_rate.TabIndex = 5;
            this.textBox_interest_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_interest_rate.TextChanged += new System.EventHandler(this.textBox_interest_rate_TextChanged);
            this.textBox_interest_rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rate_keypress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "開始年月日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "消費税率";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(47, 238);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 30);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "OK ( &O )";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(186, 238);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(100, 30);
            this.button_end.TabIndex = 3;
            this.button_end.Text = "終了 ( &E )";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label10.Location = new System.Drawing.Point(17, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(300, 30);
            this.label10.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Location = new System.Drawing.Point(39, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "現在の税率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_current_tax
            // 
            this.textBox_current_tax.Enabled = false;
            this.textBox_current_tax.Font = new System.Drawing.Font("Meiryo", 6F);
            this.textBox_current_tax.Location = new System.Drawing.Point(125, 85);
            this.textBox_current_tax.Name = "textBox_current_tax";
            this.textBox_current_tax.Size = new System.Drawing.Size(53, 19);
            this.textBox_current_tax.TabIndex = 6;
            this.textBox_current_tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label5.Location = new System.Drawing.Point(189, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // description_label
            // 
            this.description_label.BackColor = System.Drawing.Color.Yellow;
            this.description_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.description_label.Location = new System.Drawing.Point(17, 281);
            this.description_label.Name = "description_label";
            this.description_label.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.description_label.Size = new System.Drawing.Size(300, 17);
            this.description_label.TabIndex = 14;
            this.description_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tax_modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_current_tax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "tax_modify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消費税変更設定";
            this.Load += new System.EventHandler(this.tax_modify_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_day;
        private System.Windows.Forms.TextBox textBox_month;
        private System.Windows.Forms.TextBox textBox_year;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_interest_rate;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_current_tax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label description_label;
    }
}