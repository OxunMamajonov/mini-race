using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Scene {
    public class Menu : Scene {
        
        private double x, y;

        public Menu(Main main) : base(main) {

        }
        
        public override void paint(Graphics g) {
            x = main.screen.Width / 2 - Bundle.logo.Width / 2;
            y = main.screen.Height / 2 - Bundle.logo.Height / 2 + Math.Sin((Math.PI * main.ticks * 5 / 180.0)) * 15;
            y -= 100;

            g.DrawImage(Bundle.background, 0, 0, main.screen.Width, main.screen.Height);
            g.DrawImage(Bundle.logo, (float)x, (float)y);

            g.DrawString("Press any key to start", Bundle.menuFont,
                                                   Brushes.Black,
                                                   main.screen.Width / 2 - 195,
                                                   main.screen.Height / 2 + 55);
            g.DrawString("Press any key to start", Bundle.menuFont, 
                                                   Brushes.White, 
                                                   main.screen.Width / 2 - 200, 
                                                   main.screen.Height / 2 + 50);
            if (main.screen.enter)
                Scene.currentScene = main.gameScene;
        }

    }
}
