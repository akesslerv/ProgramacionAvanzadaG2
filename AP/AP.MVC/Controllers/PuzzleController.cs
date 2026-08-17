using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AP.Core.Interfaces;
using AP.Core.Services;
using System.Web.Mvc;

namespace AP.MVC.Controllers
{
    //SOLID: SRP - solicited de puzzles
    //DP: MVC - controller
    public class PuzzleController : Controller
    {
        private readonly IPuzzleService service;

        public PuzzleController()
        {
            service = new PuzzleService();
        }

        public ActionResult Index()
        {
            var puzzles = service.GetAll();

            return View(puzzles);
        }
    }
}