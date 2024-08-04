using EducationPortal.Application.DTOs;
using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly private ITeamReadRepository _teamReadRepository;
        readonly private ITeamWriteRepository _teamWriteRepository;

        public TeamController(ITeamWriteRepository teamWriteRepository, ITeamReadRepository teamReadRepository)
        {
            _teamWriteRepository = teamWriteRepository;
            _teamReadRepository = teamReadRepository;
        }
        // GET: api/Team
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = _teamReadRepository.GetAll().ToList();
            return Ok(teams);
        }

        // GET: api/Team/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var team = await _teamReadRepository.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        // POST: api/Team
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamDto teamDto)
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = teamDto.Name,
            };

            await _teamWriteRepository.AddAsync(team);
            await _teamWriteRepository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        // PUT: api/Team/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TeamDto teamDto)
        {
            var team = await _teamReadRepository.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            team.Name = teamDto.Name;

            _teamWriteRepository.Update(team);
            await _teamWriteRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/Team/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var team = await _teamReadRepository.GetByIdAsync(id);
            if (team == null)
                return NotFound();

            await _teamWriteRepository.RemoveAsync(id);
            await _teamWriteRepository.SaveAsync();

            return NoContent();
        }

    }
}
