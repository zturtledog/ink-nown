using System;
using System.Drawing;
using System.Windows.Forms;

namespace ink_nown {
    public class renderer {
        public Bitmap screen;
        public Form mainwindow;
        public int screenwidth;
        public int screenheight;

        public renderer(int ix, int iy, String icn) {
            screen = new Bitmap(ix,iy);

            screenwidth = ix;
            screenheight = iy;

            Form frm = new Form();
            // frm.Controls.Add(new Label() {Text = "Version 5.0"});
            frm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frm.ClientSize = new System.Drawing.Size(ix, iy);
            frm.Text = "engine_csharp_test_window";
            frm.Icon = new Icon(icn);
            frm.ShowDialog();

            mainwindow = frm;
        }

        public void drawimage(Bitmap bitmap) {
            for (int x = 0; x < bitmap.Width; x++) {
                for (int y = 0; y < bitmap.Height; y++) {
                    screen.SetPixel(x, y, bitmap.GetPixel(x,y));
                }
            }
        }
    }
}