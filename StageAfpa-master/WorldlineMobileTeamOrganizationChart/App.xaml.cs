using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using WorldlineMobileTeamOrganizationChart.Helpers;

namespace WorldlineMobileTeamOrganizationChart
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        
       public App()
       {
            using (var context = new StaffMembersContext())
            {
                try { context.Database.EnsureCreated(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection à la base de donnée impossible" + ex.Message);
                }
            }
        }
    }
}
