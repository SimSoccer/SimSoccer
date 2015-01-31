using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sims.SimSoccerModel;

namespace SIMS.SimSoccerForm
{
    public partial class ShowResult : Form
    {
        readonly Game _game;
        LobbyForm _lobby;


        public ShowResult( Game game, LobbyForm lobby )
        {
            InitializeComponent();
            _game = game;
            _lobby = lobby;
            ViewOtherScore_TextChanged( this, EventArgs.Empty );
            
        }

        private void ViewOtherScore_TextChanged( object sender, EventArgs e )
        {
           string temp = "";
           string temp2 = "";
          
               for( int j = 0; j < _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs.Count; j++ )
               {
                   if( _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Home.Name == _game.ChoosenTeam || _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Outside.Name == _game.ChoosenTeam )
                   {
                       temp2 += _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.TextSummary + "\r\n" ;

                       if( _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerH != null && _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerO != null )
                       {
                           temp2 += "  Les buteur(s) d\' " + _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Home.Name + " sont : \r\n";

                           foreach( Player value in _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerH )
                           {
                               temp2 += "  " + value.Name + "   /";
                           }
                           temp2 += "\r\n Les buteur(s) d\' " + _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Outside.Name + " sont : \r\n";
                           foreach( Player value in _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerO )
                           {
                               temp2 += "  " + value.Name + "   /";
                           }
                       }
                       else if( _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerH == null && _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerO != null )
                       {
                           temp2 += "\r\n Les buteur(s) d\' " + _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Outside.Name + " sont : \r\n";
                           foreach( Player value in _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerO )
                           {
                               temp2 += "  " + value.Name + "   /";
                           }
                       }
                       else if( _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerH != null && _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerO == null )
                       {
                           temp2 += "\r\n Les buteur(s) d\' " + _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Home.Name + " sont : \r\n";
                           foreach( Player value in _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.ScorerH )
                           {
                               temp2 += "  " + value.Name + "   /";
                           }
                       }
                       

                   }
                   else
                   {
                   temp += _game.Ligue.Calendar.MatchDay[_game.Journey].Matchs[j].Result.TextSummary + "\r\n";
                   }
               }
               ViewOtherScore.Text = temp;
               MyMatch.Text = temp2;
        }

        private void ShowResult_FormClosing( object sender, FormClosingEventArgs e )
        {
            _game.Journey = _game.Journey + 1;
            _lobby.currentJourney_TextChanged(this, EventArgs.Empty);
        }
    }
}
