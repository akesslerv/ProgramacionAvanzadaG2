using AP.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AP.Data.Repositories
{
    public class RankingOptimizedRepository
    {
        private readonly MathPuzzleEntities db = new MathPuzzleEntities();


        public List<RankingViewModel> GetOptimizedRanking()
        {
            return db.Scores
                .OrderByDescending(s => s.TotalScore)
                .Take(10)
                .Select(s => new RankingViewModel
                {
                    PlayerName = s.Users.Name,
                    TotalScore = s.TotalScore,
                    ReachedLevel = s.ReachedLevel,
                    RemainingLives = s.RemainingLives
                })
                .ToList();
        }
    }
}