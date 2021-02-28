
namespace kk_sms
{
    partial class Form_salesManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_salesManagement));
            this.label_title = new System.Windows.Forms.Label();
            this.panel_buttonGroup = new System.Windows.Forms.Panel();
            this.button_correctAccident = new System.Windows.Forms.Button();
            this.button_inputAccident = new System.Windows.Forms.Button();
            this.button_printTable = new System.Windows.Forms.Button();
            this.button_correct = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_description = new System.Windows.Forms.Label();
            this.panel_buttonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(27, 14);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(280, 60);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "売上管理メニュー";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_buttonGroup
            // 
            this.panel_buttonGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.panel_buttonGroup.Controls.Add(this.button_correctAccident);
            this.panel_buttonGroup.Controls.Add(this.button_inputAccident);
            this.panel_buttonGroup.Controls.Add(this.button_printTable);
            this.panel_buttonGroup.Controls.Add(this.button_correct);
            this.panel_buttonGroup.Controls.Add(this.button_input);
            this.panel_buttonGroup.Location = new System.Drawing.Point(27, 87);
            this.panel_buttonGroup.Name = "panel_buttonGroup";
            this.panel_buttonGroup.Size = new System.Drawing.Size(280, 245);
            this.panel_buttonGroup.TabIndex = 1;
            // 
            // button_correctAccident
            // 
            this.button_correctAccident.Location = new System.Drawing.Point(27, 195);
            this.button_correctAccident.Name = "button_correctAccident";
            this.button_correctAccident.Size = new System.Drawing.Size(225, 35);
            this.button_correctAccident.TabIndex = 4;
            this.button_correctAccident.Text = "売上事故伝票修正 ( &K )";
            this.button_correctAccident.UseVisualStyleBackColor = true;
            this.button_correctAccident.Click += new System.EventHandler(this.button_correctAccident_Click);
            // 
            // button_inputAccident
            // 
            this.button_inputAccident.Location = new System.Drawing.Point(27, 150);
            this.button_inputAccident.Name = "button_inputAccident";
            this.button_inputAccident.Size = new System.Drawing.Size(225, 35);
            this.button_inputAccident.TabIndex = 3;
            this.button_inputAccident.Text = "売上事故伝票入力 ( &J )";
            this.button_inputAccident.UseVisualStyleBackColor = true;
            this.button_inputAccident.Click += new System.EventHandler(this.button_inputAccident_Click);
            // 
            // button_printTable
            // 
            this.button_printTable.Location = new System.Drawing.Point(27, 105);
            this.button_printTable.Name = "button_printTable";
            this.button_printTable.Size = new System.Drawing.Size(225, 35);
            this.button_printTable.TabIndex = 2;
            this.button_printTable.Text = "売上一覧表印刷 ( &P )";
            this.button_printTable.UseVisualStyleBackColor = true;
            // 
            // button_correct
            // 
            this.button_correct.Location = new System.Drawing.Point(27, 60);
            this.button_correct.Name = "button_correct";
            this.button_correct.Size = new System.Drawing.Size(225, 35);
            this.button_correct.TabIndex = 1;
            this.button_correct.Text = "売上伝票修正 ( &M )";
            this.button_correct.UseVisualStyleBackColor = true;
            this.button_correct.Click += new System.EventHandler(this.button_correct_Click);
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(27, 15);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(225, 35);
            this.button_input.TabIndex = 0;
            this.button_input.Text = "売上伝票入力 ( &I )";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(54, 348);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(225, 35);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "終了 ・ 戻る ( &E )";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(27, 396);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(280, 17);
            this.label_description.TabIndex = 3;
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_salesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 429);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.panel_buttonGroup);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_salesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "売上メニュー";
            this.Load += new System.EventHandler(this.Form_salesManagement_Load);
            this.panel_buttonGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_buttonGroup;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Button button_correct;
        private System.Windows.Forms.Button button_printTable;
        private System.Windows.Forms.Button button_inputAccident;
        private System.Windows.Forms.Button button_correctAccident;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_description;
    }
}