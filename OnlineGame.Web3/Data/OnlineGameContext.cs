using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineGame.Web3.Models;

namespace OnlineGame.Web3.Data
{
    public class OnlineGameContext : DbContext
    {
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
