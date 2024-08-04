using EducationPortal.Application.DTOs;
using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly private IRoleReadRepository _roleReadRepository;
        readonly private IRoleWriteRepository _roleWriteRepository;

        public RoleController(IRoleWriteRepository roleWriteRepository, IRoleReadRepository roleReadRepository)
        {
            _roleWriteRepository = roleWriteRepository;
            _roleReadRepository = roleReadRepository;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = _roleReadRepository.GetAll().ToList();
            return Ok(roles);
        }

        // GET: api/Role/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await _roleReadRepository.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {
            var role = new Role
            {
                Id= Guid.NewGuid(),
                Name = roleDto.Name
            };

            await _roleWriteRepository.AddAsync(role);
            await _roleWriteRepository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        // PUT: api/Role/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] RoleDto roleDto)
        {
            var role = await _roleReadRepository.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            role.Name = roleDto.Name;

            _roleWriteRepository.Update(role);
            await _roleWriteRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleReadRepository.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            await _roleWriteRepository.RemoveAsync(id);
            await _roleWriteRepository.SaveAsync();

            return NoContent();
        }
    }
}
