using MiniRace.Game;
using MiniRace.Game.Scene;
using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MiniRace {
    public partial class Screen : Form {

        Main main;

        public Screen(Main main) {
            this.main = main;

            InitializeComponent();
            DoubleBuffered = true;

            main.Width = Width;
            main.Height = Height;
        }

        private void Screen_FormClosed(object sender, FormClosedEventArgs e) {
            main.t.Abort();
        }

        private void Screen_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            
            if(Scene.currentScene != null)
                Scene.currentScene.render(g);
        }

        private void Screen_SizeChanged(object sender, EventArgs e) {
            main.Width = Width;
            main.Height = Height;
        }
    }
}
