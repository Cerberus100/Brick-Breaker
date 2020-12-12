using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Brick_Breaker
{
    class Ball
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int xspeed;
        public int yspeed;
        public int clientw;
        public int clienth;
        public bool life; 
        public Rectangle hitbox; 
        
        public Ball (int xx, int yy, int w, int h, int xs, int ys, int cw, int ch)
        {
            x = xx;
            y = yy;
            width = w;
            height = h;
            xspeed = xs;
            yspeed = ys;
            clientw = cw;
            clienth = ch;
            life = true; 
             
            hitbox = new Rectangle(x, y, width, height); 
        }

        public void update()
        {
            life = true; 
            x += xspeed; 
            y += yspeed; 

            if(x <= 0 || x + width >= clientw)
            {
                xspeed *= -1; 
            }

            if(y <= 0)
            {
                yspeed *= -1;
                
            }

            if(y + height >= clienth)
            {
                yspeed *= -1;
                life = false;
            }

            hitbox.X = x;
            hitbox.Y = y; 
        }

        public void draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Black, x, y, width, height);
        }
    }
}
