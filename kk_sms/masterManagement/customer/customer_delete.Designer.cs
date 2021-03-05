
namespace kk_sms.masterManagement.customer
{
    partial class customer_delete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customer_delete));
            this.customer_delete_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rep_content = new System.Windows.Forms.TextBox();
            this.rep_no = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customer_delete_label
            // 
            this.customer_delete_label.BackColor = System.Drawing.Color.DarkViolet;
            this.customer_delete_label.Font = new System.Drawing.Font("Meiryo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.customer_delete_label.ForeColor = System.Drawing.Color.Gold;
            this.customer_delete_label.Location = new System.Drawing.Point(15, 30);
            this.customer_delete_label.Name = "customer_delete_label";
            this.customer_delete_label.Size = new System.Drawing.Size(300, 40);
            this.customer_delete_label.TabIndex = 0;
            this.customer_delete_label.Text = "得意先削除";
            this.customer_delete_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rep_content);
            this.groupBox1.Controls.Add(this.rep_no);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(15, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "削除対象得意先";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MediumBlue;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(157, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "[ - ] で一覧、[ . ] 検索";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rep_content
            // 
            this.rep_content.Enabled = false;
            this.rep_content.Location = new System.Drawing.Point(107, 56);
            this.rep_content.Name = "rep_content";
            this.rep_content.Size = new System.Drawing.Size(137, 20);
            this.rep_content.TabIndex = 3;
            // 
            // rep_no
            // 
            this.rep_no.Location = new System.Drawing.Point(107, 26);
            this.rep_no.Name = "rep_no";
            this.rep_no.Size = new System.Drawing.Size(40, 20);
            this.rep_no.TabIndex = 2;
            this.rep_no.TextChanged += new System.EventHandler(this.textBox_supplier_no_TextChanged);
            this.rep_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.no_keypress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(37, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "得意先名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "得意先番号";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(43, 192);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(100, 40);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "削除( &D )";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(179, 192);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 40);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "終了( &E )";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_description.Location = new System.Drawing.Point(15, 255);
            this.label_description.Name = "label_description";
            this.label_description.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label_description.Size = new System.Drawing.Size(300, 17);
            this.label_description.TabIndex = 5;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customer_delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 281);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customer_delete_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "customer_delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先削除";
            this.Load += new System.EventHandler(this.supplier_delete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label customer_delete_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rep_content;
        private System.Windows.Forms.TextBox rep_no;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label4;
    }
}