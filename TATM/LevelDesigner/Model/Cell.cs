using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign.Model
{
    public enum CellType {
        Left = 1, LeftUP = 2, Up = 3, Blank = 4
    }
    public class Cell
    {
        #region Fields
        private CellType _Type;

        public CellType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private bool _IsExit = false;

        public bool IsExit
        {
            get { return _IsExit; }
            set { _IsExit = value; }
        }
        private bool _IsStart = false;

        public bool IsStart
        {
            get { return _IsStart; }
            set { _IsStart = value; }
        }
        private bool _IsTheseus =false;

        public bool IsTheseus
        {
            get { return _IsTheseus; }
            set { _IsTheseus = value; }
        }
        private bool _IsMinotaur =false;

        public bool IsMinotaur
        {
            get { return _IsMinotaur; }
            set { _IsMinotaur = value; }
        } 
        #endregion
        public Cell()
        {
            this._Type = CellType.Blank;
        }
        public Cell(CellType type)
        {
            this._Type = type;
        }
        
    }
}
