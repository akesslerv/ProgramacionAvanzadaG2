using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Models.Entities
{
    //SOLID; SRP - informacion del puzzle
    public class Puzzle
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public int Answer { get; set; }

        public int Difficulty { get; set; }

        public int Points { get; set; }
    }
}
