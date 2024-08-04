using EducationPortal.Application.DTOs;
using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities;
using EducationPortal.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationReadRepository _notificationReadRepository;
        private readonly INotificationWriteRepository _notificationWriteRepository;

        public NotificationController(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository)
        {
            _notificationReadRepository = notificationReadRepository;
            _notificationWriteRepository = notificationWriteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = _notificationReadRepository.GetAll().ToList();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var notification = await _notificationReadRepository.GetByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationDto notificationDto)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message=notificationDto.Message

                // Diğer gerekli alanlar
            };

            var result = await _notificationWriteRepository.AddAsync(notification);
            if (!result)
                return BadRequest();

            await _notificationWriteRepository.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Notification notification)
        {
            var existingNotification = await _notificationReadRepository.GetByIdAsync(id);
            if (existingNotification == null)
            {
                return NotFound();
            }

            existingNotification.Message = notification.Message;
            // Update other properties as needed

            var result = _notificationWriteRepository.Update(existingNotification);
            if (result)
            {
                await _notificationWriteRepository.SaveAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _notificationWriteRepository.RemoveAsync(id);
            if (result)
            {
                await _notificationWriteRepository.SaveAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
