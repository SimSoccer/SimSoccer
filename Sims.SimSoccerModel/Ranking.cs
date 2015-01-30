using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
             DateTime today = DateTime.Now;
             XDocument doc;
            string userDoc = @".\..\..\..\user_" + _game.UserName + "_save_" + today.Year + today.Month + today.Day + ".xml";
            if( File.Exists( userDoc ) )
            {
                doc = XDocument.Load( userDoc ); 
                for( int i = 0; i < _game.TeamList.Teams.Count; i++ )
                {
                    board.Add( _game.TeamList.Teams[i].Name, _game.TeamList.Teams[i].LeaguePoint );
                    XElement points = doc.Element( "Game" ).Element( "Teams" ).Elements( "Team" )
                        .Where( tN => tN.Attribute( "Name" ).Value == _game.TeamList.Teams[i].Name )
                        .Select( e => e.Element( "Points" ) )
                        .Single();

                    points.Value = _game.TeamList.Teams[i].LeaguePoint.ToString();
                    doc.Save( userDoc );
                }
            }

            board = board.OrderByDescending( kvp => kvp.Value ).ToDictionary( kvp => kvp.Key, kvp => kvp.Value );

            return board;
        }
        
    }
}
