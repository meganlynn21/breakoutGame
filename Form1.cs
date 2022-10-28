using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BreakOutGame
{
    public partial class BreakoutForm : Form
    {
        private int xChange = 2;
        private int yChange = 3;
        
        public BreakoutForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move ball
            ballPictureBox.Left += xChange;
            ballPictureBox.Top += yChange;
            //Check if ball collides with wall
            if (ballPictureBox.Left < 0 || ballPictureBox.Right > Width)
                xChange *= -1;
            if (ballPictureBox.Top < 0)
                yChange *= -1;
            if (ballPictureBox.Bottom > Height)
                ballPictureBox.Top = 150;

            /* See if the ball intersects with the bricks and if it does remove bricks
            */
            Brick brick = new Brick();

            foreach(Control c in Controls)
            {
                if (c.Name.Contains("brick") && c.Visible && ballPictureBox.Bounds.IntersectsWith(c.Bounds))
                { 
                    yChange *= -1;
                    Controls.Remove(c);
                    c.Visible = false;
                }
            }
        }


        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && paddlePictureBox.Right < Width)
                paddlePictureBox.Left += 5;
            if (e.KeyCode == Keys.Left && paddlePictureBox.Left > 0)
                paddlePictureBox.Left -= 5;
            /* In the same function, you can test if the paddle hits the ball
             * by testing if (paddle.Bounds.IntersectsWith(ball.Bounds)). 
             * If it does, then bounce off by multiplying yChange by -1. 
             * */
            if (paddlePictureBox.Bounds.IntersectsWith(ballPictureBox.Bounds))
                yChange *= -1;
        }

        private void BreakoutForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            /* Set up variables for your grid of bricks: 
             */
            int numRows = 5;
            int numCols = 10;
            int brickWidth = 30;
            int brickHeight = 20;
            int spacer = 3;
            int xOffset = 240;
            int yOffset = 20;

            /* Set up nested loops to go through the rows and
             * columns with two loop variables row and col. 
             */
            var imageFile = @"C:\Users\megan\OneDrive\Documents\C#\CSharpClassProjects\BreakOutGame\bin\Debug\netcoreapp3.1\Breakout Images\Breakout Images\blueBrick.jpg";

            for (int row = 0; row <= numRows; row++)
            {
                // increment y coordinate for row spacing
                int y = row * (brickHeight + spacer) + yOffset;
                for (int col = 0; col <= numCols; col++)
                {
                    // increment x coordinate for column spacing
                    int x = col * (brickWidth + spacer) + xOffset;
                    // Create a brick
                    Brick b = new Brick(x, y, brickWidth, brickHeight, imageFile.ToString());
                    Controls.Add(b);                  
                }              
            }
        }

        private void paddlePictureBox_Click(object sender, EventArgs e)
        {

        }

    }
}
