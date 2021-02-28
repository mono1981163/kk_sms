
namespace kk_sms.inventoryManagement
{
    partial class Form_ChangePurchaser
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.Snumval = new System.Windows.Forms.TextBox();
            this.EmNoval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(110, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "在庫品仕入担当者変更";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNum,
            this.PName,
            this.ENum,
            this.EName,
            this.Suplier,
            this.DateText});
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(617, 214);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SNum
            // 
            this.SNum.HeaderText = "伝票番号";
            this.SNum.Name = "SNum";
            this.SNum.ReadOnly = true;
            // 
            // PName
            // 
            this.PName.HeaderText = "品名";
            this.PName.Name = "PName";
            // 
            // ENum
            // 
            this.ENum.HeaderText = "社員番号";
            this.ENum.Name = "ENum";
            // 
            // EName
            // 
            this.EName.HeaderText = "氏名";
            this.EName.Name = "EName";
            // 
            // Suplier
            // 
            this.Suplier.HeaderText = "仕入先";
            this.Suplier.Name = "Suplier";
            // 
            // DateText
            // 
            this.DateText.HeaderText = "日付";
            this.DateText.Name = "DateText";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(90, 329);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(145, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "伝票番号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Snumval
            // 
            this.Snumval.Location = new System.Drawing.Point(163, 335);
            this.Snumval.Name = "Snumval";
            this.Snumval.Size = new System.Drawing.Size(61, 24);
            this.Snumval.TabIndex = 3;
            this.Snumval.TextChanged += new System.EventHandler(this.Snumval_TextChanged);
            // 
            // EmNoval
            // 
            this.EmNoval.Location = new System.Drawing.Point(491, 334);
            this.EmNoval.Name = "EmNoval";
            this.EmNoval.Size = new System.Drawing.Size(61, 24);
            this.EmNoval.TabIndex = 5;
            this.EmNoval.TextChanged += new System.EventHandler(this.EmNoval_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(418, 328);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(145, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "社員番号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Search.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(60, 398);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(81, 29);
            this.Search.TabIndex = 6;
            this.Search.Text = "検   索 (&S)";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Modify
            // 
            this.Modify.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Modify.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify.Location = new System.Drawing.Point(263, 398);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(81, 29);
            this.Modify.TabIndex = 6;
            this.Modify.Text = "修  正 (&M)";
            this.Modify.UseVisualStyleBackColor = false;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Meiryo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(462, 398);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(81, 29);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "終  了 (&E)";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Yellow;
            this.statusLabel.Location = new System.Drawing.Point(23, 442);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(606, 21);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_ChangePurchaser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 472);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.EmNoval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Snumval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_ChangePurchaser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ChangePurchaser";
            this.Load += new System.EventHandler(this.Form_ChangePurchaser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENum;
        private System.Windows.Forms.DataGridViewTextBoxColumn EName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Snumval;
        private System.Windows.Forms.TextBox EmNoval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label statusLabel;
    }
}