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
        public static Bitmap background { get; set; }
        public static Font menuFont { get; set; }

        public static Bitmap wall { get; set; }
        public static Bitmap floor { get; set; }
        public static Bitmap car { get; set; }

        public static void init() {
            logo = new Bitmap("../../Resources/logo.png");
            background = new Bitmap("../../Resources/background.png");

            wall = new Bitmap("../../Resources/wall.png");
            floor = new Bitmap("../../Resources/floor.png");
            car = new Bitmap("../../Resources/car.png");

            PrivateFontCollection f = new PrivateFontCollection();
            f.AddFontFile("../../Resources/Upheaval.otf");
            menuFont = new Font(f.Families[0], 24);
        }
    }
}
