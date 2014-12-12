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
            string csvString = @"4.3.3,35,93.5,5,85,65,85,35,33,35,55,,,10,18,60,18,22,18,48,18,35,3,30,57,38,57
4.4.2,35,93.5,,,,,35,33,35,55,,,10,18,60,18,22,18,48,18,35,3,,,,
4.2.3.1,35,93.5,5,85,65,85,35,33,35,55,35,84,10,18,60,18,22,18,48,18,35,3,,,,
5.3.2,35,93.5,,,,,,,35,55,,,,,,,22,18,48,18,35,3,10,57,60,57
3.5.2,35,93.5,,,,,35,33,35,55,,,,,,,22,18,48,18,35,3,10,60,60,60
5.4.1,35,93.5,,,,,,,35,55,,,10,25,60,25,22,18,48,18,35,3,10,60,60,60
4.4.2 losange,35,93.5,,,,,35,33,,,35,84,10,18,60,18,22,18,48,18,35,3,30,55,40,55";

            File.WriteAllText("Tactic.csv", csvString);
            // Read into an array of strings.
            string[] source = File.ReadAllLines("Tactic.csv");
            XElement cust = new XElement("Game",
                 new XElement("Tactics",
                from str in source
                let fields = str.Split(',')
                select new XElement("Tactic",
                    new XAttribute("Formation", fields[0]),
                    new XElement("ATX", fields[1]),
                    new XElement("ATY", fields[2]),
                    new XElement("AGX", fields[3]),
                    new XElement("AGY", fields[4]),
                    new XElement("ADX", fields[5]),
                    new XElement("ADY", fields[6]),
                    new XElement("MDFX", fields[7]),
                    new XElement("MDFY", fields[8]),
                    new XElement("MCX", fields[9]),
                    new XElement("MCY", fields[10]),
                    new XElement("MOX", fields[11]),
                    new XElement("MOY", fields[12]),
                    new XElement("LGX", fields[13]),
                    new XElement("LGY", fields[14]),
                    new XElement("LDX", fields[15]),
                    new XElement("LDY", fields[16]),
                    new XElement("DCGX", fields[17]),
                    new XElement("DCGY", fields[18]),
                    new XElement("DCDX", fields[19]),
                    new XElement("DCDY", fields[20]),
                    new XElement("GBX", fields[21]),
                    new XElement("GBY", fields[22]),
                    new XElement("MLGX", fields[23]),
                    new XElement("MLGY", fields[24]),
                    new XElement("MLDX", fields[25]),
                    new XElement("MLDY", fields[26]) ) ) );
            cust.Save(@"C:\Users\user\Documents\SimSoccer\Tactics.xml");
        }
    }
}