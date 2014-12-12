using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateXMLTeams
{
    class Program
    {
        static void Main( string[] args )
        {
            string csvString = @"0,Sporting Club de Bastia,SCB,Bastia,Armand-Cesari,http://medias.lequipe.fr/logo-football/16/300?LFW0FOX0004800Y-14-46,Ghislain PRINTANT,1,50
1,Football Club des Girondins de Bordeaux,FCB,Bordeaux,Jacques Chaban-Delmas,http://medias.lequipe.fr/logo-football/18/300?LFW0FOX0004800Y-14-46,Willy SAGNOL,2,50
2,Stade Malherbe de Caen,SMC,Cean,Michel-d'Ornano,http://medias.lequipe.fr/logo-football/41/300?LFW0FOX0004800Y-14-46,Patrice GARANDE,3,50
3,Evian Thonon Gaillard Football Club,ETG,Evian,Parc des Sports,http://medias.lequipe.fr/logo-football/1897/300?LFW0FOX0004800Y-14-46,Pascal DUPRAZ,4,50
4,En Avant Guingamp,EAG,Guingamp,Stade du Roudourou,http://medias.lequipe.fr/logo-football/37/300?LFW0FOX0004800Y-14-46,Jocelyn GOURVENNEC,5,50
5,Racing Club de Lens,RCL,Lens,Bollaert-Delelis,http://medias.lequipe.fr/logo-football/9/300?LFW0FOX0004800Y-14-46,Antoine KOMBOUARE,6,50
6,Lille Olympique Sporting Club ,LOSC,Lille,Stade Pierre-Mauroy,http://medias.lequipe.fr/logo-football/43/300?LFW0FOX0004800Y-14-46,René GIRARD,7,50
7,Football Club Lorient-Bretagne Sud,FCL,Lorient,Yves-Allainmat,http://medias.lequipe.fr/logo-football/11/300?LFW0FOX0004800Y-14-46,Sylvain RIPOLL,8,50
8,Olympique Lyonnais,OL,Lyon,Gerland,http://medias.lequipe.fr/logo-football/22/300?LFW0FOX0004800Y-14-46,Hubert FOURNIER,9,50
9,Olympique de Marseille,OM,Marseille,Velodrome,http://medias.lequipe.fr/logo-football/6/300?LFW0FOX0004800Y-14-46,Marcelo BIELSA,10,50
10,Football Club de Metz,FCM,Metz,Saint-Symphorien,http://medias.lequipe.fr/logo-football/20/300?LFW0FOX0004800Y-14-46,Albert CARTIER,11,50
11,Association sportive de Monaco FC,ASM,Monaco,Louis II,http://medias.lequipe.fr/logo-football/25/300?LFW0FOX0004800Y-14-46,Leonardo JARDIM,12,50
12,Montpellier-Herault Sports Club,MHSC,Montpellier,La Mosson,http://medias.lequipe.fr/logo-football/17/300?LFW0FOX0004800Y-14-46,Rolland COURBIS,13,50
13,Football Club de Nantes,FCN,Nantes,La Beaujoire,http://medias.lequipe.fr/logo-football/15/300?LFW0FOX0004800Y-14-46,Michel DER ZAKARIAN,14,50
14,Olympique Gymnaste Club Nice Côte d'Azur,OGCN,Nice,Allianz Riviera,http://medias.lequipe.fr/logo-football/46/300?LFW0FOX0004800Y-14-46,Claude PUEL,15,50
15,Paris-Saint-Germain Football Club,PSG,Paris,Parc des Princes,http://medias.lequipe.fr/logo-football/26/300?LFW0FOX0004800Y-14-46,Laurent BLANC,16,50
16,Stade de Reims,SDR,Reims,Auguste-Delaune,http://medias.lequipe.fr/logo-football/211/300?LFW0FOX0004800Y-14-46,Jean-Luc VASSEUR,17,50
17,Stade Rennais Football Club,SRFC,Rennes,Stade de la Route de Lorient,http://medias.lequipe.fr/logo-football/14/300?LFW0FOX0004800Y-14-46,Philippe MONTANIER,18,50
18,Association Sportive de St-Etienne,ASSE,Saint-Etiennes,Geoffroy-Guichard,http://medias.lequipe.fr/logo-football/38/300?LFW0FOX0004800Y-14-46,Christophe GALTIER,19,50
29,Toulouse Football Club,TFC,Toulouse,Stadium Municipal,http://medias.lequipe.fr/logo-football/12/300?LFW0FOX0004800Y-14-46,Alain CASANOVA,20,50
";
            File.WriteAllText( "cust.csv", csvString );

            // Read into an array of strings.
            string[] source = File.ReadAllLines( "cust.csv" );
            XElement cust = new XElement( "Teams",
                from str in source
                let fields = str.Split( ',' )
                select new XElement( "Team",
                    new XAttribute( "Id", fields[0] ),
                    new XAttribute( "Name", fields[1] ),
                    new XElement( "TeamTag", fields[2] ),
                    new XElement( "Town", fields[3] ),
                    new XElement( "Stadium", fields[4] ),
                    new XElement( "Logo", fields[5] ),
                    new XElement( "Manager", fields[6] ),
                    new XElement( "LeagueRanking", fields[7] ),
                    new XElement( "Level", fields[8] ) ) );
            cust.Save( @"C:\Users\Guenole\Desktop\SimSoccer\Ligue1Teams.xml" );
        }
    }
}