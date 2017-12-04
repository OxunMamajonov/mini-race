using MiniRace.Game.Scene;
using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MiniRace.Game {
    public class Main {

        public Scene.Scene gameScene { get; set; }
        public Scene.Scene menuScene { get; set; }
        public Scene.Scene recordsScene { get; set; }
        public Screen screen { get; set; }

        public int tickTread { get; set; } = 0;

        public int ticks { get; set; } = 0;

        public Main(Screen screen) {
            this.screen = screen;

            Bundle.init();

            gameScene = new Scene.Game(this);
            menuScene = new Scene.Menu(this);
            recordsScene = new Scene.Records(this);
            Scene.Scene.currentScene = menuScene;
        }

        public void Screen_FormClosed(object sender, FormClosedEventArgs e) { }

        public void timer_Tick(object sender, EventArgs e) {

            screen.Invalidate();

            if (ticks < 360)
                ticks++;
            else
                ticks = 0;
        }

        public void Screen_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(55, 55, 55));

            if (Scene.Scene.currentScene != null)
                Scene.Scene.currentScene.paint(g);

        }
    }
}

