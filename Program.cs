//# puropse : main runtime file / entry point

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ink_nown {
    class Program {
        private static renderer rndr;
        private static dtps data;
        private static string confpath = ""; 

        [STAThread]
        static void Main() {
            //.load config
                //# commented because there is no config file yet
                //: configdata = (new dtps()).load(confpath);

            //.setup renderer
                //# icon should be 512 by 512
            rndr = new renderer(300,300, "resources/peach.ico",  "engine_csharp_test_window");

            //.no clue what the hell this does
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //.update loop
                //# todo loop
        }

        static void update() { 
            //.update renderer
            rndr.update();
        }
    }
}
