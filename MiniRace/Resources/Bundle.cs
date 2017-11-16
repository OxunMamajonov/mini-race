using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Resources {
    public class Bundle {

        public static Bitmap logo { get; set; }
        public static Font menuFont { get; set; }
        
        public static void init() {
            logo = new Bitmap("../../Resources/logo.png");

            PrivateFontCollection f = new PrivateFontCollection();
            f.AddFontFile("../../Resources/Upheaval.otf");
            menuFont = new Font(f.Families[0], 24);
        }
    }
}
