
namespace kk_sms.purchaseManagement
{
    partial class Form_input_selectPacking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_input_selectPacking));
            this.label_title = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packing_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.Brown;
            this.label_title.Font = new System.Drawing.Font("Meiryo", 16F);
            this.label_title.ForeColor = System.Drawing.Color.Yellow;
            this.label_title.Location = new System.Drawing.Point(29, 23);
            this.label_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(146, 52);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "荷姿一覧";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.Color.Yellow;
            this.label_description.Location = new System.Drawing.Point(44, 253);
            this.label_description.Name = "label_description";
            this.label_description.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label_description.Size = new System.Drawing.Size(119, 17);
            this.label_description.TabIndex = 1;
            this.label_description.Text = "OKで番号入力します";
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.packing_no,
            this.name});
            this.dataGridView1.Location = new System.Drawing.Point(21, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(163, 98);
            this.dataGridView1.TabIndex = 2;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(58, 208);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(88, 33);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "OK ( &O )";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // no
            // 
            this.no.HeaderText = "Rec";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // packing_no
            // 
            this.packing_no.HeaderText = "荷番";
            this.packing_no.Name = "packing_no";
            this.packing_no.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "荷姿";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Form_input_selectPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 283);
            this.ControlBox = false;
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Form_input_selectPacking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "荷姿一覧";
            this.Load += new System.EventHandler(this.Form_selectRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn packing_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}