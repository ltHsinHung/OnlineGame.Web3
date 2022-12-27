using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineGame.Web3.Models
{
    [Table("Gamer", Schema = "dbo")]
    public class Gamer
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}
