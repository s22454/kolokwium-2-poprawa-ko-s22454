using System.Collections.Generic;

namespace kolokwium_2_poprawa_ko_s22454.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamsName { get; set; }
        public string TeamDescription { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}