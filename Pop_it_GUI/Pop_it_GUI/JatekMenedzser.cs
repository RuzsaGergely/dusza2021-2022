using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pop_it_GUI
{
    internal class JatekMenedzser
    {
        public DataGridView jatekter_grid { get; set; }
        public Label jatekos_status { get; set; }
        public Form aktualis_form { get; set; }
        public int jatekos { get; set; }  = 1 ;
        // 0 - jatekos 1
        // 1 - jatekos 2
        public int[] jatekos_stats { get; set; } = { 0, 0 };
        public Logger error_logger = new Logger("logs.txt");

        public JatekMenedzser(DataGridView jatekter, Label jatekos_status, Form aktualis_form)
        {
            this.jatekter_grid = jatekter;
            this.jatekos_status = jatekos_status;
            this.aktualis_form = aktualis_form;
        }

        public void JatekEllenor()
        {
            try
            {
                bool ervenyes_tamadas = true;
                string cella = jatekter_grid.SelectedCells[0].Value.ToString();
                foreach (DataGridViewCell item in jatekter_grid.SelectedCells)
                {
                    if (item.Value.ToString() != cella || item.Style.BackColor == Color.Gray)
                    {
                        ervenyes_tamadas = false;
                        break;
                    }
                }
                if (ervenyes_tamadas)
                {
                    foreach (DataGridViewCell item in jatekter_grid.SelectedCells)
                    {
                        item.Style.BackColor = Color.Gray;
                    }
                    if (jatekos == 1)
                    {
                        jatekos_status.Text = "Játékos: Játékos 2";
                        jatekos_stats[0] += jatekter_grid.SelectedCells.Count;
                        jatekos = 2;
                    }
                    else
                    {
                        jatekos_status.Text = "Játékos: Játékos 1";
                        jatekos_stats[1] += jatekter_grid.SelectedCells.Count;
                        jatekos = 1;
                    }
                    if (JatekVege())
                    {
                        if(jatekos == 1)
                            MessageBox.Show($"Játékos 2 nyert! Gratulálunk, szép játék volt!", "A játékos időnek vége");
                        else
                            MessageBox.Show($"Játékos 1 nyert! Gratulálunk, szép játék volt!", "A játékos időnek vége");

                        MessageBox.Show($"Statisztikák:\nJátékos 1 kinyomott mezői: {jatekos_stats[0]} db\nJátékos 2 kinyomott mezői: {jatekos_stats[1]} db", "Statisztika");
                        aktualis_form.Close();
                    }
                    KijelolesTorlese();
                }
                else
                {
                    MessageBox.Show("Érvénytelen lépés!", "Hiba!");
                }
            }
            catch (Exception ex)
            {
                error_logger.LogError(ex.ToString());
            }
        }
        private bool JatekVege()
        {
            bool vege = true;
            foreach (DataGridViewRow row in jatekter_grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor != Color.Gray)
                    {
                        vege = false;
                        break;
                    }
                }
            }
            return vege;
        }
        private void KijelolesTorlese()
        {
            foreach (DataGridViewCell item in jatekter_grid.SelectedCells)
            {
                item.Selected = false;
            }
        }
        public void Render(Palya palya)
        {
            Szinek szines = new Szinek();
            jatekter_grid.Columns.Clear();
            char[,] valasztott_palya = palya.palya;
            for (int i = 0; i < valasztott_palya.GetLength(0); i++)
            {
                jatekter_grid.Columns.Add(i.ToString(), i.ToString());
            }
            for (int i = 0; i < valasztott_palya.GetLength(0); i++)
            {
                int rowId = jatekter_grid.Rows.Add();
                DataGridViewRow row = jatekter_grid.Rows[rowId];
                row.Height = (jatekter_grid.Height / valasztott_palya.GetLength(0));
                for (int ii = 0; ii < valasztott_palya.GetLength(1); ii++)
                {
                    row.Cells[ii].Value = valasztott_palya[i, ii];
                    row.Cells[ii].Style.BackColor = szines.szinkodok[valasztott_palya[i, ii]];
                    row.Cells[ii].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    row.Cells[ii].Style.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
                }
            }
        }
    }
}
