using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class HighScoresController : Controller
    {
        //
        // GET: /HighScores/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GuessThatNumber()
        {
            Models.Entities db = new Models.Entities();
            return View(db.HighScores.Where(x => x.Game == "GuessThatNumber"));
        }

        public ActionResult Battleship()
        {
            Models.Entities db = new Models.Entities();
            return View(db.HighScores.Where(x => x.Game == "Battleship"));
        }

        public ActionResult Hangman()
        {
            Models.Entities db = new Models.Entities();
            return View(db.HighScores.Where(x => x.Game == "Hangman"));
        }

        public ActionResult CombatSimulator()
        {
            Models.Entities db = new Models.Entities();
            return View(db.HighScores.Where(x => x.Game == "CombatSimulator"));
        }

        public ActionResult Trivia()
        {
            Models.Entities db = new Models.Entities();
            return View(db.HighScores.Where(x => x.Game == "Trivia"));
        }

    }
}
