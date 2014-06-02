using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlayer.Forms
{
    public partial class SaveGame : Form
    {
        public SaveGame()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tbx_GameName.Text != null)
            {
                StorageManagement.Filer.saveToFile(GamePlayer.game.GameController.CurrentGame.CurrentGameInstance.getInstance(), "../../Resources/xml/saves/" + tbx_GameName.Text);
                Close();
            }
            else
            {
                MessageBox.Show("plese enter save name");
            }
        }
    }
}
