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

        public Thread t { get; set; }

        public Scene.Scene gameScene { get; set; }
        public Scene.Scene menuScene { get; set; }
        public Screen screen { get; set; }

        public int ticks { get; set; } = 0;

        public Main() {
            t = new Thread(init);
            t.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            screen = new Screen(this);
            Application.Run(screen);
        }

        private void init() {
            Bundle.init();

            gameScene = new Scene.Game(this);
            menuScene = new Scene.Menu(this);
            Scene.Scene.currentScene = menuScene;

            double timePerTick = 1000000000 / 60;
            double delta = 0;

            long nano = (10000L * Stopwatch.GetTimestamp()) / TimeSpan.TicksPerMillisecond * 100L;

            long now,
                 timer = 0,
                 last = nano;

            while (true) {

                nano = (10000L * Stopwatch.GetTimestamp()) / TimeSpan.TicksPerMillisecond * 100L;

                now = nano;
                delta += (now - last) / timePerTick;
                timer = now - last;
                last = now;
                if (delta >= 1) {
                    screen.Invalidate();
                    ticks++;
                    delta--;
                }

                if (timer >= 1000000000) {
                    ticks = 0;
                    timer = 0;
                }

            }
        }

        public void Screen_FormClosed(object sender, FormClosedEventArgs e) {
            t.Abort();
        }

        public void Screen_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(80, 107, 81));

            if (Scene.Scene.currentScene != null)
                Scene.Scene.currentScene.paint(g);
        }
    }
}
