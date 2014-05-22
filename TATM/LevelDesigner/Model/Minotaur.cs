using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign.Model
{
    public class Minotaur : Character
    {
        //Image of Minotaur
        private Image _MinotaurImage;

        public Image MinotaurImage
        {
            //Get/Set the image of Minotaur
            get { return _MinotaurImage; }
            set { _MinotaurImage = value; }
        }

        //The Minotaur's position of x
        private int _XPosition;

        public int XPosition
        {
            //Get/Set Minotaur's x position
            get { return _XPosition; }
            set { _XPosition = value; }
        }

        //The Minotaur's position of Y
        private int _YPosition;

        public int YPosition
        {
            //Get/Set Minotaur's Y position
            get { return _YPosition; }
            set { _YPosition = value; }
        }

        //Minotaur's move remaining
        private int _MovesRemaining;

        public int MovesRemaining
        {
            //Get/Set Minotaur's remaining moves
            get { return _MovesRemaining; }
            set { _MovesRemaining = value; }
        }
        public Minotaur()
        {
            this._XPosition = 2;
        }
    }
}
