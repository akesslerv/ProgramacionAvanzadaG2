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
        private readonly RankingOptimizedRepository optimizedRepository;

        public RankingController()
        {
            repository = new RankingRepository();
            optimizedRepository = new RankingOptimizedRepository();
        }


        public ActionResult Index()
        {
            var ranking = repository.GetTopScores();

            ViewBag.TipoRanking = "Normal";

            return View(ranking);
        }


        public ActionResult Optimized()
        {
            var ranking = optimizedRepository.GetOptimizedRanking();

            ViewBag.TipoRanking = "Optimizado";

            return View("Optimized", ranking);
        }
    }
}