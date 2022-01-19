
namespace Pop_it_GUI
{
    partial class JatekForm
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
            this.dgv_jatekter = new System.Windows.Forms.DataGridView();
            this.lbl_palyaneve = new System.Windows.Forms.Label();
            this.lbl_ido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_jatekter
            // 
            this.dgv_jatekter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jatekter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_jatekter.Location = new System.Drawing.Point(0, 101);
            this.dgv_jatekter.Name = "dgv_jatekter";
            this.dgv_jatekter.Size = new System.Drawing.Size(463, 349);
            this.dgv_jatekter.TabIndex = 0;
            // 
            // lbl_palyaneve
            // 
            this.lbl_palyaneve.Location = new System.Drawing.Point(159, 56);
            this.lbl_palyaneve.Name = "lbl_palyaneve";
            this.lbl_palyaneve.Size = new System.Drawing.Size(128, 28);
            this.lbl_palyaneve.TabIndex = 1;
            this.lbl_palyaneve.Text = "Palya0";
            this.lbl_palyaneve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ido
            // 
            this.lbl_ido.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ido.Location = new System.Drawing.Point(162, 22);
            this.lbl_ido.Name = "lbl_ido";
            this.lbl_ido.Size = new System.Drawing.Size(125, 34);
            this.lbl_ido.TabIndex = 2;
            this.lbl_ido.Text = "00:00";
            this.lbl_ido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JatekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.lbl_ido);
            this.Controls.Add(this.lbl_palyaneve);
            this.Controls.Add(this.dgv_jatekter);
            this.Name = "JatekForm";
            this.Text = "Pop it! GUI - by Csodacsapat [Játék]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JatekForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_jatekter;
        private System.Windows.Forms.Label lbl_palyaneve;
        private System.Windows.Forms.Label lbl_ido;
    }
}