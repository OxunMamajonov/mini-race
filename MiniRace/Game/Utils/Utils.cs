using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniRace.Game.Utils {
    public class Utils {
        public static void drawString(Graphics g, string str, Font font, Color c, int x, int y) {
                TextRenderer.DrawText(g, str, font, new Point(x + 5, y + 5), Color.Black);
                TextRenderer.DrawText(g, str, font, new Point(x, y), c);
            }
        }
    }
