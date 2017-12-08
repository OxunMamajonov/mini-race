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
        public bool esc { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public bool left { get; set; }
        public bool right { get; set; }

        public bool enterOnce { get; set; }
        public bool escOnce { get; set; }
        public bool upOnce { get; set; }
        public bool downOnce { get; set; }
        public bool leftOnce { get; set; }
        public bool rightOnce { get; set; }

        public bool enterCant { get; set; }
        public bool escCant { get; set; }
        public bool upCant { get; set; }
        public bool downCant { get; set; }
        public bool leftCant { get; set; }
        public bool rightCant { get; set; }

        public Screen() {

            InitializeComponent();

            this.main = new Main(this);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(main.Screen_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(main.Screen_Paint);
            this.timer.Tick += new System.EventHandler(main.timer_Tick);
            DoubleBuffered = true;
        }

        public void tick() {
            if(enterCant && !enter) {
                enterCant = false;
            } else if(enterOnce) {
                enterCant = true;
                enterOnce = false;
            }
            if(!enterCant && enter) {
                enterOnce = true;
            }
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
                case Keys.Escape:
                    esc = false;
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
                case Keys.Escape:
                        esc = true;
                    break;
            }

        }

        private void Screen_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
