using System.Collections.Generic;

namespace kolokwium_2_poprawa_ko_s22454.Models.DTOs
{
    public class TeamGet
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamsName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<Member> Members { get; set; }

        public class Member
        {
            public int MemberID { get; set; }
            public int OrganizationID { get; set; }
            public string MemberName { get; set; }
            public string MemberSurname { get; set; }
            public string? MemberNickName { get; set; }
        }
    }
}