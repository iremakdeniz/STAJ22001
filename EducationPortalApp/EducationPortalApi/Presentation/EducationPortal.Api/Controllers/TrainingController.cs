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
    public class TrainingController : ControllerBase
    {
        readonly private ITrainingReadRepository _trainingReadRepository;
        readonly private ITrainingWriteRepository _trainingWriteRepository;

        public TrainingController(ITrainingWriteRepository trainingWriteRepository, ITrainingReadRepository trainingReadRepository)
        {
            _trainingWriteRepository = trainingWriteRepository;
            _trainingReadRepository = trainingReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = _trainingReadRepository.GetAll().ToList();
            return Ok(trainings);
        }

        // GET: api/Training/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var training = await _trainingReadRepository.GetByIdAsync(id);
            if (training == null)
                return NotFound();

            return Ok(training);
        }

        // POST: api/Training
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] TrainingDto trainingDto)
        {
            var training = new Training
            {
                Id = Guid.NewGuid(),
                Title = trainingDto.Title,
                Description = trainingDto.Description,
                CategoryId = trainingDto.CategoryId,
            };

            await _trainingWriteRepository.AddAsync(training);
            await _trainingWriteRepository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = training.Id }, training);
        }

        // PUT: api/Training/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id, [FromBody] TrainingDto trainingDto)
        {
            var training = await _trainingReadRepository.GetByIdAsync(id);
            if (training == null)
                return NotFound();

            training.Title = trainingDto.Title;
            training.Description = trainingDto.Description;
            training.CategoryId = trainingDto.CategoryId;

            _trainingWriteRepository.Update(training);
            await _trainingWriteRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/Training/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var training = await _trainingReadRepository.GetByIdAsync(id);
            if (training == null)
                return NotFound();

            await _trainingWriteRepository.RemoveAsync(id);
            await _trainingWriteRepository.SaveAsync();

            return NoContent();
        }
    }
}
