using Sims.SimSoccerModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreatePlayerListConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            string userName = "guegue";
            string passWord = "toto";

            Game g = new Game( userName, passWord );


            string folderPath = @".\..\..\..\";
            DirectoryInfo dir = new DirectoryInfo( folderPath );
            FileInfo[] files = dir.GetFiles( "user_" + g.UserName + "*", SearchOption.TopDirectoryOnly );

            string[] fileNames = files.Select( f => f.Name ).ToArray();
            Console.WriteLine( fileNames[0] );

            var xml = XDocument.Load( @".\..\..\..\" + fileNames[0] );
            xml.Root.Element( "Teams" )
                .Element( "Team" )
                .Elements()
               .Where( x => x.Attribute( "Id" ).Value == "0" )
               .Remove();
            xml.Save( @".\..\..\..\test" );

            Console.Read();
        }
    }
}
