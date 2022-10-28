using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
                if (c.Name.Contains("brick") && brick.Visible == false)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Game Over");
                }
            }
            /*When all the bricks are invisible (check in a loop in timer_Tick 
             * with a bool flag variable if you find one that’s visible), pop up a 
             * MessageBox to say Game Over and set the timer1.Enabled to false to
             * stop the movement.
             * */
            if (ballPictureBox.Bottom >= paddlePictureBox.Top && ballPictureBox.Bottom <= paddlePictureBox.Bottom && ballPictureBox.Left >= paddlePictureBox.Left && ballPictureBox.Right <= paddlePictureBox.Right)    //collision
            {
                yChange += 1;
                yChange = -yChange;          // change the direction
            }
        }


        private void keydown(object sender, KeyEventArgs e)
        {
            // Check collision between paddle and ball
            if (paddlePictureBox.Bounds.IntersectsWith(ballPictureBox.Bounds))
                yChange *= -1; 
            // Change speed of paddle
            if (e.KeyCode == Keys.Right && paddlePictureBox.Right < Width)
                paddlePictureBox.Left += 15;
            if (e.KeyCode == Keys.Left && paddlePictureBox.Left > 0)
                paddlePictureBox.Left -= 15;
 
        }

        private void BreakoutForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            /* Set up variables for your grid of bricks: 
             */
            int numRows = 5;
            int numCols = 15;
            int brickWidth = 40;
            int brickHeight = 30;
            int spacer = 3;
            int xOffset = 300;
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
