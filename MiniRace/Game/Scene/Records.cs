using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Scene
{
    public class Records : Scene
    {
        public Records(Main main) : base(main) {

        }

        public override void paint(Graphics g)
        {
            g.DrawImage(Bundle.background, 0, 0, main.screen.Width, main.screen.Height);
            g.DrawString("Game over", Bundle.menuFont,
                                                   Brushes.Black,
                                                   main.screen.Width / 2 - 75,
                                                   main.screen.Height / 2 - 15);
            g.DrawString("Game over", Bundle.menuFont,
                                                   Brushes.White,
                                                   main.screen.Width / 2 - 80,
                                                   main.screen.Height / 2 - 20);
            if (main.screen.enter)
            {
                main.menuScene = new Menu(main);
                main.gameScene = new Game(main);
                Scene.currentScene = main.menuScene;
            }
        }
    }
}
