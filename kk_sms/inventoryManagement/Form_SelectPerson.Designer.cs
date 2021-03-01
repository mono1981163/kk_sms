
namespace kk_sms.inventoryManagement
{
    partial class Form_SelectPerson
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
            System.Windows.Forms.Label label_title;
            label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            label_title.BackColor = System.Drawing.Color.Indigo;
            label_title.Font = new System.Drawing.Font("Meiryo", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_title.ForeColor = System.Drawing.Color.Yellow;
            label_title.Location = new System.Drawing.Point(73, 35);
            label_title.Name = "label_title";
            label_title.Size = new System.Drawing.Size(300, 50);
            label_title.TabIndex = 0;
            label_title.Text = "在庫調整対象者選択";
            label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_SelectPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 561);
            this.Controls.Add(label_title);
            this.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form_SelectPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SelectPerson";
            this.Load += new System.EventHandler(this.Form_SelectPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}