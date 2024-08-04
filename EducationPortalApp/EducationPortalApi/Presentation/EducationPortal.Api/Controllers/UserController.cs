using EducationPortal.Application.Services;
using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EducationPortal.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using EducationPortal.Application.Repositories;

namespace EducationPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UserController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = _userReadRepository.GetAll().ToList();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userReadRepository.GetByIdAsync(id.ToString());
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password

            // Diğer gerekli alanlar
        };

            var result = await _userWriteRepository.AddAsync(user);
            if (!result)
                return BadRequest();

            await _userWriteRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserDto userDto)
        {
            var existingUser = await _userReadRepository.GetByIdAsync(id.ToString());
            if (existingUser == null)
                return NotFound();

            existingUser.UserName = userDto.UserName;
            existingUser.Email = userDto.Email;
            existingUser.Password = userDto.Password;
            existingUser.UserType = userDto.UserType;
            existingUser.Team.Name = userDto.Team.Name;
            // Diğer gerekli alanlar

            var result = _userWriteRepository.Update(existingUser);
            if (!result)
                return BadRequest();

            await _userWriteRepository.SaveAsync();
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userReadRepository.GetByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            user.IsDeleted = true;
            await _userWriteRepository.SaveAsync();

            return NoContent();
        }
    }
}