
namespace Pop_it_GUI
{
    partial class PalyaValasztoForm
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
            this.listbox_palyak = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_jatek = new System.Windows.Forms.Button();
            this.dgv_preview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_csatlakozas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_palyak
            // 
            this.listbox_palyak.Dock = System.Windows.Forms.DockStyle.Left;
            this.listbox_palyak.FormattingEnabled = true;
            this.listbox_palyak.Location = new System.Drawing.Point(0, 0);
            this.listbox_palyak.Name = "listbox_palyak";
            this.listbox_palyak.Size = new System.Drawing.Size(215, 452);
            this.listbox_palyak.TabIndex = 0;
            this.listbox_palyak.SelectedIndexChanged += new System.EventHandler(this.listbox_palyak_SelectedIndexChanged);
            this.listbox_palyak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listbox_palyak_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(219, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 452);
            this.panel1.TabIndex = 1;
            // 
            // btn_jatek
            // 
            this.btn_jatek.Location = new System.Drawing.Point(107, 36);
            this.btn_jatek.Name = "btn_jatek";
            this.btn_jatek.Size = new System.Drawing.Size(75, 35);
            this.btn_jatek.TabIndex = 1;
            this.btn_jatek.Text = "Játék!";
            this.btn_jatek.UseVisualStyleBackColor = true;
            this.btn_jatek.Click += new System.EventHandler(this.btn_jatek_Click);
            // 
            // dgv_preview
            // 
            this.dgv_preview.AllowUserToAddRows = false;
            this.dgv_preview.AllowUserToDeleteRows = false;
            this.dgv_preview.AllowUserToResizeColumns = false;
            this.dgv_preview.AllowUserToResizeRows = false;
            this.dgv_preview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_preview.ColumnHeadersVisible = false;
            this.dgv_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_preview.Location = new System.Drawing.Point(3, 16);
            this.dgv_preview.Name = "dgv_preview";
            this.dgv_preview.RowHeadersVisible = false;
            this.dgv_preview.Size = new System.Drawing.Size(270, 316);
            this.dgv_preview.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_preview);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 335);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Előnézet";
            // 
            // btn_csatlakozas
            // 
            this.btn_csatlakozas.Enabled = false;
            this.btn_csatlakozas.Location = new System.Drawing.Point(15, 36);
            this.btn_csatlakozas.Name = "btn_csatlakozas";
            this.btn_csatlakozas.Size = new System.Drawing.Size(75, 35);
            this.btn_csatlakozas.TabIndex = 3;
            this.btn_csatlakozas.Text = "Csatlakozás";
            this.btn_csatlakozas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_csatlakozas);
            this.groupBox2.Controls.Add(this.btn_jatek);
            this.groupBox2.Location = new System.Drawing.Point(30, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inditópult";
            // 
            // PalyaValasztoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listbox_palyak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PalyaValasztoForm";
            this.Text = "Pop it! GUI - by Csodacsapat [Pálya választó]";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_palyak;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_preview;
        private System.Windows.Forms.Button btn_jatek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_csatlakozas;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}