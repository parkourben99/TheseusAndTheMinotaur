using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManagement;

namespace LevelDesign.Model
{
   /* public enum Rating 
    {
        one,two,three,four,five,six,seven,eight,nine,ten
    } */

    [Serializable]
    public class Level
    {
        #region Fields
        private string _LevelName;
        private string _LevelPublisher;
        private int _Rating;
        private string _Theme;
        private decimal _AvgTime;
        private SerialDict<string, string> _TileSet;
        private string _SoundLocation;
        private string _MusicLocation;
        private List<Cell> _CellCollection = new List<Cell>();
        private int _Width;
        private int _Height;
        private SerialDict<string, int> _HighScore;
        private int _MinotaurLocation;
        private int _TheseusLocation;
        private int _LevelSize;
        private int _ExitLocation;

        public int ExitLocation
        {
            //Set the exit for this map
            get { return _ExitLocation; }
            set { _ExitLocation = value; }
        }

        public int LevelSize
        {
            //Set the level size for this map
            get { return _LevelSize; }
            set { _LevelSize = value; }
        }
        #endregion
        #region GetSet

        public string LevelPublisher
        {
            get { return _LevelPublisher; }
            set { _LevelPublisher = value; }
        }
        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public decimal AvgTime
        {
            get { return _AvgTime; }
            set { _AvgTime = value; }
        }
        public SerialDict<string, string> TileSet
        {
            get { return _TileSet; }
            set { _TileSet = value; }
        }
        public string SoundLocation
        {
            get { return _SoundLocation; }
            set { _SoundLocation = value; }
        }
        public string MusicLocation
        {
            get { return _MusicLocation; }
            set { _MusicLocation = value; }
        }
        public List<Cell> CellCollection
        {
            get { return _CellCollection; }
            set { _CellCollection = value; }
        }
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        public SerialDict<string,int> LocalHighScore
        {
            get { return _HighScore; }
            set { _HighScore = value; }
        }
        public string LevelName
        {
            get { return _LevelName; }
            set { _LevelName = value; }
        }
        public int TheseusLocation
        {
            get { return _TheseusLocation; }
            set { _TheseusLocation = value; }
        }
        public int MinotaurLocation
        {
            get { return _MinotaurLocation; }
            set { _MinotaurLocation = value; }
        }

        #endregion
        #region Constructors
        public Level( int width, int height) 
        {
            _Width = width;
            _Height = height;
            _LevelSize = width * height;
            _TileSet = StorageManagement.StorageManagement.getTileset(_Theme);
            LevelName = "";
            LevelPublisher = "";
            SoundLocation = "";
            MusicLocation = "";
            _Theme = "default";
            LocalHighScore = new SerialDict<string, int>();
        }

        public Level(string newLevelName, string newPublisher, int newRating, decimal newAvgTime, SerialDict<string, string> newTileSet, string newSounds, string newMusic, List<int> newCells, int newWidth, int newHeight, int newHighscore, SerialDict<string,int> newLocalHighscore, int newTheseusLocation, int newMinotaurLocation, int newExitLocation, string newTheme)
        {
            LevelName = newLevelName;
            LevelPublisher = newPublisher;
            Rating = newRating;
            AvgTime = newAvgTime;
            TileSet = newTileSet;
            SoundLocation = newSounds;
            MusicLocation = newMusic;
            CellCollection = this.CreateCells(newCells);
            _Theme = newTheme;
            Width = newWidth;
            Height = newHeight;
            LocalHighScore = newLocalHighscore;
            TheseusLocation = newTheseusLocation;
            MinotaurLocation = newMinotaurLocation;
            ExitLocation = newExitLocation;
        }
        public Level()
        {

        }
        #endregion

        //#region Methods
        //public void SetWall();
        //public void SetT();
        //public void SetM();
        //public void ReturnLevelData();
        //public void SetLevelName();
        //public void setSounds();
        //public void setMusic();
        //public void setTileSet(); 
        //#endregion

        // check if theseus has been placed, move if it has or place it if it hasn't
        //public void setTheseus(int cell)
        //{
        //    if (this.TheseusLocation == null)
        //    {
        //        this.cellCollection[this.TheseusLocation].IsMinotaur = false;
        //    }
        //    this.cellCollection[cell].IsMinotaur = true;
        //    this.TheseusLocation = cell;
        //}

        //// check if minotaur has been placed, move if it has or place it if it hasn't
        //public void setMinotaur(int cell)
        //{
        //    if (this.MinotaurLocation == null)
        //    {
        //        this.cellCollection[this.MinotaurLocation].IsMinotaur = false;
        //    }
        //    this.cellCollection[cell].IsMinotaur = true;
        //    this.MinotaurLocation = cell;
        //}
        public void CreateCells()
        {
            //creating columns
            for (int y = 0; y < this._Height; y++)
            {
                //creating rows
                for (int x = 0; x < this._Width; x++)
                {
                    this._CellCollection.Add(new Cell());
                }
            }
            //create topleft hand corner 
            this.updateCell(0, CellType.LeftUP);
            //creat Top wall
            for (int a = 1; a < (this._Width - 1); a++)
            {
                this.updateCell(a, CellType.Up);
            }
            //create left and right wall
            for (int b = 1; b < (this._Height); b++)
            {
                int c = b * this.Width;
                this.updateCell(c, CellType.Left);
                this.updateCell(c - 1, CellType.Left);
            }
            //create bottom wall
            for (int d = (this._LevelSize - this._Width); d < this._LevelSize; d++)
            {
                this.updateCell(d, CellType.Up);
            }
            //create bottom right hand corner 
            this.updateCell((this._LevelSize - 1), CellType.Blank);
        }

        public List<Cell> CreateCells(List<int> cellData)
        {
            List<Cell> cellCollection = new List<Cell>();
            //creating columns by _Hight
            for (int y = 0; y < this._Height; y++)
            {
                //creating rows by _Width
                for (int x = 0; x < this._Width; x++)
                {
                    cellCollection.Add(new Cell((CellType)cellData[x]));
                }
            }

            /*
            //create topleft hand corner 
            this.updateCell(0, CellType.LeftUP);
            //creat Top wall
            for (int a = 1; a < (this._Width - 1); a++)
            {
                this.updateCell(a, CellType.Up);
            }
            //create left and right wall
            for (int b = 1; b < (this._Height); b++)
            {
                int c = b * this.Width;
                this.updateCell(c, CellType.Left);
                this.updateCell(c - 1, CellType.Left);
            }
            //create bottom wall
            for (int d = (this._LevelSize - this._Width); d < this._LevelSize; d++)
            {
                this.updateCell(d, CellType.Up);
            } */
            //create bottom right hand corner 
            this.updateCell((this._LevelSize - 1), CellType.Blank);
            return cellCollection;
        }
             

        public void updateCell(int cell, CellType type)
        {
            //update the cell type 
            this._CellCollection[cell].Type = type;
        }

        public void SetTheseus(int x, int y )
        {
            //update start graphic of Theseus
            this.SetStart(x, y);
        }

        //Set Minotaur to (x,y)
        public void SetMinotaur(int x, int y)
        {

        }

        public void SetStart(int x, int y)
        {
            //check for existing start
            //if a start already exist, remove previous start.
            for (int a = 0; a < this._LevelSize; a++)
            {
                if (this._CellCollection[a].IsStart)
                {
                    this._CellCollection[a].IsStart = false;
                    break;
                }
            }
            //set the position 
            this._CellCollection[CoordinateToList(x, y)].IsStart = true;
        }

        public void SetExit(int x, int y)
        {
            //check for existing Exit
            for (int a = 0; a < this._LevelSize; a++)
            {
                if (this._CellCollection[a].IsExit)
                {
                    this._CellCollection[a].IsExit = false;
                    break;
                }
            }
            //set the position 
            this._CellCollection[CoordinateToList(x, y)].IsExit = true;
            ExitLocation = CoordinateToList(x, y);
        }

        public int CoordinateToList(int x, int y)
        {
            //give index number to every cell
            //index start from 0 at (0,0) and incease 1 by along x axis
            int listIndex = 0;
            listIndex = (y - 1) * this._Width;
            listIndex += (x -1);

            return listIndex;
        }

    }
}
