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
        // Name of level
        public string levelName;
        // Name of publisher
        public string publisherName;
        public LevelSave()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // check for null text in levels name
            if (txtLevelName.Text != null)
            {
                // set level name as level name text
                levelName = txtLevelName.Text;
                // if publisher sets name make it that, otherwise set as anonymous
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
                // if the name is not set, ask for name
                MessageBox.Show("Please Name Level!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cancel save game
            this.Close();
        }
    }
}
