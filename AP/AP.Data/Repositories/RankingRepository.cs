using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AP.Data.Repositories
{
    //SOLID: SRP - acceso al ranking
    //DP: Repository pattern
    public class RankingRepository
    {
        private readonly MathPuzzleEntities db = new MathPuzzleEntities();

        public List<Scores> GetTopScores()
        {
            return db.Scores
                     .GroupBy(s => s.UserId)
                     .Select(g => g
                         .OrderByDescending(x => x.TotalScore)
                         .ThenByDescending(x => x.ReachedLevel)
                         .ThenByDescending(x => x.RemainingLives)
                         .ThenByDescending(x => x.PlayedDate)
                         .FirstOrDefault())
                     .OrderByDescending(s => s.TotalScore)
                     .ThenByDescending(s => s.ReachedLevel)
                     .ThenByDescending(s => s.RemainingLives)
                     .ThenByDescending(s => s.PlayedDate)
                     .Take(10)
                     .ToList();
        }
    }
}