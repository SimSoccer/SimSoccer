using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace Sims.SimSoccerModel
{
    public class PlayerList
    {
        readonly Game _game;
        readonly List<Player> _players;
        Image i;

        public PlayerList( Game game )
        {
            _game = game;
            _players = new List<Player>();

        }

        public Game Game
        {
            get { return _game; }
        }

        public PlayerList( Game game, XElement e )
        {
            i = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            _game = game;
            _players = e.Elements( "Player" )
                .OrderBy( eT => int.Parse( eT.Attribute( "Id" ).Value ) )
                .Select( eT => new Player( this, eT, i  ) )
                .ToList();
        }

        public PlayerList( Game game, XElement e, string s )
        {
            i = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            _game = game;
            _players = e.Elements( "Player" )
                .OrderBy( eT => int.Parse( eT.Attribute( "Id" ).Value ) )
                .Select( eT => new Player( this, eT, i ) )
                .ToList();
        }

        public PlayerList( Game game, XElement e, int forNothing )
        {
            i = Image.FromFile( @".\..\..\..\images\PlayerOne.png" );
            _game = game;
            _players = e.Elements( "Player" )
                .OrderBy( eT => int.Parse( eT.Attribute( "Id" ).Value ) )
                .Select( eT => new Player( this, eT, i, 1 ) )
                .ToList();
        }

        public XElement ToXml()
        {
            return new XElement( "Players", _players.Select( ( t, idx ) => t.ToXml( idx ) ) );
        }

        public IReadOnlyList<Player> Players
        {
            get { return _players; }
        }

        public void RemovePlayer( Player p )
        {
            int idx = _players.IndexOf( p );
            if( idx < 0 ) throw new ArgumentException();
            _players.RemoveAt( idx );
        }

        public Player CreatePlayer( string uniqueName )
        {
            if( _players.Any( t => t.Name == uniqueName ) ) throw new InvalidOperationException( "Name must be unique!" );
            var player = new Player( this, uniqueName );
            _players.Add( player );
            return player;
        }

        public void AddPlayerToList(Player p)
        {
            _players.Add( p );
        }
    }
}
