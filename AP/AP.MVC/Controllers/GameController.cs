using System.Web.Mvc;
using AP.Core.Interfaces;
using AP.Core.Services;
using AP.Models.Entities;

namespace AP.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IPuzzleService service;

        public GameController()
        {
            service = new PuzzleService();
        }

        public ActionResult Index()
        {
            GameState game;

            if (Session["Game"] == null)
            {
                game = new GameState
                {
                    CurrentQuestion = service.GenerateQuestion(),
                    Lives = 3,
                    Score = 0,
                    Level = 1,
                    GameOver = false
                };

                Session["Game"] = game;
            }
            else
            {
                game = (GameState)Session["Game"];
            }

            return View(game);
        }

        [HttpPost]
        public ActionResult Answer(string selectedAnswer)
        {
            if (Session["Game"] == null)
            {
                return RedirectToAction("Index");
            }

            GameState game = (GameState)Session["Game"];

            if (selectedAnswer == game.CurrentQuestion.CorrectAnswer)
            {
                game.Score += game.CurrentQuestion.Points;

                // Si acaba de completar el nivel 15, gana
                if (game.Level >= 15)
                {
                    Session["Game"] = game;
                    return RedirectToAction("Win");
                }

                // Si aún no ha llegado al último nivel, avanza
                game.Level++;
            }
            else
            {
                game.Lives--;
            }

            if (game.Lives <= 0)
            {
                game.GameOver = true;
                Session["Game"] = game;

                return RedirectToAction("Index", "GameOver");
            }

            // Generar una nueva pregunta
            game.CurrentQuestion = service.GenerateQuestion();

            // Guardar nuevamente la partida
            Session["Game"] = game;

            return RedirectToAction("Index");
        }

        public ActionResult NewGame()
        {
            Session.Remove("Game");

            return RedirectToAction("Index");
        }

        public ActionResult Win()
        {
            return View();
        }
    }
}