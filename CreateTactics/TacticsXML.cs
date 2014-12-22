using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateTactics
{
    public class TacticsXML
    {

        static void Main(string[] args)
        {
            string csvString = @"4.3.3-800,300-0-0-750,100-750,500-0-0-350,300-500,200-0-500,400-600,400-600,200-0-200,100-200,500-200,200-200,400-0-30,300-550,100-550,500
4.4.2-0-850,200-850,400-0-0-500,200-500,400-0-35,55-0-0-0-0-0-200,100-200,500-200,200-200,400-0-30,300-0-0
4.2.3.1-800,300-0-0-0-0-350,225-350,375-0-35,55-0-0-650,450-650,150-650,300-200,100-200,500-200,200-200,400-0-30,300-0-0
5.3.2-0-850,200-850,400-0-0-0-0-400,300-35,55-0-0-0-0-0-300,100-300,500-200,200-200,400-200,300-30,300-550,150-550,450
3.5.2-0-850,200-850,400-0-0-0-0-0-500,200-0-500,400-0-0-650,300-300,100-300,500-200,200-200,400-200,300-30,300-500,100-500,500
5.4.1-800,300-0-0-0-0-0-0-0-35,55-0-0-600,450-600,150-0-10,25-60,25-200,200-200,400-200,300-30,300-0-0
4.4.2 losange-0-850,200-850,400-0-0-0-0-350,300-0-0-0-0-0-700,300-200,100-200,500-200,200-200,400-0-30,300-550,150-550,450";


            File.WriteAllText("Tactic.csv", csvString);
            // Read into an array of strings.
            string[] source = File.ReadAllLines("Tactic.csv");
            XElement cust = new XElement("Game",
                 new XElement("Tactics",
                from str in source
                let fields = str.Split('-')
                select new XElement("Tactic",
                    new XAttribute("Formation", fields[0]),
                    new XElement("BU", fields[1]),
                    new XElement("ATG", fields[2]),
                    new XElement("ATD", fields[3]),
                    new XElement("AG", fields[4]),
                    new XElement("AD", fields[5]),
                    new XElement("MDFG", fields[6]),
                    new XElement("MDFD", fields[7]),
                    new XElement("MDF", fields[8]),
                    new XElement("MCG", fields[9]),
                    new XElement("MC", fields[10]),
                    new XElement("MCD", fields[11]),
                    new XElement("MOD", fields[12]),
                    new XElement("MOG", fields[13]),
                    new XElement("MO", fields[14]),
                    new XElement("DLG", fields[15]),
                    new XElement("DLD", fields[16]),
                    new XElement("DCG", fields[17]),
                    new XElement("DCD", fields[18]),
                    new XElement("DC", fields[19]),
                    new XElement("GB", fields[20]),
                    new XElement("MLG", fields[21]),
                    new XElement("MLD", fields[22]))));
            cust.Save(@"C:\Users\user\Documents\SimSoccer\Tactics.xml");
        }
    }
}