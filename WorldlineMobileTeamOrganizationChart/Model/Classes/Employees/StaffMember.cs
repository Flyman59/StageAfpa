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
        [Required]
        public string Mail { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tel { get; set; }
        public Fonction FonctionStaff { get; set; }
    }
}
