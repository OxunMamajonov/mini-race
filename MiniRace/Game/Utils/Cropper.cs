using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Utils {
    public class Cropper {

        private Bitmap bmp;

        public Cropper(Bitmap bmp) {
            this.bmp = bmp;
        }

        public Bitmap crop(int x, int y, int width, int height) {
            return bmp.Clone(new Rectangle(x, y, width, height), bmp.PixelFormat);
        }
    }
}
