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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            var menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private List<Palya> cache = new List<Palya>();
        private int selectedID = -1;

        private void bt_generate_Click(object sender, EventArgs e)
        {
            selectedID = cache.Count - 1;
            cache.Add(PalyaGenerator.General((int)nm_ID.Value, (int)nm_size.Value, (int)nm_curves.Value));
            tb_current.Text = (++selectedID + 1).ToString();
            new JatekMenedzser(dgv_jatekter, null, this).Render(cache[selectedID]);
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                cache.RemoveAt(0);
                dgv_jatekter.Columns.Clear();
                selectedID--;
            }
            else if (selectedID > 0)
            {
                cache.RemoveAt(selectedID--);
                new JatekMenedzser(dgv_jatekter, null, this).Render(cache[selectedID]);
            }
        }

        private void bg_prev_back_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
                new JatekMenedzser(dgv_jatekter, null, this).Render(cache[--selectedID]);
            tb_current.Text = (selectedID + 1).ToString();
        }

        private void bt_prev_for_Click(object sender, EventArgs e)
        {
            if (selectedID < cache.Count - 1)
                new JatekMenedzser(dgv_jatekter, null, this).Render(cache[++selectedID]);
            tb_current.Text = (selectedID + 1).ToString();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            string palya_neve = "";
            if(tb_palyanev.TextLength > 0)
            {
                palya_neve = $"palya_{tb_palyanev.Text.ToLowerInvariant()}";
            } else
            {
                try
                {
                    palya_neve = $"palya_{cache[selectedID].id}";
                }
                catch (Exception)
                {
                    MessageBox.Show("Mentés előtt generálnia kell egy pályát!");
                    return;
                }
            }
            using (var writer = new StreamWriter(File.Create(Path.Combine("palyak", $"{palya_neve}.txt")), Encoding.UTF8))
            {
                writer.WriteLine(palya_neve);
                writer.WriteLine($"{cache[selectedID].palya.GetLength(0)};{cache[selectedID].palya.GetLength(0)}");
                for (int i = 0; i < cache[selectedID].palya.GetLength(0); i++)
                {
                    for (int j = 0; j < cache[selectedID].palya.GetLength(0); j++)
                    {
                        writer.Write(cache[selectedID].palya[i,j]);
                    }
                    writer.WriteLine();
                }
                //writer.Close();
                MessageBox.Show("A pálya mentése sikeres volt!");
            }
        }

        private void tb_current_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)13:
                    int.TryParse(tb_current.Text, out selectedID);
                    selectedID--;
                    if (selectedID > cache.Count - 1)
                    {
                        selectedID = cache.Count - 1;
                        tb_current.Text = (selectedID + 1).ToString();
                    }
                    else if (selectedID < 1)
                    {
                        selectedID = 0;
                        tb_current.Text = (selectedID + 1).ToString();
                    }
                    new JatekMenedzser(dgv_jatekter, null, this).Render(cache[selectedID]);
                    break;
            }
        }
    }
}
