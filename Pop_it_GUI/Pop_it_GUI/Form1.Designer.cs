
namespace Pop_it_GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_popithub = new System.Windows.Forms.Button();
            this.btn_kilepes = new System.Windows.Forms.Button();
            this.btn_generalas = new System.Windows.Forms.Button();
            this.btn_jatek = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_aktual_verzio = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_popithub);
            this.groupBox1.Controls.Add(this.btn_kilepes);
            this.groupBox1.Controls.Add(this.btn_generalas);
            this.groupBox1.Controls.Add(this.btn_jatek);
            this.groupBox1.Location = new System.Drawing.Point(59, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 162);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menü";
            // 
            // btn_popithub
            // 
            this.btn_popithub.Location = new System.Drawing.Point(17, 53);
            this.btn_popithub.Name = "btn_popithub";
            this.btn_popithub.Size = new System.Drawing.Size(226, 28);
            this.btn_popithub.TabIndex = 1;
            this.btn_popithub.Text = "Pop-it! - hub";
            this.btn_popithub.UseVisualStyleBackColor = true;
            this.btn_popithub.Click += new System.EventHandler(this.btn_popithub_Click);
            // 
            // btn_kilepes
            // 
            this.btn_kilepes.ForeColor = System.Drawing.Color.Red;
            this.btn_kilepes.Location = new System.Drawing.Point(17, 121);
            this.btn_kilepes.Name = "btn_kilepes";
            this.btn_kilepes.Size = new System.Drawing.Size(226, 28);
            this.btn_kilepes.TabIndex = 3;
            this.btn_kilepes.Text = "Kilépés";
            this.btn_kilepes.UseVisualStyleBackColor = true;
            this.btn_kilepes.Click += new System.EventHandler(this.btn_kilepes_Click);
            // 
            // btn_generalas
            // 
            this.btn_generalas.Location = new System.Drawing.Point(17, 87);
            this.btn_generalas.Name = "btn_generalas";
            this.btn_generalas.Size = new System.Drawing.Size(226, 28);
            this.btn_generalas.TabIndex = 2;
            this.btn_generalas.Text = "Pályagenerálás";
            this.btn_generalas.UseVisualStyleBackColor = true;
            this.btn_generalas.Click += new System.EventHandler(this.btn_generalas_Click);
            // 
            // btn_jatek
            // 
            this.btn_jatek.Location = new System.Drawing.Point(17, 19);
            this.btn_jatek.Name = "btn_jatek";
            this.btn_jatek.Size = new System.Drawing.Size(226, 28);
            this.btn_jatek.TabIndex = 0;
            this.btn_jatek.Text = "Játék helyi gépen";
            this.btn_jatek.UseVisualStyleBackColor = true;
            this.btn_jatek.Click += new System.EventHandler(this.btn_jatek_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pop-it! - Csodacsapat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dusza Árpád Emlékverseny 2022";
            // 
            // lbl_aktual_verzio
            // 
            this.lbl_aktual_verzio.AutoSize = true;
            this.lbl_aktual_verzio.Location = new System.Drawing.Point(3, 256);
            this.lbl_aktual_verzio.Name = "lbl_aktual_verzio";
            this.lbl_aktual_verzio.Size = new System.Drawing.Size(28, 13);
            this.lbl_aktual_verzio.TabIndex = 9;
            this.lbl_aktual_verzio.Text = "v2.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(386, 270);
            this.Controls.Add(this.lbl_aktual_verzio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(402, 309);
            this.MinimumSize = new System.Drawing.Size(402, 309);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pop-it! GUI - Csodacsapat [Menü]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_kilepes;
        private System.Windows.Forms.Button btn_generalas;
        private System.Windows.Forms.Button btn_jatek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_aktual_verzio;
        private System.Windows.Forms.Button btn_popithub;
    }
}

