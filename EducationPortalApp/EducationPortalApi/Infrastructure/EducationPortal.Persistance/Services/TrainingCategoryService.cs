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
    public class TrainingCategoryService : ITrainingCategoryService
    {
        private readonly ITrainingCategoryReadRepository _trainingCategoryReadRepository;
        private readonly ITrainingCategoryWriteRepository _trainingCategoryWriteRepository;

        public TrainingCategoryService(ITrainingCategoryReadRepository trainingCategoryReadRepository, ITrainingCategoryWriteRepository trainingCategoryWriteRepository)
        {
            _trainingCategoryReadRepository = trainingCategoryReadRepository;
            _trainingCategoryWriteRepository = trainingCategoryWriteRepository;
        }

        public async Task<TrainingCategory> GetTrainingCategoryByIdAsync(int id)
        {
            return await _trainingCategoryReadRepository.GetByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<TrainingCategory>> GetAllTrainingCategoriesAsync()
        {
            return await _trainingCategoryReadRepository.GetAll().ToListAsync();
        }

        public async Task AddTrainingCategoryAsync(TrainingCategory trainingCategory)
        {
            await _trainingCategoryWriteRepository.AddAsync(trainingCategory);
            await _trainingCategoryWriteRepository.SaveAsync();
        }

        public async Task UpdateTrainingCategoryAsync(TrainingCategory trainingCategory)
        {
            _trainingCategoryWriteRepository.Update(trainingCategory);
            await _trainingCategoryWriteRepository.SaveAsync();
        }

        public async Task DeleteTrainingCategoryAsync(int id)
        {
            await _trainingCategoryWriteRepository.RemoveAsync(id.ToString());
            await _trainingCategoryWriteRepository.SaveAsync();
        }
    }
}
