
namespace kk_sms
{
    partial class Form_voucherPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_voucherPrinting));
            this.label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(27, 14);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(280, 60);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "伝票印刷メニュー";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(27, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 167);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "売渡代金請求一覧表 ( &D )";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "販売代金請求一覧表 ( &H )";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "売渡明細書 ( &U )";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(54, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(225, 35);
            this.button4.TabIndex = 2;
            this.button4.Text = "終了 ・ 戻る ( &E )";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(27, 322);
            this.label_description.Name = "label_description";
            this.label_description.Padding = new System.Windows.Forms.Padding(2);
            this.label_description.Size = new System.Drawing.Size(280, 17);
            this.label_description.TabIndex = 3;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_voucherPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 354);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_voucherPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票印刷";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label_description;
    }
}