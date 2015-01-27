using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims.SimSoccerModel
{
    public class Ranking
    {
        readonly Game _game;
        Team _current;

        public Game Game
        {
            get { return _game; }
        }

        public Team Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public Ranking( Game Game )
        {
            _game = Game;

        }

        public Dictionary<string, int> getRanking()
        {
            Dictionary<string, int> board = new Dictionary<string, int>();

            for( int i = 0; i < _game.TeamList.Teams.Count; i++ )
            {
                board.Add( _game.TeamList.Teams[i].Name, _game.TeamList.Teams[i].LeaguePoint );
            }

            
            board = board.OrderByDescending( kvp => kvp.Value ).ToDictionary( kvp => kvp.Key, kvp => kvp.Value );

            return board;
        }
        
    }
}
