using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Scene {
    public class MenuScene : Scene {
        
        private double x, y;

        public MenuScene(Main main) : base(main) {

        }

        public override void update() {

            x = main.screen.Width / 2 - Bundle.logo.Width / 2;
            y = main.screen.Height / 2 - Bundle.logo.Height / 2 + Math.Sin((Math.PI * main.ticks * 5 / 180.0)) * 15;
            y -= 100;

        }

        public override void render(Graphics g) {
            g.DrawImage(Bundle.logo, (float)x, (float)y);
            g.DrawString("Press any key to start", Bundle.menuFont, 
                                                   Brushes.White, 
                                                   main.screen.Width / 2 - 200, 
                                                   main.screen.Height / 2 + 50);
        }

    }
}
