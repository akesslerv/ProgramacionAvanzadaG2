using System.Web.Mvc;
using AP.Core.Interfaces;
using AP.Core.Services;
using AP.Models.Entities;
using AP.Data.Repositories;

namespace AP.MVC.Controllers
{
    //SOLID: SRP - flujo del juego
    //DP: MVC - controller
    public class GameController : Controller
    {
        private readonly IPuzzleService service;
        private readonly UserRepository userRepository;
        private readonly ScoreRepository scoreRepository;

        public GameController()
        {
            service = new PuzzleService();

            userRepository = new UserRepository();
            scoreRepository = new ScoreRepository();
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
                // Los puntos aumentan según el nivel
                game.Score += game.Level * 10;

                // Si acaba de completar el nivel 15, gana
                if (game.Level >= 15)
                {
                    Session["Game"] = game;

                    SaveScore(game);

                    return RedirectToAction("Win");
                }

                // Si aún no ha llegado al último nivel, avanza
                game.Level++;
            }
            else
            {
                // Restar puntos según el nivel
                game.Score -= game.Level * 5;

                // Evitar puntajes negativos
                if (game.Score < 0)
                {
                    game.Score = 0;
                }

                game.Lives--;
            }

            if (game.Lives <= 0)
            {
                game.GameOver = true;
                Session["Game"] = game;

                SaveScore(game);

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

        private void SaveScore(GameState game)
        {
            if (Session["User"] == null)
                return;

            var username = Session["User"].ToString();

            var user = userRepository.GetByUsername(username);

            if (user == null)
                return;

            scoreRepository.SaveGame(user, game);
        }
    }
}