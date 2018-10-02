using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{
    public enum Fonction
    {
        [Description("Manager")]
        Manager,
        [Description("Chef de projet")]
        ChefDeProjet,
        [Description("Développeur")]
        Développeur

    }
}
