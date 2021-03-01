
namespace kk_sms.masterManagement
{
    partial class Form_supplier
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_supplier));
            this.supplier_label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplier_label_title
            // 
            this.supplier_label_title.BackColor = System.Drawing.Color.DarkRed;
            this.supplier_label_title.Font = new System.Drawing.Font("Meiryo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.supplier_label_title.ForeColor = System.Drawing.Color.Gold;
            this.supplier_label_title.Location = new System.Drawing.Point(17, 40);
            this.supplier_label_title.Name = "supplier_label_title";
            this.supplier_label_title.Size = new System.Drawing.Size(200, 45);
            this.supplier_label_title.TabIndex = 0;
            this.supplier_label_title.Text = "仕⼊先DB管理";
            this.supplier_label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(17, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 150);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "一覧表示( &L )";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "仕⼊先削除( &D )";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "仕⼊先追加( &A ) ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(40, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 30);
            this.button4.TabIndex = 2;
            this.button4.Text = "キャンセル( &C )";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form_supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 341);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.supplier_label_title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕⼊先DB管理";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Label supplier_label_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}