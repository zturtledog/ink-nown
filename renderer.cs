using System;
using System.Drawing;

namespace ink_nown {
    class renderer {
        public Bitmap drawimage(Bitmap bitmap) {
            // Bitmap bitmap = new Bitmap(640, 480);

            for (int x = 0; x < bitmap.Width; x++) {
                for (int y = 0; y < bitmap.Height; y++) {
                    bitmap.SetPixel(x, y, Color.BlueViolet);
                }
            }

            return bitmap;
        }
    }
}