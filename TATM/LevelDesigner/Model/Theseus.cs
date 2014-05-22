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
        //Image of Theseus
        private Image _TheseusImage;
                
        public Image TheseusImage
        {
            //Get/Set the image of Theseus
            get { return _TheseusImage; }
            set { _TheseusImage = value; }
        }

        //The Theseus's position of x
        private int _XPosition;

        public int XPosition
        {
            //Get/Set Theseus's x position
            get { return _XPosition; }
            set { _XPosition = value; }
        }

        //The Theseus's position of y
        private int _YPosition;

        public int YPosition
        {
            //Get/Set Theseus's y position
            get { return _YPosition; }
            set { _YPosition = value; }
        }

        //Remaining moves for Theseus
        private int _MovesRemaining;

        public int MovesRemaining
        {
            //Get/Set Theseus's remaining move
            get { return _MovesRemaining; }
            set { _MovesRemaining = value; }
        }
    }
}
