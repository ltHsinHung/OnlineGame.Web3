using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineGame.Web3.Models
{
    [Table("Team", Schema = "dbo")]
    public class Team
    {
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public List<Gamer> Gamers { get; set; }
    }
}
