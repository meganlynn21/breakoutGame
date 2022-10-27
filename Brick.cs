using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Policy;

namespace BreakOutGame
{
    internal class Brick : PictureBox
    {

        //Add the properties (prop tab tab) for x, y, width, height, imageFile.
        public int X { get; set; }
        public int Y { get; set; }
        public int Width1 { get; set; }
        public int Height1 { get; set; }
        public string ImageFile { get; set; }


        /*Add a constructor that takes 4 arguments for the properties and 
         * call : base() after it. The PictureBox class just has a default 
         * constructor with no arguments, so we will have to set its 
         * properties inside the Brick constructor
         * */
        public Brick(int x, int y, int width, int height, string imageFile) : base()
        {
            BreakoutForm breakoutForm = new BreakoutForm();
            string blueBrickBox = breakoutForm.ImgFile;

            X = x;
            Y = y;
            Width1 = width;
            Height1 = height;
            ImageFile = imageFile;
       
            base.Name = "brick" + X + Y;
            base.Size = new Size(Width1, Height1);
            base.Location = new Point(X, Y);
            base.Image = Image.FromFile(blueBrickBox);
            base.SizeMode = PictureBoxSizeMode.Zoom;

        }

}
}
