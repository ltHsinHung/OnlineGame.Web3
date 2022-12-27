using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OnlineGame.Web3.Data;
using OnlineGame.Web3.Models;

namespace OnlineGame.Web3.Controllers
{
    public class TeamController:Controller
    {
        public ActionResult Index()
        {
            OnlineGameContext context = new OnlineGameContext();
            List<Team> teams = context.Teams.ToList();
            return View(teams);
        }
    }
}
