using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class PlayerAgent
    {
        readonly Game _game;
        readonly Team _owner;

        public Game Game
        {
            get { return _owner.Game; }
        }

        public Team Team
        {
            get { return _owner; }
        }

        public PlayerAgent(Game game, Team owner)
        {
            _game = game;
            _owner = owner;
        }

        public void Transfer(Player player)
        {
            string folderPath = @".\..\..\..\";
            DirectoryInfo dir = new DirectoryInfo( folderPath );
            FileInfo[] files = dir.GetFiles( "user_" + _game.UserName + "*", SearchOption.TopDirectoryOnly );

            string[] fileNames = files.Select( f => f.Name ).ToArray();
            XDocument doc = XDocument.Load( @".\..\..\..\" + fileNames[0] );

        }
    }
}
