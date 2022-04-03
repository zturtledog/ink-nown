//# puropse : to create and render a window object
//# contributor : confusedParrotfish

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ink_nown {
    public class renderer {
        //.main output screen
        public Bitmap screen;
        public Form mainwindow;
        public int screenwidth;
        public int screenheight;

        public renderer(int ix, int iy, String icn, String title) {
            screen = new Bitmap(ix,iy);

            screenwidth = ix;
            screenheight = iy;

            Form frm = new Form();
            // frm.Controls.Add(new Label() {Text = "Version 5.0"});
            
            //.set atributes of file
            frm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //# initial size of window
            frm.ClientSize = new System.Drawing.Size(ix, iy);
                //# set title
            frm.Text = title;
                //# set icon
            frm.Icon = new Icon(icn);
            frm.ShowDialog();

            mainwindow = frm;
        }

        public void drawimage(int x,int y,Bitmap bitmap) {
            for (int i = 0; i < bitmap.Width; i++) {
                for (int j = 0; j < bitmap.Height; j++) {
                    //.ensure that pixil is inside screen
                    if (x+i >= 0 && y+j >= 0 && x+i < screen.Width && y+j < screen.Height) {
                        screen.SetPixel(x+i, y+j, bitmap.GetPixel(i,j));
                    }
                }
            }
        }

        public Bitmap addsprite(String path) {
            //.automaticaly creates a bitmap from image
            return new Bitmap(path);
        }

        public void update() {
            //TODO: render link
        }
    }
}