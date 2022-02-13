using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pop_it_GUI
{
    public partial class PalyaValasztoForm : Form
    {
        public PalyaValasztoForm(bool lan)
        {
            InitializeComponent();
            PalyakBeolvasas();
            if (lan)
            {
                btn_csatlakozas.Enabled = true;
                LAN = true;
            }
                
        }
        static List<Palya> palyak = new List<Palya>();
        static bool LAN;

        public void PalyakBeolvasas()
        {
            string[] fajlok = Directory.GetFiles(@"palyak");
            int id = 0;
            foreach (var item in fajlok)
            {
                StreamReader reader = new StreamReader(item);
                string nev = reader.ReadLine();
                string[] meret = reader.ReadLine().Split(';');
                char[,] palya = new char[Convert.ToInt32(meret[0]), Convert.ToInt32(meret[0])];
                for (int i = 0; i < palya.GetLength(0); i++)
                {
                    string sor = reader.ReadLine();
                    for (int ii = 0; ii < palya.GetLength(1); ii++)
                    {
                        palya[i, ii] = sor[ii];
                    }
                }
                palyak.Add(new Palya(id, nev, palya));
                id++;
                listbox_palyak.Items.Add(nev);
            }
        }

        private void btn_jatek_Click(object sender, EventArgs e)
        {
            JatekIndit();
        }

        private void JatekIndit()
        {
            //a kijelölt pálya in továbbadása, kijelölés hiányában az 1-es indexet adja tovább
            if (LAN)
            {
                JatekForm jatek = new JatekForm((listbox_palyak.SelectedIndex != -1) ? listbox_palyak.SelectedIndex : 1, palyak);
                jatek.Show();
                this.Hide();
            } else
            {
                JatekFormLAN jatek = new JatekFormLAN((listbox_palyak.SelectedIndex != -1) ? listbox_palyak.SelectedIndex : 1, palyak);
                jatek.Show();
                this.Hide();
            }
        }
        static Szinek szines = new Szinek();
        private void listbox_palyak_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_preview.Columns.Clear();
                char[,] valasztott_palya = palyak[listbox_palyak.SelectedIndex].palya;
                for (int i = 0; i < valasztott_palya.GetLength(0); i++)
                {
                    dgv_preview.Columns.Add(i.ToString(), i.ToString());
                    dgv_preview.Columns[i].Width = 20;
                }
                for (int i = 0; i < valasztott_palya.GetLength(0); i++)
                {
                    int rowId = dgv_preview.Rows.Add();
                    DataGridViewRow row = dgv_preview.Rows[rowId];
                    for (int ii = 0; ii < valasztott_palya.GetLength(1); ii++)
                    {
                        row.Cells[ii].Value = valasztott_palya[i, ii];
                        row.Cells[ii].Style.BackColor = szines.szinkodok[valasztott_palya[i, ii]];
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void listbox_palyak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                JatekIndit();
            }
        }

        private void PalyaValasztoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //menü mutatása ha a from bezáródik
            var menu = new Form1();
            menu.Show();
        }

        private void PalyaValasztoForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
