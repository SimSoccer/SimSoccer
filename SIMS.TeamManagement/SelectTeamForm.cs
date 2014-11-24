using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS.TeamsManagement
{
    public partial class SelectTeamForm : Form
    {

        /*public Team Read_Dictionnay(){
        
        TeamListReader team = new TeamListReader();
        team.CreateTeamsList();
       
        Team currentTeam = null;

        currentTeam = team.Teams[i];
        
        return currentTeam;
        }*/


        
        

   
        int i = 1;

        public SelectTeamForm()
        {
            
            InitializeComponent();
          
            
        }

      
        private void Next_Click( object sender, EventArgs e )
        {
           
         /*   if( i == team.Teams.count)
            {
                i = 1;
            }
            else
            {
                i++;
            }
            
            pictureBox1_Click( this, EventArgs.Empty );
        */}

        private void Previous_Click( object sender, EventArgs e )
        {
           /* if( i ==  0)
            {
                i = 9;
            }
            else
            {
                i--;
            }
            pictureBox1_Click( this, EventArgs.Empty );
            */
        }

        private void SelectTeamForm_Load( object sender, EventArgs e )
        {

        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            using( FileStream fs = new FileStream( @"C:\Users\famille\Pictures\Sans titre.png", FileMode.Open ) )
            {
                Logo.Image = Image.FromStream( fs );
                teamName_TextChanged( this, EventArgs.Empty );
            }
            
            
        }

        private void teamName_TextChanged( object sender, EventArgs e )
        {
            
            //teamName.Text = currentTeam
            

        }

        
    }
}
