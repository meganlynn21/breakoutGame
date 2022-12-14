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

        //Add the properties 
        public int X { get; set; }
        public int Y { get; set; }
        public int Width1 { get; set; }
        public int Height1 { get; set; }
        public string ImageFile { get; set;}


        //Add constructors
         
        public Brick() { }
        public Brick(int x, int y, int width, int height, string imageFile) : base()
        {

            X = x;
            Y = y;
            Width1 = width;
            Height1 = height;
            ImageFile = imageFile;
       
            base.Name = "brick" + X + Y;
            base.Size = new Size(Width1, Height1);
            base.Location = new Point(X, Y);
            base.Image = Image.FromFile(@"C:\Users\megan\OneDrive\Documents\C#\CSharpClassProjects\BreakOutGame\bin\Debug\netcoreapp3.1\Breakout Images\Breakout Images\blueBrick.jpg");
            base.SizeMode = PictureBoxSizeMode.Zoom;

        }

}
}
