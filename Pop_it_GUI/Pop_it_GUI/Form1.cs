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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_kilepes_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_generalas_Click(object sender, EventArgs e)
        {
            //menü elrejtése
            Hide();
            //generálás menü mutatása
            GeneralasForm generalas = new GeneralasForm();
            generalas.Show();
        }

        private void btn_jatek_Click(object sender, EventArgs e)
        {
            //menü elrejtése
            Hide();
            //pályaválasztó menü mutatása
            PalyaValasztoForm valaszto = new PalyaValasztoForm();
            valaszto.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //a kilépés gomb használata nélkül se fusson a háttérben
            //ha bármely okból becsukódik a form, akkor kilép a program
            Environment.Exit(0);
        }

        private void btn_popithub_Click(object sender, EventArgs e)
        {
            Hub hub = new Hub();
            hub.Show();
        }
    }
}
