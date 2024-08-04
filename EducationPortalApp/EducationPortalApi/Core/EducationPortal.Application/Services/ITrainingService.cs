using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Services
{
    public interface ITrainingService
    {
        Task<Training> GetTrainingByIdAsync(int id);
        Task<IEnumerable<Training>> GetAllTrainingsAsync();
        Task AddTrainingAsync(Training training);
        Task UpdateTrainingAsync(Training training);
        Task DeleteTrainingAsync(int id);
    }
}
