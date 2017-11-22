using MiniRace.Game.DB;
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

namespace MiniRace.Game.Scene
{
    public class Records : Scene
    {
        public int score { get; set; }
        ScoresContainer db = new ScoresContainer();

        public Records(Main main) : base(main) {

        }

        public override void paint(Graphics g)
        {
            g.DrawImage(Bundle.background, 0, 0, main.screen.Width, main.screen.Height);

            drawString(g, "Game over", main.screen.Width / 2, main.screen.Height / 4);
            drawString(g, "Your name: ", main.screen.Width / 2, main.screen.Height / 4+100); 
            drawString(g, $"{SystemInformation.ComputerName} / {Environment.UserName}", main.screen.Width / 2, main.screen.Height / 4 + 150);
            drawString(g, $"Scores: {score}", main.screen.Width / 2, main.screen.Height / 4 + 200);

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


            //if (main.screen.enter)
            //{

            //    string timeStr = DateTime.Now.ToLongTimeString();
            //    string scoreStr = score.ToString();

            //    Score scoreDB = new Score {
            //        Time = timeStr,
            //        Ammount = scoreStr
            //    };

            //    db.PlayerSet.Add(
            //    new Player {
            //        Name = $"{SystemInformation.ComputerName} / {Environment.UserName}",
            //        Description = scoreDB
            //    });

            //    db.SaveChanges();

            //    main.menuScene = new Menu(main);
            //    main.gameScene = new Game(main);
            //    Scene.currentScene = main.menuScene;
            //}

        }
        private void drawString(Graphics g, string str, int x, int y) {

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(str, Bundle.menuFont, Brushes.Black, x+5, y+5, stringFormat);
            g.DrawString(str, Bundle.menuFont, Brushes.White, x, y, stringFormat);
        }
    }
}
