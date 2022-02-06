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
    public partial class GeneralasForm : Form
    {
        public GeneralasForm()
        {
            InitializeComponent();
        }

        private void GeneralasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //menü mutatása ha a from bezáródik
            var menu = new Form1();
            menu.Show();
        }

        private void GeneralasForm_DoubleClick(object sender, EventArgs e)
        {
            var asd = PalyaGenerator.General(1, 10, 4);
        }
    }
}
