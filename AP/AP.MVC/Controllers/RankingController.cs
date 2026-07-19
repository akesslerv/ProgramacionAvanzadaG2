using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AP.Data.Repositories;


namespace AP.MVC.Controllers
{
    public class RankingController : Controller
    {
        private readonly RankingRepository repository;

        public RankingController()
        {
            repository = new RankingRepository();
        }

        public ActionResult Index()
        {
            var ranking = repository.GetTopScores();

            return View(ranking);
        }
    }
}