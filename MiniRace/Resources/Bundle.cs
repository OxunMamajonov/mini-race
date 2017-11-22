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
        public static Bitmap[] oil { get; set; }
        public static Bitmap oilpath { get; set; }

        public static void init() {
            logo = new Bitmap("../../Resources/logo.png");
            background = new Bitmap("../../Resources/background.png");

            wall = new Bitmap("../../Resources/wall.png");
            floor = new Bitmap("../../Resources/floor.png");
            car = new Bitmap("../../Resources/car.png");

            oil = new Bitmap[6];
            oil[0] = new Bitmap("../../Resources/oil.png");
            oil[1] = new Bitmap("../../Resources/oil2.png");
            oil[2] = new Bitmap("../../Resources/oil3.png");
            oil[3] = new Bitmap("../../Resources/oil_big.png");
            oil[4] = new Bitmap("../../Resources/oil2_big.png");
            oil[5] = new Bitmap("../../Resources/oil3_big.png");

            oilpath = new Bitmap("../../Resources/oilpath.png");

            PrivateFontCollection f = new PrivateFontCollection();
            f.AddFontFile("../../Resources/Upheaval.otf");
            menuFont = new Font(f.Families[0], 24);
        }
    }
}
