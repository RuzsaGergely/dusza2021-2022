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
            GeneralasForm generalas = new GeneralasForm();
            generalas.Show();
        }

        private void btn_jatek_Click(object sender, EventArgs e)
        {
            PalyaValasztoForm valaszto = new PalyaValasztoForm(false);
            valaszto.Show();
        }

        private void btn_lanplay_Click(object sender, EventArgs e)
        {
            PalyaValasztoForm valaszto = new PalyaValasztoForm(true);
            valaszto.Show();
        }
    }
}
