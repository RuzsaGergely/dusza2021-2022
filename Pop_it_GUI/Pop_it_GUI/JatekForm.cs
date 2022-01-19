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
        public JatekForm(int jatek_id)
        {
            InitializeComponent();
        }

        private void JatekForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
