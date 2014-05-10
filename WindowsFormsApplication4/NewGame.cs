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
        // declare gloabal var
        public static int coordinate = 50;
        public static int[,] theseusArray = new int[2, 2];
        public static int[,] minotaurArray = new int[2, 2];
        public static int[,] exitArray = new int[2, 2];
        public static string walls = "";


        public NewGame()
        {
            InitializeComponent();
        //    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGame_KeyDown);
            this.pnlGame.Focus();

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

        private void btnLoad_Click(object sender, EventArgs e)
        {

            walls = "2333112441134411444133334";

            string thesusTest = "0,1";

            string minotaurTest = "4,1";

            string exitTest = "5,5";

            build(walls, thesusTest, minotaurTest, exitTest);
        }

        

        private void build(string wallCreate, string thesusCreate, string minotaurCreate, string exitCreate)
        {

            // change the string to a char array
            //char[] wallArray = wallCreate.ToCharArray();
            
            // change the sting to a int array
            theseusArray[0, 0] = 0;
            theseusArray[1, 0] = 1;

            // change the sting to a int array
            minotaurArray[0, 0] = 4;
            minotaurArray[1, 0] = 1;

            // change the sting to a int array
            exitArray[0, 0] = 5;
            exitArray[1, 0] = 5;
            

            //build the map from the array
            buildMap(walls);

            //place Thesus & Minotaur & Exit
            buildCharacters();


        }


        
        protected void buildMap(string wallCreate)
        {
            char[] wallArray = wallCreate.ToCharArray();


            // convert to double then square root and convert back to int
            double gridSizeDouble = Convert.ToDouble(wallArray.Length);
            double gridSizeRootDouble = Math.Sqrt(gridSizeDouble);
            int gridSizeRoot = Convert.ToInt32(gridSizeRootDouble);

            drawFloor(gridSizeRoot);
            
            // setting the grid size
            int gridCount = 0;
            int whichRow = 0;
 
            // defining the array for each row
            char[,] MultiArray = new char[gridSizeRoot, gridSizeRoot];
            
 
             // looping - lenght on the string
             for (int i = 0; i < wallArray.Length; i++)
             {
                // checking if its to the grid size to splice to the next row
                if(gridCount == gridSizeRoot)
                {
                    gridCount = 0;
                    whichRow++;                 
                }
 
                 // adding into the mulidimentional array
                 MultiArray[whichRow, gridCount] = wallArray[i];


                 gridCount++;
             }
            

                 for (int x = 0; x < gridSizeRoot; x++)                
                 {
                     for (int y = 0; y < gridSizeRoot; y++)
                     {

                         switch (MultiArray[x, y])
                         {
 
                             case '1':
                                drawVertical(y,x);
                                 break;
 
                             case '2':
                                 drawBoth(y, x);
                                 break;
 
                              case '3':
                                 drawHorizontal(y, x);
                                 break;
 
                              case '4':
                                 // grass??
                                 break;
 
                         }
 
                     }
 
                 
                }
        }


        protected void drawVertical(int y, int x)
        {

            string wallVerticalImg = @"../../Images/Walls/VerticalWall.png";
            Image wallVertical = Image.FromFile(wallVerticalImg);

            y = y * NewGame.coordinate;
            x = x * NewGame.coordinate;

            draw(y, x, wallVertical);

        }


        protected void drawBoth(int y, int x)
        {
            string wallHorizontalImg = @"../../Images/Walls/HorizontalWall.png";
            Image wallHorizontal = Image.FromFile(wallHorizontalImg);
            string wallVerticalImg = @"../../Images/Walls/VerticalWall.png";
            Image wallVertical = Image.FromFile(wallVerticalImg);

            y = y * NewGame.coordinate;
            x = x * NewGame.coordinate;

            draw(y, x, wallHorizontal);
            draw(y, x, wallVertical);
            

        }

        protected void drawHorizontal(int y, int x)
        {

            string wallHorizontalImg = @"../../Images/Walls/HorizontalWall.png";
            Image wallHorizontal = Image.FromFile(wallHorizontalImg);

            y = y * NewGame.coordinate;
            x = x * NewGame.coordinate;

            draw(y, x, wallHorizontal);

        }

        protected void drawFloor(int gridSize)
        {

            string floor1 = @"../../Images/Ground1.png";
            string floor2 = @"../../Images/Ground2.png";
            Image floor1Image = Image.FromFile(floor1);
            Image floor2Image = Image.FromFile(floor2);

            int i = 0;  
            for (int x = 0; x < (gridSize-1); x++)
            {
                i++;
                for (int y = 0; y < (gridSize-1); y++)
                {
                    int y1 = y * NewGame.coordinate + 300;
                    int x1 = x * NewGame.coordinate + 300;
                    //ltbLevel.Items.Add(floor1Image.Size.ToString());
                    if (i % 2 == 0)
                    {
                        //draw(y1, x1, floor1Image);
                        using (Graphics graphics = pnlGame.CreateGraphics())
                        {
                            Rectangle destRect = new Rectangle(x1, y1, 50, 50);
                            graphics.DrawImage(floor1Image, destRect);
                        }
                    }
                    else
                    {
                        //draw(y1, x1, floor2Image);
                        using (Graphics graphics = pnlGame.CreateGraphics())
                        {
                            Rectangle destRect = new Rectangle(x1, y1, 50, 50);
                            graphics.DrawImage(floor2Image, destRect);
                        }
                    }
                    i++;
                }
            }

        }

        protected void draw(int y, int x, Image image)
        {

            using (Graphics graphics = pnlGame.CreateGraphics())
            {
                graphics.DrawImage(image, new PointF(y, x));
            }
        }



        protected void buildCharacters()
        {

            //change for diffrent computer -wip-
            string begingPath = @"../../";

            //set the images
            string theseus = begingPath + @"Images/Players/Theseus.png";
            Image thesusImg = Image.FromFile(theseus);

            string minotaur = begingPath + @"Images/Players/Minotaur.png";
            Image minotaurImg = Image.FromFile(minotaur);

            string exit = begingPath + @"Images/Players/Exit.png";
            Image exitImg = Image.FromFile(exit);


                using (Graphics graphics = pnlGame.CreateGraphics())
                {

                    graphics.DrawImage(thesusImg, new Point(theseusArray[0, 0] * NewGame.coordinate, theseusArray[1, 0] * NewGame.coordinate));
                    graphics.DrawImage(minotaurImg, new Point(minotaurArray[0, 0] * NewGame.coordinate, minotaurArray[1, 0] * NewGame.coordinate));
                    //graphics.DrawImage(exitImg, new Point(exitArray[0,0] * NewGame.coordinate, exitArray[1,0] * NewGame.coordinate));

                }
        }


        protected void theseusMove (string direction)
        {

            string theseus = "theseus";
            int currentY = theseusArray[1, 0];
            int currentX = theseusArray[0, 0];

            if(direction == "UP")
            {
                currentY--;
            }
            else if (direction == "DOWN")
            {
                currentY++;
            }
            else if (direction == "LEFT")
            {
                currentX--;
            }
            else if (direction == "RIGHT")
            {
                currentX++;
            }
            // setting the old values in the array
            theseusArray[0, 1] = theseusArray[0, 0]; //x
            theseusArray[1, 1] = theseusArray[1, 0]; //y

            // new values
            theseusArray[1, 0] = currentY;
            theseusArray[0, 0] = currentX;

            drawPlayers(theseus);
        }

        protected void drawPlayers(string who)
        {
            string theseus = @"../../Images/Players/Theseus.png";
            Image thesusImg = Image.FromFile(theseus);
            
            using (Graphics graphics = pnlGame.CreateGraphics())
            {
                if (who == "theseus")
                {
                    buildMap(walls);
                    graphics.DrawImage(thesusImg, new Point(theseusArray[0, 0] * NewGame.coordinate, theseusArray[1, 0] * NewGame.coordinate));
                }
            }
        }


        private void NewGame_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
              
            }

            if (e.KeyCode == Keys.A)
            {

            }
            if (e.KeyCode == Keys.S)
            {

            }
            if (e.KeyCode == Keys.D)
            {

            }
            ltbLevel.Items.Add("a");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string direction = "UP";
            theseusMove(direction);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            string direction = "LEFT";
            theseusMove(direction);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            string direction = "RIGHT";
            theseusMove(direction);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string direction = "DOWN";
            theseusMove(direction);
        }

    }
}
