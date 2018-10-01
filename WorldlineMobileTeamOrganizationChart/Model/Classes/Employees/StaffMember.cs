using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{
    public class StaffMember
    {
        [Key]
        public int ID { get; set; }
        public string mail { get; set; }
        public string firstName { get; set; }
        public string Name { get; set; }
        public int Tel { get; set; }

        public Fonction fonction { get; set; }
    }
}
