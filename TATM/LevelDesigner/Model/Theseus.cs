using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign.Model
{
    public class Theseus : Character
    {
        private Image _TheseusImage;

        public Image TheseusImage
        {
            get { return _TheseusImage; }
            set { _TheseusImage = value; }
        }
        private int _XPosition;

        public int XPosition
        {
            get { return _XPosition; }
            set { _XPosition = value; }
        }

        private int _YPosition;

        public int YPosition
        {
            get { return _YPosition; }
            set { _YPosition = value; }
        }

        private int _MovesRemaining;

        public int MovesRemaining
        {
            get { return _MovesRemaining; }
            set { _MovesRemaining = value; }
        }
    }
}
