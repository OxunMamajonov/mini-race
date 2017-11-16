using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Scene {
    public abstract class Scene {

        protected Screen screen { get; set; }
        protected Main main { get; set; }

        public static Scene currentScene { get; set; } = null;

        public abstract void update();
        public abstract void render(Graphics g);

        public Scene(Main main) {
            this.main = main;
            this.screen = screen;
        }
    }
}
