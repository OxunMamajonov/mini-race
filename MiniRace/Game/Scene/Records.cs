
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
        //ScoresContainer db = new ScoresContainer();

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
                                   main.screen.Width / 2 - 100,
                                   main.screen.Height / 2 - 120);


            ScoresContext context = new ScoresContext();
            SqlConnection connection = new SqlConnection(@"Data Source=SEDYH;Initial Catalog=ScoresDBB;Integrated Security=True");
            
            context.players.Add(new Player { Name = Environment.UserName });
            context.SaveChanges();

            //Utils.Utils.drawString(g, "Your records:",
            //                       Bundle.menuFont,
            //                       Color.FromArgb(84, 153, 84), 0, main.screen.Height / 3);

            //var player = from pl in context.players
            //             join sc in context.scores
            //             on pl.ScoreID equals sc.ScoreID
            //             where pl.Name == Environment.UserName
            //             select pl.Name +" "+ sc.Ammount +" "+sc.Time;

            //int outer = 20;
            //foreach(string str in player) {
            //    Utils.Utils.drawString(g, str,
            //                           Bundle.menuFont,
            //                           Color.FromArgb(84, 153, 84), 0, main.screen.Height / 3 + outer);
            //    outer += 20;
            //}


            //Utils.Utils.drawString(g, "Top records:",
            //                       Bundle.menuFont,
            //                       Color.FromArgb(84, 153, 84), main.screen.Width - 150, main.screen.Height / 3);


            if (main.screen.enterOnce) {
                //Player exist = null;
                //foreach (Player p in context.players) {
                //    if (p.Name == Environment.UserName)
                //        exist = p;
                //}

                //if (exist != null) {
                //    exist.Score.Add(new Score { Ammount = score.ToString(), Time = DateTime.Now.ToLongTimeString() });
                //} else {

                //    Player p = new Player { Name = Environment.UserName };

                //    p.Score.Add(new Score {
                //        Ammount = score.ToString(),
                //        Time = DateTime.Now.ToLongTimeString()
                //    });

                //    context.players.Add(p);
                //}

                //context.SaveChanges();

                main.gameScene = new Game(main);
                Thread.Sleep(60);
                Scene.currentScene = main.menuScene;
            }

        }
    }
}
