using System;
using System.Linq;
using System.Web.Mvc;
using AP.Data;
using AP.Data.Repositories;
using AP.MVC.Models;

namespace AP.MVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly MathPuzzleEntities db;

        public ProfileController()
        {
            userRepository = new UserRepository();
            db = new MathPuzzleEntities();
        }

        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Login");

            var username = Session["User"].ToString();

            var user = userRepository.GetByUsername(username);

            if (user == null)
                return RedirectToAction("Logout", "Login");

            var scores = db.Scores
                           .Where(s => s.UserId == user.Id)
                           .ToList();

            var model = new ProfileViewModel
            {
                Name = user.Name,
                Username = user.Username,
                GamesPlayed = scores.Count,
                BestScore = scores.Any() ? scores.Max(s => s.TotalScore) : 0,
                MaxLevel = scores.Any() ? scores.Max(s => s.ReachedLevel) : 0,
                BestLives = scores.Any() ? scores.Max(s => s.RemainingLives) : 0,
                LastGame = scores.Any()
                    ? scores.OrderByDescending(s => s.PlayedDate)
                            .First()
                            .PlayedDate
                    : null
            };

            return View(model);
        }
    }
}