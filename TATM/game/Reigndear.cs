using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StorageManagement;

namespace GamePlayer.game
{
    // the renderer for games graphics
    public class Reigndear
    {
        // the graphics to draw to
        private Graphics graphics;

        public Reigndear()
        {
        }
        
        // draw image from image data to location
        public void drawRect(Tuple<string, int, int, int, int> sprite)
        {
            // set the image
            Image img = Image.FromFile(sprite.Item1);
            // set the draw shape
            Rectangle rect = new Rectangle(sprite.Item2, sprite.Item3, sprite.Item4, sprite.Item5);
            // tell graphics to draw
            graphics.DrawImage(img, rect);
        }

        public void clearAll()
        {
            // clears graphics with blue color
            graphics.Clear(Color.Blue);
        }
        public void initialiseGraphics(Graphics newGraphics)
        {
            // set graphics
            graphics = newGraphics;
        }
    }
}
