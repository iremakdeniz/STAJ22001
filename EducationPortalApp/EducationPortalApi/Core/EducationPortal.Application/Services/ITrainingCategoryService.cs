using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Services
{
    public interface ITrainingCategoryService
    {
        Task<TrainingCategory> GetTrainingCategoryByIdAsync(int id);
        Task<IEnumerable<TrainingCategory>> GetAllTrainingCategoriesAsync();
        Task AddTrainingCategoryAsync(TrainingCategory trainingCategory);
        Task UpdateTrainingCategoryAsync(TrainingCategory trainingCategory);
        Task DeleteTrainingCategoryAsync(int id);
    }
}
