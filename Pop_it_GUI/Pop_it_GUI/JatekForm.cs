using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pop_it_GUI
{
    public partial class JatekForm : Form
    {
        static List<Palya> palyak;
        public JatekForm(int jatek_id, List<Palya> lista)
        {
            InitializeComponent();
            palyak = lista;
            Kiiratas(jatek_id);
            lbl_uzenet.Text = "";
        }

        private void Kiiratas(int palya)
        {
            Szinek szines = new Szinek();
            dgv_jatekter.Columns.Clear();
            char[,] valasztott_palya = palyak[palya].palya;
            for (int i = 0; i < valasztott_palya.GetLength(0); i++)
            {
                dgv_jatekter.Columns.Add(i.ToString(), i.ToString());
                dgv_jatekter.Columns[i].Width = (dgv_jatekter.Width / valasztott_palya.GetLength(1))-2;
            }
            for (int i = 0; i < valasztott_palya.GetLength(0); i++)
            {
                int rowId = dgv_jatekter.Rows.Add();
                DataGridViewRow row = dgv_jatekter.Rows[rowId];
                row.Height = (dgv_jatekter.Height / valasztott_palya.GetLength(0))-2;
                for (int ii = 0; ii < valasztott_palya.GetLength(1); ii++)
                {
                    row.Cells[ii].Value = valasztott_palya[i, ii];
                    row.Cells[ii].Style.BackColor = szines.szinkodok[valasztott_palya[i, ii]];
                }
            }
        }

        private void JatekForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void lbl_ervenyesites_Click(object sender, EventArgs e)
        {
            JatekEllenor();
        }

        private void JatekForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Space)
            {
                JatekEllenor();
            }
        }

        private int jatekos = 1;
        private void JatekEllenor()
        {
            lbl_uzenet.Text = "";
            bool ervenyes_tamadas = true;
            string cella = dgv_jatekter.SelectedCells[0].Value.ToString();
            foreach (DataGridViewCell item in dgv_jatekter.SelectedCells)
            {
                if(item.Value.ToString() != cella)
                {
                    ervenyes_tamadas = false;
                    break;
                }
            }
            if (ervenyes_tamadas)
            {
                foreach (DataGridViewCell item in dgv_jatekter.SelectedCells)
                {
                    item.Style.BackColor = Color.Gray;
                }
                KijelolesTorlese();
                if (JatekVege())
                {
                    MessageBox.Show($"Játkos {jatekos} nyert! Gratulálok!", "A játékos időnek vége");
                    this.Close();
                }
                if (jatekos == 1)
                {
                    lbl_jatekos.Text = "Játékos: Játékos 2";
                    jatekos = 2;
                }
                else
                {
                    lbl_jatekos.Text = "Játékos: Játékos 1";
                    jatekos = 1;
                }
            } else
            {
                lbl_uzenet.Text = "Hiba! Érvénytelen lépés!";
            }
        }
        private bool JatekVege()
        {
            bool vege = true;
            foreach (DataGridViewRow row in dgv_jatekter.Rows)
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
            foreach (DataGridViewCell item in dgv_jatekter.SelectedCells)
            {
                item.Selected = false;
            }
        }
    }
}
