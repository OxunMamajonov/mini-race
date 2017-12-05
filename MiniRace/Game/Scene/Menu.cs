using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniRace.Game.Scene {
    public class Menu : Scene {
        
        private double x, y;
        int counter = 0;

        public Menu(Main main) : base(main) {

        }
        
        public override void paint(Graphics g) {
            x = main.screen.Width / 2 - Bundle.logo.Width / 2;
            y = main.screen.Height / 2 - Bundle.logo.Height / 2 + Math.Sin((Math.PI * main.ticks * 5 / 180.0)) * 15;
            y -= 100;

            if (counter > -1200)
                counter-= 8;
            else
                counter = 0;

            g.DrawImageUnscaled(Bundle.background, counter, 0, main.screen.Width, main.screen.Height);
            g.DrawImage(Bundle.logo, (float)x, (float)y);

            Utils.Utils.drawString(g, "Press enter to start", 
                                   Bundle.menuFont,
                                   Color.FromArgb(84, 153, 84),
                                   main.screen.Width / 2-180, main.screen.Height / 2);

            if (main.screen.enterOnce)
                Scene.currentScene = main.gameScene;
        }

    }
}
