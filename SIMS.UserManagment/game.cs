using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.UserManagment
{
    public class Game
    {
        
        public string UserName
        {
            get;
            set;
        }
        public string GameName
        {
            get;
            set;
        }

        Game game = new Game { UserName = "Florian", GameName = "Partie de Florian" };

        List<Game> games = new List<Game> {
            new Game(){UserName = "Thibaud", GameName = "Partie de Thibaud"},
            new Game(){UserName = "Guenole", GameName = "Partie de Guenole"},
            new Game(){UserName = "Loic", GameName = "Partie de Loic"}
        };

    }
   
}
