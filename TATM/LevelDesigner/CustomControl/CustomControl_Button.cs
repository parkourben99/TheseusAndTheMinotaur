using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LevelDesign.Model;

namespace LevelDesign.CustomControl
{
    public class CustomControl_Button : Button
    {
        public Cell _PreviousCell;
        private Character _ChildCharacter;
        private int _X;

        public int X
        {
            get { return _X; }
            set { _X = value; }
        }
        private int _Y;

        public int Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        public Character ChildCharacter
        {
            get { return _ChildCharacter; }
            set
            {
                _PreviousCell = this._ChildCell;
                if (value is Theseus)
                {
                    string TheseusImg = LevelDesigner.MyLevel.TileSet["Theseus"];
                    var TheseusImage = Image.FromFile(TheseusImg);
                    this.BackgroundImage = MergeImages(this.BackgroundImage, TheseusImage);
                }
                if (value is Minotaur)
                {
                    string MinotaurImg = LevelDesigner.MyLevel.TileSet["Minotaur"];
                    var MinotaurImage = Image.FromFile(MinotaurImg);
                    this.BackgroundImage = MergeImages(this.BackgroundImage, MinotaurImage);
                }
                _ChildCharacter = value; 
            }
        }
        private Cell _ChildCell;
        public Cell ChildCell
        {
            get { return _ChildCell; }
            set
            {
                    switch (value.Type)
                    {
                        case CellType.Left:
                            string LeftWallImg = LevelDesigner.MyLevel.TileSet["Left"];
                            this.BackgroundImage = Image.FromFile(LeftWallImg);
                            break;
                        case CellType.Up:
                            string UpWallImg = LevelDesigner.MyLevel.TileSet["Up"];
                            this.BackgroundImage = Image.FromFile(UpWallImg);
                            break;
                        case CellType.Ground:
                            string Ground1 = LevelDesigner.MyLevel.TileSet["Ground1"];
                            this.BackgroundImage = Image.FromFile(Ground1);
                            break;
                        case CellType.LeftUP:
                            string LeftUpWallImg = LevelDesigner.MyLevel.TileSet["LeftUP"];
                            this.BackgroundImage = Image.FromFile(LeftUpWallImg);
                            break;
                        case CellType.Exit:
                            string Exit = LevelDesigner.MyLevel.TileSet["Exit"];
                            this.BackgroundImage = Image.FromFile(Exit);
                            break;
                    }
                    _ChildCell = value;
            }
        }
        public CustomControl_Button() { }
        private Image MergeImages(Image backgroundImage,
                         Image overlayImage)
        {
            Image theResult = backgroundImage;
            if (null != overlayImage)
            {
                Image theOverlay = overlayImage;
                if (PixelFormat.Format32bppArgb != overlayImage.PixelFormat)
                {
                    theOverlay = new Bitmap(overlayImage.Width,
                                            overlayImage.Height,
                                            PixelFormat.Format32bppArgb);
                    using (Graphics graphics = Graphics.FromImage(theOverlay))
                    {
                        graphics.DrawImage(overlayImage,
                                           new Rectangle(0, 0, theOverlay.Width, theOverlay.Height),
                                           new Rectangle(0, 0, overlayImage.Width, overlayImage.Height),
                                           GraphicsUnit.Pixel);
                    }
                    ((Bitmap)theOverlay).MakeTransparent();
                }

                using (Graphics graphics = Graphics.FromImage(theResult))
                {
                    graphics.DrawImage(theOverlay,
                                       new Rectangle(0, 0, theResult.Width, theResult.Height),
                                       new Rectangle(0, 0, theOverlay.Width, theOverlay.Height),
                                       GraphicsUnit.Pixel);
                }
            }

            return theResult;
        }
        public void ClearCharacters()
        {
            _ChildCharacter = null;
            this._ChildCell = this._PreviousCell;
        }

    }
}
