using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Services
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationByIdAsync(int id);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
    } 
}
