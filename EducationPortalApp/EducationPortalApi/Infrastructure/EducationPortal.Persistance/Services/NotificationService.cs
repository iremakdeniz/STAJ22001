using EducationPortal.Application.Repositories;
using EducationPortal.Application.Services;
using EducationPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Persistance.Services
{

        public class NotificationService : INotificationService
        {
            private readonly INotificationReadRepository _notificationReadRepository;
            private readonly INotificationWriteRepository _notificationWriteRepository;

            public NotificationService(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository)
            {
                _notificationReadRepository = notificationReadRepository;
                _notificationWriteRepository = notificationWriteRepository;
            }

            public async Task<Notification> GetNotificationByIdAsync(int id)
            {
                return await _notificationReadRepository.GetByIdAsync(id.ToString());
            }

            public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
            {
                return await _notificationReadRepository.GetAll().ToListAsync();
            }

            public async Task AddNotificationAsync(Notification notification)
            {
                await _notificationWriteRepository.AddAsync(notification);
                await _notificationWriteRepository.SaveAsync();
            }

            public async Task UpdateNotificationAsync(Notification notification)
            {
                _notificationWriteRepository.Update(notification);
                await _notificationWriteRepository.SaveAsync();
            }

            public async Task DeleteNotificationAsync(int id)
            {
                await _notificationWriteRepository.RemoveAsync(id.ToString());
                await _notificationWriteRepository.SaveAsync();
            }
        }
    }

