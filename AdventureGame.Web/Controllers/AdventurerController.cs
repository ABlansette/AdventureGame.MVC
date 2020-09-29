using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureGame.MVC.Controllers
{
    public class AdventurerController : Controller
    {
        // GET: Adventurer
        public ActionResult Index()
        {
            return View();
        }
    }
}