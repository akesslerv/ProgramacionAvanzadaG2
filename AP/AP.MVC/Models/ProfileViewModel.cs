using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AP.MVC.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public int BestScore { get; set; }

        public int GamesPlayed { get; set; }

        public int MaxLevel { get; set; }

        public int BestLives { get; set; }

        public DateTime? LastGame { get; set; }
    }
}