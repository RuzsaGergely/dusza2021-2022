namespace Pop_it_GUI
{
    partial class Hub
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
            this.lbox_onlinelist = new System.Windows.Forms.ListBox();
            this.btn_letoltes = new System.Windows.Forms.Button();
            this.pbar_status = new System.Windows.Forms.ProgressBar();
            this.lbl_download_status = new System.Windows.Forms.Label();
            this.btn_feltoltes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbox_onlinelist
            // 
            this.lbox_onlinelist.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbox_onlinelist.FormattingEnabled = true;
            this.lbox_onlinelist.Location = new System.Drawing.Point(0, 0);
            this.lbox_onlinelist.Name = "lbox_onlinelist";
            this.lbox_onlinelist.Size = new System.Drawing.Size(317, 238);
            this.lbox_onlinelist.TabIndex = 0;
            // 
            // btn_letoltes
            // 
            this.btn_letoltes.Location = new System.Drawing.Point(21, 244);
            this.btn_letoltes.Name = "btn_letoltes";
            this.btn_letoltes.Size = new System.Drawing.Size(130, 40);
            this.btn_letoltes.TabIndex = 1;
            this.btn_letoltes.Text = "Letöltés";
            this.btn_letoltes.UseVisualStyleBackColor = true;
            this.btn_letoltes.Click += new System.EventHandler(this.btn_letoltes_Click);
            // 
            // pbar_status
            // 
            this.pbar_status.Location = new System.Drawing.Point(45, 328);
            this.pbar_status.Name = "pbar_status";
            this.pbar_status.Size = new System.Drawing.Size(223, 30);
            this.pbar_status.TabIndex = 3;
            // 
            // lbl_download_status
            // 
            this.lbl_download_status.Location = new System.Drawing.Point(94, 302);
            this.lbl_download_status.Name = "lbl_download_status";
            this.lbl_download_status.Size = new System.Drawing.Size(126, 23);
            this.lbl_download_status.TabIndex = 4;
            this.lbl_download_status.Text = "N/A";
            this.lbl_download_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_feltoltes
            // 
            this.btn_feltoltes.Location = new System.Drawing.Point(166, 244);
            this.btn_feltoltes.Name = "btn_feltoltes";
            this.btn_feltoltes.Size = new System.Drawing.Size(130, 40);
            this.btn_feltoltes.TabIndex = 5;
            this.btn_feltoltes.Text = "Feltöltés";
            this.btn_feltoltes.UseVisualStyleBackColor = true;
            this.btn_feltoltes.Click += new System.EventHandler(this.btn_feltoltes_Click);
            // 
            // Hub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 372);
            this.Controls.Add(this.btn_feltoltes);
            this.Controls.Add(this.lbl_download_status);
            this.Controls.Add(this.pbar_status);
            this.Controls.Add(this.btn_letoltes);
            this.Controls.Add(this.lbox_onlinelist);
            this.Name = "Hub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pop it! GUI - by Csodacsapat [Hub]";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_onlinelist;
        private System.Windows.Forms.Button btn_letoltes;
        private System.Windows.Forms.ProgressBar pbar_status;
        private System.Windows.Forms.Label lbl_download_status;
        private System.Windows.Forms.Button btn_feltoltes;
    }
}