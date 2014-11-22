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
            string csvString = @"1,Alphonse Aréola,1,FRA,G,1.90,85,27/02/1993,Paris,Paris St-Germain,Sporting Club de Bastia,50,100,false,100,10000,SCB
2,Romain Achilli,2,FRA,D,1.75,70,15/02/1993,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
3,Hervin Ongenda,3,FRA,F,1.70,64,24/06/1995,Paris,Paris St-Germain,Sporting Club de Bastia,50,100,false,100,10000,SCB
4,Florian Marange,4,FRA,D,1.76,70,03/03/1986,Talence,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
5,Sébastien Squillaci,5,FRA,D,1.84,76,11/08/1980,Toulon,Arsenal,Sporting Club de Bastia,50,100,false,100,10000,SCB
6,N'Dri Romaric,6,CIV,M,1.87,88,04/06/1983,Abidjan,Zaragoza,Sporting Club de Bastia,50,100,false,100,10000,SCB
7,Floyd Ayité,7,TOG,M,1.74,68,15/12/1988,Bordeaux,Reims,Sporting Club de Bastia,50,100,false,100,10000,SCB
8,El-Hajdi Ba,8,FRA,M,1.83,74,05/03/1993,Paris,Sunderland,Sporting Club de Bastia,50,100,false,100,10000,SCB
9,Djibril Cissé,9,FRA,F,1.82,78,12/08/1981,Arles,Kuban Krasnodar,Sporting Club de Bastia,50,100,false,100,10000,SCB
10,Ryad Boudebouz,10,ALG,M,1.72,59,19/02/1990,Colmar,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
11,Gadji Celi Junior Tallo,11,CIV,F,1.87,77,21/12/1992,Ouragahio,Roma,Sporting Club de Bastia,50,100,false,100,10000,SCB
12,Christophe Vincent,12,FRA,M,1.78,72,08/11/1992,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
13,Abdoulaye Keita,13,MLI,M,1.75,75,05/01/1994,Bamako,Centre Salif Keita,Sporting Club de Bastia,50,100,false,100,10000,SCB
14,Famoussa Koné,14,MLI,F,1.75,74,03/05/1994,Bamako,CO Bamako,Sporting Club de Bastia,50,100,false,100,10000,SCB
15,Julian Palmieri,15,FRA,D,1.70,66,17/12/1986,Lyon,Istres,Sporting Club de Bastia,50,100,false,100,10000,SCB
16,Jean-Louis Leca,16,FRA,G,1.77,65,21/09/1985,Bastia,Valenciennes,Sporting Club de Bastia,50,100,false,100,10000,SCB
17,Mathieu Peybernes,17,FRA,D,1.84,80,21/10/1990,Toulouse,Sochaux,Sporting Club de Bastia,50,100,false,100,10000,SCB
18,Yannick Cahuzac,18,FRA,M,1.78,66,18/01/1985,Ajaccio,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
19,Benjamin Mokulu,19,BEL,F,1.85,83,11/10/1989,Brussels,Mechelen,Sporting Club de Bastia,50,100,false,100,10000,SCB
20,François Modestó,20,FRA,D,1.83,80,19/08/1978,Bastia,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
21,Luka Kikabidze,21,GEO,M,,,21/01/1995,Tbilisi,Lokomotivi Tbilisi,Sporting Club de Bastia,50,100,false,100,10000,SCB
22,Christopher Maboulou,22,FRA,M,1.85,79,19/03/1990,Montfermeil,Châteauroux,Sporting Club de Bastia,50,100,false,100,10000,SCB
23,Drissa Diakité,23,MLI,D,1.75,69,18/02/1985,Bamako,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
24,Joao Rodríguez,24,COL,F,1.77,69,12/05/1996,Cúcuta,Chelsea,Sporting Club de Bastia,50,100,false,100,10000,SCB
25,François Kamano,25,GUI,F,,,01/05/1996,,Satellite FC,Sporting Club de Bastia,50,100,false,100,10000,SCB
26,Brandão,26,BRA,F,1.89,78,16/06/1980,São Paulo,St-Etienne,Sporting Club de Bastia,50,100,false,100,10000,SCB
27,Guillaume Gillet,27,BEL,M,1.86,77,09/03/1985,Liège,Anderlecht,Sporting Club de Bastia,50,100,false,100,10000,SCB
28,Juan Pablo Pino,28,COL,M,1.76,72,30/03/1987,Cartagena,Olympiakos,Sporting Club de Bastia,50,100,false,100,10000,SCB
29,Gilles Cioni,29,FRA,D,1.65,65,14/06/1984,Bastia,Paris FC,Sporting Club de Bastia,50,100,false,100,10000,SCB
30,Thomas Vincensini,30,FRA,G,1.90,73,12/09/1993,Bastia,None,Sporting Club de Bastia,50,100,false,100,10000,SCB
31,Ažbe Jug,1,SVN,G,1.92,91,03/03/1992,Maribor,Interblock,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
32,Mariano,2,BRA,D,1.77,70,23/06/1986,São João,Fluminense,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
33,Diego Contento,3,ITA,D,1.76,70,01/05/1990,Munich,Bayern Munich,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
34,Tiago Ilori,4,POR,D,1.90,80,26/02/1993,Hampstead,Liverpool,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
35,Nicolas Pallois,5,FRA,D,1.90,85,19/09/1987,Elbeuf,Niort,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
36,Ludovic Sané,6,SEN,D,1.92,77,22/03/1987,Villeneuve-sur-Lot,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
37,Abdou Traoré,7,MLI,M,1.79,73,17/01/1988,Bamako,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
38,Grégory Sertic,8,FRA,M,1.81,69,05/08/1989,Brétigny-sur-Orge,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
39,Diego Rolán,9,URU,F,1.78,74,24/03/1993,Montevideo,Defensor Sporting,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
40,Henri Saivet,10,FRA,F,1.73,70,26/10/1990,Dakar,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
41,Emiliano Sala,11,ARG,F,1.87,75,31/10/1990,Cululú,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
42,Thomas Touré,13,FRA,F,1.75,75,27/12/1993,Grasse,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
43,Cheikh Diabaté,14,MLI,F,1.94,84,25/04/1988,Bamako,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
44,Younès Kaabouni,15,FRA,M,1.79,67,23/05/1995,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
45,Cédric Carrasso,16,FRA,G,1.87,87,30/12/1981,Avignon,Toulouse,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
46,André Biyogo Poko,17,GAB,M,1.73,72,01/01/1993,Bitam,US Bitam,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
47,Jaroslav Plašil,18,CZE,M,1.83,72,05/01/1982,Opo?no,Osasuna,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
48,Nicolas Maurice-Belay,19,FRA,M,1.82,76,19/04/1985,Sucy-en-Brie,Sochaux,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
49,Jussiê,20,BRA,F,1.80,76,19/09/1983,Nova Venécia,Lens,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
50,Julien Faubert,22,FRA,D,1.80,75,01/08/1983,Le Havre,Elaz??spor,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
51,Wahbi Khazri,24,TUN,M,1.82,78,08/02/1991,Ajaccio,Bastia,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
52,Théo Pellenard,25,FRA,D,1.82,71,04/03/1994,Lille,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
53,Clément Badin,26,FRA,M,1.68,71,26/05/1993,Bruges,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
54,Marc Planus,27,FRA,D,1.83,76,07/03/1982,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
55,Maxime Poundjé,29,FRA,D,1.79,71,16/08/1992,Bordeaux,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
56,Jérôme Prior,30,FRA,G,1.84,88,08/08/1995,Toulon,None,Football Club des Girondins de Bordeaux,50,100,false,100,10000,FCB
57,Rémy Vercoutre,1,FRA,G,1.85,78,26/06/1980,Grande-Synthe,Lyon,Stade Malherbe de Caen,50,100,false,100,10000,SMC
58,Nicolas Seube,2,FRA,M,1.80,72,11/08/1979,Toulouse,Toulouse,Stade Malherbe de Caen,50,100,false,100,10000,SMC
59,Alaeddine Yahia,5,TUN,D,1.86,81,26/08/1981,Courbevoie,Lens,Stade Malherbe de Caen,50,100,false,100,10000,SMC
61,Mathieu Duhamel,7,FRA,F,1.83,76,12/07/1984,Mont-Saint-Aignan,Metz,Stade Malherbe de Caen,50,100,false,100,10000,SMC
62,Sloan Privat,9,FRA,F,1.86,83,24/07/1989,Cayenne,KAA Gent,Stade Malherbe de Caen,50,100,false,100,10000,SMC
63,Lenny Nangis,10,FRA,F,1.73,65,24/03/1994,Caen,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
64,Bengadli-Fodé Koita,11,FRA,F,1.86,86,21/10/1990,Paris,Montpellier,Stade Malherbe de Caen,50,100,false,100,10000,SMC
65,Dennis Appiah,12,FRA,D,1.79,68,09/06/1992,Toulouse,Monaco,Stade Malherbe de Caen,50,100,false,100,10000,SMC
66,Jean-Jacques Pierre,13,HAI,D,1.80,79,23/01/1981,Leogane,Panionios,Stade Malherbe de Caen,50,100,false,100,10000,SMC
67,Emmanuel Imorou,15,BEN,D,1.81,69,16/09/1988,Bourges,Clermont,Stade Malherbe de Caen,50,100,false,100,10000,SMC
68,Damien Perquis,16,FRA,G,1.84,82,08/03/1986,Saint-Brieuc,Beauvais,Stade Malherbe de Caen,50,100,false,100,10000,SMC
69,Ngolo Kanté,17,FRA,M,1.70,70,29/03/1991,Paris,Boulogne,Stade Malherbe de Caen,50,100,false,100,10000,SMC
70,Jordan Adéoti,18,BEN,M,1.83,77,12/03/1989,L'Union,Laval,Stade Malherbe de Caen,50,100,false,100,10000,SMC
71,Felipe Saad,19,BRA,D,1.87,83,11/09/1983,Santos,Ajaccio,Stade Malherbe de Caen,50,100,false,100,10000,SMC
72,Hervé Bazile,20,FRA,F,1.80,73,18/03/1990,Créteil,Le Poiré-sur-Vie,Stade Malherbe de Caen,50,100,false,100,10000,SMC
73,José Saez,21,FRA,M,1.70,63,07/05/1982,Memin,Valenciennes,Stade Malherbe de Caen,50,100,false,100,10000,SMC
74,Alexandre Raineau,22,FRA,D,1.78,71,21/06/1986,Paris,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
75,Jean Calvé,23,FRA,D,1.83,78,30/04/1984,Cormeilles-en-Parisis,Nancy,Stade Malherbe de Caen,50,100,false,100,10000,SMC
76,Florian Raspentino,24,FRA,F,1.79,73,06/06/1989,Marignane,Marseille,Stade Malherbe de Caen,50,100,false,100,10000,SMC
77,Julien Féret,25,FRA,M,1.87,74,05/07/1982,Saint Brieuc,Rennes,Stade Malherbe de Caen,50,100,false,100,10000,SMC
78,Jonathan Beaulieu,26,FRA,M,1.80,65,11/03/1993,Meudon,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
79,Thomas Lemar,27,FRA,M,1.63,46,12/11/1995,Baie-Mahault,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
80,Damien Da Silva,28,FRA,D,1.84,77,17/05/1988,Talence,Clermont,Stade Malherbe de Caen,50,100,false,100,10000,SMC
81,Yrondu Musavu-King,29,GAB,D,1.86,83,08/01/1992,Libreville,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
82,Paul Reulet,30,FRA,G,1.81,64,14/01/1994,Caen,None,Stade Malherbe de Caen,50,100,false,100,10000,SMC
83,Johann Durand,1,FRA,G,1.82,71,17/06/1981,Evian,Gaillard,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
84,Kassim Abdallah,2,FRA,D,1.89,76,09/04/1987,Marseille,Marseille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
85,Miloš Ninkovi?,5,SRB,M,1.80,76,25/12/1984,Belgrade,Crvena Zvezda,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
86,Djakaridja Koné,6,BFA,M,1.83,75,22/07/1986,Abidjan,Dinamo Bucure?ti,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
87,Adrien Thomasson,7,FRA,F,1.82,75,10/12/1993,Bourg-Saint-Maurice,Annecy,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
88,Yeltsin Tejeda,8,CRC,M,1.77,66,17/03/1992,Puerto Limón,Deportivo Saprissa,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
89,Gianni Bruno,9,BEL,F,1.78,64,19/08/1991,Rocourt,Lille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
90,Nicolas Benezet,10,FRA,M,1.72,61,24/02/1991,Montpellier,Nîmes,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
91,Fabien Camus,11,FRA,M,1.79,67,28/02/1985,Arles,KRC Genk,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
92,Gaël Givet,12,FRA,D,1.81,75,09/10/1981,Arles,Arles-Avignon,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
93,Cédric Barbosa,14,FRA,M,1.79,67,06/03/1976,Aubenas,Metz,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
94,Aldo Angoula,17,FRA,D,1.84,82,04/05/1981,Le Havre,Boulogne,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
95,Daniel Wass,18,DEN,D,1.81,74,31/05/1989,Gladsaxe,Benfica,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
96,Youssouf Sabaly,19,FRA,D,1.74,71,05/03/1993,Chesnay,Paris St-Germain,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
97,Modou Sougou,20,SEN,F,1.78,68,18/12/1984,Fissel,Marseille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
98,Cédric Mongongu,21,COD,D,1.89,76,22/06/1989,Kinshasa,Monaco,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
99,Cédric Cambon,22,FRA,D,1.84,76,20/09/1986,Montpellier,Litex Lovech,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
100,Nicki Bille Nielsen,23,DEN,F,1.84,76,07/02/1988,Vigerslev,Rosenborg,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
101,Olivier Sorlin,24,FRA,M,1.82,77,09/04/1979,Saint-Etienne,PAOK,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
102,Jonathan Mensah,25,GHA,D,1.88,75,13/07/1990,Accra,Udinese,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
103,Jesper Juelsgaard,26,DEN,D,1.82,78,26/01/1989,Spjald,FC Midtjylland,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
104,Clarck N'Sikulu,27,FRA,F,1.80,78,10/07/1992,Lille,Lille,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
105,Najib Baouia,28,ALG,F,1.65,65,25/02/1992,El Meghaier,None,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
106,Jesper Hansen,30,DEN,G,1.88,78,31/03/1985,Frederikssund,FC Nordsjælland,Evian Thonon Gaillard Football Club,50,100,false,100,10000,ETG
107,Jonas Lössl,1,DEN,G,1.95,89,01/02/1989,Kolding,FC Midtjylland,En Avant Guingamp,50,100,false,100,10000,EAG
108,Lars Jacobsen,2,DEN,D,1.81,75,20/09/1979,Odense,FC København,En Avant Guingamp,50,100,false,100,10000,EAG
109,Angoua Brou Benjamin,3,CIV,D,1.78,69,28/11/1986,Anyama,Valenciennes,En Avant Guingamp,50,100,false,100,10000,EAG
110,Baïssama Sankoh,4,FRA,D,1.80,73,20/03/1992,Nogent-sur-Marne,Sarcelles,En Avant Guingamp,50,100,false,100,10000,EAG
111,Moustapha Diallo,5,SEN,M,1.88,78,14/05/1986,Dakar,ASC Diaraf,En Avant Guingamp,50,100,false,100,10000,EAG
112,Maxime Baca,6,FRA,D,1.71,68,02/06/1983,Corbeil Essonnes,Lorient,En Avant Guingamp,50,100,false,100,10000,EAG
113,Dorian Levêque,7,FRA,D,1.82,72,22/11/1989,Annecy,Boulogne,En Avant Guingamp,50,100,false,100,10000,EAG
114,Ronnie Schwartz,8,DEN,F,1.83,74,29/08/1989,Ulsted,Randers,En Avant Guingamp,50,100,false,100,10000,EAG
115,Younousse Sankharé,10,FRA,M,1.84,76,10/09/1989,Sarcelles,Dijon,En Avant Guingamp,50,100,false,100,10000,EAG
116,Claudio Beauvue,12,FRA,M,1.74,66,16/04/1988,Saint-Claude,Châteauroux,En Avant Guingamp,50,100,false,100,10000,EAG
117,Christophe Mandanne,13,FRA,F,1.71,62,07/02/1985,Toulouse,Dijon,En Avant Guingamp,50,100,false,100,10000,EAG
118,Ladislas Douniama,14,CGO,F,1.63,62,24/05/1986,Brazzaville,Lorient,En Avant Guingamp,50,100,false,100,10000,EAG
119,Jérémy Sorbon,15,FRA,D,1.83,79,05/08/1983,Caen,Caen,En Avant Guingamp,50,100,false,100,10000,EAG
120,Hugo Guichard,16,FRA,G,1.89,77,16/05/1992,Saint-Étienne,Bordeaux,En Avant Guingamp,50,100,false,100,10000,EAG
121,Rachid Alioui,17,FRA,F,1.86,81,18/06/1992,La Rochelle,None,En Avant Guingamp,50,100,false,100,10000,EAG
122,Lionel Mathis,18,FRA,M,1.74,71,04/10/1981,Montreuil-sous-Bois,Sochaux,En Avant Guingamp,50,100,false,100,10000,EAG
123,Laurent Dos Santos,20,FRA,M,1.77,70,21/09/1993,Montmorency,None,En Avant Guingamp,50,100,false,100,10000,EAG
124,Sylvain Marveaux,21,FRA,M,1.72,66,15/04/1986,Vannes,Newcastle U,En Avant Guingamp,50,100,false,100,10000,EAG
125,Julien Cardy,22,FRA,M,1.76,71,29/09/1981,Pau,Arles-Avignon,En Avant Guingamp,50,100,false,100,10000,EAG
126,Jérémy Pied,23,FRA,M,1.73,69,23/02/1989,Grenoble,Nice,En Avant Guingamp,50,100,false,100,10000,EAG
127,Sambou Yatabaré,24,MLI,M,1.90,82,02/03/1989,Beauvais,Olympiakos,En Avant Guingamp,50,100,false,100,10000,EAG
128,Reynald Lemaître,25,FRA,D,1.75,66,28/06/1983,Chambray-lès-Tours,Nancy,En Avant Guingamp,50,100,false,100,10000,EAG
129,Thibault Giresse,26,FRA,M,1.72,68,25/05/1981,Talence,Amiens,En Avant Guingamp,50,100,false,100,10000,EAG
130,Christophe Kerbrat,29,FRA,D,1.83,74,02/08/1986,Brest,Plabennec,En Avant Guingamp,50,100,false,100,10000,EAG
131,Mamadou Samassa,30,MLI,G,1.91,81,16/02/1990,Montreuil,None,En Avant Guingamp,50,100,false,100,10000,EAG
132,Rudy Riou,1,FRA,G,1.85,78,22/01/1980,Grande-Synthe,Nantes,Racing Club de Lens,50,100,false,100,10000,RCL
133,Ahmed Kantari,4,MAR,D,1.85,80,28/06/1985,Blois,Brest,Racing Club de Lens,50,100,false,100,10000,RCL
134,Jérôme Lemoigne,6,FRA,M,1.88,77,15/02/1983,Toulon,Sedan,Racing Club de Lens,50,100,false,100,10000,RCL
135,Yoann Touzghar,7,FRA,F,1.79,75,28/11/1986,Avignon,Amiens,Racing Club de Lens,50,100,false,100,10000,RCL
136,Adamo Coulibaly,9,FRA,F,1.87,81,14/08/1981,Paris,Debrecen,Racing Club de Lens,50,100,false,100,10000,RCL
137,Pablo Chavarría,11,ARG,F,1.82,74,02/01/1988,Las Perdices,Anderlecht,Racing Club de Lens,50,100,false,100,10000,RCL
138,Deme N'Diaye,14,SEN,M,1.83,72,06/02/1985,Dakar,Arles-Avignon,Racing Club de Lens,50,100,false,100,10000,RCL
139,Patrick Fradj,15,FRA,D,1.76,70,11/03/1992,Saint-Saulve,None,Racing Club de Lens,50,100,false,100,10000,RCL
140,Pierrick Valdivia,18,FRA,M,1.85,67,18/04/1988,Bron,Sedan,Racing Club de Lens,50,100,false,100,10000,RCL
141,Baptiste Guillaume,19,FRA,F,1.89,77,16/06/1995,Brussels,None,Racing Club de Lens,50,100,false,100,10000,RCL
142,Lalaina Nomenjanahary,20,MDA,M,1.88,74,16/01/1986,Antananarivo,Avion,Racing Club de Lens,50,100,false,100,10000,RCL
143,Alharbi El Jadeyaoui,21,FRA,M,1.75,68,08/08/1986,Strasbourg,Angers,Racing Club de Lens,50,100,false,100,10000,RCL
144,Loïck Landré,22,FRA,D,1.82,75,05/05/1992,Aubervilliers,Paris St-Germain,Racing Club de Lens,50,100,false,100,10000,RCL
145,Wylan Cyprien,23,FRA,M,1.80,75,28/01/1995,Pointe-à-Pitre,None,Racing Club de Lens,50,100,false,100,10000,RCL
146,Ludovic Baal,24,FRA,D,1.76,72,24/05/1986,Paris,Le Mans,Racing Club de Lens,50,100,false,100,10000,RCL
147,Jean-Philippe Gbamin,25,FRA,D,1.86,83,25/05/1995,San-Pédro,None,Racing Club de Lens,50,100,false,100,10000,RCL
148,Benjamin Boulenger,27,FRA,D,1.88,80,01/03/1990,Maubeuge,Boulogne,Racing Club de Lens,50,100,false,100,10000,RCL
149,Benjamin Bourigeaud,29,FRA,M,1.78,71,14/01/1994,Calais,None,Racing Club de Lens,50,100,false,100,10000,RCL
150,Vincent Enyeama,1,NGA,G,1.80,80,29/08/1982,Aba,Maccabi Tel Aviv,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
151,Sébastien Corchia,2,FRA,D,1.74,65,01/11/1990,Noisy-le-Sec,Sochaux,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
152,Florent Balmont,4,FRA,M,1.68,71,02/02/1980,Sainte-Foy-les-Lyon,Nice,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
153,Idrissa Gueye,5,SEN,M,1.74,64,26/09/1989,Dakar,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
154,Jonathan Delaplace,6,FRA,M,1.67,60,20/03/1986,La Seyne-sur-Mer,Zulte-Waregem,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
155,Ronny Rodelin,9,FRA,F,1.92,70,18/11/1989,Saint-Denis de La Réunion,Nantes,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
156,Marvin Martin,10,FRA,M,1.71,63,10/06/1988,Paris,Sochaux,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
157,Michael Frey,11,SUI,F,1.78,72,19/07/1994,,Young Boys,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
158,Souahilo Meïté,12,FRA,M,1.87,80,17/03/1994,Paris,Auxerre,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
159,Adama Soumaoro,13,CIV,D,1.87,75,18/06/1992,Fontenay-aux-Roses,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
160,Simon Kjær,14,DEN,D,1.89,82,26/03/1989,Horsens,Wolfsburg,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
161,Djibril Sidibé,15,FRA,D,1.82,73,29/07/1992,Troyes,Troyes,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
162,Steeve Elana,16,FRA,G,1.87,85,11/07/1980,Marseille,Brest,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
163,Marcos Lopes,17,POR,M,1.74,68,28/12/1995,Belém,Manchester C,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
164,Franck Béria,18,FRA,D,1.77,75,23/05/1983,Argenteuil,Metz,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
165,Ryan Mendes,20,CPV,F,1.75,77,08/01/1990,Mindelo,Le Havre,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
166,David Rozehnal,22,CZE,D,1.93,77,05/07/1980,Šternberk,Hamburg,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
167,Pape N'Diaye Souaré,23,SEN,D,1.78,68,06/06/1990,Mbao,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
168,Rio Antonio Mavuba,24,FRA,M,1.72,70,08/03/1984,Born At Sea,Villarreal,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
169,Marko Baša,25,SRB,D,1.90,79,29/12/1982,Trstenik,Lokomotiv Moscow,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
170,Nolan Roux,26,FRA,F,1.82,75,01/03/1988,Compiègne,Brest,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
171,Divock Origi,27,BEL,F,1.85,75,18/04/1995,Ostend,Liverpool,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
172,Jean Butez,30,FRA,G,1.88,75,08/06/1995,Lille,None,Lille Olympique Sporting Club,50,100,false,100,10000,LOSC
173,Lamine Koné,2,FRA,D,1.86,83,01/02/1989,Paris,Châteauroux,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
174,Pedrinho,3,POR,D,1.77,73,06/03/1985,Vila do Conde,Académica,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
175,Vincent Le Goff,4,FRA,D,1.75,64,15/10/1989,Quimper,Istres,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
176,Mehdi Mostefa Sbaa,5,ALG,M,1.81,82,30/08/1983,Dijon,Ajaccio,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
177,François Bellugou,6,FRA,D,1.86,70,25/04/1987,Prades,Nancy,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
178,Sadio Diallo,7,GUI,F,1.82,75,28/12/1990,Conakry,Rennes,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
179,Yann Jouffre,8,FRA,M,1.75,65,23/07/1984,Montélimar,Guingamp,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
180,Jordan Ayew,9,GHA,F,1.82,81,11/09/1991,Marseille,Marseille,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
181,Mathieu Coutadeur,10,FRA,M,1.70,69,20/06/1986,Le Mans,Monaco,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
182,Pierre Lavenant,12,FRA,M,1.80,74,03/08/1995,Saint-Malo,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
183,Rafidine Abdullah,13,FRA,M,1.79,75,15/01/1994,Marseille,Marseille,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
184,Raphaël Guerreiro,14,FRA,D,1.70,67,22/12/1993,Le Blanc-Mesnil,Caen,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
185,Fabien Robert,15,FRA,F,1.74,67,06/01/1989,Hennebont,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
186,Fabien Audard,16,FRA,G,1.88,89,28/03/1978,Toulouse,Bastia,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
187,Walid Mesloub,17,ALG,M,1.80,69,04/09/1985,Trappes,Le Havre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
188,Gilles Sunu,18,FRA,M,1.80,70,30/03/1991,Châteauroux,Arsenal,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
189,Bryan Pelé,19,FRA,M,1.69,65,25/03/1992,Ploërmel,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
190,Julien Quercia,20,FRA,F,1.68,65,17/08/1986,Thionville,Auxerre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
191,Alain Traoré,21,BFA,M,1.76,66,31/12/1988,Bobo-Dioulasso,Auxerre,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
192,Benjamin Jeannot,22,FRA,F,1.81,73,22/01/1992,Laxou,Nancy,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
193,Mathias Autret,23,FRA,M,1.79,64,01/03/1991,Morlaix,Brest,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
194,Wesley Lautoa,24,FRA,D,1.72,65,25/08/1987,Épernay,Sedan,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
195,Lamine Gassama,25,SEN,D,1.81,74,20/10/1989,Marseille,Lyon,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
196,Yohann Wachter,26,FRA,D,1.77,65,07/04/1992,Courbevoie,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
197,Enzo Reale,27,FRA,M,1.75,69,07/10/1991,Venissieux,Lyon,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
198,Maxime Barthelme,28,FRA,M,1.77,65,08/09/1988,Sartrouville,Racing Club de France,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
199,Cheick Touré,29,CIV,D,1.85,86,16/12/1992,Koukourandoumi,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
200,Florent Chaigneau,30,FRA,G,1.97,94,21/03/1984,La Roche-sur-Yon,Le Poiré-sur-Vie,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
201,Valentin Lavigne,31,FRA,F,1.71,72,04/06/1994,Lorient,None,Football Club Lorient-Bretagne Sud,50,100,false,100,10000,FCL
202,Anthony Lopes,1,POR,G,1.84,81,01/10/1990,Givors,None,Olympique Lyonnais,50,100,false,100,10000,OL
203,Mehdi Zeffane,2,FRA,D,1.74,63,19/05/1992,Sainte-Foy-lès-Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
204,Henri Bedimo Nsame,3,CMR,D,1.80,80,04/06/1984,Douala,Montpellier,Olympique Lyonnais,50,100,false,100,10000,OL
205,Bakari Koné,4,BFA,D,1.88,80,27/04/1988,Ouagadougou,Guingamp,Olympique Lyonnais,50,100,false,100,10000,OL
206,Milan Biševac,5,SRB,D,1.85,83,31/08/1983,Mitrovica,Paris St-Germain,Olympique Lyonnais,50,100,false,100,10000,OL
207,Gueïda Fofana,6,FRA,M,1.82,74,16/05/1991,Le Havre,Le Havre,Olympique Lyonnais,50,100,false,100,10000,OL
208,Clément Grenier,7,FRA,M,1.86,72,07/01/1991,Annonay,None,Olympique Lyonnais,50,100,false,100,10000,OL
209,Yoann Gourcuff,8,FRA,M,1.85,79,11/07/1986,Lorient,Bordeaux,Olympique Lyonnais,50,100,false,100,10000,OL
210,Alexandre Lacazette,10,FRA,F,1.74,69,28/05/1991,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
211,Rachid Ghezzal,11,FRA,M,1.82,65,09/05/1992,Décines-Charpieu,None,Olympique Lyonnais,50,100,false,100,10000,OL
212,Jordan Ferri,12,FRA,M,1.72,70,12/03/1992,Cavaillon,None,Olympique Lyonnais,50,100,false,100,10000,OL
213,Christophe Jallet,13,FRA,D,1.78,65,31/10/1983,Cognac,Paris St-Germain,Olympique Lyonnais,50,100,false,100,10000,OL
214,Mouhamadou Dabo,14,SEN,D,1.76,67,28/11/1986,Dakar,Sevilla,Olympique Lyonnais,50,100,false,100,10000,OL
215,Jérémy Frick,16,SUI,G,1.92,88,08/03/1993,Geneva,Genève-Servette-Carouge,Olympique Lyonnais,50,100,false,100,10000,OL
216,Steed Malbranque,17,FRA,M,1.72,73,06/01/1980,Mouscron,St-Etienne,Olympique Lyonnais,50,100,false,100,10000,OL
217,Nabil Fekir,18,FRA,M,1.73,72,18/07/1993,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
218,Mohamed Yattara,19,GUI,F,1.85,76,28/07/1993,Conakry,None,Olympique Lyonnais,50,100,false,100,10000,OL
219,Clinton N'Jie,20,CMR,F,1.75,68,15/08/1993,Douala,None,Olympique Lyonnais,50,100,false,100,10000,OL
220,Maxime Gonalons,21,FRA,M,1.87,76,10/03/1989,Vénissieux,None,Olympique Lyonnais,50,100,false,100,10000,OL
221,Lindsay Rose,22,FRA,D,1.84,79,08/02/1992,Rennes,Valenciennes,Olympique Lyonnais,50,100,false,100,10000,OL
222,Samuel Umtiti,23,FRA,D,1.81,75,14/11/1993,Yaoundé,None,Olympique Lyonnais,50,100,false,100,10000,OL
223,Corentin Tolisso,24,FRA,M,1.65,54,03/08/1994,Tarare,None,Olympique Lyonnais,50,100,false,100,10000,OL
224,Yassine Benzia,25,FRA,F,1.79,71,08/09/1994,Saint-Aubin Lès-Elbeuf,None,Olympique Lyonnais,50,100,false,100,10000,OL
225,Gaël Danic,26,FRA,M,1.76,65,19/11/1981,Vannes,Valenciennes,Olympique Lyonnais,50,100,false,100,10000,OL
226,Arnold Mvuemba,28,FRA,M,1.72,67,28/01/1985,Alencon,Lorient,Olympique Lyonnais,50,100,false,100,10000,OL
227,Fares Bahlouli,29,FRA,M,1.81,78,08/04/1995,Lyon,None,Olympique Lyonnais,50,100,false,100,10000,OL
228,Mathieu Gorgelin,30,FRA,G,1.87,83,05/08/1990,Ambérieu-en-Bugey,None,Olympique Lyonnais,50,100,false,100,10000,OL
229,Nicolas Nkoulou,3,CMR,D,1.80,77,27/03/1990,Yaoundé,Monaco,Olympique de Marseille,50,100,false,100,10000,OM
230,Dória,4,BRA,D,1.88,82,08/11/1994,São Gonçalo,Botafogo,Olympique de Marseille,50,100,false,100,10000,OM
231,Stéphane Sparagna,5,FRA,D,1.86,82,17/02/1995,Marseille,None,Olympique de Marseille,50,100,false,100,10000,OM
232,Momar Bangoura,6,FRA,M,1.76,65,24/02/1994,Dakar,None,Olympique de Marseille,50,100,false,100,10000,OM
233,Benoît Cheyrou,7,FRA,M,1.82,78,03/05/1981,Suresnes,Auxerre,Olympique de Marseille,50,100,false,100,10000,OM
234,Mario Lemina,8,FRA,M,1.84,76,01/09/1993,Libreville,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
235,André-Pierre Gignac,9,FRA,F,1.87,84,12/05/1985,Martigues,Toulouse,Olympique de Marseille,50,100,false,100,10000,OM
236,André Ayew,10,GHA,F,1.76,72,17/12/1989,Seclin,None,Olympique de Marseille,50,100,false,100,10000,OM
237,Romain Alessandrini,11,FRA,M,1.66,60,03/04/1989,Marseille,Rennes,Olympique de Marseille,50,100,false,100,10000,OM
238,Florian Thauvin,14,FRA,M,1.79,70,26/01/1993,Orléans,Lille,Olympique de Marseille,50,100,false,100,10000,OM
239,Jérémy Morel,15,FRA,D,1.72,71,02/04/1984,Lorient,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
240,Brice Samba,16,CGO,G,1.86,79,25/04/1994,Linzolo,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
241,Dimitri Payet,17,FRA,F,1.74,70,29/03/1987,St-Pierre de la Réunion,Lille,Olympique de Marseille,50,100,false,100,10000,OM
242,Alaixys Romao,20,TOG,M,1.80,74,18/01/1984,L'Hay-les-Roses,Lorient,Olympique de Marseille,50,100,false,100,10000,OM
243,Michy Batshuayi,22,BEL,F,1.80,78,02/10/1993,Brussels,Standard Liège,Olympique de Marseille,50,100,false,100,10000,OM
244,Benjamin Mendy,23,FRA,D,1.80,72,17/07/1994,Longjumeau,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
245,Rod Fanni,24,FRA,D,1.86,78,06/12/1981,Martigues,Rennes,Olympique de Marseille,50,100,false,100,10000,OM
246,Gianelli Imbula,25,CGO,M,1.83,77,12/09/1992,Vilvoorde,Guingamp,Olympique de Marseille,50,100,false,100,10000,OM
247,Brice Dja Djedje,26,CIV,D,1.76,70,23/12/1990,Abidjan,Évian TG,Olympique de Marseille,50,100,false,100,10000,OM
248,Abdelaziz Barrada,27,MAR,M,1.79,73,19/06/1989,Provins,Al-Jazira,Olympique de Marseille,50,100,false,100,10000,OM
249,Jérémie Porsan-Clemente,29,FRA,F,1.78,73,16/12/1997,Schœlcher,None,Olympique de Marseille,50,100,false,100,10000,OM
250,Steve Mandanda,30,FRA,G,1.85,82,28/03/1985,Kinshasa,Le Havre,Olympique de Marseille,50,100,false,100,10000,OM
251,Johann Carrasso,1,FRA,G,1.85,79,07/05/1988,Avignon,Rennes,Football Club de Metz,50,100,false,100,10000,FCM
252,Jonathan Rivierez,3,FRA,D,1.81,79,18/05/1989,Le Blanc-Mesnil,Le Havre,Football Club de Metz,50,100,false,100,10000,FCM
253,Sylvain Marchal,4,FRA,D,1.84,80,10/02/1980,Langres,Bastia,Football Club de Metz,50,100,false,100,10000,FCM
254,Guido Milan,5,ARG,D,1.94,93,03/07/1987,Haedo,Atlanta,Football Club de Metz,50,100,false,100,10000,FCM
255,Romain Rocchi,7,FRA,M,1.83,75,02/10/1981,Cavaillon,Arles-Avignon,Football Club de Metz,50,100,false,100,10000,FCM
256,Cheick Doukouré,8,FRA,M,1.80,72,11/09/1992,Abidjan,Lorient,Football Club de Metz,50,100,false,100,10000,FCM
257,Juan Manuel Falcón,9,VEN,F,1.79,81,24/02/1989, Acarigua,Zamora,Football Club de Metz,50,100,false,100,10000,FCM
258,Bouna Sarr,10,FRA,M,1.77,65,31/01/1992,Lyon,None,Football Club de Metz,50,100,false,100,10000,FCM
259,Federico Andrada,11,ARG,F,1.79,74,03/03/1994,Carapachay,River Plate,Football Club de Metz,50,100,false,100,10000,FCM
260,Kwamé Nsor,12,GHA,F,1.88,76,01/08/1992,Accra,Kaiserslautern,Football Club de Metz,50,100,false,100,10000,FCM
261,Florent Malouda,13,FRA,M,1.81,73,13/06/1980,Cayenne,Trabzonspor,Football Club de Metz,50,100,false,100,10000,FCM
262,Fadil Sido,14,BFA,M,1.70,65,13/04/1993,Ouagadougou,Le Mans,Football Club de Metz,50,100,false,100,10000,FCM
263,Romain Métanire,15,FRA,D,1.78,72,28/03/1990,Metz,None,Football Club de Metz,50,100,false,100,10000,FCM
264,Anthony Mfa Mezui,16,GAB,G,1.82,91,07/03/1991,Beauvais,None,Football Club de Metz,50,100,false,100,10000,FCM
265,Maxwel Cornet,17,FRA,F,1.79,69,27/09/1996,Bregbo,None,Football Club de Metz,50,100,false,100,10000,FCM
266,Jérémy Choplin,18,FRA,D,1.83,70,09/02/1985,Le Mans,Bastia,Football Club de Metz,50,100,false,100,10000,FCM
267,Thibaut Vion,19,FRA,F,1.85,68,11/12/1993,Mont-Saint-Martin,FC Porto,Football Club de Metz,50,100,false,100,10000,FCM
268,Modibo Maïga,20,MLI,F,1.85,76,03/09/1986,Bamako,West Ham U,Football Club de Metz,50,100,false,100,10000,FCM
269,Ahmed Kashi,21,FRA,M,1.78,76,18/11/1988,Aubervilliers,Châteauroux,Football Club de Metz,50,100,false,100,10000,FCM
270,Kévin Lejeune,22,FRA,M,1.81,76,22/01/1985,Cambrai,Tours,Football Club de Metz,50,100,false,100,10000,FCM
271,Yeni Atito Ngbakoto,23,FRA,M,1.72,71,23/01/1992,Croix,None,Football Club de Metz,50,100,false,100,10000,FCM
272,Gaétan Bussmann,24,FRA,D,1.84,75,02/02/1991,Épinal,None,Football Club de Metz,50,100,false,100,10000,FCM
273,Guirane N'Daw,25,SEN,M,1.89,79,24/04/1984,Rufisque,Asteras Tripolis,Football Club de Metz,50,100,false,100,10000,FCM
274,Chris Philipps,26,LUX,D,1.82,72,08/03/1994,Wiltz,None,Football Club de Metz,50,100,false,100,10000,FCM
275,José Luis Palomino,27,ARG,D,1.86,87,05/01/1990,San Miguel de Tucumán,Argentinos Juniors,Football Club de Metz,50,100,false,100,10000,FCM
276,Mayoro N'Doye-Baye,28,SEN,M,1.76,67,18/12/1991,Mbao,None,Football Club de Metz,50,100,false,100,10000,FCM
277,Sergey Krivets,29,BLR,M,1.77,77,08/06/1986,Grodno,BATE,Football Club de Metz,50,100,false,100,10000,FCM
278,David Oberhauser,30,FRA,G,1.83,75,29/11/1989,Bitche,UTA Arad,Football Club de Metz,50,100,false,100,10000,FCM
279,Danijel Subaši?,1,CRO,G,1.92,84,27/10/1984,Zadar,Hajduk Split,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
280,Fabinho,2,BRA,D,1.87,78,23/10/1993,Campinas,Rio Ave,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
281,Layvin Kurzawa,3,FRA,D,1.81,73,04/09/1992,Fréjuis,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
282,Borja López,4,ESP,D,1.92,83,02/02/1994,Gijón,Sporting Gijón,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
283,Aymen Abdennour,5,TUN,D,1.87,84,06/08/1989,Sousse,Toulouse,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
284,Ricardo Carvalho,6,POR,D,1.83,76,18/05/1978,Amarante,Real Madrid,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
285,Nabil Dirar,7,MAR,M,1.82,79,25/02/1986,Casablanca,Club Brugge,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
286,João Moutinho,8,POR,M,1.70,61,08/09/1986,Portimão,FC Porto,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
287,Dimitar Berbatov,10,BUL,F,1.88,79,30/01/1981,Blagoevgrad,Fulham,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
288,Lucas Ocampos,11,ARG,M,1.87,82,11/07/1994,Quilmes,River Plate,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
289,Wallace,13,BRA,D,1.91,78,14/10/1994,Rio de Janeiro,Sporting Braga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
290,Tiemoué Bakayoko,14,FRA,M,1.85,77,17/08/1994,Paris,Rennes,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
291,Bernardo Silva,15,POR,M,1.73,62,10/08/1994,Lisbon,Benfica,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
292,Maarten Stekelenburg,16,NED,G,1.97,92,22/09/1982,Haarlem,Fulham,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
293,Yannick Ferreira Carrasco,17,BEL,M,1.80,67,04/09/1993,Elsene,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
294,Valère Germain,18,FRA,F,1.81,75,17/04/1990,Marseille,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
295,Lacina Traoré,19,CIV,F,1.86,75,20/08/1990,Abidjan,Anzhi Makhachkala,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
296,Elderson Uwa Echiejile,21,NGA,D,1.84,76,20/01/1988,Cotonou,Sporting Braga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
297,Geoffrey Kondogbia,22,FRA,M,1.83,71,25/04/1993,Saint-Denis,Sevilla,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
298,Anthony Martial,23,FRA,F,1.81,76,05/12/1995,Massy,Lyon,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
299,Andrea Raggi,24,ITA,D,1.87,82,24/06/1984,Carrara,Bologna,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
300,Jérémy Toulalan,28,FRA,M,1.83,77,10/09/1983,Nantes,Málaga,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
301,Dylan Bahamboula,29,FRA,M,1.85,65,22/05/1995,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
302,Seydou Sy,30,SEN,G,1.92,80,12/12/1995,Dakar,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
303,Abdou Diallo,34,FRA,D,1.83,72,04/05/1996,Tours,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
304,Aboud Aziz Thiam,37,FRA,M,1.80,62,15/01/1997,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
305,Almary Touré,38,MLI,D,1.82,72,28/04/1996,,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
306,Marc-Aurèle Caillard,40,FRA,G,1.91,79,12/05/1994,Melun,None,Association Sportive de Monaco FC,50,100,false,100,10000,ASM
307,Laurent Pionnier,1,FRA,G,1.84,76,24/05/1982,Bagnois sur Cèze,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
308,Daniel Congré,3,FRA,D,1.84,79,05/04/1985,Toulouse,Toulouse,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
309,Hilton,4,BRA,D,1.82,73,13/09/1977,Brasilia,Marseille,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
310,Siaka Tiéné,5,CIV,D,1.76,72,22/02/1982,Abidjan,Paris St-Germain,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
311,Joris Marveaux,6,FRA,M,1.78,69,15/08/1982,Vannes,Clermont,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
312,Anthony Mounier,7,FRA,F,1.74,65,27/09/1987,Aubenas,Nice,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
313,Jonas Martin,8,FRA,M,1.82,70,09/04/1990,Besançon,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
314,Kévin Bérigaud,9,FRA,F,1.78,69,03/03/1984,Thonon-les-Bains,Évian TG,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
315,Lucas Barrios,10,PAR,F,1.87,87,13/11/1984,San Fernando,Spartak Moscow,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
316,Victor Hugo Montaño,11,COL,F,1.77,76,01/05/1984,Cali,Rennes,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
317,Dylan Gissi,13,SUI,D,1.92,79,27/04/1991,Geneva,Olimpo (BB),Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
318,Bryan Dabo,14,FRA,M,1.85,75,18/02/1992,Marseille,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
319,Geoffrey Jourdren,16,FRA,G,1.81,73,04/02/1986,Paris,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
320,Paul Lasne,17,FRA,M,1.83,72,16/01/1989,Saint-Cloud,Ajaccio,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
321,Karim Aït-Fana,18,MAR,F,1.75,65,25/02/1989,Limoges,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
322,Souleymane Camara,19,SEN,F,1.74,72,22/12/1982,Dakar,Nice,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
323,Morgan Sanson,20,FRA,M,1.82,70,18/08/1994,Saint-Doulchard,Le Mans,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
324,Abdelhamid El Kaoutari,21,MAR,D,1.80,73,17/03/1990,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
325,Jamel Saihi,23,TUN,M,1.81,73,27/01/1987,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
326,Jean Deza,24,PER,F,1.81,71,09/06/1993,Callao,Universidad San Martín,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
327,Mathieu Deplagne,25,FRA,D,1.80,66,01/10/1991,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
328,Yassine Jebbour,26,MAR,D,1.80,70,24/08/1991,Poitiers,Rennes,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
329,Steve Mounié,27,BEN,F,1.90,80,29/09/1994,Parakou,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
330,Djamel Bakar,28,FRA,F,1.71,67,06/04/1989,Marseille,Nancy,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
331,Gianni Seraf,29,FRA,M,1.69,65,05/07/1994,Thiais,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
332,Jonathan Ligali,30,FRA,G,1.83,82,28/05/1991,Montpellier,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
333,Quentin Cornette,31,FRA,F,1.72,75,17/01/1994,La Ciotat,None,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
334,Nicolas Saint-Ruf,32,FRA,D,1.87,81,24/10/1992,Rouen,Lens,Montpellier-Herault Sports Club,50,100,false,100,10000,MHSC
335,Rémy Riou,1,FRA,G,1.91,81,06/08/1987,Lyon,Toulouse,Football Club de Nantes,50,100,false,100,10000,FCN
336,Kian Hansen,2,DEN,D,1.84,74,03/03/1989,Grindsted,Esbjerg,Football Club de Nantes,50,100,false,100,10000,FCN
337,Papy Mison Djilobodji,3,SEN,D,1.93,82,01/12/1988,Kaolack,Sénart-Moissy,Football Club de Nantes,50,100,false,100,10000,FCN
338,Oswaldo Vizcarrondo,4,VEN,D,1.91,86,31/05/1984,Caracas,América,Football Club de Nantes,50,100,false,100,10000,FCN
339,Olivier Veigneau,5,FRA,D,1.74,69,16/07/1985,Suresnes,Duisburg,Football Club de Nantes,50,100,false,100,10000,FCN
340,Rémi Gomis,6,SEN,M,1.80,64,14/02/1984,Versailles,Levante,Football Club de Nantes,50,100,false,100,10000,FCN
341,Alejandro Bedoya,7,USA,M,1.78,73,29/04/1987,Weston,Helsingborgs IF,Football Club de Nantes,50,100,false,100,10000,FCN
342,Vincent Bessat,8,FRA,M,1.78,73,08/11/1985,Lyon,Boulogne,Football Club de Nantes,50,100,false,100,10000,FCN
343,Itay Shechter,9,ISR,F,1.80,77,22/02/1987,Ramat Yishai,Hapoel Tel Aviv,Football Club de Nantes,50,100,false,100,10000,FCN
344,Fernando Aristeguieta,10,VEN,F,1.87,80,09/04/1992,Caracas,Caracas,Football Club de Nantes,50,100,false,100,10000,FCN
345,Ismaël Bangoura,11,GUI,F,1.74,72,02/01/1985,Conakry,Al-Nasr [UAE],Football Club de Nantes,50,100,false,100,10000,FCN
346,Birama Touré,12,MLI,M,1.83,75,06/06/1992,Kayes,Beauvais,Football Club de Nantes,50,100,false,100,10000,FCN
347,Serge Gakpé,13,TOG,M,1.77,79,07/05/1987,Bondy,Monaco,Football Club de Nantes,50,100,false,100,10000,FCN
348,Georges-Kevin Nkoudou,14,FRA,M,1.73,68,13/02/1995,Versailles,None,Football Club de Nantes,50,100,false,100,10000,FCN
349,Léo Dubois,15,FRA,D,1.78,65,14/09/1994,Segré,None,Football Club de Nantes,50,100,false,100,10000,FCN
350,Erwin Zelazny,16,FRA,G,1.86,80,22/09/1991,Grande-Synthe,None,Football Club de Nantes,50,100,false,100,10000,FCN
351,Lucas Deaux,18,FRA,M,1.86,77,26/12/1988,Reims,Reims,Football Club de Nantes,50,100,false,100,10000,FCN
352,Abdoulaye Touré,19,FRA,M,1.87,77,03/03/1994,Nantes,None,Football Club de Nantes,50,100,false,100,10000,FCN
353,Amine Oudrhiri,20,FRA,M,1.84,75,04/11/1992,Ermont,Red Star 93,Football Club de Nantes,50,100,false,100,10000,FCN
354,Johan Audel,21,FRA,F,1.80,73,12/12/1983,Nice,Stuttgart,Football Club de Nantes,50,100,false,100,10000,FCN
355,Issa Cissokho,22,FRA,D,1.73,73,23/02/1985,Paris,Carquefou,Football Club de Nantes,50,100,false,100,10000,FCN
356,Yacine Bammou,23,FRA,F,1.88,78,11/09/1991,Paris,Évry,Football Club de Nantes,50,100,false,100,10000,FCN
357,Chaker Alhadhur,24,COM,D,1.71,56,04/12/1991,Nantes,None,Football Club de Nantes,50,100,false,100,10000,FCN
358,Jordan Veretout,25,FRA,M,1.76,66,01/03/1993,Ancenis,None,Football Club de Nantes,50,100,false,100,10000,FCN
359,Koffi Djidji,26,FRA,D,1.84,71,30/11/1992,Bagnolet,None,Football Club de Nantes,50,100,false,100,10000,FCN
360,Valentin Rongier,28,FRA,M,1.72,66,07/12/1994,Mâcon,None,Football Club de Nantes,50,100,false,100,10000,FCN
361,Maxime Dupé,30,FRA,G,1.86,85,04/03/1993,Malestroit,None,Football Club de Nantes,50,100,false,100,10000,FCN
362,Mouez Hassan,1,FRA,G,1.85,74,05/03/1995,Fréjus,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
363,Carlos Eduardo,3,BRA,M,1.83,72,17/10/1989,Sorocaba,FC Porto,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
364,Kevin Gomis,5,FRA,D,1.86,85,20/01/1989,Paris,Naval,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
365,Didier Digard,6,FRA,M,1.83,76,12/07/1986,Gisors,Middlesbrough,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
366,Julien Vercauteren,7,BEL,M,1.70,66,12/01/1993,Sint-Agatha-Berchem,Lierse,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
367,Mahamane Traoré,8,MLI,M,1.76,66,31/08/1988,Bamako,CO Bamako,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
368,Xavier Pentecôte,9,FRA,F,1.80,77,13/08/1986,St Dié,Toulouse,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
369,Valentin Eysseric,10,FRA,M,1.81,73,25/03/1992,Aix-en-Provence,Monaco,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
370,Eric Bauthéac,11,FRA,M,1.65,65,24/08/1987,Bagnols-sur-Cèze,Dijon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
371,Darío Cvitanich,12,ARG,F,1.75,67,16/05/1984,Baradero,Ajax,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
372,Niklas Hult,13,SWE,M,1.73,65,13/02/1990,Värnamo,IF Elfsborg,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
373,Alassane Pléa,14,FRA,M,1.80,72,10/03/1993,Lille,Lyon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
374,Grégoire Puel,15,FRA,D,1.80,67,20/02/1992,Nice,Lyon,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
375,Simon Pouplin,16,FRA,G,1.87,79,28/05/1985,Cholet,Sochaux,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
376,Neal Maupay,18,FRA,F,1.71,69,14/08/1996,Versailles,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
377,Jordan Amavi,19,FRA,D,1.76,70,09/03/1994,Toulon,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
378,Souleymane Diawara,20,SEN,D,1.87,88,24/12/1978,Gabou,Marseille,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
379,Lloyd Palun,21,GAB,D,1.84,73,28/11/1988,Arles,Trinité FC,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
380,Nampalys Mendy,22,FRA,M,1.68,68,23/06/1992,La Seyne-sur-Mer,Monaco,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
381,Alexy Bosetti,23,FRA,F,1.72,66,23/04/1993,Nice,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
382,Mathieu Bodmer,24,FRA,D,1.90,91,22/11/1982,Evreux,Paris St-Germain,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
383,Romain Genevois,25,HAI,D,1.80,66,28/10/1987,L'Estère,Tours,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
384,Bryan Constant,27,FRA,F,1.72,65,27/03/1994,Fréjus,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
385,Fabien Dao Castellana,28,FRA,M,1.69,61,28/07/1993,Saint-Raphaël,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
386,Joris Delle,30,FRA,G,1.90,84,29/03/1990,Briey,Metz,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
387,Moussa M'Bow,31,SEN,D,1.92,80,07/02/1992,Gwediawayé,None,Olympique Gymnaste Club Nice Côte d'Azur,50,100,false,100,10000,OGCN
388,Nicolas Douchez,1,FRA,G,1.85,77,22/04/1980,Rasny-sous-Bois,Rennes,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
389,Thiago Silva,2,BRA,D,1.83,79,22/09/1984,Rio de Janeiro,Milan,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
390,Yohan Cabaye,4,FRA,M,1.75,72,14/01/1986,Tourcoing,Newcastle U,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
391,Marquinhos,5,BRA,D,1.81,67,14/05/1994,São Paulo,Roma,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
392,Zoumana Camara,6,FRA,D,1.82,76,03/04/1979,Colombes,St-Etienne,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
393,Lucas,7,BRA,M,1.72,66,13/08/1992,São Paulo,São Paulo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
394,Thiago Motta,8,ITA,M,1.88,77,28/08/1982,São Bernardo do Campo,Internazionale,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
395,Edinson Cavani,9,URU,F,1.84,71,14/02/1987,Montevideo,Napoli,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
396,Zlatan Ibrahimovi?,10,SWE,F,1.92,84,03/10/1981,Malmö,Milan,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
397,Blaise Matuidi,14,FRA,M,1.75,70,09/04/1987,Toulouse,St-Etienne,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
398,Jean-Christophe Bahebeck,15,FRA,F,1.82,70,01/05/1993,Saint-Denis,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
399,Mike Maignan,16,FRA,G,1.87,80,03/07/1995,Cayenne,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
400,Maxwell,17,BRA,D,1.75,73,27/08/1981,Vila Velha,Barcelona,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
401,Serge Aurier,19,CIV,D,1.75,75,24/12/1992,Abidjan,Toulouse,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
402,Clément Chantôme,20,FRA,M,1.80,71,11/09/1987,Sens,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
403,Lucas Digne,21,FRA,D,1.84,75,20/07/1993,Meaux,Lille,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
404,Ezequiel Lavezzi,22,ARG,F,1.73,75,03/05/1985,Villa Gobernador Gálvez,Napoli,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
405,Gregory van der Wiel,23,NED,D,1.81,68,03/02/1988,Amsterdam,Ajax,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
406,Marco Verratti,24,ITA,M,1.65,60,05/11/1992,Pescara,Pescara,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
407,Adrien Rabiot,25,FRA,M,1.88,71,03/04/1995,Saint-Maurice,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
408,Javier Pastore,27,ARG,M,1.87,75,20/06/1989,Córdoba,Palermo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
409,Salvatore Sirigu,30,ITA,G,1.90,80,12/01/1987,Nuoro,Palermo,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
410,David Luiz,32,BRA,D,1.89,84,22/04/1987,São Paulo,Chelsea,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
411,Mory Diaw,40,FRA,G,1.95,95,22/06/1993,Poissy,None,Paris-Saint-Germain Football Club,50,100,false,100,10000,PSG
412,Sacha Bastien,1,FRA,G,1.93,85,22/01/1995,Metz,Sedan,Stade de Reims,50,100,false,100,10000,SDR
413,Mohamed Fofana,2,MLI,D,1.81,75,07/03/1985,Gonesse,Toulouse,Stade de Reims,50,100,false,100,10000,SDR
414,Franck Signorino,3,ITA,D,1.73,60,19/09/1981,Nogent-sur-Marne,Laval,Stade de Reims,50,100,false,100,10000,SDR
415,Valentin Roberge,4,FRA,D,1.85,73,09/06/1987,Montreuil,Sunderland,Stade de Reims,50,100,false,100,10000,SDR
416,Grégory Bourillon,5,FRA,M,1.87,74,01/07/1984,Laval,Lorient,Stade de Reims,50,100,false,100,10000,SDR
417,Antoine Devaux,6,FRA,M,1.85,70,21/02/1985,Dieppe,Toulouse,Stade de Reims,50,100,false,100,10000,SDR
418,Odaïr Fortes,7,CPV,F,1.82,70,31/03/1987,Alfortville,Alfortville,Stade de Reims,50,100,false,100,10000,SDR
419,Prince Oniangue,8,FRA,M,1.90,78,04/11/1988,Paris,Tours,Stade de Reims,50,100,false,100,10000,SDR
420,Eliran Atar,9,ISR,F,1.79,73,17/02/1987,Tel Aviv,Maccabi Tel Aviv,Stade de Reims,50,100,false,100,10000,SDR
421,Gaëtan Charbonnier,10,FRA,F,1.88,80,27/12/1988,Saint-Mandé,Montpellier,Stade de Reims,50,100,false,100,10000,SDR
422,Diego,11,BRA,F,1.75,72,09/03/1988,Americana,Tours,Stade de Reims,50,100,false,100,10000,SDR
423,Nicolas De Préville,12,FRA,F,1.82,77,08/01/1991,Istres,Istres,Stade de Reims,50,100,false,100,10000,SDR
424,Benjamin Moukandjo,14,CMR,F,1.79,76,12/11/1988,Douala,Nancy,Stade de Reims,50,100,false,100,10000,SDR
425,Chris Mavinga,15,FRA,D,1.83,78,26/05/1991,Meaux,Rubin Kazan,Stade de Reims,50,100,false,100,10000,SDR
426,Kossi Agassa,16,TOG,G,1.90,86,07/07/1978,Lomé,Hércules,Stade de Reims,50,100,false,100,10000,SDR
427,Mads Albæk,17,DEN,M,1.82,76,14/01/1990,Roskilde,FC Midtjylland,Stade de Reims,50,100,false,100,10000,SDR
428,Gaëtan Courtet,18,FRA,F,1.80,72,22/02/1989,Lorient,Lorient,Stade de Reims,50,100,false,100,10000,SDR
429,Alexi Peuget,19,FRA,M,1.86,75,18/12/1990,Mulhouse,Strasbourg,Stade de Reims,50,100,false,100,10000,SDR
430,Yann Benedick,20,FRA,F,1.76,73,01/02/1992,Strasbourg,Strasbourg,Stade de Reims,50,100,false,100,10000,SDR
431,Bocundji Ca,21,GNB,M,1.72,69,28/12/1986,Biombo,Nancy,Stade de Reims,50,100,false,100,10000,SDR
432,Mickaël Tacalfred,22,FRA,D,1.75,69,23/04/1981,Colombes,Dijon,Stade de Reims,50,100,false,100,10000,SDR
433,Aïssa Mandi,23,ALG,D,1.86,78,22/10/1991,Châlons-en-Champagne,None,Stade de Reims,50,100,false,100,10000,SDR
434,David N'Gog,24,FRA,F,1.90,79,01/04/1989,Gennevilliers,Swansea C,Stade de Reims,50,100,false,100,10000,SDR
435,Anthony Weber,25,FRA,D,1.90,82,11/06/1987,Strasbourg,Paris FC,Stade de Reims,50,100,false,100,10000,SDR
436,Omenuke Mfulu,26,COD,D,1.82,69,20/03/1994,,Lille,Stade de Reims,50,100,false,100,10000,SDR
437,Christopher Glombard,27,FRA,D,1.78,74,05/06/1989,Montreuil,Bordeaux,Stade de Reims,50,100,false,100,10000,SDR
438,Antoine Conte,28,FRA,D,1.79,73,29/01/1994,Paris,Paris St-Germain,Stade de Reims,50,100,false,100,10000,SDR
439,Grejohn Kiey,29,FRA,F,1.87,84,12/08/1995,,None,Stade de Reims,50,100,false,100,10000,SDR
440,Johnny Placide,30,HAI,G,1.81,84,29/01/1988,Montfermeil,Le Havre,Stade de Reims,50,100,false,100,10000,SDR
441,Benoît Costil,1,FRA,G,1.87,83,03/07/1987,Caen,Sedan,Stade Rennais Football Club,50,100,false,100,10000,SRFC
442,Cheikh M'Bengué,3,SEN,D,1.83,75,23/07/1988,Toulouse,Toulouse,Stade Rennais Football Club,50,100,false,100,10000,SRFC
443,Mexer,4,MOZ,D,1.81,75,08/09/1985,Maputo,Nacional [POR],Stade Rennais Football Club,50,100,false,100,10000,SRFC
444,Jean-Armel Kana-Biyik,5,CMR,D,1.83,86,03/07/1989,Metz,Le Havre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
445,Gelson Fernandes,6,SUI,M,1.83,70,02/09/1986,Praia,Freiburg,Stade Rennais Football Club,50,100,false,100,10000,SRFC
446,Paul-Georges Ntep,7,FRA,F,1.80,75,29/07/1992,Douala,Auxerre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
447,Abdoulaye Doucouré,8,FRA,M,1.82,69,01/01/1993,Meulan-en-Yvelines,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
448,Ola Toivonen,9,SWE,F,1.90,74,03/07/1986,Degerfors,PSV Eindhoven,Stade Rennais Football Club,50,100,false,100,10000,SRFC
449,Kamil Grosicki,10,POL,M,1.80,78,08/06/1988,Szczecin,Sivasspor,Stade Rennais Football Club,50,100,false,100,10000,SRFC
450,Philipp Hosiner,11,AUT,F,1.79,75,15/05/1989,Eisenstadt,Austria Vienna,Stade Rennais Football Club,50,100,false,100,10000,SRFC
451,Steven Moreira,12,FRA,D,1.76,67,13/08/1994,Noisy-le-Grand,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
452,Fallou Diagné,14,SEN,D,1.85,75,14/08/1989,Pikine,Freiburg,Stade Rennais Football Club,50,100,false,100,10000,SRFC
453,Jean II Makoun,15,CMR,M,1.73,69,29/05/1983,Yaoundé,Aston Villa,Stade Rennais Football Club,50,100,false,100,10000,SRFC
454,Olivier Sorin,16,FRA,G,1.88,76,16/04/1981,Gien,Auxerre,Stade Rennais Football Club,50,100,false,100,10000,SRFC
455,Vincent Pajot,17,FRA,M,1.76,64,19/08/1990,Domont,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
456,Pedro Henrique,18,BRA,M,1.79,72,16/06/1990,Novo Hamburgo,Zürich,Stade Rennais Football Club,50,100,false,100,10000,SRFC
457,Adrien Hunou,19,FRA,M,1.78,66,19/01/1994,Evry,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
458,Axel Ngando,20,FRA,M,1.77,66,13/07/1993,Asnières-sur-Seine,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
459,Benjamin André,21,FRA,D,1.77,68,03/08/1990,Nice,Ajaccio,Stade Rennais Football Club,50,100,false,100,10000,SRFC
460,Sylvain Armand,22,FRA,D,1.82,82,01/08/1980,Saint-Etienne,Paris St-Germain,Stade Rennais Football Club,50,100,false,100,10000,SRFC
461,Anders Konradsen,23,NOR,M,1.85,79,18/07/1990,Bodø,Strømsgodset,Stade Rennais Football Club,50,100,false,100,10000,SRFC
462,Sanjin Prci?,24,BIH,M,1.81,73,20/11/1993,Belfort,Sochaux,Stade Rennais Football Club,50,100,false,100,10000,SRFC
463,Zana Allée,25,FRA,M,1.72,66,29/04/1996,Baghdad,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
464,Mahamadou Habib Habibou,27,CTA,F,1.92,80,16/04/1987,Bria,KAA Gent,Stade Rennais Football Club,50,100,false,100,10000,SRFC
465,Gjoko Zajkov,28,MKD,D,1.86,78,10/02/1995,Skopje,Rabotni?ki Skopje,Stade Rennais Football Club,50,100,false,100,10000,SRFC
466,Romain Danzé,29,FRA,D,1.84,72,03/07/1986,Douarnenez,None,Stade Rennais Football Club,50,100,false,100,10000,SRFC
467,Baptiste Valette,1,FRA,G,1.85,80,01/09/1992,Sète,Montpellier,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
468,Kévin Theophile Catherine,2,FRA,D,1.80,77,28/10/1989,Saint Brieuc,Cardiff C,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
469,Jérémy Clément,6,FRA,M,1.74,61,26/08/1984,Béziers,Paris St-Germain,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
470,Max Gradel,7,CIV,F,1.80,70,30/11/1987,Abidjan,Leeds U,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
471,Benjamin Corgnet,8,FRA,M,1.80,75,06/04/1987,Thionville,Lorient,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
472,Mevlüt Erdinç,9,TUR,F,1.81,85,25/02/1987,Saint-Claude,Rennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
473,Renaud Cohade,10,FRA,M,1.80,74,29/09/1984,Aubenas,Valenciennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
474,Yohan Mollo,11,FRA,F,1.75,74,18/07/1989,Martigues,Nancy,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
475,Allan Saint-Maximin,12,FRA,F,1.73,67,12/03/1997,Châtenay-Malabry,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
476,Ricky van Wolfswinkel,13,NED,F,1.85,69,27/01/1989,Amersfoort,Norwich C,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
477,Stéphane Ruffier,16,FRA,G,1.87,89,27/09/1986,Bayonne,Monaco,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
478,Fabien Lemoine,18,FRA,M,1.75,67,16/03/1987,Fougères,Rennes,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
479,Florentin Pogba,19,GUI,D,1.88,87,19/08/1990,Conakry,Sedan,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
480,Jonathan Brison,20,FRA,D,1.79,73,07/02/1983,Soissons,Nancy,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
481,Romain Hamouma,21,FRA,M,1.77,67,29/03/1987,Lure,Caen,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
482,Kévin Monnet-Paquet,22,FRA,F,1.83,73,19/08/1988,Bourgoin-Jallieu,Lorient,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
483,Paul Baysse,23,FRA,D,1.84,82,15/05/1988,Bordeaux,Brest,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
484,Loïc Perrin,24,FRA,D,1.80,76,07/08/1985,Saint-Etienne,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
485,Moustapha Bayal Sall,26,SEN,D,1.90,90,30/11/1985,Dakar,US Gorée,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
486,Franck Tabanou,27,FRA,M,1.78,70,30/01/1989,Thiais,Toulouse,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
487,Ismaël Diomande,28,CIV,M,1.80,75,28/08/1992,Abidjan,None,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
488,François Clerc,29,FRA,D,1.86,77,18/04/1983,Bourg en Bresse,Nice,Association Sportive de St-Etienne,50,100,false,100,10000,ASSE
489,Jessy Moulin,30,FRA,G,1.84,80,13/01/1986,Valence,None,Association Sportive de St-Etienne,50,100,false,100,10000,TFC
490,Zacharie Boucher,1,FRA,G,1.80,74,07/03/1992,St Pierre,Le Havre,Toulouse Football Club,50,100,false,100,10000,TFC
491,Maxime Spano,2,FRA,D,1.84,79,31/10/1994,Aubagne,ES Pennoise,Toulouse Football Club,50,100,false,100,10000,TFC
492,Tongo Doumbia,4,MLI,M,1.90,79,06/08/1989,Vernon,Wolverhampton W,Toulouse Football Club,50,100,false,100,10000,TFC
493,Issiaga Sylla,5,GUI,D,1.80,70,01/01/1994,Conakry,Horoya AC,Toulouse Football Club,50,100,false,100,10000,TFC
494,William Matheus,6,BRA,D,1.87,85,02/04/1990,Rio de Janeiro,Palmeiras,Toulouse Football Club,50,100,false,100,10000,TFC
495,Jean-Daniel Akpa Akpro,7,CIV,D,1.80,66,11/10/1992,Toulouse,None,Toulouse Football Club,50,100,false,100,10000,TFC
496,Etienne Didot,8,FRA,M,1.75,65,24/07/1983,Paimpol,Rennes,Toulouse Football Club,50,100,false,100,10000,TFC
497,Martin Braithwaite,9,DEN,F,1.79,77,05/06/1991,Esbjerg,Esbjerg,Toulouse Football Club,50,100,false,100,10000,TFC
498,Wissam Ben Yedder,10,FRA,F,1.70,68,12/08/1990,Sarcelles,Alfortville,Toulouse Football Club,50,100,false,100,10000,TFC
499,Aleksandar Peši?,11,SRB,F,1.90,83,21/05/1992,Niš,Jagodina,Toulouse Football Club,50,100,false,100,10000,TFC
500,Florian David,12,FRA,F,1.80,71,16/11/1992,Champigny-sur-Marne,None,Toulouse Football Club,50,100,false,100,10000,TFC
501,Dominik Furman,13,POL,M,1.81,71,06/07/1992,Szyd?owiec,Legia Warszawa,Toulouse Football Club,50,100,false,100,10000,TFC
502,François Sirieix,14,FRA,M,1.80,72,07/10/1980,Bordeaux,Auxerre,Toulouse Football Club,50,100,false,100,10000,TFC
503,Uroš Spaji?,15,SRB,D,1.86,76,13/02/1993,Belgrade,Crvena Zvezda,Toulouse Football Club,50,100,false,100,10000,TFC
504,Marc Vidal,16,FRA,G,1.87,80,03/06/1991,Saint-Affrique,None,Toulouse Football Club,50,100,false,100,10000,TFC
505,Adrien Regattin,17,MAR,M,1.66,67,22/08/1991,Sète,Sète,Toulouse Football Club,50,100,false,100,10000,TFC
506,Óscar Trejo,18,ARG,M,1.80,79,26/04/1988,Santiago del Estero,Sporting Gijón,Toulouse Football Club,50,100,false,100,10000,TFC
507,Steeve Yago,20,FRA,D,1.80,72,16/12/1992,Sarcelles,None,Toulouse Football Club,50,100,false,100,10000,TFC
508,Abel Aguilar,21,COL,M,1.85,82,06/01/1985,Santa Fe de Bogota,Hércules,Toulouse Football Club,50,100,false,100,10000,TFC
509,Dušan Veškovac,22,SRB,D,1.87,78,16/03/1986,Kruševac,Young Boys,Toulouse Football Club,50,100,false,100,10000,TFC
510,Marcel Tisserand,23,COD,D,1.84,70,10/01/1993,Meaux,Monaco,Toulouse Football Club,50,100,false,100,10000,TFC
511,Pavle Ninkov,24,SRB,D,1.83,81,20/04/1985,Belgrade,Crvena Zvezda,Toulouse Football Club,50,100,false,100,10000,TFC
512,Drago? Grigore,25,ROU,D,1.85,76,07/09/1986,Vaslui,Dinamo Bucure?ti,Toulouse Football Club,50,100,false,100,10000,TFC
513,Sana Zaniou,26,BFA,F,1.70,65,31/12/1994,Cinsense,AS Sonabel,Toulouse Football Club,50,100,false,100,10000,TFC
514,Amadou Soukouna,27,FRA,F,1.82,76,21/06/1992,Paris,None,Toulouse Football Club,50,100,false,100,10000,TFC
515,Mihai Roman,28,ROU,M,1.73,70,16/11/1984,Suceava,Rapid Bucure?ti,Toulouse Football Club,50,100,false,100,10000,TFC
516,François Moubandje,29,SUI,D,1.82,76,21/06/1990,Geneva,Servette,Toulouse Football Club,50,100,false,100,10000,TFC
517,Ali Ahamada,30,FRA,G,1.89,83,19/08/1991,Martigues,None,Toulouse Football Club,50,100,false,100,10000,TFC
";
            File.WriteAllText( "cust.csv", csvString );

            // Read into an array of strings.
            string[] source = File.ReadAllLines( "cust.csv" );
            XElement cust = new XElement( "Players",
                from str in source
                let fields = str.Split( ',' )
                select new XElement( "Player",
                    new XAttribute( "Id", fields[0] ),
                    new XAttribute( "Name", fields[1] ),
                    new XElement( "ShirtNumber", fields[2] ),
                    new XElement( "Nationality", fields[3] ),
                    new XElement( "Poste", fields[4] ),
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
                    new XElement( "FinancialValue", fields[15] ) ) );
            cust.Save( @"C:\Users\Guenole\Documents\GitHub\RealSimSoccer\SimSoccer\Ligue1Players2.xml" );
        }
    }
}