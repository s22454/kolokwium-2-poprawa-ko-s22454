using System.Threading.Tasks;
using kolokwium_2_poprawa_ko_s22454.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_2_poprawa_ko_s22454.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _service;

        public TeamsController(ITeamsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeam(int id)
        {
            var res = await _service.GetTeam(id);

            if (res is null)
            {
                return NotFound("Nie ma takiego zaspołu!");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}