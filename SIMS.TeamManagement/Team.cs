using SIMS.PlayersManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.TeamsManagement
{
    public class Team
    {
        int _id; 
        string _name,  _teamTag, _town;
        string _stadium, _logo, _manager;
        int _leagueRanking; int _level;
        Player _players;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string TeamTag
        {
            get { return _teamTag; }
            set { _teamTag = value; }
        }

        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        public string Stadium
        {
            get { return _stadium; }
            set { _stadium = value; }
        }

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public int LeagueRanking
        {
            get { return _leagueRanking; }
            set { _leagueRanking = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public IEnumerable<Player> Composition
        {
            get
            {
                PlayersList players = new PlayersList();
                players.CreatePlayersList();

            }
            set { }
        }
    }
}
