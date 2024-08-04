using EducationPortal.Application.DTOs;
using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCategoryController : ControllerBase
    {
        readonly private ITrainingCategoryReadRepository _trainingCategoryReadRepository;
        readonly private ITrainingCategoryWriteRepository _trainingCategoryWriteRepository;

        public TrainingCategoryController(ITrainingCategoryWriteRepository trainingCategoryWriteRepository, ITrainingCategoryReadRepository trainingCategoryReadRepository)
        {
            _trainingCategoryWriteRepository = trainingCategoryWriteRepository;
            _trainingCategoryReadRepository = trainingCategoryReadRepository;
        }
        // GET: api/TrainingCategory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = _trainingCategoryReadRepository.GetAll().ToList();
            return Ok(categories);
        }

        // GET: api/TrainingCategory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _trainingCategoryReadRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/TrainingCategory
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] TrainingCategoryDto categoryDto)
        {
            var category = new TrainingCategory
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name
            };

            await _trainingCategoryWriteRepository.AddAsync(category);
            await _trainingCategoryWriteRepository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // PUT: api/TrainingCategory/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id, [FromBody] TrainingCategoryDto categoryDto)
        {
            var category = await _trainingCategoryReadRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            category.Name = categoryDto.Name;

            _trainingCategoryWriteRepository.Update(category);
            await _trainingCategoryWriteRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/TrainingCategory/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _trainingCategoryReadRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await _trainingCategoryWriteRepository.RemoveAsync(id);
            await _trainingCategoryWriteRepository.SaveAsync();

            return NoContent();
        }
    }
}
