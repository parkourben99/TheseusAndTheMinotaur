using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign.Model
{
    //Define cell type by number
    //The direction indictes where the wall is
    //Example: Left => wall on left
    public enum CellType {
        Left = 1, LeftUP = 2, Up = 3, Ground = 4, Exit = 5
    }
    public class Cell
    {
        #region Fields
        private CellType _Type;

        //Method of get and set cell type
        public CellType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //The 'is exit' value to a cell
        private bool _IsExit = false;

        //Get/Set the value of 'is exit' from a cell
        public bool IsExit
        {
            get { return _IsExit; }
            set { _IsExit = value; }
        }

        //The 'is start' value to a cell
        private bool _IsStart = false;

        //Get/Set the value of 'is start' from a cell
        public bool IsStart
        {
            get { return _IsStart; }
            set { _IsStart = value; }
        }

        //The 'has Theseus' status on the cell
        private bool _IsTheseus =false;

        //Get/Set the value of 'has Theseus' from a cell
        public bool IsTheseus
        {
            get { return _IsTheseus; }
            set { _IsTheseus = value; }
        }

        //The 'has Minotaur' status on the cell
        private bool _IsMinotaur =false;

        //Get/Set the value of 'has Minotaur' from a cell
        public bool IsMinotaur
        {
            get { return _IsMinotaur; }
            set { _IsMinotaur = value; }
        } 
        #endregion
        public Cell()
        {
            this._Type = CellType.Ground;
        }
        public Cell(CellType type)
        {
            this._Type = type;
        }
        
    }
}
