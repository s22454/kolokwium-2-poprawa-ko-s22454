using System.Threading.Tasks;
using kolokwium_2_poprawa_ko_s22454.Models.DTOs;

namespace kolokwium_2_poprawa_ko_s22454.Services
{
    public interface ITeamsService
    {
        public Task<TeamGet> GetTeam(int id);
        public Task<bool> AddMemberToTeam(int memberId, int teamId);
    }
}