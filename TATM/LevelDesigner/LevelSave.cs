using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelDesign
{
    public partial class LevelSave : Form
    {
        public string levelName;
        public string publisherName;
        public LevelSave()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLevelName.Text != null)
            {
                levelName = txtLevelName.Text;
                if ((txtPubName.Text != null) && (txtPubName.Text != ""))
                {
                    publisherName = txtPubName.Text;
                }
                else
                {
                    publisherName = "Anonymous";
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Name Level!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
