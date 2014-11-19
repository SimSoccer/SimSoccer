using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConvertCSVToXML
{
    class Program
    {
        static void Main( string[] args )
        {
            string csvString = @"1,1,Alphonse Aréola,FRA,G,1.90,85,27/02/1993,Paris,Paris St-Germain,Sporting Club de Bastia,50,100,false,100,10000,SCB
2,2,Romain Achilli,FRA,D,1.75,70,15/02/1993,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
3,3,Hervin Ongenda,FRA,F,1.70,64,24/06/1995,Paris,Paris St-Germain,Sporting Club de Bastia,50,100,false,100,10000,SCB
4,4,Florian Marange,FRA,D,1.76,70,03/03/1986,Talence,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
5,5,Sébastien Squillaci,FRA,D,1.84,76,11/08/1980,Toulon,Arsenal,Sporting Club de Bastia,50,100,false,100,10000,SCB
6,6,N'Dri Romaric,CIV,M,1.87,88,04/06/1983,Abidjan,Zaragoza,Sporting Club de Bastia,50,100,false,100,10000,SCB
7,7,Floyd Ayité,TOG,M,1.74,68,15/12/1988,Bordeaux,Reims,Sporting Club de Bastia,50,100,false,100,10000,SCB
8,8,El-Hajdi Ba,FRA,M,1.83,74,05/03/1993,Paris,Sunderland,Sporting Club de Bastia,50,100,false,100,10000,SCB
9,9,Djibril Cissé,FRA,F,1.82,78,12/08/1981,Arles,Kuban Krasnodar,Sporting Club de Bastia,50,100,false,100,10000,SCB
10,10,Ryad Boudebouz,ALG,M,1.72,59,19/02/1990,Colmar,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
11,11,Gadji Celi Junior Tallo,CIV,F,1.87,77,21/12/1992,Ouragahio,Roma,Sporting Club de Bastia,50,100,false,100,10000,SCB
12,12,Christophe Vincent,FRA,M,1.78,72,08/11/1992,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
13,13,Abdoulaye Keita,MLI,M,1.75,75,05/01/1994,Bamako,Centre Salif Keita,Sporting Club de Bastia,50,100,false,100,10000,SCB
14,14,Famoussa Koné,MLI,F,1.75,74,03/05/1994,Bamako,CO Bamako,Sporting Club de Bastia,50,100,false,100,10000,SCB
15,15,Julian Palmieri,FRA,D,1.70,66,17/12/1986,Lyon,Istres,Sporting Club de Bastia,50,100,false,100,10000,SCB
16,16,Jean-Louis Leca,FRA,G,1.77,65,21/09/1985,Bastia,Valenciennes,Sporting Club de Bastia,50,100,false,100,10000,SCB
17,17,Mathieu Peybernes,FRA,D,1.84,80,21/10/1990,Toulouse,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
18,18,Yannick Cahuzac,FRA,M,1.78,66,18/01/1985,Ajaccio,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
19,19,Benjamin Mokulu,BEL,F,1.85,83,11/10/1989,Brussels,Mechelen,Sporting Club de Bastia,50,100,false,100,10000,SCB
20,20,François Modestó,FRA,D,1.83,80,19/08/1978,Bastia,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
21,21,Luka Kikabidze,GEO,M,,,21/01/1995,Tbilisi,Lokomotivi Tbilisi,Sporting Club de Bastia,50,100,false,100,10000,SCB
22,22,Christopher Maboulou,FRA,M,1.85,79,19/03/1990,Montfermeil,Châteauroux,Sporting Club de Bastia,50,100,false,100,10000,SCB
23,23,Drissa Diakité,MLI,D,1.75,69,18/02/1985,Bamako,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
24,24,Joao Rodríguez,COL,F,1.77,69,12/05/1996,Cúcuta,Chelsea,Sporting Club de Bastia,50,100,false,100,10000,SCB
25,25,François Kamano,GUI,F,,,01/05/1996,,Satellite FC,Sporting Club de Bastia,50,100,false,100,10000,SCB
26,26,Brandão,BRA,F,1.89,78,16/06/1980,São Paulo,St-Etienne,Sporting Club de Bastia,50,100,false,100,10000,SCB
27,27,Guillaume Gillet,BEL,M,1.86,77,09/03/1985,Liège,Anderlecht,Sporting Club de Bastia,50,100,false,100,10000,SCB
28,28,Juan Pablo Pino,COL,M,1.76,72,30/03/1987,Cartagena,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
29,29,Gilles Cioni,FRA,D,1.65,65,14/06/1984,Bastia,Paris FC,Sporting Club de Bastia,50,100,false,100,10000,SCB
30,30,Thomas Vincensini,FRA,G,1.90,73,12/09/1993,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
31,1,Ažbe Jug,SVN,G,1.92,91,03/03/1992,Maribor,Interblock,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
32,2,Mariano,BRA,D,1.77,70,23/06/1986,São João,Fluminense,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
33,3,Diego Contento,ITA,D,1.76,70,01/05/1990,Munich,Bayern Munich,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
34,4,Tiago Ilori,POR,D,1.90,80,26/02/1993,Hampstead,Liverpool,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
35,5,Nicolas Pallois,FRA,D,1.90,85,19/09/1987,Elbeuf,Niort,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
36,6,Ludovic Sané,SEN,D,1.92,77,22/03/1987,Villeneuve-sur-Lot,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
37,7,Abdou Traoré,MLI,M,1.79,73,17/01/1988,Bamako,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
38,8,Grégory Sertic,FRA,M,1.81,69,05/08/1989,Brétigny-sur-Orge,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
39,9,Diego Rolán,URU,F,1.78,74,24/03/1993,Montevideo,Defensor Sporting,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
40,10,Henri Saivet,FRA,F,1.73,70,26/10/1990,Dakar,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
41,11,Emiliano Sala,ARG,F,1.87,75,31/10/1990,Cululú,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
42,13,Thomas Touré,FRA,F,1.75,75,27/12/1993,Grasse,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
43,14,Cheikh Diabaté,MLI,F,1.94,84,25/04/1988,Bamako,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
44,15,Younès Kaabouni,FRA,M,1.79,67,23/05/1995,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
45,16,Cédric Carrasso,FRA,G,1.87,87,30/12/1981,Avignon,Toulouse,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
46,17,André Biyogo Poko,GAB,M,1.73,72,01/01/1993,Bitam,US Bitam,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
47,18,Jaroslav Plašil,CZE,M,1.83,72,05/01/1982,Opo?no,Osasuna,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
48,19,Nicolas Maurice-Belay,FRA,M,1.82,76,19/04/1985,Sucy-en-Brie,Sochaux,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
49,20,Jussiê,BRA,F,1.80,76,19/09/1983,Nova Venécia,Lens,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
50,22,Julien Faubert,FRA,D,1.80,75,01/08/1983,Le Havre,Elaz??spor,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
51,24,Wahbi Khazri,TUN,M,1.82,78,08/02/1991,Ajaccio,Bastia,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
52,25,Théo Pellenard,FRA,D,1.82,71,04/03/1994,Lille,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
53,26,Clément Badin,FRA,M,1.68,71,26/05/1993,Bruges,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
54,27,Marc Planus,FRA,D,1.83,76,07/03/1982,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
55,29,Maxime Poundjé,FRA,D,1.79,71,16/08/1992,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
56,30,Jérôme Prior,FRA,G,1.84,88,08/08/1995,Toulon,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
57,1,Rémy Vercoutre,FRA,G,1.85,78,26/06/1980,Grande-Synthe,Lyon,Stade Malherbe de Caen,50,100,false,100,10000,SMC
58,2,Nicolas Seube,FRA,M,1.80,72,11/08/1979,Toulouse,Toulouse,Stade Malherbe de Caen,50,100,false,100,10000,SMC
59,5,Alaeddine Yahia,TUN,D,1.86,81,26/08/1981,Courbevoie,Lens,Stade Malherbe de Caen,50,100,false,100,10000,SMC
61,7,Mathieu Duhamel,FRA,F,1.83,76,12/07/1984,Mont-Saint-Aignan,Metz,Stade Malherbe de Caen,50,100,false,100,10000,SMC
62,9,Sloan Privat,FRA,F,1.86,83,24/07/1989,Cayenne,KAA Gent,Stade Malherbe de Caen,50,100,false,100,10000,SMC
63,10,Lenny Nangis,FRA,F,1.73,65,24/03/1994,Caen,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
64,11,Bengadli-Fodé Koita,FRA,F,1.86,86,21/10/1990,Paris,Montpellier,Stade Malherbe de Caen,50,100,false,100,10000,SMC
65,12,Dennis Appiah,FRA,D,1.79,68,09/06/1992,Toulouse,Monaco,Stade Malherbe de Caen,50,100,false,100,10000,SMC
66,13,Jean-Jacques Pierre,HAI,D,1.80,79,23/01/1981,Leogane,Panionios,Stade Malherbe de Caen,50,100,false,100,10000,SMC
67,15,Emmanuel Imorou,BEN,D,1.81,69,16/09/1988,Bourges,Clermont,Stade Malherbe de Caen,50,100,false,100,10000,SMC
68,16,Damien Perquis,FRA,G,1.84,82,08/03/1986,Saint-Brieuc,Beauvais,Stade Malherbe de Caen,50,100,false,100,10000,SMC
69,17,Ngolo Kanté,FRA,M,1.70,70,29/03/1991,Paris,Boulogne,Stade Malherbe de Caen,50,100,false,100,10000,SMC
70,18,Jordan Adéoti,BEN,M,1.83,77,12/03/1989,L'Union,Laval,Stade Malherbe de Caen,50,100,false,100,10000,SMC
71,19,Felipe Saad,BRA,D,1.87,83,11/09/1983,Santos,Ajaccio,Stade Malherbe de Caen,50,100,false,100,10000,SMC
72,20,Hervé Bazile,FRA,F,1.80,73,18/03/1990,Créteil,Le Poiré-sur-Vie,Stade Malherbe de Caen,50,100,false,100,10000,SMC
73,21,José Saez,FRA,M,1.70,63,07/05/1982,Memin,Valenciennes,Stade Malherbe de Caen,50,100,false,100,10000,SMC
74,22,Alexandre Raineau,FRA,D,1.78,71,21/06/1986,Paris,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
75,23,Jean Calvé,FRA,D,1.83,78,30/04/1984,Cormeilles-en-Parisis,Nancy,Stade Malherbe de Caen,50,100,false,100,10000,SMC
76,24,Florian Raspentino,FRA,F,1.79,73,06/06/1989,Marignane,Marseille,Stade Malherbe de Caen,50,100,false,100,10000,SMC
77,25,Julien Féret,FRA,M,1.87,74,05/07/1982,Saint Brieuc,Rennes,Stade Malherbe de Caen,50,100,false,100,10000,SMC
78,26,Jonathan Beaulieu,FRA,M,1.80,65,11/03/1993,Meudon,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
79,27,Thomas Lemar,FRA,M,1.63,46,12/11/1995,Baie-Mahault,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
80,28,Damien Da Silva,FRA,D,1.84,77,17/05/1988,Talence,Clermont,Stade Malherbe de Caen,50,100,false,100,10000,SMC
81,29,Yrondu Musavu-King,GAB,D,1.86,83,08/01/1992,Libreville,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
82,30,Paul Reulet,FRA,G,1.81,64,14/01/1994,Caen,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
83,1,Johann Durand,FRA,G,1.82,71,17/06/1981,Evian,Gaillard,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
84,2,Kassim Abdallah,FRA,D,1.89,76,09/04/1987,Marseille,Marseille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
85,5,Miloš Ninkovi?,SRB,M,1.80,76,25/12/1984,Belgrade,Crvena Zvezda,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
86,6,Djakaridja Koné,BFA,M,1.83,75,22/07/1986,Abidjan,Dinamo Bucure?ti,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
87,7,Adrien Thomasson,FRA,F,1.82,75,10/12/1993,Bourg-Saint-Maurice,Annecy,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
88,8,Yeltsin Tejeda,CRC,M,1.77,66,17/03/1992,Puerto Limón,Deportivo Saprissa,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
89,9,Gianni Bruno,BEL,F,1.78,64,19/08/1991,Rocourt,Lille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
90,10,Nicolas Benezet,FRA,M,1.72,61,24/02/1991,Montpellier,Nîmes,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
91,11,Fabien Camus,FRA,M,1.79,67,28/02/1985,Arles,KRC Genk,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
92,12,Gaël Givet,FRA,D,1.81,75,09/10/1981,Arles,Arles-Avignon,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
93,14,Cédric Barbosa,FRA,M,1.79,67,06/03/1976,Aubenas,Metz,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
94,17,Aldo Angoula,FRA,D,1.84,82,04/05/1981,Le Havre,Boulogne,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
95,18,Daniel Wass,DEN,D,1.81,74,31/05/1989,Gladsaxe,Benfica,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
96,19,Youssouf Sabaly,FRA,D,1.74,71,05/03/1993,Chesnay,Paris St-Germain,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
97,20,Modou Sougou,SEN,F,1.78,68,18/12/1984,Fissel,Marseille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
98,21,Cédric Mongongu,COD,D,1.89,76,22/06/1989,Kinshasa,Monaco,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
99,22,Cédric Cambon,FRA,D,1.84,76,20/09/1986,Montpellier,Litex Lovech,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
100,23,Nicki Bille Nielsen,DEN,F,1.84,76,07/02/1988,Vigerslev,Rosenborg,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
101,24,Olivier Sorlin,FRA,M,1.82,77,09/04/1979,Saint-Etienne,PAOK,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
102,25,Jonathan Mensah,GHA,D,1.88,75,13/07/1990,Accra,Udinese,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
103,26,Jesper Juelsgaard,DEN,D,1.82,78,26/01/1989,Spjald,FC Midtjylland,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
104,27,Clarck N'Sikulu,FRA,F,1.80,78,10/07/1992,Lille,Lille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
105,28,Najib Baouia,ALG,F,1.65,65,25/02/1992,El Meghaier,None,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
106,30,Jesper Hansen,DEN,G,1.88,78,31/03/1985,Frederikssund,FC Nordsjælland,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
107,1,Jonas Lössl,DEN,G,1.95,89,01/02/1989,Kolding,FC Midtjylland,En Avant Guingamp,50,100,false,100,10000,EAG
108,2,Lars Jacobsen,DEN,D,1.81,75,20/09/1979,Odense,FC København,En Avant Guingamp,50,100,false,100,10000,EAG
109,3,Angoua Brou Benjamin,CIV,D,1.78,69,28/11/1986,Anyama,Valenciennes,En Avant Guingamp,50,100,false,100,10000,EAG
110,4,Baïssama Sankoh,FRA,D,1.80,73,20/03/1992,Nogent-sur-Marne,Sarcelles,En Avant Guingamp,50,100,false,100,10000,EAG
111,5,Moustapha Diallo,SEN,M,1.88,78,14/05/1986,Dakar,ASC Diaraf,En Avant Guingamp,50,100,false,100,10000,EAG
112,6,Maxime Baca,FRA,D,1.71,68,02/06/1983,Corbeil Essonnes,Lorient,En Avant Guingamp,50,100,false,100,10000,EAG
113,7,Dorian Levêque,FRA,D,1.82,72,22/11/1989,Annecy,Boulogne,En Avant Guingamp,50,100,false,100,10000,EAG
114,8,Ronnie Schwartz,DEN,F,1.83,74,29/08/1989,Ulsted,Randers,En Avant Guingamp,50,100,false,100,10000,EAG
115,10,Younousse Sankharé,FRA,M,1.84,76,10/09/1989,Sarcelles,Dijon,En Avant Guingamp,50,100,false,100,10000,EAG
116,12,Claudio Beauvue,FRA,M,1.74,66,16/04/1988,Saint-Claude,Châteauroux,En Avant Guingamp,50,100,false,100,10000,EAG
117,13,Christophe Mandanne,FRA,F,1.71,62,07/02/1985,Toulouse,Dijon,En Avant Guingamp,50,100,false,100,10000,EAG
118,14,Ladislas Douniama,CGO,F,1.63,62,24/05/1986,Brazzaville,Lorient,En Avant Guingamp,50,100,false,100,10000,EAG
119,15,Jérémy Sorbon,FRA,D,1.83,79,05/08/1983,Caen,Caen,En Avant Guingamp,50,100,false,100,10000,EAG
120,16,Hugo Guichard,FRA,G,1.89,77,16/05/1992,Saint-Étienne,Bordeaux,En Avant Guingamp,50,100,false,100,10000,EAG
121,17,Rachid Alioui,FRA,F,1.86,81,18/06/1992,La Rochelle,None,En Avant Guingamp,50,100,false,100,10000,EAG
122,18,Lionel Mathis,FRA,M,1.74,71,04/10/1981,Montreuil-sous-Bois,Sochaux,En Avant Guingamp,50,100,false,100,10000,EAG
123,20,Laurent Dos Santos,FRA,M,1.77,70,21/09/1993,Montmorency,None,En Avant Guingamp,50,100,false,100,10000,EAG
124,21,Sylvain Marveaux,FRA,M,1.72,66,15/04/1986,Vannes,Newcastle U,En Avant Guingamp,50,100,false,100,10000,EAG
125,22,Julien Cardy,FRA,M,1.76,71,29/09/1981,Pau,Arles-Avignon,En Avant Guingamp,50,100,false,100,10000,EAG
126,23,Jérémy Pied,FRA,M,1.73,69,23/02/1989,Grenoble,Nice,En Avant Guingamp,50,100,false,100,10000,EAG
127,24,Sambou Yatabaré,MLI,M,1.90,82,02/03/1989,Beauvais,Olympiakos,En Avant Guingamp,50,100,false,100,10000,EAG
128,25,Reynald Lemaître,FRA,D,1.75,66,28/06/1983,Chambray-lès-Tours,Nancy,En Avant Guingamp,50,100,false,100,10000,EAG
129,26,Thibault Giresse,FRA,M,1.72,68,25/05/1981,Talence,Amiens,En Avant Guingamp,50,100,false,100,10000,EAG
130,29,Christophe Kerbrat,FRA,D,1.83,74,02/08/1986,Brest,Plabennec,En Avant Guingamp,50,100,false,100,10000,EAG
131,30,Mamadou Samassa,MLI,G,1.91,81,16/02/1990,Montreuil,None,En Avant Guingamp,50,100,false,100,10000,EAG
132,1,Rudy Riou,FRA,G,1.85,78,22/01/1980,Grande-Synthe,Nantes,Racing Club de Lens,50,100,false,100,10000,RCL
133,4,Ahmed Kantari,MAR,D,1.85,80,28/06/1985,Blois,Brest,Racing Club de Lens,50,100,false,100,10000,RCL
134,6,Jérôme Lemoigne,FRA,M,1.88,77,15/02/1983,Toulon,Sedan,Racing Club de Lens,50,100,false,100,10000,RCL
135,7,Yoann Touzghar,FRA,F,1.79,75,28/11/1986,Avignon,Amiens,Racing Club de Lens,50,100,false,100,10000,RCL
136,9,Adamo Coulibaly,FRA,F,1.87,81,14/08/1981,Paris,Debrecen,Racing Club de Lens,50,100,false,100,10000,RCL
137,11,Pablo Chavarría,ARG,F,1.82,74,02/01/1988,Las Perdices,Anderlecht,Racing Club de Lens,50,100,false,100,10000,RCL
138,14,Deme N'Diaye,SEN,M,1.83,72,06/02/1985,Dakar,Arles-Avignon,Racing Club de Lens,50,100,false,100,10000,RCL
139,15,Patrick Fradj,FRA,D,1.76,70,11/03/1992,Saint-Saulve,None,Racing Club de Lens,50,100,false,100,10000,RCL
140,18,Pierrick Valdivia,FRA,M,1.85,67,18/04/1988,Bron,Sedan,Racing Club de Lens,50,100,false,100,10000,RCL
141,19,Baptiste Guillaume,FRA,F,1.89,77,16/06/1995,Brussels,None,Racing Club de Lens,50,100,false,100,10000,RCL
142,20,Lalaina Nomenjanahary,MDA,M,1.88,74,16/01/1986,Antananarivo,Avion,Racing Club de Lens,50,100,false,100,10000,RCL
143,21,Alharbi El Jadeyaoui,FRA,M,1.75,68,08/08/1986,Strasbourg,Angers,Racing Club de Lens,50,100,false,100,10000,RCL
144,22,Loïck Landré,FRA,D,1.82,75,05/05/1992,Aubervilliers,Paris St-Germain,Racing Club de Lens,50,100,false,100,10000,RCL
145,23,Wylan Cyprien,FRA,M,1.80,75,28/01/1995,Pointe-à-Pitre,None,Racing Club de Lens,50,100,false,100,10000,RCL
146,24,Ludovic Baal,FRA,D,1.76,72,24/05/1986,Paris,Le Mans,Racing Club de Lens,50,100,false,100,10000,RCL
147,25,Jean-Philippe Gbamin,FRA,D,1.86,83,25/05/1995,San-Pédro,None,Racing Club de Lens,50,100,false,100,10000,RCL
148,27,Benjamin Boulenger,FRA,D,1.88,80,01/03/1990,Maubeuge,Boulogne,Racing Club de Lens,50,100,false,100,10000,RCL
149,29,Benjamin Bourigeaud,FRA,M,1.78,71,14/01/1994,Calais,None,Racing Club de Lens,50,100,false,100,10000,RCL
150,1,Vincent Enyeama,NGA,G,1.80,80,29/08/1982,Aba,Maccabi Tel Aviv,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
151,2,Sébastien Corchia,FRA,D,1.74,65,01/11/1990,Noisy-le-Sec,Sochaux,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
152,4,Florent Balmont,FRA,M,1.68,71,02/02/1980,Sainte-Foy-les-Lyon,Nice,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
153,5,Idrissa Gueye,SEN,M,1.74,64,26/09/1989,Dakar,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
154,6,Jonathan Delaplace,FRA,M,1.67,60,20/03/1986,La Seyne-sur-Mer,Zulte-Waregem,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
155,9,Ronny Rodelin,FRA,F,1.92,70,18/11/1989,Saint-Denis de La Réunion,Nantes,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
156,10,Marvin Martin,FRA,M,1.71,63,10/06/1988,Paris,Sochaux,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
157,11,Michael Frey,SUI,F,1.78,72,19/07/1994,,Young Boys,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
158,12,Souahilo Meïté,FRA,M,1.87,80,17/03/1994,Paris,Auxerre,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
159,13,Adama Soumaoro,CIV,D,1.87,75,18/06/1992,Fontenay-aux-Roses,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
160,14,Simon Kjær,DEN,D,1.89,82,26/03/1989,Horsens,Wolfsburg,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
161,15,Djibril Sidibé,FRA,D,1.82,73,29/07/1992,Troyes,Troyes,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
162,16,Steeve Elana,FRA,G,1.87,85,11/07/1980,Marseille,Brest,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
163,17,Marcos Lopes,POR,M,1.74,68,28/12/1995,Belém,Manchester C,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
164,18,Franck Béria,FRA,D,1.77,75,23/05/1983,Argenteuil,Metz,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
165,20,Ryan Mendes,CPV,F,1.75,77,08/01/1990,Mindelo,Le Havre,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
166,22,David Rozehnal,CZE,D,1.93,77,05/07/1980,Šternberk,Hamburg,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
167,23,Pape N'Diaye Souaré,SEN,D,1.78,68,06/06/1990,Mbao,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
168,24,Rio Antonio Mavuba,FRA,M,1.72,70,08/03/1984,Born At Sea,Villarreal,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
169,25,Marko Baša,SRB,D,1.90,79,29/12/1982,Trstenik,Lokomotiv Moscow,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
170,26,Nolan Roux,FRA,F,1.82,75,01/03/1988,Compiègne,Brest,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
171,27,Divock Origi,BEL,F,1.85,75,18/04/1995,Ostend,Liverpool,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
172,30,Jean Butez,FRA,G,1.88,75,08/06/1995,Lille,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
173,2,Lamine Koné,FRA,D,1.86,83,01/02/1989,Paris,Châteauroux,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
174,3,Pedrinho,POR,D,1.77,73,06/03/1985,Vila do Conde,Académica,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
175,4,Vincent Le Goff,FRA,D,1.75,64,15/10/1989,Quimper,Istres,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
176,5,Mehdi Mostefa Sbaa,ALG,M,1.81,82,30/08/1983,Dijon,Ajaccio,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
177,6,François Bellugou,FRA,D,1.86,70,25/04/1987,Prades,Nancy,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
178,7,Sadio Diallo,GUI,F,1.82,75,28/12/1990,Conakry,Rennes,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
179,8,Yann Jouffre,FRA,M,1.75,65,23/07/1984,Montélimar,Guingamp,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
180,9,Jordan Ayew,GHA,F,1.82,81,11/09/1991,Marseille,Marseille,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
181,10,Mathieu Coutadeur,FRA,M,1.70,69,20/06/1986,Le Mans,Monaco,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
182,12,Pierre Lavenant,FRA,M,1.80,74,03/08/1995,Saint-Malo,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
183,13,Rafidine Abdullah,FRA,M,1.79,75,15/01/1994,Marseille,Marseille,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
184,14,Raphaël Guerreiro,FRA,D,1.70,67,22/12/1993,Le Blanc-Mesnil,Caen,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
185,15,Fabien Robert,FRA,F,1.74,67,06/01/1989,Hennebont,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
186,16,Fabien Audard,FRA,G,1.88,89,28/03/1978,Toulouse,Bastia,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
187,17,Walid Mesloub,ALG,M,1.80,69,04/09/1985,Trappes,Le Havre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
188,18,Gilles Sunu,FRA,M,1.80,70,30/03/1991,Châteauroux,Arsenal,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
189,19,Bryan Pelé,FRA,M,1.69,65,25/03/1992,Ploërmel,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
190,20,Julien Quercia,FRA,F,1.68,65,17/08/1986,Thionville,Auxerre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
191,21,Alain Traoré,BFA,M,1.76,66,31/12/1988,Bobo-Dioulasso,Auxerre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
192,22,Benjamin Jeannot,FRA,F,1.81,73,22/01/1992,Laxou,Nancy,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
193,23,Mathias Autret,FRA,M,1.79,64,01/03/1991,Morlaix,Brest,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
194,24,Wesley Lautoa,FRA,D,1.72,65,25/08/1987,Épernay,Sedan,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
195,25,Lamine Gassama,SEN,D,1.81,74,20/10/1989,Marseille,Lyon,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
196,26,Yohann Wachter,FRA,D,1.77,65,07/04/1992,Courbevoie,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
197,27,Enzo Reale,FRA,M,1.75,69,07/10/1991,Venissieux,Lyon,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
198,28,Maxime Barthelme,FRA,M,1.77,65,08/09/1988,Sartrouville,Racing Club de France,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
199,29,Cheick Touré,CIV,D,1.85,86,16/12/1992,Koukourandoumi,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
200,30,Florent Chaigneau,FRA,G,1.97,94,21/03/1984,La Roche-sur-Yon,Le Poiré-sur-Vie,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
201,31,Valentin Lavigne,FRA,F,1.71,72,04/06/1994,Lorient,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
202,1,Anthony Lopes,POR,G,1.84,81,01/10/1990,Givors,None,Olympique Lyonnais,50,100,false,100,10000,OL
203,2,Mehdi Zeffane,FRA,D,1.74,63,19/05/1992,Sainte-Foy-lès-Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
204,3,Henri Bedimo Nsame,CMR,D,1.80,80,04/06/1984,Douala,Montpellier,Olympique Lyonnais,50,100,false,100,10000,OL
205,4,Bakari Koné,BFA,D,1.88,80,27/04/1988,Ouagadougou,Guingamp,Olympique Lyonnais,50,100,false,100,10000,OL
206,5,Milan Biševac,SRB,D,1.85,83,31/08/1983,Mitrovica,Paris St-Germain,Olympique Lyonnais,50,100,false,100,10000,OL
207,6,Gueïda Fofana,FRA,M,1.82,74,16/05/1991,Le Havre,Le Havre,Olympique Lyonnais,50,100,false,100,10000,OL
208,7,Clément Grenier,FRA,M,1.86,72,07/01/1991,Annonay,None,Olympique Lyonnais,50,100,false,100,10000,OL
209,8,Yoann Gourcuff,FRA,M,1.85,79,11/07/1986,Lorient,Bordeaux,Olympique Lyonnais,50,100,false,100,10000,OL
210,10,Alexandre Lacazette,FRA,F,1.74,69,28/05/1991,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
211,11,Rachid Ghezzal,FRA,M,1.82,65,09/05/1992,Décines-Charpieu,None,Olympique Lyonnais,50,100,false,100,10000,OL
212,12,Jordan Ferri,FRA,M,1.72,70,12/03/1992,Cavaillon,None,Olympique Lyonnais,50,100,false,100,10000,OL
213,13,Christophe Jallet,FRA,D,1.78,65,31/10/1983,Cognac,Paris St-Germain,Olympique Lyonnais,50,100,false,100,10000,OL
214,14,Mouhamadou Dabo,SEN,D,1.76,67,28/11/1986,Dakar,Sevilla,Olympique Lyonnais,50,100,false,100,10000,OL
215,16,Jérémy Frick,SUI,G,1.92,88,08/03/1993,Geneva,Genève-Servette-Carouge,Olympique Lyonnais,50,100,false,100,10000,OL
216,17,Steed Malbranque,FRA,M,1.72,73,06/01/1980,Mouscron,St-Etienne,Olympique Lyonnais,50,100,false,100,10000,OL
217,18,Nabil Fekir,FRA,M,1.73,72,18/07/1993,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
218,19,Mohamed Yattara,GUI,F,1.85,76,28/07/1993,Conakry,None,Olympique Lyonnais,50,100,false,100,10000,OL
219,20,Clinton N'Jie,CMR,F,1.75,68,15/08/1993,Douala,None,Olympique Lyonnais,50,100,false,100,10000,OL
220,21,Maxime Gonalons,FRA,M,1.87,76,10/03/1989,Vénissieux,None,Olympique Lyonnais,50,100,false,100,10000,OL
221,22,Lindsay Rose,FRA,D,1.84,79,08/02/1992,Rennes,Valenciennes,Olympique Lyonnais,50,100,false,100,10000,OL
222,23,Samuel Umtiti,FRA,D,1.81,75,14/11/1993,Yaoundé,None,Olympique Lyonnais,50,100,false,100,10000,OL
223,24,Corentin Tolisso,FRA,M,1.65,54,03/08/1994,Tarare,None,Olympique Lyonnais,50,100,false,100,10000,OL
224,25,Yassine Benzia,FRA,F,1.79,71,08/09/1994,Saint-Aubin Lès-Elbeuf,None,Olympique Lyonnais,50,100,false,100,10000,OL
225,26,Gaël Danic,FRA,M,1.76,65,19/11/1981,Vannes,Valenciennes,Olympique Lyonnais,50,100,false,100,10000,OL
226,28,Arnold Mvuemba,FRA,M,1.72,67,28/01/1985,Alencon,Lorient,Olympique Lyonnais,50,100,false,100,10000,OL
227,29,Fares Bahlouli,FRA,M,1.81,78,08/04/1995,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
228,30,Mathieu Gorgelin,FRA,G,1.87,83,05/08/1990,Ambérieu-en-Bugey,None,Olympique Lyonnais,50,100,false,100,10000,OL
229,3,Nicolas Nkoulou,CMR,D,1.80,77,27/03/1990,Yaoundé,Monaco,Olympique de Marseille,50,100,false,100,10000,OM
230,4,Dória,BRA,D,1.88,82,08/11/1994,São Gonçalo,Botafogo,Olympique de Marseille,50,100,false,100,10000,OM
231,5,Stéphane Sparagna,FRA,D,1.86,82,17/02/1995,Marseille,None,Olympique de Marseille,50,100,false,100,10000,OM
232,6,Momar Bangoura,FRA,M,1.76,65,24/02/1994,Dakar,None,Olympique de Marseille,50,100,false,100,10000,OM
233,7,Benoît Cheyrou,FRA,M,1.82,78,03/05/1981,Suresnes,Auxerre,Olympique de Marseille,50,100,false,100,10000,OM
234,8,Mario Lemina,FRA,M,1.84,76,01/09/1993,Libreville,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
235,9,André-Pierre Gignac,FRA,F,1.87,84,12/05/1985,Martigues,Toulouse,Olympique de Marseille,50,100,false,100,10000,OM
236,10,André Ayew,GHA,F,1.76,72,17/12/1989,Seclin,None,Olympique de Marseille,50,100,false,100,10000,OM
237,11,Romain Alessandrini,FRA,M,1.66,60,03/04/1989,Marseille,Rennes,Olympique de Marseille,50,100,false,100,10000,OM
238,14,Florian Thauvin,FRA,M,1.79,70,26/01/1993,Orléans,Lille,Olympique de Marseille,50,100,false,100,10000,OM
239,15,Jérémy Morel,FRA,D,1.72,71,02/04/1984,Lorient,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
240,16,Brice Samba,CGO,G,1.86,79,25/04/1994,Linzolo,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
241,17,Dimitri Payet,FRA,F,1.74,70,29/03/1987,St-Pierre de la Réunion,Lille,Olympique de Marseille,50,100,false,100,10000,OM
242,20,Alaixys Romao,TOG,M,1.80,74,18/01/1984,L'Hay-les-Roses,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
243,22,Michy Batshuayi,BEL,F,1.80,78,02/10/1993,Brussels,Standard Liège,Olympique de Marseille,50,100,false,100,10000,OM
244,23,Benjamin Mendy,FRA,D,1.80,72,17/07/1994,Longjumeau,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
245,24,Rod Fanni,FRA,D,1.86,78,06/12/1981,Martigues,Rennes,Olympique de Marseille,50,100,false,100,10000,OM
246,25,Gianelli Imbula,CGO,M,1.83,77,12/09/1992,Vilvoorde,Guingamp,Olympique de Marseille,50,100,false,100,10000,OM
247,26,Brice Dja Djedje,CIV,D,1.76,70,23/12/1990,Abidjan,Évian TG,Olympique de Marseille,50,100,false,100,10000,OM
248,27,Abdelaziz Barrada,MAR,M,1.79,73,19/06/1989,Provins,Al-Jazira,Olympique de Marseille,50,100,false,100,10000,OM
249,29,Jérémie Porsan-Clemente,FRA,F,1.78,73,16/12/1997,Schœlcher,None,Olympique de Marseille,50,100,false,100,10000,OM
250,30,Steve Mandanda,FRA,G,1.85,82,28/03/1985,Kinshasa,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
251,1,Johann Carrasso,FRA,G,1.85,79,07/05/1988,Avignon,Rennes,Football Club de Metz,50,100,false,100,10000,FCM
252,3,Jonathan Rivierez,FRA,D,1.81,79,18/05/1989,Le Blanc-Mesnil,Le Havre,Football Club de Metz,50,100,false,100,10000,FCM
253,4,Sylvain Marchal,FRA,D,1.84,80,10/02/1980,Langres,Bastia,Football Club de Metz,50,100,false,100,10000,FCM
254,5,Guido Milan,ARG,D,1.94,93,03/07/1987,Haedo,Atlanta,Football Club de Metz,50,100,false,100,10000,FCM
255,7,Romain Rocchi,FRA,M,1.83,75,02/10/1981,Cavaillon,Arles-Avignon,Football Club de Metz,50,100,false,100,10000,FCM
256,8,Cheick Doukouré,FRA,M,1.80,72,11/09/1992,Abidjan,Lorient,Football Club de Metz,50,100,false,100,10000,FCM
257,9,Juan Manuel Falcón,VEN,F,1.79,81,24/02/1989, Acarigua,Zamora,Football Club de Metz,50,100,false,100,10000,FCM
258,10,Bouna Sarr,FRA,M,1.77,65,31/01/1992,Lyon,None,Football Club de Metz,50,100,false,100,10000,FCM
259,11,Federico Andrada,ARG,F,1.79,74,03/03/1994,Carapachay,River Plate,Football Club de Metz,50,100,false,100,10000,FCM
260,12,Kwamé Nsor,GHA,F,1.88,76,01/08/1992,Accra,Kaiserslautern,Football Club de Metz,50,100,false,100,10000,FCM
261,13,Florent Malouda,FRA,M,1.81,73,13/06/1980,Cayenne,Trabzonspor,Football Club de Metz,50,100,false,100,10000,FCM
262,14,Fadil Sido,BFA,M,1.70,65,13/04/1993,Ouagadougou,Le Mans,Football Club de Metz,50,100,false,100,10000,FCM
263,15,Romain Métanire,FRA,D,1.78,72,28/03/1990,Metz,None,Football Club de Metz,50,100,false,100,10000,FCM
264,16,Anthony Mfa Mezui,GAB,G,1.82,91,07/03/1991,Beauvais,None,Football Club de Metz,50,100,false,100,10000,FCM
265,17,Maxwel Cornet,FRA,F,1.79,69,27/09/1996,Bregbo,None,Football Club de Metz,50,100,false,100,10000,FCM
266,18,Jérémy Choplin,FRA,D,1.83,70,09/02/1985,Le Mans,Bastia,Football Club de Metz,50,100,false,100,10000,FCM
267,19,Thibaut Vion,FRA,F,1.85,68,11/12/1993,Mont-Saint-Martin,FC Porto,Football Club de Metz,50,100,false,100,10000,FCM
268,20,Modibo Maïga,MLI,F,1.85,76,03/09/1986,Bamako,West Ham U,Football Club de Metz,50,100,false,100,10000,FCM
269,21,Ahmed Kashi,FRA,M,1.78,76,18/11/1988,Aubervilliers,Châteauroux,Football Club de Metz,50,100,false,100,10000,FCM
270,22,Kévin Lejeune,FRA,M,1.81,76,22/01/1985,Cambrai,Tours,Football Club de Metz,50,100,false,100,10000,FCM
271,23,Yeni Atito Ngbakoto,FRA,M,1.72,71,23/01/1992,Croix,None,Football Club de Metz,50,100,false,100,10000,FCM
272,24,Gaétan Bussmann,FRA,D,1.84,75,02/02/1991,Épinal,None,Football Club de Metz,50,100,false,100,10000,FCM
273,25,Guirane N'Daw,SEN,M,1.89,79,24/04/1984,Rufisque,Asteras Tripolis,Football Club de Metz,50,100,false,100,10000,FCM
274,26,Chris Philipps,LUX,D,1.82,72,08/03/1994,Wiltz,None,Football Club de Metz,50,100,false,100,10000,FCM
275,27,José Luis Palomino,ARG,D,1.86,87,05/01/1990,San Miguel de Tucumán,Argentinos Juniors,Football Club de Metz,50,100,false,100,10000,FCM
276,28,Mayoro N'Doye-Baye,SEN,M,1.76,67,18/12/1991,Mbao,None,Football Club de Metz,50,100,false,100,10000,FCM
277,29,Sergey Krivets,BLR,M,1.77,77,08/06/1986,Grodno,BATE,Football Club de Metz,50,100,false,100,10000,FCM
278,30,David Oberhauser,FRA,G,1.83,75,29/11/1989,Bitche,UTA Arad,Football Club de Metz,50,100,false,100,10000,FCM
279,1,Danijel Subaši?,CRO,G,1.92,84,27/10/1984,Zadar,Hajduk Split,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
280,2,Fabinho,BRA,D,1.87,78,23/10/1993,Campinas,Rio Ave,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
281,3,Layvin Kurzawa,FRA,D,1.81,73,04/09/1992,Fréjuis,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
282,4,Borja López,ESP,D,1.92,83,02/02/1994,Gijón,Sporting Gijón,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
283,5,Aymen Abdennour,TUN,D,1.87,84,06/08/1989,Sousse,Toulouse,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
284,6,Ricardo Carvalho,POR,D,1.83,76,18/05/1978,Amarante,Real Madrid,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
285,7,Nabil Dirar,MAR,M,1.82,79,25/02/1986,Casablanca,Club Brugge,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
286,8,João Moutinho,POR,M,1.70,61,08/09/1986,Portimão,FC Porto,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
287,10,Dimitar Berbatov,BUL,F,1.88,79,30/01/1981,Blagoevgrad,Fulham,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
288,11,Lucas Ocampos,ARG,M,1.87,82,11/07/1994,Quilmes,River Plate,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
289,13,Wallace,BRA,D,1.91,78,14/10/1994,Rio de Janeiro,Sporting Braga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
290,14,Tiemoué Bakayoko,FRA,M,1.85,77,17/08/1994,Paris,Rennes,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
291,15,Bernardo Silva,POR,M,1.73,62,10/08/1994,Lisbon,Benfica,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
292,16,Maarten Stekelenburg,NED,G,1.97,92,22/09/1982,Haarlem,Fulham,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
293,17,Yannick Ferreira Carrasco,BEL,M,1.80,67,04/09/1993,Elsene,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
294,18,Valère Germain,FRA,F,1.81,75,17/04/1990,Marseille,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
295,19,Lacina Traoré,CIV,F,1.86,75,20/08/1990,Abidjan,Anzhi Makhachkala,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
296,21,Elderson Uwa Echiejile,NGA,D,1.84,76,20/01/1988,Cotonou,Sporting Braga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
297,22,Geoffrey Kondogbia,FRA,M,1.83,71,25/04/1993,Saint-Denis,Sevilla,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
298,23,Anthony Martial,FRA,F,1.81,76,05/12/1995,Massy,Lyon,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
299,24,Andrea Raggi,ITA,D,1.87,82,24/06/1984,Carrara,Bologna,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
300,28,Jérémy Toulalan,FRA,M,1.83,77,10/09/1983,Nantes,Málaga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
301,29,Dylan Bahamboula,FRA,M,1.85,65,22/05/1995,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
302,30,Seydou Sy,SEN,G,1.92,80,12/12/1995,Dakar,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
303,34,Abdou Diallo,FRA,D,1.83,72,04/05/1996,Tours,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
304,37,Aboud Aziz Thiam,FRA,M,1.80,62,15/01/1997,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
305,38,Almary Touré,MLI,D,1.82,72,28/04/1996,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
306,40,Marc-Aurèle Caillard,FRA,G,1.91,79,12/05/1994,Melun,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
307,1,Laurent Pionnier,FRA,G,1.84,76,24/05/1982,Bagnois sur Cèze,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
308,3,Daniel Congré,FRA,D,1.84,79,05/04/1985,Toulouse,Toulouse,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
309,4,Hilton,BRA,D,1.82,73,13/09/1977,Brasilia,Marseille,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
310,5,Siaka Tiéné,CIV,D,1.76,72,22/02/1982,Abidjan,Paris St-Germain,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
311,6,Joris Marveaux,FRA,M,1.78,69,15/08/1982,Vannes,Clermont,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
312,7,Anthony Mounier,FRA,F,1.74,65,27/09/1987,Aubenas,Nice,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
313,8,Jonas Martin,FRA,M,1.82,70,09/04/1990,Besançon,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
314,9,Kévin Bérigaud,FRA,F,1.78,69,03/03/1984,Thonon-les-Bains,Évian TG,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
315,10,Lucas Barrios,PAR,F,1.87,87,13/11/1984,San Fernando,Spartak Moscow,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
316,11,Victor Hugo Montaño,COL,F,1.77,76,01/05/1984,Cali,Rennes,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
317,13,Dylan Gissi,SUI,D,1.92,79,27/04/1991,Geneva,Olimpo (BB),Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
318,14,Bryan Dabo,FRA,M,1.85,75,18/02/1992,Marseille,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
319,16,Geoffrey Jourdren,FRA,G,1.81,73,04/02/1986,Paris,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
320,17,Paul Lasne,FRA,M,1.83,72,16/01/1989,Saint-Cloud,Ajaccio,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
321,18,Karim Aït-Fana,MAR,F,1.75,65,25/02/1989,Limoges,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
322,19,Souleymane Camara,SEN,F,1.74,72,22/12/1982,Dakar,Nice,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
323,20,Morgan Sanson,FRA,M,1.82,70,18/08/1994,Saint-Doulchard,Le Mans,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
324,21,Abdelhamid El Kaoutari,MAR,D,1.80,73,17/03/1990,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
325,23,Jamel Saihi,TUN,M,1.81,73,27/01/1987,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
326,24,Jean Deza,PER,F,1.81,71,09/06/1993,Callao,Universidad San Martín,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
327,25,Mathieu Deplagne,FRA,D,1.80,66,01/10/1991,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
328,26,Yassine Jebbour,MAR,D,1.80,70,24/08/1991,Poitiers,Rennes,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
329,27,Steve Mounié,BEN,F,1.90,80,29/09/1994,Parakou,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
330,28,Djamel Bakar,FRA,F,1.71,67,06/04/1989,Marseille,Nancy,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
331,29,Gianni Seraf,FRA,M,1.69,65,05/07/1994,Thiais,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
332,30,Jonathan Ligali,FRA,G,1.83,82,28/05/1991,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
333,31,Quentin Cornette,FRA,F,1.72,75,17/01/1994,La Ciotat,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
334,32,Nicolas Saint-Ruf,FRA,D,1.87,81,24/10/1992,Rouen,Lens,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
335,1,Rémy Riou,FRA,G,1.91,81,06/08/1987,Lyon,Toulouse,Football Club de Nantes,50,100,false,100,10000,FCN
336,2,Kian Hansen,DEN,D,1.84,74,03/03/1989,Grindsted,Esbjerg,Football Club de Nantes,50,100,false,100,10000,FCN
337,3,Papy Mison Djilobodji,SEN,D,1.93,82,01/12/1988,Kaolack,Sénart-Moissy,Football Club de Nantes,50,100,false,100,10000,FCN
338,4,Oswaldo Vizcarrondo,VEN,D,1.91,86,31/05/1984,Caracas,América,Football Club de Nantes,50,100,false,100,10000,FCN
339,5,Olivier Veigneau,FRA,D,1.74,69,16/07/1985,Suresnes,Duisburg,Football Club de Nantes,50,100,false,100,10000,FCN
340,6,Rémi Gomis,SEN,M,1.80,64,14/02/1984,Versailles,Levante,Football Club de Nantes,50,100,false,100,10000,FCN
341,7,Alejandro Bedoya,USA,M,1.78,73,29/04/1987,Weston,Helsingborgs IF,Football Club de Nantes,50,100,false,100,10000,FCN
342,8,Vincent Bessat,FRA,M,1.78,73,08/11/1985,Lyon,Boulogne,Football Club de Nantes,50,100,false,100,10000,FCN
343,9,Itay Shechter,ISR,F,1.80,77,22/02/1987,Ramat Yishai,Hapoel Tel Aviv,Football Club de Nantes,50,100,false,100,10000,FCN
344,10,Fernando Aristeguieta,VEN,F,1.87,80,09/04/1992,Caracas,Caracas,Football Club de Nantes,50,100,false,100,10000,FCN
345,11,Ismaël Bangoura,GUI,F,1.74,72,02/01/1985,Conakry,Al-Nasr [UAE],Football Club de Nantes,50,100,false,100,10000,FCN
346,12,Birama Touré,MLI,M,1.83,75,06/06/1992,Kayes,Beauvais,Football Club de Nantes,50,100,false,100,10000,FCN
347,13,Serge Gakpé,TOG,M,1.77,79,07/05/1987,Bondy,Monaco,Football Club de Nantes,50,100,false,100,10000,FCN
348,14,Georges-Kevin Nkoudou,FRA,M,1.73,68,13/02/1995,Versailles,None,Football Club de Nantes,50,100,false,100,10000,FCN
349,15,Léo Dubois,FRA,D,1.78,65,14/09/1994,Segré,None,Football Club de Nantes,50,100,false,100,10000,FCN
350,16,Erwin Zelazny,FRA,G,1.86,80,22/09/1991,Grande-Synthe,None,Football Club de Nantes,50,100,false,100,10000,FCN
351,18,Lucas Deaux,FRA,M,1.86,77,26/12/1988,Reims,Reims,Football Club de Nantes,50,100,false,100,10000,FCN
352,19,Abdoulaye Touré,FRA,M,1.87,77,03/03/1994,Nantes,None,Football Club de Nantes,50,100,false,100,10000,FCN
353,20,Amine Oudrhiri,FRA,M,1.84,75,04/11/1992,Ermont,Red Star 93,Football Club de Nantes,50,100,false,100,10000,FCN
354,21,Johan Audel,FRA,F,1.80,73,12/12/1983,Nice,Stuttgart,Football Club de Nantes,50,100,false,100,10000,FCN
355,22,Issa Cissokho,FRA,D,1.73,73,23/02/1985,Paris,Carquefou,Football Club de Nantes,50,100,false,100,10000,FCN
356,23,Yacine Bammou,FRA,F,1.88,78,11/09/1991,Paris,Évry,Football Club de Nantes,50,100,false,100,10000,FCN
357,24,Chaker Alhadhur,COM,D,1.71,56,04/12/1991,Nantes,None,Football Club de Nantes,50,100,false,100,10000,FCN
358,25,Jordan Veretout,FRA,M,1.76,66,01/03/1993,Ancenis,None,Football Club de Nantes,50,100,false,100,10000,FCN
359,26,Koffi Djidji,FRA,D,1.84,71,30/11/1992,Bagnolet,None,Football Club de Nantes,50,100,false,100,10000,FCN
360,28,Valentin Rongier,FRA,M,1.72,66,07/12/1994,Mâcon,None,Football Club de Nantes,50,100,false,100,10000,FCN
361,30,Maxime Dupé,FRA,G,1.86,85,04/03/1993,Malestroit,None,Football Club de Nantes,50,100,false,100,10000,FCN
362,1,Mouez Hassan,FRA,G,1.85,74,05/03/1995,Fréjus,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
363,3,Carlos Eduardo,BRA,M,1.83,72,17/10/1989,Sorocaba,FC Porto,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
364,5,Kevin Gomis,FRA,D,1.86,85,20/01/1989,Paris,Naval,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
365,6,Didier Digard,FRA,M,1.83,76,12/07/1986,Gisors,Middlesbrough,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
366,7,Julien Vercauteren,BEL,M,1.70,66,12/01/1993,Sint-Agatha-Berchem,Lierse,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
367,8,Mahamane Traoré,MLI,M,1.76,66,31/08/1988,Bamako,CO Bamako,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
368,9,Xavier Pentecôte,FRA,F,1.80,77,13/08/1986,St Dié,Toulouse,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
369,10,Valentin Eysseric,FRA,M,1.81,73,25/03/1992,Aix-en-Provence,Monaco,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
370,11,Eric Bauthéac,FRA,M,1.65,65,24/08/1987,Bagnols-sur-Cèze,Dijon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
371,12,Darío Cvitanich,ARG,F,1.75,67,16/05/1984,Baradero,Ajax,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
372,13,Niklas Hult,SWE,M,1.73,65,13/02/1990,Värnamo,IF Elfsborg,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
373,14,Alassane Pléa,FRA,M,1.80,72,10/03/1993,Lille,Lyon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
374,15,Grégoire Puel,FRA,D,1.80,67,20/02/1992,Nice,Lyon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
375,16,Simon Pouplin,FRA,G,1.87,79,28/05/1985,Cholet,Sochaux,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
376,18,Neal Maupay,FRA,F,1.71,69,14/08/1996,Versailles,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
377,19,Jordan Amavi,FRA,D,1.76,70,09/03/1994,Toulon,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
378,20,Souleymane Diawara,SEN,D,1.87,88,24/12/1978,Gabou,Marseille,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
379,21,Lloyd Palun,GAB,D,1.84,73,28/11/1988,Arles,Trinité FC,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
380,22,Nampalys Mendy,FRA,M,1.68,68,23/06/1992,La Seyne-sur-Mer,Monaco,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
381,23,Alexy Bosetti,FRA,F,1.72,66,23/04/1993,Nice,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
382,24,Mathieu Bodmer,FRA,D,1.90,91,22/11/1982,Evreux,Paris St-Germain,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
383,25,Romain Genevois,HAI,D,1.80,66,28/10/1987,L'Estère,Tours,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
384,27,Bryan Constant,FRA,F,1.72,65,27/03/1994,Fréjus,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
385,28,Fabien Dao Castellana,FRA,M,1.69,61,28/07/1993,Saint-Raphaël,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
386,30,Joris Delle,FRA,G,1.90,84,29/03/1990,Briey,Metz,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
387,31,Moussa M'Bow,SEN,D,1.92,80,07/02/1992,Gwediawayé,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
388,1,Nicolas Douchez,FRA,G,1.85,77,22/04/1980,Rasny-sous-Bois,Rennes,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
389,2,Thiago Silva,BRA,D,1.83,79,22/09/1984,Rio de Janeiro,Milan,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
390,4,Yohan Cabaye,FRA,M,1.75,72,14/01/1986,Tourcoing,Newcastle U,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
391,5,Marquinhos,BRA,D,1.81,67,14/05/1994,São Paulo,Roma,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
392,6,Zoumana Camara,FRA,D,1.82,76,03/04/1979,Colombes,St-Etienne,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
393,7,Lucas,BRA,M,1.72,66,13/08/1992,São Paulo,São Paulo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
394,8,Thiago Motta,ITA,M,1.88,77,28/08/1982,São Bernardo do Campo,Internazionale,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
395,9,Edinson Cavani,URU,F,1.84,71,14/02/1987,Montevideo,Napoli,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
396,10,Zlatan Ibrahimovi?,SWE,F,1.92,84,03/10/1981,Malmö,Milan,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
397,14,Blaise Matuidi,FRA,M,1.75,70,09/04/1987,Toulouse,St-Etienne,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
398,15,Jean-Christophe Bahebeck,FRA,F,1.82,70,01/05/1993,Saint-Denis,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
399,16,Mike Maignan,FRA,G,1.87,80,03/07/1995,Cayenne,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
400,17,Maxwell,BRA,D,1.75,73,27/08/1981,Vila Velha,Barcelona,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
401,19,Serge Aurier,CIV,D,1.75,75,24/12/1992,Abidjan,Toulouse,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
402,20,Clément Chantôme,FRA,M,1.80,71,11/09/1987,Sens,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
403,21,Lucas Digne,FRA,D,1.84,75,20/07/1993,Meaux,Lille,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
404,22,Ezequiel Lavezzi,ARG,F,1.73,75,03/05/1985,Villa Gobernador Gálvez,Napoli,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
405,23,Gregory van der Wiel,NED,D,1.81,68,03/02/1988,Amsterdam,Ajax,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
406,24,Marco Verratti,ITA,M,1.65,60,05/11/1992,Pescara,Pescara,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
407,25,Adrien Rabiot,FRA,M,1.88,71,03/04/1995,Saint-Maurice,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
408,27,Javier Pastore,ARG,M,1.87,75,20/06/1989,Córdoba,Palermo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
409,30,Salvatore Sirigu,ITA,G,1.90,80,12/01/1987,Nuoro,Palermo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
410,32,David Luiz,BRA,D,1.89,84,22/04/1987,São Paulo,Chelsea,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
411,40,Mory Diaw,FRA,G,1.95,95,22/06/1993,Poissy,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
412,1,Sacha Bastien,FRA,G,1.93,85,22/01/1995,Metz,Sedan,Stade de Reims,50,100,false,100,10000,SDR
413,2,Mohamed Fofana,MLI,D,1.81,75,07/03/1985,Gonesse,Toulouse,Stade de Reims,50,100,false,100,10000,SDR
414,3,Franck Signorino,ITA,D,1.73,60,19/09/1981,Nogent-sur-Marne,Laval,Stade de Reims,50,100,false,100,10000,SDR
415,4,Valentin Roberge,FRA,D,1.85,73,09/06/1987,Montreuil,Sunderland,Stade de Reims,50,100,false,100,10000,SDR
416,5,Grégory Bourillon,FRA,M,1.87,74,01/07/1984,Laval,Lorient,Stade de Reims,50,100,false,100,10000,SDR
417,6,Antoine Devaux,FRA,M,1.85,70,21/02/1985,Dieppe,Toulouse,Stade de Reims,50,100,false,100,10000,SDR
418,7,Odaïr Fortes,CPV,F,1.82,70,31/03/1987,Alfortville,Alfortville,Stade de Reims,50,100,false,100,10000,SDR
419,8,Prince Oniangue,FRA,M,1.90,78,04/11/1988,Paris,Tours,Stade de Reims,50,100,false,100,10000,SDR
420,9,Eliran Atar,ISR,F,1.79,73,17/02/1987,Tel Aviv,Maccabi Tel Aviv,Stade de Reims,50,100,false,100,10000,SDR
421,10,Gaëtan Charbonnier,FRA,F,1.88,80,27/12/1988,Saint-Mandé,Montpellier,Stade de Reims,50,100,false,100,10000,SDR
422,11,Diego,BRA,F,1.75,72,09/03/1988,Americana,Tours,Stade de Reims,50,100,false,100,10000,SDR
423,12,Nicolas De Préville,FRA,F,1.82,77,08/01/1991,Istres,Istres,Stade de Reims,50,100,false,100,10000,SDR
424,14,Benjamin Moukandjo,CMR,F,1.79,76,12/11/1988,Douala,Nancy,Stade de Reims,50,100,false,100,10000,SDR
425,15,Chris Mavinga,FRA,D,1.83,78,26/05/1991,Meaux,Rubin Kazan,Stade de Reims,50,100,false,100,10000,SDR
426,16,Kossi Agassa,TOG,G,1.90,86,07/07/1978,Lomé,Hércules,Stade de Reims,50,100,false,100,10000,SDR
427,17,Mads Albæk,DEN,M,1.82,76,14/01/1990,Roskilde,FC Midtjylland,Stade de Reims,50,100,false,100,10000,SDR
428,18,Gaëtan Courtet,FRA,F,1.80,72,22/02/1989,Lorient,Lorient,Stade de Reims,50,100,false,100,10000,SDR
429,19,Alexi Peuget,FRA,M,1.86,75,18/12/1990,Mulhouse,Strasbourg,Stade de Reims,50,100,false,100,10000,SDR
430,20,Yann Benedick,FRA,F,1.76,73,01/02/1992,Strasbourg,Strasbourg,Stade de Reims,50,100,false,100,10000,SDR
431,21,Bocundji Ca,GNB,M,1.72,69,28/12/1986,Biombo,Nancy,Stade de Reims,50,100,false,100,10000,SDR
432,22,Mickaël Tacalfred,FRA,D,1.75,69,23/04/1981,Colombes,Dijon,Stade de Reims,50,100,false,100,10000,SDR
433,23,Aïssa Mandi,ALG,D,1.86,78,22/10/1991,Châlons-en-Champagne,None,Stade de Reims,50,100,false,100,10000,SDR
434,24,David N'Gog,FRA,F,1.90,79,01/04/1989,Gennevilliers,Swansea C,Stade de Reims,50,100,false,100,10000,SDR
435,25,Anthony Weber,FRA,D,1.90,82,11/06/1987,Strasbourg,Paris FC,Stade de Reims,50,100,false,100,10000,SDR
436,26,Omenuke Mfulu,COD,D,1.82,69,20/03/1994,,Lille,Stade de Reims,50,100,false,100,10000,SDR
437,27,Christopher Glombard,FRA,D,1.78,74,05/06/1989,Montreuil,Bordeaux,Stade de Reims,50,100,false,100,10000,SDR
438,28,Antoine Conte,FRA,D,1.79,73,29/01/1994,Paris,Paris St-Germain,Stade de Reims,50,100,false,100,10000,SDR
439,29,Grejohn Kiey,FRA,F,1.87,84,12/08/1995,,None,Stade de Reims,50,100,false,100,10000,SDR
440,30,Johnny Placide,HAI,G,1.81,84,29/01/1988,Montfermeil,Le Havre,Stade de Reims,50,100,false,100,10000,SDR
441,1,Benoît Costil,FRA,G,1.87,83,03/07/1987,Caen,Sedan,Stade Rennais Football Club,50,100,false,100,10000,SRFC
442,3,Cheikh M'Bengué,SEN,D,1.83,75,23/07/1988,Toulouse,Toulouse,Stade Rennais Football Club,50,100,false,100,10000,SRFC
443,4,Mexer,MOZ,D,1.81,75,08/09/1985,Maputo,Nacional [POR],Stade Rennais Football Club,50,100,false,100,10000,SRFC
444,5,Jean-Armel Kana-Biyik,CMR,D,1.83,86,03/07/1989,Metz,Le Havre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
445,6,Gelson Fernandes,SUI,M,1.83,70,02/09/1986,Praia,Freiburg,Stade Rennais Football Club,50,100,false,100,10000,SRFC
446,7,Paul-Georges Ntep,FRA,F,1.80,75,29/07/1992,Douala,Auxerre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
447,8,Abdoulaye Doucouré,FRA,M,1.82,69,01/01/1993,Meulan-en-Yvelines,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
448,9,Ola Toivonen,SWE,F,1.90,74,03/07/1986,Degerfors,PSV Eindhoven,Stade Rennais Football Club,50,100,false,100,10000,SRFC
449,10,Kamil Grosicki,POL,M,1.80,78,08/06/1988,Szczecin,Sivasspor,Stade Rennais Football Club,50,100,false,100,10000,SRFC
450,11,Philipp Hosiner,AUT,F,1.79,75,15/05/1989,Eisenstadt,Austria Vienna,Stade Rennais Football Club,50,100,false,100,10000,SRFC
451,12,Steven Moreira,FRA,D,1.76,67,13/08/1994,Noisy-le-Grand,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
452,14,Fallou Diagné,SEN,D,1.85,75,14/08/1989,Pikine,Freiburg,Stade Rennais Football Club,50,100,false,100,10000,SRFC
453,15,Jean II Makoun,CMR,M,1.73,69,29/05/1983,Yaoundé,Aston Villa,Stade Rennais Football Club,50,100,false,100,10000,SRFC
454,16,Olivier Sorin,FRA,G,1.88,76,16/04/1981,Gien,Auxerre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
455,17,Vincent Pajot,FRA,M,1.76,64,19/08/1990,Domont,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
456,18,Pedro Henrique,BRA,M,1.79,72,16/06/1990,Novo Hamburgo,Zürich,Stade Rennais Football Club,50,100,false,100,10000,SRFC
457,19,Adrien Hunou,FRA,M,1.78,66,19/01/1994,Evry,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
458,20,Axel Ngando,FRA,M,1.77,66,13/07/1993,Asnières-sur-Seine,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
459,21,Benjamin André,FRA,D,1.77,68,03/08/1990,Nice,Ajaccio,Stade Rennais Football Club,50,100,false,100,10000,SRFC
460,22,Sylvain Armand,FRA,D,1.82,82,01/08/1980,Saint-Etienne,Paris St-Germain,Stade Rennais Football Club,50,100,false,100,10000,SRFC
461,23,Anders Konradsen,NOR,M,1.85,79,18/07/1990,Bodø,Strømsgodset,Stade Rennais Football Club,50,100,false,100,10000,SRFC
462,24,Sanjin Prci?,BIH,M,1.81,73,20/11/1993,Belfort,Sochaux,Stade Rennais Football Club,50,100,false,100,10000,SRFC
463,25,Zana Allée,FRA,M,1.72,66,29/04/1996,Baghdad,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
464,27,Mahamadou Habib Habibou,CTA,F,1.92,80,16/04/1987,Bria,KAA Gent,Stade Rennais Football Club,50,100,false,100,10000,SRFC
465,28,Gjoko Zajkov,MKD,D,1.86,78,10/02/1995,Skopje,Rabotni?ki Skopje,Stade Rennais Football Club,50,100,false,100,10000,SRFC
466,29,Romain Danzé,FRA,D,1.84,72,03/07/1986,Douarnenez,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
467,1,Baptiste Valette,FRA,G,1.85,80,01/09/1992,Sète,Montpellier,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
468,2,Kévin Theophile Catherine,FRA,D,1.80,77,28/10/1989,Saint Brieuc,Cardiff C,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
469,6,Jérémy Clément,FRA,M,1.74,61,26/08/1984,Béziers,Paris St-Germain,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
470,7,Max Gradel,CIV,F,1.80,70,30/11/1987,Abidjan,Leeds U,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
471,8,Benjamin Corgnet,FRA,M,1.80,75,06/04/1987,Thionville,Lorient,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
472,9,Mevlüt Erdinç,TUR,F,1.81,85,25/02/1987,Saint-Claude,Rennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
473,10,Renaud Cohade,FRA,M,1.80,74,29/09/1984,Aubenas,Valenciennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
474,11,Yohan Mollo,FRA,F,1.75,74,18/07/1989,Martigues,Nancy,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
475,12,Allan Saint-Maximin,FRA,F,1.73,67,12/03/1997,Châtenay-Malabry,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
476,13,Ricky van Wolfswinkel,NED,F,1.85,69,27/01/1989,Amersfoort,Norwich C,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
477,16,Stéphane Ruffier,FRA,G,1.87,89,27/09/1986,Bayonne,Monaco,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
478,18,Fabien Lemoine,FRA,M,1.75,67,16/03/1987,Fougères,Rennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
479,19,Florentin Pogba,GUI,D,1.88,87,19/08/1990,Conakry,Sedan,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
480,20,Jonathan Brison,FRA,D,1.79,73,07/02/1983,Soissons,Nancy,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
481,21,Romain Hamouma,FRA,M,1.77,67,29/03/1987,Lure,Caen,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
482,22,Kévin Monnet-Paquet,FRA,F,1.83,73,19/08/1988,Bourgoin-Jallieu,Lorient,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
483,23,Paul Baysse,FRA,D,1.84,82,15/05/1988,Bordeaux,Brest,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
484,24,Loïc Perrin,FRA,D,1.80,76,07/08/1985,Saint-Etienne,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
485,26,Moustapha Bayal Sall,SEN,D,1.90,90,30/11/1985,Dakar,US Gorée,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
486,27,Franck Tabanou,FRA,M,1.78,70,30/01/1989,Thiais,Toulouse,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
487,28,Ismaël Diomande,CIV,M,1.80,75,28/08/1992,Abidjan,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
488,29,François Clerc,FRA,D,1.86,77,18/04/1983,Bourg en Bresse,Nice,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
489,30,Jessy Moulin,FRA,G,1.84,80,13/01/1986,Valence,None,Association Sportive de St-Etienne,50,100,false,100,10000,TFC
490,1,Zacharie Boucher,FRA,G,1.80,74,07/03/1992,St Pierre,Le Havre,Toulouse Football Club,50,100,false,100,10000,TFC
491,2,Maxime Spano,FRA,D,1.84,79,31/10/1994,Aubagne,ES Pennoise,Toulouse Football Club,50,100,false,100,10000,TFC
492,4,Tongo Doumbia,MLI,M,1.90,79,06/08/1989,Vernon,Wolverhampton W,Toulouse Football Club,50,100,false,100,10000,TFC
493,5,Issiaga Sylla,GUI,D,1.80,70,01/01/1994,Conakry,Horoya AC,Toulouse Football Club,50,100,false,100,10000,TFC
494,6,William Matheus,BRA,D,1.87,85,02/04/1990,Rio de Janeiro,Palmeiras,Toulouse Football Club,50,100,false,100,10000,TFC
495,7,Jean-Daniel Akpa Akpro,CIV,D,1.80,66,11/10/1992,Toulouse,None,Toulouse Football Club,50,100,false,100,10000,TFC
496,8,Etienne Didot,FRA,M,1.75,65,24/07/1983,Paimpol,Rennes,Toulouse Football Club,50,100,false,100,10000,TFC
497,9,Martin Braithwaite,DEN,F,1.79,77,05/06/1991,Esbjerg,Esbjerg,Toulouse Football Club,50,100,false,100,10000,TFC
498,10,Wissam Ben Yedder,FRA,F,1.70,68,12/08/1990,Sarcelles,Alfortville,Toulouse Football Club,50,100,false,100,10000,TFC
499,11,Aleksandar Peši?,SRB,F,1.90,83,21/05/1992,Niš,Jagodina,Toulouse Football Club,50,100,false,100,10000,TFC
500,12,Florian David,FRA,F,1.80,71,16/11/1992,Champigny-sur-Marne,None,Toulouse Football Club,50,100,false,100,10000,TFC
501,13,Dominik Furman,POL,M,1.81,71,06/07/1992,Szyd?owiec,Legia Warszawa,Toulouse Football Club,50,100,false,100,10000,TFC
502,14,François Sirieix,FRA,M,1.80,72,07/10/1980,Bordeaux,Auxerre,Toulouse Football Club,50,100,false,100,10000,TFC
503,15,Uroš Spaji?,SRB,D,1.86,76,13/02/1993,Belgrade,Crvena Zvezda,Toulouse Football Club,50,100,false,100,10000,TFC
504,16,Marc Vidal,FRA,G,1.87,80,03/06/1991,Saint-Affrique,None,Toulouse Football Club,50,100,false,100,10000,TFC
505,17,Adrien Regattin,MAR,M,1.66,67,22/08/1991,Sète,Sète,Toulouse Football Club,50,100,false,100,10000,TFC
506,18,Óscar Trejo,ARG,M,1.80,79,26/04/1988,Santiago del Estero,Sporting Gijón,Toulouse Football Club,50,100,false,100,10000,TFC
507,20,Steeve Yago,FRA,D,1.80,72,16/12/1992,Sarcelles,None,Toulouse Football Club,50,100,false,100,10000,TFC
508,21,Abel Aguilar,COL,M,1.85,82,06/01/1985,Santa Fe de Bogota,Hércules,Toulouse Football Club,50,100,false,100,10000,TFC
509,22,Dušan Veškovac,SRB,D,1.87,78,16/03/1986,Kruševac,Young Boys,Toulouse Football Club,50,100,false,100,10000,TFC
510,23,Marcel Tisserand,COD,D,1.84,70,10/01/1993,Meaux,Monaco,Toulouse Football Club,50,100,false,100,10000,TFC
511,24,Pavle Ninkov,SRB,D,1.83,81,20/04/1985,Belgrade,Crvena Zvezda,Toulouse Football Club,50,100,false,100,10000,TFC
512,25,Drago? Grigore,ROU,D,1.85,76,07/09/1986,Vaslui,Dinamo Bucure?ti,Toulouse Football Club,50,100,false,100,10000,TFC
513,26,Sana Zaniou,BFA,F,1.70,65,31/12/1994,Cinsense,AS Sonabel,Toulouse Football Club,50,100,false,100,10000,TFC
514,27,Amadou Soukouna,FRA,F,1.82,76,21/06/1992,Paris,None,Toulouse Football Club,50,100,false,100,10000,TFC
515,28,Mihai Roman,ROU,M,1.73,70,16/11/1984,Suceava,Rapid Bucure?ti,Toulouse Football Club,50,100,false,100,10000,TFC
516,29,François Moubandje,SUI,D,1.82,76,21/06/1990,Geneva,Servette,Toulouse Football Club,50,100,false,100,10000,TFC
517,30,Ali Ahamada,FRA,G,1.89,83,19/08/1991,Martigues,None,Toulouse Football Club,50,100,false,100,10000,TFC";
            File.WriteAllText( "cust.csv", csvString );

            // Read into an array of strings.
            string[] source = File.ReadAllLines( "cust.csv" );
            XElement cust = new XElement( "Players",
                from str in source
                let fields = str.Split( ',' )
                select new XElement( "Player",
                    new XElement( "Id", fields[0] ),
                    new XElement( "ShirtNumber", fields[1] ),
                    new XElement( "Name", fields[2] ),
                    new XElement( "Nationality", fields[3] ),
                    new XElement( "FieldPosition", fields[4] ),
                    new XElement( "Height", fields[5] ),
                    new XElement( "Weight", fields[6] ),
                    new XElement( "BirthDate", fields[7] ),
                    new XElement( "BirthPlace", fields[8] ),
                    new XElement( "PreviousClub", fields[9] ),
                    new XElement( "ActualClub", fields[10] ),
                    new XElement( "Stats", fields[11] ),
                    new XElement( "FormState", fields[12] ),
                    new XElement( "Injury", fields[13] ),
                    new XElement( "Mental", fields[14] ),
                    new XElement( "FinancialValue", fields[15] ),
                    new XElement( "ActualClubTag", fields[16] ) ) );
            cust.Save( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players2.xml" );
        }
    }
}