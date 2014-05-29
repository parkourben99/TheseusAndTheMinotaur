using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelDesign
{
    public partial class LevelSelect : Form
    {
        public string selectedLevelName;
        public LevelSelect(List<string> levels )
        {
            InitializeComponent();
            foreach (string level in levels)
            {
                lBoxLevels.Items.Add(level);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lBoxLevels.SelectedItem != null)
            {
                selectedLevelName = (string)lBoxLevels.SelectedItem;
                this.Close();
            }
            else
            {
                MessageBox.Show("No Level Selected!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void LevelSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
