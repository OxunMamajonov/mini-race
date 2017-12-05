
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

            Utils.Utils.drawString(g, $"Game over\n\nYour name:\n{SystemInformation.ComputerName} / {Environment.UserName}\n\nScores: {score}", 
                                   Bundle.menuFont, 
                                   Color.FromArgb(84, 153, 84), 
                                   main.screen.Width / 2-100, 
                                   main.screen.Height / 2-120);

            //var name = from ps in db.PlayerSet
            //           orderby ps.Description.Ammount
            //           select ps.Description.Ammount;

            //int a = 250;
            //int count = 0;
            //foreach (string str in name) {
            //    drawString(g, str, main.screen.Width / 2, main.screen.Height / 4 + a);
            //    a += 50;

            //    if (count < 4)
            //        count++;
            //    else
            //        break;
            //}


            if (main.screen.enterOnce) {

                //string timeStr = DateTime.Now.ToLongTimeString();
                //string scoreStr = score.ToString();

                //Score scoreDB = new Score {
                //    Time = timeStr,
                //    Ammount = scoreStr
                //};

                //db.PlayerSet.Add(
                //new Player {
                //    Name = $"{SystemInformation.ComputerName} / {Environment.UserName}",
                //    Description = scoreDB
                //});

                //db.SaveChanges();
                
                main.gameScene = new Game(main);
                Thread.Sleep(60);
                Scene.currentScene = main.menuScene;
            }

        }
    }
}
