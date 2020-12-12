using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Brick_Breaker
{
    class Brick
    {
        public int x;
        public int y;
        int width;
        int height;
        int clientw;
        int clienth;
        public Rectangle hitbox; 

        public Brick (int xx, int yy , int w, int h, int cw, int ch)
        {
            x = xx;
            y = yy;
            width = w;
            height = h;
            clientw = cw;
            clienth = ch;

            hitbox = new Rectangle(x, y, height, width);
        }

        public void draw(Graphics gfx)
        {
            hitbox.X = x;
            hitbox.Y = y;
            hitbox.Width = width;
            hitbox.Height = height; 

            gfx.FillRectangle(Brushes.Blue, x, y, width, height); 
        }
    }
}
