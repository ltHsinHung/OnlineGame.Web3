using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using OnlineGame.Web3.Data;
using Gamer = OnlineGame.Web3.Models.Gamer;

namespace OnlineGame.Web3.Controllers
{
    public class GamerController : Controller
    {
        public ActionResult Details(int id = 0)
        {
            var onlineGameContext = new Data.OnlineGameContext();
            Gamer gamer;
            if (id == 0)
            {
                gamer = new Gamer
                {
                    Id = 0,
                    Name = "Name0",
                    Gender = "NULL",
                    City = "NULL"
                };
                // or you may throw exception here.
            }
            else
            {
                gamer = onlineGameContext.Gamers.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
            }
            return View(gamer);
        }
        public ActionResult Index(int teamId)
        {
            var context = new Data.OnlineGameContext();
            List<Gamer> gamers = context.Gamers.Where(gamer => gamer.TeamId == teamId).ToList();
            return View(gamers);
        }

        public ActionResult Index2()
        {
            //Ado.Net
            GamerBusinessLayer gamerBusinessLayer = new GamerBusinessLayer();
            List<BusinessLayer.Gamer> gamers = gamerBusinessLayer.Gamers.ToList();
            return View(gamers);
        }
        //[HttpGet] attribute means it only respond to the "GET" request.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // 1. Retrieve form data using FormCollection
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            ////FormCollection implement C# indexer.
            ////See each key and value of formCollection.
            //foreach (string key in formCollection.AllKeys)
            //{
            // Response.Write($"key=={key}, {formCollection[key]}, <br/>");
            //}
            int teamId;
            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer
            {
                Name = formCollection["Name"],
                Gender = formCollection["Gender"],
                City = formCollection["City"],
                DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]),
                TeamId = int.TryParse(formCollection["TeamId"], out teamId) ? teamId : 0
            };
            GamerBusinessLayer gamerBusinessLayer =
            new GamerBusinessLayer();
            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }
        // 2. Retrieve form data using name attribute of input tag from cshtml
        [HttpPost]
        public ActionResult Create2(string name, string gender, string city, DateTime dateOfBirth, int teamId)
        {
            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer
            {
                Name = name,
                Gender = gender,
                City = city,
                DateOfBirth = dateOfBirth,
                TeamId = teamId
            };
            GamerBusinessLayer gamerBusinessLayer =
            new GamerBusinessLayer();
            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }
        // 3. Retrieve form data using model binding
        [HttpPost]
        public ActionResult Create3(BusinessLayer.Gamer gamer)
        {
            //if any of input is not valid.
            if (!ModelState.IsValid)
            {
                return View("Create");
                //Go to Create.cshtml,
                //so users can correct their input value.
            }
            GamerBusinessLayer gamerBusinessLayer =
            new GamerBusinessLayer();
            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }
        // 4. Retrieve form data using model binding by UpdateModel() or TryUpdateModel()
        [HttpPost]
        [ActionName("Create4")]
        public ActionResult Create_Post()
        {
            //if any of input is not valid.
            if (!ModelState.IsValid)
            {
                return View("Create");
                //Go to Create.cshtml,
                //so users can correct their input value.
            }
            GamerBusinessLayer gamerBusinessLayer =
            new GamerBusinessLayer();
            BusinessLayer.Gamer gamer = new BusinessLayer.Gamer();
            //UpdateModel<BusinessLayer.Gamer>(gamer);
            //UpdateModel(gamer);
            TryUpdateModel(gamer);
            //1.
            // UpdateModel() and TryUpdateModel() inspects all the HttpRequest inputs
            // such as posted Form data, QueryString,
            // Cookies and Server variables and populate the gamer object.
            gamerBusinessLayer.AddGamer(gamer);
            return RedirectToAction("Index2");
        }

    }
}
