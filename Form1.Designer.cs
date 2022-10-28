namespace BreakOutGame
{
    partial class BreakoutForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BreakoutForm));
            this.ballPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.paddlePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ballPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ballPictureBox
            // 
            this.ballPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ballPictureBox.Image")));
            this.ballPictureBox.Location = new System.Drawing.Point(74, 90);
            this.ballPictureBox.Name = "ballPictureBox";
            this.ballPictureBox.Size = new System.Drawing.Size(60, 42);
            this.ballPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ballPictureBox.TabIndex = 0;
            this.ballPictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // paddlePictureBox
            // 
            this.paddlePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.paddlePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("paddlePictureBox.Image")));
            this.paddlePictureBox.Location = new System.Drawing.Point(501, 670);
            this.paddlePictureBox.Name = "paddlePictureBox";
            this.paddlePictureBox.Size = new System.Drawing.Size(201, 49);
            this.paddlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.paddlePictureBox.TabIndex = 1;
            this.paddlePictureBox.TabStop = false;
            this.paddlePictureBox.Click += new System.EventHandler(this.paddlePictureBox_Click);
            // 
            // BreakoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1265, 776);
            this.Controls.Add(this.paddlePictureBox);
            this.Controls.Add(this.ballPictureBox);
            this.Name = "BreakoutForm";
            this.Text = "Breakout!";
            this.Load += new System.EventHandler(this.BreakoutForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            ((System.ComponentModel.ISupportInitialize)(this.ballPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddlePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ballPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox paddlePictureBox;
    }
}
