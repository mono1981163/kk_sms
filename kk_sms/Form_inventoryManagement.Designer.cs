
namespace kk_sms
{
    partial class Form_inventoryManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_inventoryManagement));
            this.label_title = new System.Windows.Forms.Label();
            this.panel_buttonGroup = new System.Windows.Forms.Panel();
            this.button_changePurchaser = new System.Windows.Forms.Button();
            this.button_printTable = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.panel_buttonGroup.SuspendLayout();
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
            this.label_title.Text = "在庫管理メニュー";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_buttonGroup
            // 
            this.panel_buttonGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel_buttonGroup.Controls.Add(this.button_changePurchaser);
            this.panel_buttonGroup.Controls.Add(this.button_printTable);
            this.panel_buttonGroup.Controls.Add(this.button_input);
            this.panel_buttonGroup.Location = new System.Drawing.Point(27, 88);
            this.panel_buttonGroup.Name = "panel_buttonGroup";
            this.panel_buttonGroup.Size = new System.Drawing.Size(280, 167);
            this.panel_buttonGroup.TabIndex = 1;
            // 
            // button_changePurchaser
            // 
            this.button_changePurchaser.Location = new System.Drawing.Point(27, 116);
            this.button_changePurchaser.Name = "button_changePurchaser";
            this.button_changePurchaser.Size = new System.Drawing.Size(225, 35);
            this.button_changePurchaser.TabIndex = 2;
            this.button_changePurchaser.Text = "商品仕入担当者変更 ( &C )";
            this.button_changePurchaser.UseVisualStyleBackColor = true;
            this.button_changePurchaser.Click += new System.EventHandler(this.button_changePurchaser_Click);
            this.button_changePurchaser.GotFocus += new System.EventHandler(this.button_changePurchaser_GotFocus);
            // 
            // button_printTable
            // 
            this.button_printTable.Location = new System.Drawing.Point(27, 65);
            this.button_printTable.Name = "button_printTable";
            this.button_printTable.Size = new System.Drawing.Size(225, 35);
            this.button_printTable.TabIndex = 1;
            this.button_printTable.Text = "在庫商品一覧表印刷 ( &P )";
            this.button_printTable.UseVisualStyleBackColor = true;
            this.button_printTable.Click += new System.EventHandler(this.button_printTable_Click);
            this.button_printTable.GotFocus += new System.EventHandler(this.button_printTable_GotFocus);
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(27, 15);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(225, 35);
            this.button_input.TabIndex = 0;
            this.button_input.Text = "在庫調整入力 ( &M )";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            this.button_input.GotFocus += new System.EventHandler(this.button_input_GotFocus);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(54, 271);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(225, 35);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "終了 ・ 戻る ( &E )";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.GotFocus += new System.EventHandler(this.button_exit_GotFocus);
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(27, 322);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(280, 17);
            this.label_description.TabIndex = 3;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_inventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 354);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.panel_buttonGroup);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_inventoryManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品在庫調整";
            this.Load += new System.EventHandler(this.Form_inventoryManagement_Load);
            this.panel_buttonGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_buttonGroup;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Button button_printTable;
        private System.Windows.Forms.Button button_changePurchaser;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_description;
    }
}