
namespace kk_sms.masterManagement.grade
{
    partial class grade_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(grade_add));
            this.group_add_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_grade_name = new System.Windows.Forms.TextBox();
            this.textBox_grade_no = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_add_label
            // 
            this.group_add_label.BackColor = System.Drawing.Color.Green;
            this.group_add_label.Font = new System.Drawing.Font("Meiryo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.group_add_label.ForeColor = System.Drawing.Color.Gold;
            this.group_add_label.Location = new System.Drawing.Point(15, 30);
            this.group_add_label.Name = "group_add_label";
            this.group_add_label.Size = new System.Drawing.Size(300, 40);
            this.group_add_label.TabIndex = 0;
            this.group_add_label.Text = "等級追加";
            this.group_add_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.textBox_grade_name);
            this.groupBox1.Controls.Add(this.textBox_grade_no);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(15, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "追加等級";
            // 
            // textBox_grade_name
            // 
            this.textBox_grade_name.Location = new System.Drawing.Point(130, 57);
            this.textBox_grade_name.Name = "textBox_grade_name";
            this.textBox_grade_name.Size = new System.Drawing.Size(137, 20);
            this.textBox_grade_name.TabIndex = 3;
            this.textBox_grade_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.name_keypress);
            // 
            // textBox_grade_no
            // 
            this.textBox_grade_no.Location = new System.Drawing.Point(130, 25);
            this.textBox_grade_no.Name = "textBox_grade_no";
            this.textBox_grade_no.Size = new System.Drawing.Size(40, 20);
            this.textBox_grade_no.TabIndex = 2;
            this.textBox_grade_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.no_keypress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(37, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "等級名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "等級番号";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(43, 192);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(100, 40);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "保存( &S )";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(179, 192);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 40);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "キャンセル( &C )";
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
            // grade_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 281);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_add_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "grade_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "等級追加";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label group_add_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_grade_name;
        private System.Windows.Forms.TextBox textBox_grade_no;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_description;
    }
}