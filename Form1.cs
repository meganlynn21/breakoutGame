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
        public string ImgFile
        {
            get { return blueBrick.ToString(); }
        }
        
        public BreakoutForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* Move Ball: Double click on the Timer object to generate the
             * Timer_Tick function. Set up variables for xChange and yChange
             * outside of the function and set them equal to 2 or 3.
             * To move the ball PictureBox, you can change its Left and Top 
             * properties by adding the xChange or yChange variables to them 
             * respectively (use +=). Test and notice that your ball will move 
             * off screen. Now we need to make it bounce off the walls. 
            */

            ballPictureBox.Left += xChange;
            ballPictureBox.Top += yChange;
            /*Add if statements to the Timer_Tick function that changes
             * the direction of the ball if it hits a wall.You will 
             * write an if statement for each wall. The ball collides 
             * with a wall if its Left property goes below 0 or its Right
             * property above Width or if its Top property goes below 0 or 
             * its Bottom property above Height.  If it does reach these
             * boundaries, you can multiply xChange or yChange by -1(use *=) 
             * to change the ball’s direction(change xChange if you hit 
             * the left or right wall and change yChange if you hit the top wall).
             * For collisions with the bottom, set Ball.Top to some value in 
             * the middle of the screen(maybe 150) to make it restart. 
             * */
            if (ballPictureBox.Left < 0 || ballPictureBox.Right > Width)
                xChange *= -1;
            if (ballPictureBox.Top < 0)
                yChange *= -1;
            if (ballPictureBox.Bottom > Height)
                ballPictureBox.Top = 150;
        }

        private void keydown(object sender, KeyEventArgs e)
        {

            /*You will use an if statement that tests whether the key down
             * event e.KeyCode is equal to Keys.Right for the right arrow. 
             * You can move the paddle when it is pressed by adding a small 
             * number (I used 5) to paddle.Left (if you renamed your PictureBox 
             * to paddle) if you’re moving right.
            Use another if statement to test whether the key down event
            e.KeyCode is equal to Keys.Left for the left arrow. 
            You can move the paddle when this is pressed by subtracting a 
            small number (I used 5) from paddle.Left .
            Test and notice you can move off the screen. You can fix this
            by adding an && condition to your if statement to only move
            if paddle.Left has not gone below 0 or paddle.Right has not
            gone above Width (which is a special variable for the Width
            of the Form). 
            */
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
            /* Set up the following variables for your grid of bricks: 
             * numRows, numCols, brickWidth, brickHeight, spacer, xOffset 
             * (how far to start from the left of the window), yOffset 
             * (how far to start from the top of the window). You can set 
             * these to any values that you want (for example, you may want 
             * 5 rows, 10 columns, 30x15 bricks with 2 or 3 pixels in between 
             * and from the left and maybe 20 pixels from the top. 
             * */
            int numRows = 5;
            int numCols = 10;
            int brickWidth = 30;
            int brickHeight = 15;
            int spacer = 3;
            int xOffset = 20;
            int yOffset = 20;

            /* Set up nested loops (see slide 10) to go through the rows and
             * columns with two loop variables row and col. First, you will 
             * have a loop that counts the rows from 0 to numRows. Inside that 
             * loop, you will have another loop that counts the columns from 0 
             * to numCols.
              Inside the nested loops, you need to figure out the x and y
            coordinate to place each brick using the following formulas:
              x = col * (brickWidth + spacer) + xOffset;
              y = row * (brickHeight + spacer) + yOffset;
            */

            for (int i = 0; i <= numRows; i++)
            {
                for (int j = 0; j <= numCols; j++)
                {
                    /*Also set up a variable imageFile set to one of the brick
                      filenames you copied in You can be creative here(see step 11)
                      and change the image depending on the row number.
                      */
                    var imageFile = blueBrick;
                    // Create a brick
                    Brick b = new Brick(xChange, yChange, brickWidth, brickHeight, imageFile.ToString());
                    Controls.Add(b);
                    // increment x coordinate for column spacing
                    xChange = numCols * (brickWidth + spacer) + xOffset;
                }
                // increment y coordinate for row spacing
                yChange = numRows * (brickHeight + spacer) + yOffset;
            }



        }

        private void paddlePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void blueBrick_Click(object sender, EventArgs e)
        {

        }
    }
}
