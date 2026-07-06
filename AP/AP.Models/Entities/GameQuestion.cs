using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Models.Entities
{
    public class GameQuestion
    {
        public string Question { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string CorrectAnswer { get; set; }

        public int Points { get; set; }

        public int Difficulty { get; set; }
    }
}