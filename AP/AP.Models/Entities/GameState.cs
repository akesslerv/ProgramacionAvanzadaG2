using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Models.Entities
{
    public class GameState
    {
        public GameQuestion CurrentQuestion { get; set; }

        public int Score { get; set; }

        public int Lives { get; set; }

        public int Level { get; set; }

        public bool GameOver { get; set; }

        public string Hearts
        {
            get
            {
                switch (Lives)
                {
                    case 3:
                        return "❤️ ❤️ ❤️";

                    case 2:
                        return "❤️ ❤️ 🤍";

                    case 1:
                        return "❤️ 🤍 🤍";

                    default:
                        return "🤍 🤍 🤍";
                }
            }
        }
    }
}