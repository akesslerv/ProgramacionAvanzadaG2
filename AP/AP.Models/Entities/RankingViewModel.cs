using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Models.Entities
{
    public class RankingViewModel
    {
        public string PlayerName { get; set; }
        public int TotalScore { get; set; }
        public int ReachedLevel { get; set; }
        public int RemainingLives { get; set; }
    }
}