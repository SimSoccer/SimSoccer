﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sims.SimSoccerModel
{
    public class Formation
    {
        Game _game;
        int i;
        Dictionary<XName, Points> positionPlayers;

        /// <summary>
        /// Assign players a position that the formation
        /// of their team and their positions on the field
        /// </summary>
        /// <param name="game">The state of the game</param>
        /// <param name="fl"></param>
        /// <param name="f">Read the file tactic.xml</param>
        public Formation(Game game, FormationList fl, XElement f)
        {
            _game = game;
            positionPlayers = new Dictionary<XName, Points>();
            if (f.Attribute("Formation").Value == _game.TeamList.Teams[i].Formation)
            {
                positionPlayers = f.Elements()
                                    .Select(eT => new { n = eT.Name, Pos = eT.Value.Split(',') })
                                    .Select(eT => new { N = eT.n, P = new Points(float.Parse(eT.Pos[0]), eT.Pos.Length > 1 ? float.Parse(eT.Pos[1]) : float.Parse(eT.Pos[0])) })
                                    .ToDictionary(eT => eT.N, eT => eT.P);

                for( int j = 0; j < _game.TeamList.Teams.Count; j++ )
                {
                    for( i = 0; i < _game.TeamList.Teams[i].TeamType.Count; i++ )
                    {
                        foreach( Player p in _game.TeamList.Teams[j].TeamType )
                        {
                            p.Position = positionPlayers[p.Poste];
                        }
                    }
                }
            }
        }
    }
}