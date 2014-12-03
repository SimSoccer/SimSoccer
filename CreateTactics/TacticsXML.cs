﻿using System;
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
            string csvString = @"4-3-3.(35,93,5).(65,85).(5,85).(35,33).(35,55).null.(10,18).(60,18).(22,18).(48,18).(35,3).(30,57).(38,57)
4-4-2.(35,93,5).null.null.(35,33).(35,55).null.(10,18).(60,18).(22,18).(48,18).(35,3).null.
4-2-3-1.(35,93,5).(65,85).(5,85).(35,33).(35,55).(35,84).(10,18).(60,18).(22,18).(48,18).(35,3).
5-3-2.(35,93,5).null.null.null.(35,55).null.null.null.(22,18).(48,18).(35,3).(10,57).(60,57)
3-5-2.(35,93,5).null.null.(35,33).(35,55).null.null.null.(22,18).(48,18).(35,3).(10,60).(60,60)
5-4-1.(35,93,5).null.null.null.(35,55).null.(10,25).(60,25).(22,18).(48,18).(35,3).(10,60).60,60)
4-4-2_Losange.(35,93,5).null.null.(35,33).null.(35,84).(10,18).(60,18).(22,18).(48,18).(35,3).(30,55).(40,55)";
            File.WriteAllText("Tactic.csv", csvString);
            // Read into an array of strings.
            string[] source = File.ReadAllLines("Tactic.csv");
            XElement cust = new XElement("Tactics",
                from str in source
                let fields = str.Split('.')
                select new XElement("Tactics",
                    new XAttribute("Formation", fields[0]),
                    new XElement("AD", fields[1]),
                    new XElement("AG", fields[2]),
                    new XElement("MDF", fields[3]),
                    new XElement("MC", fields[4]),
                    new XElement("MO", fields[5]),
                    new XElement("LG", fields[6]),
                    new XElement("LD", fields[7]),
                    new XElement("DCG", fields[8]),
                    new XElement("DCD", fields[9]),
                    new XElement("GB", fields[10]),
                    new XElement("MLD", fields[11]),
                    new XElement("MLG", fields[12])));
            cust.Save(@"C:\Users\user\Documents\SimSoccer\Tactics.xml");
        }
    }
}