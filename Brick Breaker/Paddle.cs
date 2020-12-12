using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Brick_Breaker
{
    class Paddle
    {
        int x;
        int y;
        int width;
        int height;
        int xspeed;
        int clientw; 
        
        public Paddle (int xx, int yy, int w, int h, int speed, int cw)
        {
            x = xx;
            y = yy;
            width = w;
            height = h;
            xspeed = speed;
            clientw = cw; 
        }

        public void moveLeft()
        {
            if(x > 0)
            {
                x -= xspeed; 
            }
        }

        public void moveRight()
        {
            if(x + width < clientw)
            {
                x += xspeed; 
            }
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Black, x, y, width, height) ;
        }

        public Rectangle getRect()
        {
            Rectangle paddle = new Rectangle(x, y, width, height);
            return paddle;
        }
    }
}
