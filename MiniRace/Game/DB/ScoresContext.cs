using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniRace.Game.DB {
    public class ScoresContext : DbContext {
        public DbSet<Player> players { get; set; }
        public DbSet<Score> scores { get; set; }
    }
}
