using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap map;
        Graphics gfx;

        Paddle paddle;
        Ball ball;
        List<Brick> bricksList;

        Font myFont = new Font("Arial", 20); 
        bool endgame;
        int lives = 3; 

        private void Form1_Load(object sender, EventArgs e)
        {
            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(map);

            paddle = new Paddle(ClientSize.Width /2, ClientSize.Height - 50, 100, 10, 10, ClientSize.Width);
            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2 + 50, 20, 20, -3, -3, ClientSize.Width, ClientSize.Height);
            bricksList = new List<Brick>();

            int y = 10;

            int count = 0; 

            for(int a = 0; a < 4; a++)
            {
                int x = 10;
                for(int b = 0; b < 4; b++)
                {
                    bricksList.Add(new Brick(x, y, 90, 20, ClientSize.Width, ClientSize.Height));

                    x += ClientSize.Width / 4;
                    count++; 
                }

                y += 50;  
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            endgame = false; 

            if (bricksList.Count > 0 && lives > 0)
            {
                gfx.Clear(BackColor);

                ball.update();

                if(ball.life == false)
                {
                    lives--; 
                    ball.x = ClientSize.Width/2;
                    ball.y = ClientSize.Height / 2 + 50;
                    ball.xspeed = -3;
                    ball.yspeed = -3; 
                }

                if (ball.hitbox.IntersectsWith(paddle.getRect()))
                {
                    ball.yspeed *= -1;
                }

                for (int a = 0; a < bricksList.Count; a++)
                {
                    if (ball.hitbox.IntersectsWith(bricksList[a].hitbox))
                    {
                        ball.yspeed *= -1;
                        bricksList.RemoveAt(a);
                    }
                }


                for (int a = 0; a < bricksList.Count; a++)
                {
                    bricksList[a].draw(gfx);
                }

                //gfx.DrawRectangle(Pens.Red, ball.hitbox);
                paddle.draw(gfx);
                ball.draw(gfx);

                gfx.DrawString($"Lives: {lives}", new Font("Arial", 15), Brushes.Black, ClientSize.Width - 100, 100) ; 
            }
            else
            {
                gfx.Clear(Color.Gold);

                if(lives <= 0)
                {
                    gfx.DrawString("You lose", new Font("Arial", 20), Brushes.Red, ClientSize.Width / 2, 100);
                }
                else
                {
                    gfx.DrawString("You win", new Font("Arial", 20), Brushes.Green, ClientSize.Width /2, 100);
                }
                
                gfx.DrawString("Do you want to play again? Press y or n", myFont, Brushes.Black , 100,  200);

                endgame = true; 
            }


            pictureBox1.Image = map;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                paddle.moveLeft(); 
            }
            if (e.KeyCode == Keys.D)
            {
                paddle.moveRight();
            }

            if(e.KeyCode == Keys.R)
            {
                bricksList.Clear(); 
            }

            if (endgame == true)
            {
                if (e.KeyCode == Keys.Y)
                {
                    //reset;

                    bricksList.Clear(); 

                    int count = 0;

                    int y = 10; 
                    
                    for (int a = 0; a < 4; a++)
                    {
                        int x = 10;
                        for (int b = 0; b < 4; b++)
                        {
                            bricksList.Add(new Brick(x, y, 90, 20, ClientSize.Width, ClientSize.Height));

                            x += ClientSize.Width / 4;
                            count++;
                        }

                        y += 50;
                    }

                    lives = 3;

                    ball.x = ClientSize.Width / 2;
                    ball.y = ClientSize.Height / 2 + 50;
                    ball.xspeed = -3;
                    ball.yspeed = -3;
                }
                if (e.KeyCode == Keys.N) 
                {
                    Close();
                }
            }
        }
    }
}
