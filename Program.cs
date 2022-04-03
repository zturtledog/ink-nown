using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ink_nown {
    class Program {
        public static renderer rndr;

        [STAThread]
        static void Main() {
            //setup renderer
                //# icon should be 512 by 512
            rndr = new renderer(300,300, "resources/peach.ico",  "engine_csharp_test_window");

            //no clue what the hell this does
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
