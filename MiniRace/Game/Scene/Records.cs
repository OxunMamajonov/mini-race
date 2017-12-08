
using MiniRace.Resources;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Threading;
using MiniRace.Game.DB;

namespace MiniRace.Game.Scene
{
    public class Records : Scene
    {
        public int score { get; set; }
        private int counter = 0, counter2 = -1200;
        mrEntities context = new mrEntities();

        public Records(Main main) : base(main) {
        }

        public override void paint(Graphics g) {

            if (counter > -1200)
                counter -= 18;
            else
                counter = 0;

            if (counter2 < 0)
                counter2 += 12;
            else
                counter2 = -1200;

            g.DrawImageUnscaled(Bundle.backgroundEnd, counter, 0, main.screen.Width, main.screen.Height);
            g.DrawImageUnscaled(Bundle.cloudsEnd, counter2, 0, main.screen.Width, main.screen.Height);

            Utils.Utils.drawString(g, $"Game over\n\nYour name:\n{Environment.UserName}\n\nScores: {score}",
                                   Bundle.menuFont,
                                   Color.FromArgb(84, 153, 84),
                                   main.screen.Width / 2 - 260,
                                   main.screen.Height / 2 - 120);



            Utils.Utils.drawString(g, "Your records:",
                                   Bundle.menuFont,
                                   Color.FromArgb(84, 153, 84), main.screen.Width / 2 + 5, main.screen.Height / 3 + 17);

            var player = from pl in context.PlayerSet
                         join sc in context.ScoreSet
                         on pl.PlayerId equals sc.Player_PlayerId
                         orderby sc.Ammount
                         select pl.Name + "   " + sc.Ammount + "  " + sc.Time;

            int outer = 65, count = 0;
            foreach (string str in player) {
                if (count > 5)
                    break;
                Utils.Utils.drawString(g, str,
                                       Bundle.menuFont,
                                       Color.FromArgb(84, 153, 84), main.screen.Width / 2 + 5, main.screen.Height / 3 + outer);
                outer += 20;
                count++;
            }


            if (main.screen.enterOnce) {

                PlayerSet exist = null;
                foreach (PlayerSet p in context.PlayerSet) {
                    if (p.Name == Environment.UserName)
                        exist = p;
                }

                if (exist != null) {
                    exist.ScoreSet.Add(new ScoreSet { Ammount = score.ToString(), Time = DateTime.Now.ToLongTimeString() });
                } else {

                    PlayerSet p = new PlayerSet { Name = Environment.UserName };

                    p.ScoreSet.Add(new ScoreSet {
                        Ammount = score.ToString(),
                        Time = DateTime.Now.ToLongTimeString()
                    });

                    context.PlayerSet.Add(p);
                }

                context.SaveChanges();

                main.gameScene = new Game(main);
                Thread.Sleep(60);
                Scene.currentScene = main.menuScene;
            }

        }
    }
}
