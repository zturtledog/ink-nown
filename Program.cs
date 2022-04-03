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
            rndr = new renderer(300,300, "resources/peach.ico");

            //no clue what the hell this does
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //important
            Application.Run(rndr.mainwindow);
        }
    }
}
