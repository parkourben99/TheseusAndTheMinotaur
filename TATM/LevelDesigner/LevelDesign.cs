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
        private CustomControl_Button OldButton;
        public LevelDesign()
        {
            InitializeComponent();
            createGameBoard(15, 15);
            StorageManagement.StorageManagement.initLevels();
        }
        protected void createGameBoard(int rows, int columns)
        {

            //creating Level
            LevelDesigner.createLevel(rows, columns);
            LevelDesigner.MyLevel.CreateCells();
            
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
                    //Panel p = new Panel();
                    //create the control - button
                    // *** to be named as " " if we are to continue using buttons ***
                    CustomControl_Button btn_Cell = new CustomControl_Button() { Name = count.ToString() };
                    //adding the cells from cell collection to the btn
                    btn_Cell.ChildCell = LevelDesigner.MyLevel.CellCollection[count];
                    //setting the button size  
                    btn_Cell.Size = new Size(40, 40);
                    btn_Cell.Padding = new Padding(0);
                    btn_Cell.Margin = new Padding(0);
                    //p.Size = new Size(40, 40);
                    //p.Padding = new Padding(0);
                    //p.Margin = new Padding(0);
                    //add onClick Event to each Button
                    btn_Cell.Click += Button_OnClick_For_Cell;
                    //create context menu items eventHandler
                    //btn_Cell.ChildCell = CreateOuterwall(btn_Cell.Name);
                    MenuItem m1 = new MenuItem("LeftTile", new EventHandler(ContextMenu_OnClick_For_TileLeft));
                    MenuItem m2 = new MenuItem("UpTile", new EventHandler(ContextMenu_OnClick_For_TileUp));
                    MenuItem m3 = new MenuItem("BlankTile", new EventHandler(ContextMenu_OnClick_For_TileBlank));
                    MenuItem m4 = new MenuItem("LeftUpTile", new EventHandler(ContextMenu_OnClick_For_TileLeftUp));
                    MenuItem m5 = new MenuItem("Theseus", new EventHandler(ContextMenu_OnClick_For_Theseus));
                    btn_Cell.ContextMenu = new System.Windows.Forms.ContextMenu();
                    btn_Cell.ContextMenu.MenuItems.Add(m1);
                    btn_Cell.ContextMenu.MenuItems.Add(m2);
                    btn_Cell.ContextMenu.MenuItems.Add(m3);
                    btn_Cell.ContextMenu.MenuItems.Add(m4);
                    btn_Cell.ContextMenu.MenuItems.Add(m5);
                    //p.Controls.Add(btn_Cell);
                    //Finally, add the control to the correct location in the table
                    GameBoard.Controls.Add(btn_Cell, x, y);
                    count += 1;
                }
            }
            //AddBorders();
            theseus = new Theseus();
            minotaur = new Minotaur();


        }
        protected void ContextMenu_OnClick_For_Theseus(object sender, object e)
        {
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //initiating an instance of Cell class
            if (OldButton != null)
            {
                OldButton.ClearCharacters();
            }
            OldButton = theButton;
            theButton.ChildCharacter = theseus;
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // left
        protected void ContextMenu_OnClick_For_TileLeft(object sender, object e)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //create a cell object with apporiate wall
            Cell cell = new Cell() { Type = CellType.Left };
            //assign the cell instance to the button
            theButton.ChildCell = cell;
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Up
        protected void ContextMenu_OnClick_For_TileUp(object sender, object e)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //create a cell object with apporiate wall
            Cell cell = new Cell() { Type = CellType.Up };
            //assign the cell instance to the button
            theButton.ChildCell = cell;
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
                    if (OldButton != null)
                    {
                        OldButton.ClearCharacters();
                        OldButton = null;
                    }
                    OldButton = theButton;
                    theButton.ChildCharacter = theseus;
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
                            cell.Type = CellType.Blank;
                            break;
                        case "btn_TileLeftUp":
                            //Set the type of the instance to CellType.LeftUp
                            cell.Type = CellType.LeftUP;
                            break;
                    }
                   // int CellIndex = LevelDesigner.MyLevel.CoordinateToList(theButton.X, theButton.Y);
                   // LevelDesigner.MyLevel.CellCollection[CellIndex] = theButton.ChildCell;
                    theButton.ChildCell = cell;
                }
            }
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Blank
        protected void ContextMenu_OnClick_For_TileBlank(object sender, object e)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //create a cell object with apporiate wall
            Cell cell = new Cell() { Type = CellType.Blank };
            //assign the cell instance to the button
            theButton.ChildCell = cell;
        }
        // this method puts an item into, and allows it to be selected, from the right click context menu
        // Up-left
        protected void ContextMenu_OnClick_For_TileLeftUp(object sender, object e)
        {
            //Converting the button object into menuitem
            var mnu = sender as MenuItem;
            //getting the right click menu(contextmenu) of the option that was clicked(MenuItem)
            ContextMenu MyContextMenu = (ContextMenu)mnu.Parent;
            //get the button of the context btton 
            var theButton = MyContextMenu.SourceControl as CustomControl_Button;
            //create a cell object with apporiate wall
            Cell cell = new Cell() { Type = CellType.LeftUP };
            //assign the cell instance to the button
            theButton.ChildCell = cell;
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
                    LevelDesigner.MyLevel = StorageManagement.StorageManagement.loadLevel(levelSelect.selectedLevelName);
                }
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
            c.Type = CellType.Blank;
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
    }
}
