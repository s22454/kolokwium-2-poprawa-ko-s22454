using System.Collections.Generic;

namespace kolokwium_2_poprawa_ko_s22454.Models
{
    public class Member
    {
        public Member()
        {
            Memberships = new HashSet<Membership>();
        }

        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemberNickName { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}