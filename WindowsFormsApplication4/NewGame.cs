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
        public static int gridOffset = 100;
        public static int gridSize = 0;
        public static Image theseusImage = Image.FromFile(@"../../Images/Players/Theseus/Theseus.png");
        public static Image minotaurImage = Image.FromFile(@"../../Images/Players/MinoTaur/Minotaur.png");
        public static Image exitImage = Image.FromFile(@"../../Images/Stairs.png");
        public static char[,] MultiArray = new char[0, 0];


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

            string exitTest = "3,3";

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
            minotaurArray[0, 0] = 3;
            minotaurArray[1, 0] = 1;

            // change the sting to a int array
            exitArray[0, 0] = 3;
            exitArray[1, 0] = 3;
            

            //build the map from the array
            buildMap(walls);
        }


        
        protected void buildMap(string wallCreate)
        {
            char[] wallArray = wallCreate.ToCharArray();


            // convert to double then square root and convert back to int
            double gridSizeDouble = Convert.ToDouble(wallArray.Length);
            double gridSizeRootDouble = Math.Sqrt(gridSizeDouble);
            int gridSizeRoot = Convert.ToInt32(gridSizeRootDouble);
            NewGame.gridSize = gridSizeRoot;
            drawFloor(gridSizeRoot);
            drawExitTile(gridSizeRoot);
            
            // setting the grid size
            int gridCount = 0;
            int whichRow = 0;
 
            // defining the array for each row
            NewGame.MultiArray = new char[gridSizeRoot, gridSizeRoot];
            
 
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
                 drawTheseus();
                 drawMinotaur();
        }

        protected void drawExitTile(int gridSize)
        {
            int x = exitArray[0,0] * NewGame.coordinate + gridOffset;
            int y = exitArray[1,0] * NewGame.coordinate + gridOffset;
            drawRec(x, y, NewGame.coordinate, NewGame.coordinate, exitImage);
        }


        protected void drawVertical(int x, int y)
        {

            string wallVerticalImg = @"../../Images/Walls/VerticalWall.png";
            Image wallVertical = Image.FromFile(wallVerticalImg);

            y = y * NewGame.coordinate + gridOffset;
            x = x * NewGame.coordinate + gridOffset;

            drawRec(x, y-5, 8, 60, wallVertical);
        }


        protected void drawBoth(int y, int x)
        {
            string wallHorizontalImg = @"../../Images/Walls/HorizontalWall.png";
            Image wallHorizontal = Image.FromFile(wallHorizontalImg);
            string wallVerticalImg = @"../../Images/Walls/VerticalWall.png";
            Image wallVertical = Image.FromFile(wallVerticalImg);

            y = y * NewGame.coordinate + gridOffset;
            x = x * NewGame.coordinate + gridOffset;

            drawRec(x, y - 5, 55, 10, wallHorizontal);
            drawRec(x, y-5, 8, 60, wallVertical);
        }

        protected void drawHorizontal(int x, int y)
        {

            string wallHorizontalImg = @"../../Images/Walls/HorizontalWall.png";
            Image wallHorizontal = Image.FromFile(wallHorizontalImg);

            y = y * NewGame.coordinate + gridOffset - 5;
            x = x * NewGame.coordinate + gridOffset;

            drawRec(x, y, 55, 10, wallHorizontal);
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
                    int y1 = y * NewGame.coordinate + gridOffset;
                    int x1 = x * NewGame.coordinate + gridOffset;
                    //ltbLevel.Items.Add(floor1Image.Size.ToString());
                    if (i % 2 == 0)
                    {
                        drawRec(x1, y1, NewGame.coordinate, NewGame.coordinate, floor1Image);
                    }
                    else
                    {
                        drawRec(x1, y1, NewGame.coordinate, NewGame.coordinate, floor2Image);
                    }
                    i++;
                }
            }

        }

        protected void drawRec(int x, int y, int xSize,int ySize, Image image)
        {
            using (Graphics graphics = pnlGame.CreateGraphics())
            {
                Rectangle rect = new Rectangle(x, y, xSize, ySize);
                graphics.DrawImage(image, rect);
            }
        }

        protected void draw(int y, int x, Image image)
        {

            using (Graphics graphics = pnlGame.CreateGraphics())
            {
                graphics.DrawImage(image, new PointF(y, x));
            }
        }

        protected void drawTheseus()
        {
            int x = theseusArray[0, 0] * NewGame.coordinate + gridOffset;
            int y = theseusArray[1, 0] * NewGame.coordinate + gridOffset;

            drawRec(x, y, NewGame.coordinate, NewGame.coordinate, NewGame.theseusImage);
        }

        protected void drawMinotaur()
        {
            int x = minotaurArray[0, 0] * NewGame.coordinate + gridOffset;
            int y = minotaurArray[1, 0] * NewGame.coordinate + gridOffset;
            drawRec(x, y, NewGame.coordinate, NewGame.coordinate, minotaurImage);
        }

        protected void theseusMove (string direction)
        {

            string theseus = "theseus";
            int currentY = theseusArray[1, 0];
            int currentX = theseusArray[0, 0];
            bool canMove = false;

            if(direction == "UP" && checkWallUp() != true)
            {
                currentY--;
                canMove = true;
            }
            else if (direction == "DOWN" && checkWallDown() != true)
            {
                currentY++;
                canMove = true;
            }
            else if (direction == "LEFT" && checkWallLeft() != true)
            {
                currentX--;
                canMove = true;
            }
            else if (direction == "RIGHT" && checkWallRight() != true)
            {
                currentX++;
                canMove = true;
            }

            if (canMove == true)
            {
                // setting the old values in the array
                theseusArray[0, 1] = theseusArray[0, 0]; //x
                theseusArray[1, 1] = theseusArray[1, 0]; //y

                // new values
                theseusArray[1, 0] = currentY;
                theseusArray[0, 0] = currentX;

                drawPlayers(theseus);
            }
        }

        private bool checkWallLeft()
        {
            int x = theseusArray[0, 0];
            int y = theseusArray[1, 0];
            bool wallExists = false;

            char wallType = NewGame.MultiArray[y, x];
            ltbLevel.Items.Add(wallType.ToString());
            if (wallType == '1' || wallType == '2')
            {
                wallExists = true;
            }
            return wallExists;
        }

        private bool checkWallDown()
        {
            int x = theseusArray[0, 0];
            int y = theseusArray[1, 0];
            bool wallExists = false;

            char wallType = NewGame.MultiArray[y + 1, x];
            ltbLevel.Items.Add(wallType.ToString());
            if (wallType == '2' || wallType == '3')
            {
                wallExists = true;
            }
            return wallExists;
        }

        private bool checkWallRight()
        {
            int x = theseusArray[0, 0];
            int y = theseusArray[1, 0];
            bool wallExists = false;

            char wallType = NewGame.MultiArray[y, x + 1];
            ltbLevel.Items.Add(wallType.ToString());
            if (wallType == '1' || wallType == '2')
            {
                wallExists = true;
            }
            return wallExists;
        }

        private bool checkWallUp()
        {
            int x = theseusArray[0, 0];
            int y = theseusArray[1, 0];
            bool wallExists = false;

            char wallType = NewGame.MultiArray[y, x];
            ltbLevel.Items.Add(wallType.ToString());
            if (wallType == '2' || wallType == '3')
            {
                wallExists = true;
            }
            return wallExists;
        }

        protected void drawPlayers(string who)
        {
                if (who == "theseus")
                {
                    buildMap(walls);
                }
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

        private void NewGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            char upKey = 'w';
            char downKey = 's';
            char leftKey = 'a';
            char rightKey = 'd';

            if (e.KeyChar == upKey)
            {
                string direction = "UP";
                theseusMove(direction);
            }
            else if (e.KeyChar == leftKey)
            {
                string direction = "LEFT";
                theseusMove(direction);
            }
            else if (e.KeyChar == downKey)
            {
                string direction = "DOWN";
                theseusMove(direction);
            }
            else if (e.KeyChar == rightKey)
            {
                string direction = "RIGHT";
                theseusMove(direction);
            }
            
        }



    }
}
