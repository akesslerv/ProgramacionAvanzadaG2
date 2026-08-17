using System;
using AP.Models.Entities;

namespace AP.Data.Repositories
{
    //SOLID: SRP - acceso a puntuaciones
    //DP: Repository pattern
    public class ScoreRepository
    {
        private readonly MathPuzzleEntities db = new MathPuzzleEntities();

        public void SaveGame(User user, GameState game)
        {
            if (user == null || game == null)
                return;

            var score = new Scores
            {
                UserId = user.Id,
                TotalScore = game.Score,
                ReachedLevel = game.Level,
                RemainingLives = game.Lives,
                PlayedDate = DateTime.Now
            };

            db.Scores.Add(score);
            db.SaveChanges();
        }
    }
}