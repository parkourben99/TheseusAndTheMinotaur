using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class NewGame : Form
    {

        public NewGame()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry no help here :( ", "Help");
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            string wallTest = "2333112441134411444133333";

            string thesusTest = "21";

            string minotaurTest = "41";

            string exitTest = "55";

            build(wallTest, thesusTest, minotaurTest, exitTest);

        }



        protected void build(string wallCreate, string thesusCreate, string minotaurCreate, string exitCreate)
        {

            // change the string to a char array
            char[] wallArray = wallCreate.ToCharArray();
            
            // change the sting to a char array
            char[] thesusArray = thesusCreate.ToCharArray();

            // change the sting to a char array
            char[] minotaurArray = minotaurCreate.ToCharArray();

            // change the sting to a char array
            char[] exitArray = exitCreate.ToCharArray();

            // fining the grid size
            int gridSize = calcGridSize(wallCreate.Length);

            //build the map from the array
            buildMap(wallArray, gridSize);

            //place Thesus & Minotaur & Exit
            //buildCharacters(thesusArray, minotaurCreate, exitArray);


        }

        protected void buildMap(char[] wallArray, int gridSize)
        {
            //change for diffrent computer -wip-
            string begingPath = @"C:\Users\Benjamin Ayles\Desktop\Project\TheseusAndTheMinotaur\WindowsFormsApplication4\";
            
            //set the images
            string wallHorizontalImg = begingPath + @"Images\Walls\horizontal.png";
            Image wallHorizontal = Image.FromFile(wallHorizontalImg);

            string wallVerticalImg = begingPath + @"Images\Walls\vertical.png";
            Image wallVertical = Image.FromFile(wallVerticalImg);

            string wallTopLeftImg = begingPath + @"Images\Walls\top_left.png";
            Image wallTopLeft = Image.FromFile(wallTopLeftImg);

            string wallTopRightImg = begingPath + @"Images\Walls\top_right.png";
            Image wallTopRight = Image.FromFile(wallTopRightImg);

            string wallBottomLeftImg = begingPath + @"Images\Walls\bottom_left.png";
            Image wallBottomLeft = Image.FromFile(wallBottomLeftImg);

            string wallBottomRightImg = begingPath + @"Images\Walls\bottom_right.png";
            Image wallBottomRight = Image.FromFile(wallBottomRightImg);

            // convert to double then square root and convert back to int
            double gridSizeDouble = Convert.ToDouble(gridSize);
            double gridSizeRootDouble = Math.Sqrt(gridSizeDouble);
            int gridSizeRoot = Convert.ToInt32(gridSizeRootDouble);


            lblScore.Text = gridSizeRoot.ToString();
            if (gridSizeRoot == 5)
            {
                using (Graphics graphics = pnlGame.CreateGraphics())
                {


                    graphics.DrawImage(wallTopLeft, new Point(0, 0));
                    graphics.DrawImage(wallHorizontal, new Point(60, 0));
                    graphics.DrawImage(wallHorizontal, new Point(104 + 60, 0));
                    graphics.DrawImage(wallHorizontal, new Point(104 + 60 + 104, 0));
                    graphics.DrawImage(wallTopRight, new Point(312 + 60, -12));


                }
            }




        }


        protected int calcGridSize(int wallLength)
        {
            int gridSize = 0;

            if (wallLength >= 9)
            {
                // set the grid size if 3x3
                gridSize = 9;

                if (wallLength >= 16)
                {
                    // set gird size if 4x4
                    gridSize = 16;

                    if (wallLength >= 25)
                    {
                        //set grid size if 5x5
                        gridSize = 25;

                        if (wallLength >= 36)
                        {
                            //set grid size if 6x6
                            gridSize = 36;

                            if (wallLength >= 49)
                            {
                                //set grid size if 7x7
                                gridSize = 49;

                                if (wallLength >= 64)
                                {
                                    //set grid size if 8x8
                                    gridSize = 64;

                                    if (wallLength >= 81)
                                    {
                                        //set grid size if 9x9
                                        gridSize = 81;

                                        if (wallLength >= 100)
                                        {
                                            //set grid size if 10x10
                                            gridSize = 100;

                                        }

                                    }

                                }
                            }

                        }

                    }

                }
            }

            return gridSize;
        }








    }
}
