
namespace Pop_it_GUI
{
    partial class GeneralasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralasForm));
            this.nm_curves = new System.Windows.Forms.NumericUpDown();
            this.nm_ID = new System.Windows.Forms.NumericUpDown();
            this.nm_size = new System.Windows.Forms.NumericUpDown();
            this.dgv_jatekter = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_current = new System.Windows.Forms.TextBox();
            this.bg_prev_back = new System.Windows.Forms.Button();
            this.bt_prev_for = new System.Windows.Forms.Button();
            this.bt_generate = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nm_curves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nm_curves
            // 
            this.nm_curves.Location = new System.Drawing.Point(6, 103);
            this.nm_curves.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nm_curves.Name = "nm_curves";
            this.nm_curves.Size = new System.Drawing.Size(120, 20);
            this.nm_curves.TabIndex = 0;
            this.nm_curves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nm_ID
            // 
            this.nm_ID.Location = new System.Drawing.Point(6, 163);
            this.nm_ID.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nm_ID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_ID.Name = "nm_ID";
            this.nm_ID.Size = new System.Drawing.Size(120, 20);
            this.nm_ID.TabIndex = 1;
            this.nm_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nm_ID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nm_size
            // 
            this.nm_size.Location = new System.Drawing.Point(6, 43);
            this.nm_size.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nm_size.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nm_size.Name = "nm_size";
            this.nm_size.Size = new System.Drawing.Size(120, 20);
            this.nm_size.TabIndex = 2;
            this.nm_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nm_size.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // dgv_jatekter
            // 
            this.dgv_jatekter.AllowUserToAddRows = false;
            this.dgv_jatekter.AllowUserToDeleteRows = false;
            this.dgv_jatekter.AllowUserToResizeColumns = false;
            this.dgv_jatekter.AllowUserToResizeRows = false;
            this.dgv_jatekter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_jatekter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jatekter.ColumnHeadersVisible = false;
            this.dgv_jatekter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_jatekter.Location = new System.Drawing.Point(12, 12);
            this.dgv_jatekter.Name = "dgv_jatekter";
            this.dgv_jatekter.RowHeadersVisible = false;
            this.dgv_jatekter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_jatekter.Size = new System.Drawing.Size(543, 543);
            this.dgv_jatekter.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nm_size);
            this.groupBox1.Controls.Add(this.nm_curves);
            this.groupBox1.Controls.Add(this.nm_ID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(573, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 193);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generálási Faktorok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Méret";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hajlítások";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.tb_current);
            this.groupBox2.Controls.Add(this.bg_prev_back);
            this.groupBox2.Controls.Add(this.bt_prev_for);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(573, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 118);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Előnézet";
            // 
            // tb_current
            // 
            this.tb_current.Location = new System.Drawing.Point(6, 82);
            this.tb_current.Name = "tb_current";
            this.tb_current.Size = new System.Drawing.Size(124, 21);
            this.tb_current.TabIndex = 9;
            this.tb_current.Text = "1";
            this.tb_current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_current.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_current_KeyPress);
            // 
            // bg_prev_back
            // 
            this.bg_prev_back.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bg_prev_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bg_prev_back.BackgroundImage")));
            this.bg_prev_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bg_prev_back.Location = new System.Drawing.Point(6, 19);
            this.bg_prev_back.Name = "bg_prev_back";
            this.bg_prev_back.Size = new System.Drawing.Size(60, 50);
            this.bg_prev_back.TabIndex = 8;
            this.bg_prev_back.UseVisualStyleBackColor = false;
            this.bg_prev_back.Click += new System.EventHandler(this.bg_prev_back_Click);
            // 
            // bt_prev_for
            // 
            this.bt_prev_for.BackColor = System.Drawing.Color.Transparent;
            this.bt_prev_for.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_prev_for.BackgroundImage")));
            this.bt_prev_for.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_prev_for.Location = new System.Drawing.Point(70, 19);
            this.bt_prev_for.Name = "bt_prev_for";
            this.bt_prev_for.Size = new System.Drawing.Size(60, 50);
            this.bt_prev_for.TabIndex = 7;
            this.bt_prev_for.UseVisualStyleBackColor = false;
            this.bt_prev_for.Click += new System.EventHandler(this.bt_prev_for_Click);
            // 
            // bt_generate
            // 
            this.bt_generate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_generate.Location = new System.Drawing.Point(573, 211);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(136, 40);
            this.bt_generate.TabIndex = 6;
            this.bt_generate.Text = "generálás";
            this.bt_generate.UseVisualStyleBackColor = true;
            this.bt_generate.Click += new System.EventHandler(this.bt_generate_Click);
            // 
            // bt_save
            // 
            this.bt_save.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.Location = new System.Drawing.Point(573, 271);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(136, 40);
            this.bt_save.TabIndex = 7;
            this.bt_save.Text = "mentés";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_delete.Location = new System.Drawing.Point(573, 331);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(136, 40);
            this.bt_delete.TabIndex = 8;
            this.bt_delete.Text = "törlés";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exit.ForeColor = System.Drawing.Color.Red;
            this.bt_exit.Location = new System.Drawing.Point(573, 391);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(136, 40);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "kilépés";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // GeneralasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 567);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_generate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_jatekter);
            this.Name = "GeneralasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pop it! GUI - by Csodacsapat [Generálás]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralasForm_FormClosed);
            this.DoubleClick += new System.EventHandler(this.GeneralasForm_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.nm_curves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jatekter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nm_curves;
        private System.Windows.Forms.NumericUpDown nm_ID;
        private System.Windows.Forms.NumericUpDown nm_size;
        private System.Windows.Forms.DataGridView dgv_jatekter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bg_prev_back;
        private System.Windows.Forms.Button bt_prev_for;
        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.TextBox tb_current;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_exit;
    }
}