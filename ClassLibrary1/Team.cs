using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawGame
{
    public class Team
    {

        string _nameTeam;

        public Team(string name)
        {
            _nameTeam = name;
        }

        public  string TeamPlayer(string TeamChoice)
        {
            return  _nameTeam = TeamChoice;
        }
        public string Name
        {
            get {return _nameTeam;}
        }
    }
}