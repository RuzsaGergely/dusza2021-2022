using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Pop_it_GUI
{
    public partial class JatekFormLAN : Form
    {
        static List<Palya> palyak;
        static JatekMenedzser jatek;
        public JatekFormLAN(int jatek_id, List<Palya> lista)
        {
            InitializeComponent();
            palyak = lista;
            jatek = new JatekMenedzser(dgv_jatekter, lbl_jatekos, this);
            jatek.Render(palyak[jatek_id]);
        }

        private void JatekForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //menü mutatása ha a from bezáródik
            var menu = new Form1();
            menu.Show();
        }

        private void lbl_ervenyesites_Click(object sender, EventArgs e)
        {
            jatek.JatekEllenor();
        }

        private void JatekForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                jatek.JatekEllenor();
            }
        }
    }
}
