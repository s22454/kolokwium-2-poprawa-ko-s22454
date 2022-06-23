using System.Linq;
using System.Threading.Tasks;
using kolokwium_2_poprawa_ko_s22454.Models;
using kolokwium_2_poprawa_ko_s22454.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2_poprawa_ko_s22454.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly TeamsDbContext _context;

        public TeamsService(TeamsDbContext context)
        {
            _context = context;
        }
        
        public async Task<TeamGet> GetTeam(int id)
        {
            var MyOrganizationID = await _context.Teams.Where(e => e.TeamID == id).Select(e=> e.OrganizationID).FirstOrDefaultAsync();
            string MyOrganizationName = await _context.Organizations.Where(e => e.OrganizationID == MyOrganizationID).Select(e => e.OrganizationName).FirstOrDefaultAsync();

            return await _context.Teams
                .Include(e => e.Memberships)
                .ThenInclude(e => e.Member)
                .Select(e => new TeamGet
                {
                    TeamID = e.TeamID,
                    OrganizationID = e.OrganizationID,
                    TeamsName = e.TeamsName,
                    TeamDescription = e.TeamDescription,
                    OrganizationName = MyOrganizationName,
                    Members = e.Memberships.Select(e => new TeamGet.Member
                    {
                        MemberID = e.Member.MemberID,
                        OrganizationID = e.Member.OrganizationID,
                        MemberName = e.Member.MemberName,
                        MemberSurname = e.Member.MemberSurname,
                        MemberNickName = e.Member.MemberNickName
                    })
                })
                .Where(e => e.TeamID == id)
                .FirstOrDefaultAsync();
        }
    }
}