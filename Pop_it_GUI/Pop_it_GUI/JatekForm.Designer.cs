
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
            this.lbl_ervenyesites = new System.Windows.Forms.Button();
            this.lbl_jatekos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_jatekter
            // 
            this.dgv_jatekter.AllowUserToAddRows = false;
            this.dgv_jatekter.AllowUserToDeleteRows = false;
            this.dgv_jatekter.AllowUserToResizeColumns = false;
            this.dgv_jatekter.AllowUserToResizeRows = false;
            this.dgv_jatekter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jatekter.ColumnHeadersVisible = false;
            this.dgv_jatekter.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_jatekter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_jatekter.Location = new System.Drawing.Point(0, 0);
            this.dgv_jatekter.Name = "dgv_jatekter";
            this.dgv_jatekter.RowHeadersVisible = false;
            this.dgv_jatekter.Size = new System.Drawing.Size(370, 270);
            this.dgv_jatekter.TabIndex = 0;
            // 
            // lbl_ervenyesites
            // 
            this.lbl_ervenyesites.Location = new System.Drawing.Point(195, 282);
            this.lbl_ervenyesites.Name = "lbl_ervenyesites";
            this.lbl_ervenyesites.Size = new System.Drawing.Size(163, 25);
            this.lbl_ervenyesites.TabIndex = 1;
            this.lbl_ervenyesites.Text = "Lépés érvényesítése (space)";
            this.lbl_ervenyesites.UseVisualStyleBackColor = true;
            this.lbl_ervenyesites.Click += new System.EventHandler(this.lbl_ervenyesites_Click);
            // 
            // lbl_jatekos
            // 
            this.lbl_jatekos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_jatekos.Location = new System.Drawing.Point(12, 282);
            this.lbl_jatekos.Name = "lbl_jatekos";
            this.lbl_jatekos.Size = new System.Drawing.Size(163, 24);
            this.lbl_jatekos.TabIndex = 2;
            this.lbl_jatekos.Text = "Játékos: Játékos 1";
            this.lbl_jatekos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JatekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 317);
            this.Controls.Add(this.lbl_jatekos);
            this.Controls.Add(this.lbl_ervenyesites);
            this.Controls.Add(this.dgv_jatekter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "JatekForm";
            this.Text = "Pop it! GUI - by Csodacsapat [Játék]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JatekForm_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JatekForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_jatekter;
        private System.Windows.Forms.Button lbl_ervenyesites;
        private System.Windows.Forms.Label lbl_jatekos;
    }
}