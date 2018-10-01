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
        NewOrder = 1,
        [Description("Chef de projet")]
        Order = 2,
        [Description("Developpeur")]
        FinalyOrder = 3

    }
}
