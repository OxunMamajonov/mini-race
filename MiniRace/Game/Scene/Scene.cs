using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.Scene {
    public abstract class Scene {
        
        protected Main main { get; set; }

        public static Scene currentScene { get; set; } = null;
        
        public abstract void paint(Graphics g);

        public Scene(Main main) {
            this.main = main;
        }
    }
}
