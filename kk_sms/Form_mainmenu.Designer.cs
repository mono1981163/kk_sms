
namespace kk_sms
{
    partial class Form_mainmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_mainmenu));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label_title = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.panel_buttonGroup = new System.Windows.Forms.Panel();
            this.button_dailyPretreatment = new System.Windows.Forms.Button();
            this.button_purchaseManagement = new System.Windows.Forms.Button();
            this.button_salesManagement = new System.Windows.Forms.Button();
            this.button_inventoryManagement = new System.Windows.Forms.Button();
            this.button_dailyReportPrinting = new System.Windows.Forms.Button();
            this.button_voucherPrinting = new System.Windows.Forms.Button();
            this.button_monthlyProcessing = new System.Windows.Forms.Button();
            this.button_masterManagement = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_currentButton = new System.Windows.Forms.Label();
            this.label_copyright = new System.Windows.Forms.Label();
            this.panel_buttonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_title.AutoSize = true;
            this.label_title.BackColor = System.Drawing.Color.Purple;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(53, 41);
            this.label_title.Name = "label_title";
            this.label_title.Padding = new System.Windows.Forms.Padding(40, 16, 40, 16);
            this.label_title.Size = new System.Drawing.Size(337, 61);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "川崎金伝卸管理システム";
            // 
            // label_date
            // 
            this.label_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_date.Location = new System.Drawing.Point(301, 106);
            this.label_date.Name = "label_date";
            this.label_date.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.label_date.Size = new System.Drawing.Size(89, 20);
            this.label_date.TabIndex = 1;
            // 
            // panel_buttonGroup
            // 
            this.panel_buttonGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_buttonGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(253)))), ((int)(((byte)(210)))));
            this.panel_buttonGroup.Controls.Add(this.button_dailyPretreatment);
            this.panel_buttonGroup.Controls.Add(this.button_purchaseManagement);
            this.panel_buttonGroup.Controls.Add(this.button_salesManagement);
            this.panel_buttonGroup.Controls.Add(this.button_inventoryManagement);
            this.panel_buttonGroup.Controls.Add(this.button_dailyReportPrinting);
            this.panel_buttonGroup.Controls.Add(this.button_voucherPrinting);
            this.panel_buttonGroup.Controls.Add(this.button_monthlyProcessing);
            this.panel_buttonGroup.Controls.Add(this.button_masterManagement);
            this.panel_buttonGroup.Location = new System.Drawing.Point(52, 132);
            this.panel_buttonGroup.Name = "panel_buttonGroup";
            this.panel_buttonGroup.Size = new System.Drawing.Size(339, 228);
            this.panel_buttonGroup.TabIndex = 2;
            // 
            // button_dailyPretreatment
            // 
            this.button_dailyPretreatment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_dailyPretreatment.Location = new System.Drawing.Point(25, 21);
            this.button_dailyPretreatment.Name = "button_dailyPretreatment";
            this.button_dailyPretreatment.Size = new System.Drawing.Size(132, 35);
            this.button_dailyPretreatment.TabIndex = 0;
            this.button_dailyPretreatment.Text = "日次前処理 (&D)\r\n";
            this.button_dailyPretreatment.UseVisualStyleBackColor = true;
            this.button_dailyPretreatment.GotFocus += new System.EventHandler(this.Button_dailyPretreatment_GotFocus);
            // 
            // button_purchaseManagement
            // 
            this.button_purchaseManagement.AccessibleName = "";
            this.button_purchaseManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_purchaseManagement.Location = new System.Drawing.Point(25, 71);
            this.button_purchaseManagement.Name = "button_purchaseManagement";
            this.button_purchaseManagement.Size = new System.Drawing.Size(132, 35);
            this.button_purchaseManagement.TabIndex = 0;
            this.button_purchaseManagement.Text = "仕入管理 (&S)";
            this.button_purchaseManagement.UseVisualStyleBackColor = true;
            this.button_purchaseManagement.Click += new System.EventHandler(this.Button_purchaseManagement_Click);
            this.button_purchaseManagement.GotFocus += new System.EventHandler(this.Button_purchaseManagement_GotFocus);
            // 
            // button_salesManagement
            // 
            this.button_salesManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_salesManagement.Location = new System.Drawing.Point(25, 122);
            this.button_salesManagement.Name = "button_salesManagement";
            this.button_salesManagement.Size = new System.Drawing.Size(132, 35);
            this.button_salesManagement.TabIndex = 0;
            this.button_salesManagement.Text = "売上管理 (&U)\r\n";
            this.button_salesManagement.UseVisualStyleBackColor = true;
            this.button_salesManagement.Click += new System.EventHandler(this.Button_salesManagement_Click);
            this.button_salesManagement.GotFocus += new System.EventHandler(this.Button_salesManagement_GotFocus);
            // 
            // button_inventoryManagement
            // 
            this.button_inventoryManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_inventoryManagement.Location = new System.Drawing.Point(25, 172);
            this.button_inventoryManagement.Name = "button_inventoryManagement";
            this.button_inventoryManagement.Size = new System.Drawing.Size(132, 35);
            this.button_inventoryManagement.TabIndex = 0;
            this.button_inventoryManagement.Text = "在庫管理 (&Z)\r\n";
            this.button_inventoryManagement.UseVisualStyleBackColor = true;
            this.button_inventoryManagement.Click += new System.EventHandler(this.Button_inventoryManagement_Click);
            this.button_inventoryManagement.GotFocus += new System.EventHandler(this.Button_inventoryManagement_GotFocus);
            // 
            // button_dailyReportPrinting
            // 
            this.button_dailyReportPrinting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_dailyReportPrinting.Location = new System.Drawing.Point(182, 21);
            this.button_dailyReportPrinting.Name = "button_dailyReportPrinting";
            this.button_dailyReportPrinting.Size = new System.Drawing.Size(132, 35);
            this.button_dailyReportPrinting.TabIndex = 0;
            this.button_dailyReportPrinting.Text = "日報印刷 (&P)\r\n";
            this.button_dailyReportPrinting.UseVisualStyleBackColor = true;
            this.button_dailyReportPrinting.Click += new System.EventHandler(this.Button_dailyReportPrinting_Click);
            this.button_dailyReportPrinting.GotFocus += new System.EventHandler(this.Button_dailyReportPrinting_GotFocus);
            // 
            // button_voucherPrinting
            // 
            this.button_voucherPrinting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_voucherPrinting.Location = new System.Drawing.Point(182, 71);
            this.button_voucherPrinting.Name = "button_voucherPrinting";
            this.button_voucherPrinting.Size = new System.Drawing.Size(132, 35);
            this.button_voucherPrinting.TabIndex = 0;
            this.button_voucherPrinting.Text = "伝票印刷 (&Q)\r\n";
            this.button_voucherPrinting.UseVisualStyleBackColor = true;
            this.button_voucherPrinting.Click += new System.EventHandler(this.Button_voucherPrinting_Click);
            this.button_voucherPrinting.GotFocus += new System.EventHandler(this.Button_voucherPrinting_GotFocus);
            // 
            // button_monthlyProcessing
            // 
            this.button_monthlyProcessing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_monthlyProcessing.Location = new System.Drawing.Point(182, 122);
            this.button_monthlyProcessing.Name = "button_monthlyProcessing";
            this.button_monthlyProcessing.Size = new System.Drawing.Size(132, 35);
            this.button_monthlyProcessing.TabIndex = 0;
            this.button_monthlyProcessing.Text = "月次処理 (&G)\r\n";
            this.button_monthlyProcessing.UseVisualStyleBackColor = true;
            this.button_monthlyProcessing.Click += new System.EventHandler(this.Button_monthlyProcessing_Click);
            this.button_monthlyProcessing.GotFocus += new System.EventHandler(this.Button_monthlyProcessing_GotFocus);
            // 
            // button_masterManagement
            // 
            this.button_masterManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_masterManagement.Location = new System.Drawing.Point(182, 172);
            this.button_masterManagement.Name = "button_masterManagement";
            this.button_masterManagement.Size = new System.Drawing.Size(132, 35);
            this.button_masterManagement.TabIndex = 0;
            this.button_masterManagement.Text = "マスター管理 (&M)\r\n";
            this.button_masterManagement.UseVisualStyleBackColor = true;
            this.button_masterManagement.Click += new System.EventHandler(this.Button_masterManagement_Click);
            this.button_masterManagement.GotFocus += new System.EventHandler(this.Button_masterManagement_GotFocus);
            // 
            // button_exit
            // 
            this.button_exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_exit.Location = new System.Drawing.Point(109, 373);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(228, 36);
            this.button_exit.TabIndex = 0;
            this.button_exit.Text = " 終          了 (&E)\r\n";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.Button_exit_Click);
            this.button_exit.GotFocus += new System.EventHandler(this.Button_exit_GotFocus);
            // 
            // label_currentButton
            // 
            this.label_currentButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_currentButton.BackColor = System.Drawing.Color.Yellow;
            this.label_currentButton.Location = new System.Drawing.Point(53, 420);
            this.label_currentButton.Name = "label_currentButton";
            this.label_currentButton.Padding = new System.Windows.Forms.Padding(2);
            this.label_currentButton.Size = new System.Drawing.Size(337, 17);
            this.label_currentButton.TabIndex = 3;
            // 
            // label_copyright
            // 
            this.label_copyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_copyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_copyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(228)))), ((int)(((byte)(27)))));
            this.label_copyright.Location = new System.Drawing.Point(35, 447);
            this.label_copyright.Name = "label_copyright";
            this.label_copyright.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label_copyright.Size = new System.Drawing.Size(373, 19);
            this.label_copyright.TabIndex = 3;
            this.label_copyright.Text = "COPY RIGHT(C) NAGASAKI DIGITAL ENG. VER 2.0.1";
            // 
            // Form_mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(442, 499);
            this.Controls.Add(this.label_copyright);
            this.Controls.Add(this.label_currentButton);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.panel_buttonGroup);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(442, 499);
            this.Name = "Form_mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "川崎金伝メインメニュー";
            this.Load += new System.EventHandler(this.Form_mainmenu_Load);
            this.panel_buttonGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Panel panel_buttonGroup;
        private System.Windows.Forms.Button button_dailyPretreatment;
        private System.Windows.Forms.Button button_masterManagement;
        private System.Windows.Forms.Button button_voucherPrinting;
        private System.Windows.Forms.Button button_monthlyProcessing;
        private System.Windows.Forms.Button button_dailyReportPrinting;
        private System.Windows.Forms.Button button_inventoryManagement;
        private System.Windows.Forms.Button button_salesManagement;
        private System.Windows.Forms.Button button_purchaseManagement;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_currentButton;
        private System.Windows.Forms.Label label_copyright;
    }
}

