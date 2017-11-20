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
        public bool enter { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public bool left { get; set; }
        public bool right { get; set; }

        public Screen(Main main) {

            this.main = main;

            InitializeComponent();
            DoubleBuffered = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(main.Screen_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(main.Screen_Paint);
        }

        private void Screen_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    enter = false;
                    break;
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
            }
            
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    enter = true;
                    break;
                case Keys.Left:
                    left = true;
                    break;
                case Keys.Right:
                    right = true;
                    break;
                case Keys.Up:
                    up = true;
                    break;
                case Keys.Down:
                    down = true;
                    break;
            }

        }
    }
}
