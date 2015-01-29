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
            string csvString = @"0,Sporting Club de Bastia,0,SCB,Bastia,Armand-Cesari,.\..\..\..\images\SCB.png,Ghislain PRINTANT,1,70,500000,4.4.2,
1,Football Club des Girondins de Bordeaux,0,FCB,Bordeaux,Jacques Chaban-Delmas,.\..\..\..\images\FCB.png,Willy SAGNOL,2,72,500000,4.4.2,
2,Stade Malherbe de Caen,0,SMC,Cean,Michel-d'Ornano,.\..\..\..\images\SMC.png,Patrice GARANDE,3,69,500000,5.3.2,
3,Evian Thonon Gaillard Football Club,0,ETG,Evian,Parc des Sports,.\..\..\..\images\ETG.png,Pascal DUPRAZ,4,67,500000,4.4.2,
4,En Avant Guingamp,0,EAG,Guingamp,Stade du Roudourou,.\..\..\..\images\EAG.png,Jocelyn GOURVENNEC,5,70,500000,4.3.3,
5,Racing Club de Lens,0,RCL,Lens,Bollaert-Delelis,.\..\..\..\images\RCL.png,Antoine KOMBOUARE,6,64,500000,4.3.3,
6,Lille Olympique Sporting Club,0,LOSC,Lille,Stade Pierre-Mauroy,.\..\..\..\images\LOSC.png,René GIRARD,7,71,500000,4.3.3,
7,Football Club Lorient-Bretagne Sud,0,FCL,Lorient,Yves-Allainmat,.\..\..\..\images\FCL.png,Sylvain RIPOLL,8,69,500000,4.4.2,
8,Olympique Lyonnais,0,OL,Lyon,Gerland,.\..\..\..\images\OL.png,Hubert FOURNIER,9,78,500000,4.4.2 losange,
9,Olympique de Marseille,0,OM,Marseille,Velodrome,.\..\..\..\images\OM.png,Marcelo BIELSA,10,75,500000,4.3.3,
10,Football Club de Metz,0,FCM,Metz,Saint-Symphorien,.\..\..\..\images\FCM.png,Albert CARTIER,11,68,500000,4.2.3.1,
11,Association sportive de Monaco FC,0,ASM,Monaco,Louis II,.\..\..\..\images\ASM.png,Leonardo JARDIM,12,74,500000,4.3.3,
12,Montpellier-Herault Sports Club,0,MHSC,Montpellier,La Mosson,.\..\..\..\images\MHSC.png,Rolland COURBIS,13,70,500000,4.2.3.1,
13,Football Club de Nantes,0,FCN,Nantes,La Beaujoire,.\..\..\..\images\FCN.png,Michel DER ZAKARIAN,14,71,500000,4.3.3,
14,Olympique Gymnaste Club Nice Côte d'Azur,0,OGCN,Nice,Allianz Riviera,.\..\..\..\images\OGCN.png,Claude PUEL,15,70,500000,4.2.3.1,
15,Paris-Saint-Germain Football Club,0,PSG,Paris,Parc des Princes,.\..\..\..\images\PSG.png,Laurent BLANC,16,80,500000,4.3.3,
16,Stade de Reims,0,SDR,Reims,Auguste-Delaune,.\..\..\..\images\SDR.png,Jean-Luc VASSEUR,17,67,500000,4.2.3.1,
17,Stade Rennais Football Club,0,SRFC,Rennes,Stade de la Route de Lorient,.\..\..\..\images\SRFC.png,Philippe MONTANIER,18,72,500000,4.3.3,
18,Association Sportive de St-Etienne,0,ASSE,Saint-Etiennes,Geoffroy-Guichard,.\..\..\..\images\ASSE.png,Christophe GALTIER,19,75,500000,4.3.3,
29,Toulouse Football Club,0,TFC,Toulouse,Stadium Municipal,.\..\..\..\images\TFC.png,Alain CASANOVA,20,72,500000,5.3.2,
";
            File.WriteAllText( "cust.csv", csvString );

            // Read into an array of strings.
            string[] source = File.ReadAllLines( "cust.csv" );
            XElement cust = new XElement( "Game",
                new XElement( "Teams",
                from str in source
                let fields = str.Split( ',' )
                select new XElement( "Team",
                    new XAttribute( "Id", fields[0] ),
                    new XAttribute( "Name", fields[1] ),
                    new XElement("Points", fields[2]),
                    new XElement( "TeamTag", fields[3] ),
                    new XElement( "Town", fields[4] ),
                    new XElement( "Stadium", fields[5] ),
                    new XElement( "Logo", fields[6] ),
                    new XElement( "Manager", fields[7] ),
                    new XElement( "LeagueRanking", fields[8] ),
                    new XElement( "Level", fields[9] ),
                    new XElement( "Budget", fields[10] ),
                    new XElement( "Formation", fields[11] ) ) ) );
            cust.Save( @".\..\..\..\Ligue1Teams.xml" );
        }
    }
}