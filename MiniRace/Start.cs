using MiniRace.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MiniRace {
     public class Start {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Screen());
            
        }

    }
}
