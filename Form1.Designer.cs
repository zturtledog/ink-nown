﻿namespace ink_nown
{
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //do not edit
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "engine_csharp_test_window";
        }
    }
}

/*
    private void Form1_Load(object sender, EventArgs e)
{
    Paint += new PaintEventHandler(Form1_Paint); //Link the Paint event to Form1_Paint; you can do this within the designer too!
}
private void print(Bitmap BM, PaintEventArgs e)
{
    Graphics graphicsObj = e.Graphics; //Get graphics from the event
    graphicsObj.DrawImage(BM, 60, 10); // or "e.Graphics.DrawImage(bitmap, 60, 10);"
    graphicsObj.Dispose();
}

private void Form1_Paint(object sender, PaintEventArgs e)
{
     Rectangle rect = Screen.PrimaryScreen.Bounds;
     int color = Screen.PrimaryScreen.BitsPerPixel;
     PixelFormat pf;
     pf = PixelFormat.Format32bppArgb;
     Bitmap BM = new Bitmap(rect.Width, rect.Height, pf); //This is the Bitmap Image; you have not yet selected a file,
     //Bitmap BM = new Bitmap(Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"), rect.Width, rect.Height);
     Graphics g = Graphics.FromImage(BM);
     g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
     Bitmap bitamp = new Bitmap(BM);
     print(bitamp, e);
}
*/

