
namespace kk_sms.purchaseManagement
{
    partial class Form_accident
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_accident));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_slipNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_repCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_rep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_supplierCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_supplier = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_class = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_classCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_grade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_gradeCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_productName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_productCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_unitPrice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_purchaseQuantity = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_accident = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_accidentCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_correction = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Font = new System.Drawing.Font("Meiryo", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "仕入事故伝票入力";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "発生年月日";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 24);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "伝票番号";
            // 
            // textBox_slipNo
            // 
            this.textBox_slipNo.Location = new System.Drawing.Point(92, 140);
            this.textBox_slipNo.Name = "textBox_slipNo";
            this.textBox_slipNo.Size = new System.Drawing.Size(49, 24);
            this.textBox_slipNo.TabIndex = 4;
            this.textBox_slipNo.TextChanged += new System.EventHandler(this.textBox_slipNo_TextChanged);
            this.textBox_slipNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slipNo_keypress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkBlue;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(157, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "事故伝票は800番台、［.］で絡了ボタンへ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "担当者コード";
            // 
            // textBox_repCode
            // 
            this.textBox_repCode.Location = new System.Drawing.Point(92, 176);
            this.textBox_repCode.Name = "textBox_repCode";
            this.textBox_repCode.Size = new System.Drawing.Size(49, 24);
            this.textBox_repCode.TabIndex = 7;
            this.textBox_repCode.TextChanged += new System.EventHandler(this.textBox_repCode_TextChanged);
            this.textBox_repCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.repCode_keypress);
            this.textBox_repCode.GotFocus += new System.EventHandler(this.label_explain01);
            this.textBox_repCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "担当者";
            // 
            // textBox_rep
            // 
            this.textBox_rep.Enabled = false;
            this.textBox_rep.Location = new System.Drawing.Point(211, 176);
            this.textBox_rep.Name = "textBox_rep";
            this.textBox_rep.Size = new System.Drawing.Size(92, 24);
            this.textBox_rep.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "仕入先コード";
            // 
            // textBox_supplierCode
            // 
            this.textBox_supplierCode.Location = new System.Drawing.Point(92, 211);
            this.textBox_supplierCode.Name = "textBox_supplierCode";
            this.textBox_supplierCode.Size = new System.Drawing.Size(49, 24);
            this.textBox_supplierCode.TabIndex = 11;
            this.textBox_supplierCode.TextChanged += new System.EventHandler(this.textBox_supplierCode_TextChanged);
            this.textBox_supplierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierCode_keypress);
            this.textBox_supplierCode.GotFocus += new System.EventHandler(this.label_explain01);
            this.textBox_supplierCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "仕入先";
            // 
            // textBox_supplier
            // 
            this.textBox_supplier.Enabled = false;
            this.textBox_supplier.Location = new System.Drawing.Point(211, 211);
            this.textBox_supplier.Name = "textBox_supplier";
            this.textBox_supplier.Size = new System.Drawing.Size(92, 24);
            this.textBox_supplier.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.groupBox1.Controls.Add(this.textBox_class);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBox_classCode);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox_grade);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_gradeCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox_productName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_productCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 124);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "仕入潘品";
            // 
            // textBox_class
            // 
            this.textBox_class.Enabled = false;
            this.textBox_class.Location = new System.Drawing.Point(206, 87);
            this.textBox_class.Name = "textBox_class";
            this.textBox_class.Size = new System.Drawing.Size(100, 24);
            this.textBox_class.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(168, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = "階級";
            // 
            // textBox_classCode
            // 
            this.textBox_classCode.Location = new System.Drawing.Point(85, 87);
            this.textBox_classCode.Name = "textBox_classCode";
            this.textBox_classCode.Size = new System.Drawing.Size(52, 24);
            this.textBox_classCode.TabIndex = 9;
            this.textBox_classCode.TextChanged += new System.EventHandler(this.textBox_classCode_TextChanged);
            this.textBox_classCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.classCode_keypress);
            this.textBox_classCode.GotFocus += new System.EventHandler(this.label_explain01);
            this.textBox_classCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "階級コード";
            // 
            // textBox_grade
            // 
            this.textBox_grade.Enabled = false;
            this.textBox_grade.Location = new System.Drawing.Point(206, 52);
            this.textBox_grade.Name = "textBox_grade";
            this.textBox_grade.Size = new System.Drawing.Size(100, 24);
            this.textBox_grade.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(168, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "等級";
            // 
            // textBox_gradeCode
            // 
            this.textBox_gradeCode.Location = new System.Drawing.Point(85, 52);
            this.textBox_gradeCode.Name = "textBox_gradeCode";
            this.textBox_gradeCode.Size = new System.Drawing.Size(52, 24);
            this.textBox_gradeCode.TabIndex = 5;
            this.textBox_gradeCode.TextChanged += new System.EventHandler(this.textBox_gradeCode_TextChanged);
            this.textBox_gradeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gradeCode_keypress);
            this.textBox_gradeCode.GotFocus += new System.EventHandler(this.label_explain01);
            this.textBox_gradeCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "等級コード";
            // 
            // textBox_productName
            // 
            this.textBox_productName.Enabled = false;
            this.textBox_productName.Location = new System.Drawing.Point(206, 17);
            this.textBox_productName.Name = "textBox_productName";
            this.textBox_productName.Size = new System.Drawing.Size(100, 24);
            this.textBox_productName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "商品名";
            // 
            // textBox_productCode
            // 
            this.textBox_productCode.Location = new System.Drawing.Point(85, 17);
            this.textBox_productCode.Name = "textBox_productCode";
            this.textBox_productCode.Size = new System.Drawing.Size(52, 24);
            this.textBox_productCode.TabIndex = 1;
            this.textBox_productCode.TextChanged += new System.EventHandler(this.textBox_productCode_TextChanged);
            this.textBox_productCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productCode_keypress);
            this.textBox_productCode.GotFocus += new System.EventHandler(this.label_explain01);
            this.textBox_productCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "商品コード";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.textBox_amount);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.textBox_unitPrice);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.textBox_purchaseQuantity);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.textBox_accident);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.textBox_accidentCode);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(12, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 82);
            this.panel1.TabIndex = 15;
            // 
            // textBox_amount
            // 
            this.textBox_amount.Enabled = false;
            this.textBox_amount.Location = new System.Drawing.Point(271, 45);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(79, 24);
            this.textBox_amount.TabIndex = 9;
            this.textBox_amount.TextChanged += new System.EventHandler(this.textBox_amount_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(235, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 17);
            this.label19.TabIndex = 8;
            this.label19.Text = "金額";
            // 
            // textBox_unitPrice
            // 
            this.textBox_unitPrice.Location = new System.Drawing.Point(161, 45);
            this.textBox_unitPrice.Name = "textBox_unitPrice";
            this.textBox_unitPrice.Size = new System.Drawing.Size(58, 24);
            this.textBox_unitPrice.TabIndex = 7;
            this.textBox_unitPrice.TextChanged += new System.EventHandler(this.textBox_unitPrice_TextChanged);
            this.textBox_unitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.unitprice_keypress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(125, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "単価";
            // 
            // textBox_purchaseQuantity
            // 
            this.textBox_purchaseQuantity.Location = new System.Drawing.Point(52, 45);
            this.textBox_purchaseQuantity.Name = "textBox_purchaseQuantity";
            this.textBox_purchaseQuantity.Size = new System.Drawing.Size(58, 24);
            this.textBox_purchaseQuantity.TabIndex = 5;
            this.textBox_purchaseQuantity.TextChanged += new System.EventHandler(this.textBox_purchaseQuantity_TextChanged);
            this.textBox_purchaseQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.purchaseQuantity_keypress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "数量";
            // 
            // textBox_accident
            // 
            this.textBox_accident.Enabled = false;
            this.textBox_accident.Location = new System.Drawing.Point(195, 10);
            this.textBox_accident.Name = "textBox_accident";
            this.textBox_accident.Size = new System.Drawing.Size(61, 24);
            this.textBox_accident.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(137, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "事故区分";
            // 
            // textBox_accidentCode
            // 
            this.textBox_accidentCode.Location = new System.Drawing.Point(106, 10);
            this.textBox_accidentCode.Name = "textBox_accidentCode";
            this.textBox_accidentCode.Size = new System.Drawing.Size(20, 24);
            this.textBox_accidentCode.TabIndex = 1;
            this.textBox_accidentCode.TextChanged += new System.EventHandler(this.textBox_accidentCode_TextChanged);
            this.textBox_accidentCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accidentCode_keypress);
            this.textBox_accidentCode.GotFocus += new System.EventHandler(this.label_explain02);
            this.textBox_accidentCode.LostFocus += new System.EventHandler(this.label_clear);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "事故区分コード";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(54, 474);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(90, 30);
            this.button_ok.TabIndex = 16;
            this.button_ok.Text = "OK ( &O )";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_correction
            // 
            this.button_correction.Location = new System.Drawing.Point(151, 474);
            this.button_correction.Name = "button_correction";
            this.button_correction.Size = new System.Drawing.Size(90, 30);
            this.button_correction.TabIndex = 17;
            this.button_correction.Text = "訂正 ( &M )";
            this.button_correction.UseVisualStyleBackColor = true;
            this.button_correction.Click += new System.EventHandler(this.button_correction_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(248, 474);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(90, 30);
            this.button_exit.TabIndex = 18;
            this.button_exit.Text = "終了 ( &E )";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(24, 516);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(346, 17);
            this.label_description.TabIndex = 19;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_accident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 549);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_correction);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_supplier);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_supplierCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_rep);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_repCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_slipNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_accident";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入事故伝票入力";
            this.Load += new System.EventHandler(this.Form_accident_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_slipNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_repCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_rep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_supplierCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_supplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_productCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_productName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_gradeCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_grade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_classCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_class;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_accidentCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_accident;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_purchaseQuantity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_unitPrice;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_correction;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_description;
    }
}