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
    public partial class LoadGameForm : Form
    {
        
        List<string> _items = new List<string>();
        public LoadGameForm()
        {
            InitializeComponent();
            _items.Add( "One" ); 
            _items.Add( "Two" );
            _items.Add( "Three" );

            listBox1.DataSource = _items;

           
        }

       
    }
}
