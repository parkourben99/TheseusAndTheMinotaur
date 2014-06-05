using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LevelDesign.CustomControl;
using LevelDesign.Model;

namespace LevelDesign
{
    public partial class LevelDesign : Form
    {
        private Theseus theseus;
        private Minotaur minotaur;
        private int count = 0;
        private Button TheClickedButton;
        public CustomControl_Button OldTheseusButton;
        private CustomControl_Button OldMinotaurButton;
        private CustomControl_Button OldExitButton;
        public LevelDesign()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("15 x 15");
            comboBox1.Items.Add("14 x 14");
            comboBox1.Items.Add("13 x 13");
            comboBox1.Items.Add("12 x 12");
            comboBox1.Items.Add("11 x 11");
            comboBox1.Items.Add("10 x 10");
            comboBox1.Items.Add("9 x 9");
            comboBox1.Items.Add("8 x 8");
            comboBox1.Items.Add("7 x 7");
            comboBox1.Items.Add("6 x 6");
            comboBox1.Items.Add("5 x 5");

        }
        protected void createGameBoard(int rows, int columns, bool isloaded)
        {
            if (isloaded != true)
            {
                //creating Level
                LevelDesigner.createLevel(rows, columns);
                LevelDesigner.MyLevel.CreateCells();
            }

            //Clear out the existing controls, we are generating a new table layout
            GameBoard.Controls.Clear();
            GameBoard.ColumnStyles.Clear();
            GameBoard.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            GameBoard.ColumnCount = columns;
            GameBoard.RowCount = rows;

            //creating rows
            for (int y = 0; y < LevelDesigner.MyLevel.Height; y++)
            {
                //create a row
                GameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                
                //creating columns
                for (int x = 0; x < LevelDesigner.MyLevel.Width; x++)
                {
                    //create the grid
                    CustomControl_Button btn_Cell = new CustomControl_Button() { Name = count.ToString() };

                    //adding the cells from cell collection to the btn
                    btn_Cell.ChildCell = LevelDesigner.MyLevel.CellCollection[count];

                    //setting the button size  
                    btn_Cell.Size = new Size(40, 40);
                    btn_Cell.Padding = new Padding(0);
                    btn_Cell.Margin = new Padding(0);
                    btn_Cell.Click += Button_OnClick_For_Cell;

                    MenuItem m1 = new MenuItem("LeftTile", new EventHandler(ContextMenu_OnClick_For_TileLeft));
                    MenuItem m2 = new MenuItem("UpTile", new EventHandler(ContextMenu_OnClick_For_TileUp));
                    MenuItem m3 = new MenuItem("BlankTile", new EventHandler(ContextMenu_OnClick_For_TileBlank));
                    MenuItem m4 = new MenuItem("LeftUpTile", new EventHandler(ContextMenu_OnClick_For_TileLeftUp));
                    MenuItem m5 = new MenuItem("Exit", new EventHandler(ContextMenu_OnClick_For_TileExit));
                    MenuItem m6 = new MenuItem("Theseus", new EventHandler(ContextMenu_OnClick_For_Theseus));
                    MenuItem m7 = new MenuItem("Minotaur", new EventHandler(ContextMenu_OnClick_For_Minotaur));

                    btn_Cell.ContextMenu = new System.Windows.Forms.ContextMenu();
                    btn_Cell.ContextMenu.MenuItems.Add(m1);
                    btn_Cell.ContextMenu.MenuItems.Add(m2);
                    btn_Cell.ContextMenu.MenuItems.Add(m3);
                    btn_Cell.ContextMenu.MenuItems.Add(m4);
                    btn_Cell.ContextMenu.MenuItems.Add(m5);
                    btn_Cell.ContextMenu.MenuItems.Add(m6);
                    btn_Cell.ContextMenu.MenuItems.Add(m7);

                    //Finally, add the control to the correct location in the table
                    GameBoard.Controls.Add(btn_Cell, x, y);
                    count += 1;
                }
            }
            if (isloaded != true)
            {
            //AddBorders();
            theseus = new Theseus();
            minotaur = new Minotaur();
            }
        }
        protected void ContextMenu_OnClick_For_Theseus(object sender, object e)
        {
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //initiating an instance of Cell class
            if (OldTheseusButton != null)
            {
                OldTheseusButton.ClearCharacters();
            }
            OldTheseusButton = theButton;
            theButton.ChildCharacter = theseus;

            LevelDesigner.MyLevel.TheseusLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(theButton.ChildCell);
        }
        
        protected void ContextMenu_OnClick_For_Minotaur(object sender, object e)
        {
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //initiating an instance of Cell class
            if (OldMinotaurButton != null)
            {
                OldMinotaurButton.ClearCharacters();
            }
            OldMinotaurButton = theButton;
            theButton.ChildCharacter = minotaur;

            LevelDesigner.MyLevel.MinotaurLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(theButton.ChildCell);

        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // left
        protected void ContextMenu_OnClick_For_TileLeft(object sender, object e)
        {
            SetCellWallTile(sender, CellType.Left);
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Up
        protected void ContextMenu_OnClick_For_TileUp(object sender, object e)
        {
            SetCellWallTile(sender, CellType.Up);
        }

        // OnClick function for Cell Buttons
        protected void Button_OnClick_For_Cell(object sender, object e)
        {
            if(this.TheClickedButton != null){
                //converting the sender to button
                CustomControl_Button theButton = sender as CustomControl_Button;
                //initiating an instance of Cell class
                if (this.TheClickedButton.Name == "btn_Theseus")
                {

                    
                        if (OldTheseusButton != null)
                        {
                            OldTheseusButton.ClearCharacters();
                            OldTheseusButton = null;
                        }
                        OldTheseusButton = theButton;
                        theButton.ChildCharacter = theseus;

                    
                }
                else if (this.TheClickedButton.Name == "btn_Minotaur")
                {

                        if (OldTheseusButton != null)
                        {
                            OldTheseusButton.ClearCharacters();
                            OldTheseusButton = null;
                        }
                        OldTheseusButton = theButton;
                        theButton.ChildCharacter = minotaur;

                }
                else
                {
                    Cell cell = new Cell();
                    switch (this.TheClickedButton.Name)
                    {
                        case "btn_TileLeft":
                            //Set the type of the instance to CellType.Left
                            cell.Type = CellType.Left;
                            break;
                        case "btn_TileUp":
                            //Set the type of the instance to CellType.Up
                            cell.Type = CellType.Up;
                            break;
                        case "btn_TileBlank":
                            //Set the type of the instance to CellType.Blank
                            //add correct flor tile
                            cell.Type = CellType.Ground;
                            break;
                        case "btn_TileLeftUp":
                            //Set the type of the instance to CellType.LeftUp
                            cell.Type = CellType.LeftUP;
                            break;
                        case "btn_TileExit":
                            //Set the type of the instance to CellType.Exit
                            cell.Type = CellType.Exit;
                            break;
                    }
                    //sets the button
                    theButton.ChildCell = cell;
                }
            }
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Blank
        protected void ContextMenu_OnClick_For_TileBlank(object sender, object e)
        {
            SetCellWallTile(sender, CellType.Ground);
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Up-left
        protected void ContextMenu_OnClick_For_TileLeftUp(object sender, object e)
        {
            SetCellWallTile(sender, CellType.LeftUP);
        }

        private void SetCellWallTile(object sender, CellType type)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //create a cell object with apporiate wall
            // Cell cell = new Cell() { Type = CellType.LeftUP };
            //assign the cell instance to the button
            // theButton.ChildCell = cell;

            theButton.ChildCell.Type = type;
            theButton.DrawBackgroundImage(theButton.ChildCell.Type);
        }

        protected void ContextMenu_OnClick_For_TileExit(object sender, object e)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;

            if (OldExitButton != null)
            {
                OldExitButton.DrawBackgroundImage(OldExitButton._PreviousCell.Type);
            }
            OldExitButton = theButton;
            OldExitButton._PreviousCell = OldExitButton.ChildCell;
            
            //create a cell object with apporiate wall
            Cell cell = new Cell() { Type = CellType.Exit };
            //assign the cell instance to the button
            theButton.ChildCell = cell;
       //     theButton.ChildCell.Type = CellType.Exit;

            LevelDesigner.MyLevel.ExitLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(OldExitButton._PreviousCell);
          
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (var levelSave = new LevelSave())
            {
                levelSave.ShowDialog();
                LevelDesigner.MyLevel.LevelName = levelSave.levelName;
                LevelDesigner.MyLevel.LevelPublisher = levelSave.publisherName;
            }
            if (!String.IsNullOrWhiteSpace(LevelDesigner.MyLevel.LevelName))
            {
                
                StorageManagement.StorageManagement.saveLevel(LevelDesigner.MyLevel);
                MessageBox.Show("Level is \"Saved\"");
            }
            else
            {
                MessageBox.Show("Please give a name for the Level");
            }

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            List<string> allLevels = StorageManagement.StorageManagement.getLevelList();
            using (var levelSelect = new LevelSelect(allLevels))
            {
                levelSelect.ShowDialog();
                if (levelSelect.selectedLevelName != null)
                {
                    if (StorageManagement.StorageManagement.loadLevel(levelSelect.selectedLevelName) != null){
                        LevelDesigner.MyLevel = StorageManagement.StorageManagement.loadLevel(levelSelect.selectedLevelName);
                        createGameBoard(LevelDesigner.MyLevel.Height, LevelDesigner.MyLevel.Width, true);
                        comboBox1.Visible = false;
                        btn_Load.Visible = false;

                        minotaur = new Minotaur();
                        theseus = new Theseus();

                        loadGameBoard(LevelDesigner.MyLevel, sender, theseus, minotaur);

                    }
                }
            }

        } 

        private static void loadGameBoard(Level level, object sender, Theseus theseus, Minotaur minotaur)
        {
            int Theseus = level.TheseusLocation;
            int Minotaur = level.MinotaurLocation;
            int Exit = level.ExitLocation;
            int count = 0;

            Button loadButton = sender as Button;
            var theButton = sender as CustomControl_Button;
            Form parentForm = loadButton.FindForm();


            foreach (Cell cell in level.CellCollection)
            {
                theButton = parentForm.Controls.Find(count.ToString(), true).FirstOrDefault() as CustomControl_Button;


                if (Theseus == count)
                {
                    
                    OldTheseusButton = theButton;
                    OldTheseusButton.ChildCharacter = theseus;

                    LevelDesigner.MyLevel.TheseusLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(OldTheseusButton.ChildCell);


                }
                else if (Minotaur == count)
                {
                    OldMinotaurButton = theButton;
                    OldMinotaurButton.ChildCharacter = minotaur;
                    LevelDesigner.MyLevel.MinotaurLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(OldMinotaurButton.ChildCell);

                }
                else if (Exit == count)
                {
                    OldExitButton = theButton;
                    OldExitButton.ChildCell.Type = CellType.Exit;
                    OldExitButton._PreviousCell.Type = CellType.Ground;
    
                }       
                    LevelDesigner.MyLevel.ExitLocation = LevelDesigner.MyLevel.CellCollection.IndexOf(theButton.ChildCell);
                
                count++;
            }
                {
            }
        }

        private void btn_Tile2_Click(object sender, EventArgs e)
        {
            //converting the clicked button in the menu
            var b = sender as Button;
            //nominating the clicked button
            this.TheClickedButton = b;
            //MessageBox.Show("Please right-click on the button to decide what type of tile or character it needs to be ");
        }

        private void btn_Tile1_Click(object sender, EventArgs e)
        {
            //converting the clicked button in the menu
            var b = sender as Button;
            //nominating the clicked button
            this.TheClickedButton = b;
            //MessageBox.Show("Level is not \" Impelmented\"");
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Tile3_Click(object sender, EventArgs e)
        {
            //converting the clicked button in the menu
            var b = sender as Button;
            //nominating the clicked button
            this.TheClickedButton = b;
        }

        private void btn_Tile4_Click(object sender, EventArgs e)
        {
            //converting the clicked button in the menu
            var b = sender as Button;
            //nominating the clicked button
            this.TheClickedButton = b;
        }
        protected Cell CreateOuterwall(string btnname)
        {
            Cell c = new Cell();
            c.Type = CellType.Ground;
            if (btnname == "b1")
            {
                //create a cell
                //make it blank
                c.Type = CellType.LeftUP;
                return c;
            }
            return c;
        }

        private void btn_Theseus_Click(object sender, EventArgs e)
        {

                //converting the clicked button in the menu
                var b = sender as Button;
                //nominating the clicked button
                this.TheClickedButton = b;
                

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //converting the clicked button in the menu
            var b = sender as Button;
            //nominating the clicked button
            this.TheClickedButton = b;
        }

        private void btn_Minotaur_Click(object sender, EventArgs e)
        {

                //converting the clicked button in the menu
                var b = sender as Button;
                //nominating the clicked button
                this.TheClickedButton = b;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string boardSize = comboBox1.SelectedItem.ToString();


            switch (boardSize)
            {
                case "15 x 15":
                    createGameBoard(16, 16, false);
                    break;
                case "14 x 14":
                    createGameBoard(15, 15, false);
                    break;
                case "13 x 13":
                    createGameBoard(14, 14, false);
                    break;
                case "12 x 12":
                    createGameBoard(13, 13, false);
                    break;
                case "11 x 11":
                    createGameBoard(12, 12, false);
                    break;
                case "10 x 10":
                    createGameBoard(11, 11, false);
                    break;
                case "9 x 9":
                    createGameBoard(10, 10, false);
                    break;
                case "8 x 8":
                    createGameBoard(9, 9, false);
                    break;
                case "7 x 7":
                    createGameBoard(8, 8, false);
                    break;
                case "6 x 6":
                    createGameBoard(7, 7, false);
                    break;
                case "5 x 5":
                    createGameBoard(6, 6, false);
                    break;
            }
            comboBox1.Visible = false;

        }
    }
}
