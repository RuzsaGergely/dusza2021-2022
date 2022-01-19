
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
            this.dgv_preview = new System.Windows.Forms.DataGridView();
            this.btn_jatek = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // listbox_palyak
            // 
            this.listbox_palyak.Dock = System.Windows.Forms.DockStyle.Left;
            this.listbox_palyak.FormattingEnabled = true;
            this.listbox_palyak.Location = new System.Drawing.Point(0, 0);
            this.listbox_palyak.Name = "listbox_palyak";
            this.listbox_palyak.Size = new System.Drawing.Size(215, 450);
            this.listbox_palyak.TabIndex = 0;
            this.listbox_palyak.SelectedIndexChanged += new System.EventHandler(this.listbox_palyak_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_jatek);
            this.panel1.Controls.Add(this.dgv_preview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(222, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 450);
            this.panel1.TabIndex = 1;
            // 
            // dgv_preview
            // 
            this.dgv_preview.AllowUserToAddRows = false;
            this.dgv_preview.AllowUserToDeleteRows = false;
            this.dgv_preview.AllowUserToResizeColumns = false;
            this.dgv_preview.AllowUserToResizeRows = false;
            this.dgv_preview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_preview.ColumnHeadersVisible = false;
            this.dgv_preview.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_preview.Location = new System.Drawing.Point(0, 0);
            this.dgv_preview.Name = "dgv_preview";
            this.dgv_preview.RowHeadersVisible = false;
            this.dgv_preview.Size = new System.Drawing.Size(276, 307);
            this.dgv_preview.TabIndex = 0;
            // 
            // btn_jatek
            // 
            this.btn_jatek.Location = new System.Drawing.Point(59, 341);
            this.btn_jatek.Name = "btn_jatek";
            this.btn_jatek.Size = new System.Drawing.Size(156, 63);
            this.btn_jatek.TabIndex = 1;
            this.btn_jatek.Text = "Játék!";
            this.btn_jatek.UseVisualStyleBackColor = true;
            this.btn_jatek.Click += new System.EventHandler(this.btn_jatek_Click);
            // 
            // PalyaValasztoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listbox_palyak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PalyaValasztoForm";
            this.Text = "Pop it! GUI - by Csodacsapat [Pálya választó]";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_palyak;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_preview;
        private System.Windows.Forms.Button btn_jatek;
    }
}