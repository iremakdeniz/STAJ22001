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
    public class TrainingService:ITrainingService
    {
        private readonly ITrainingReadRepository _trainingReadRepository;
        private readonly ITrainingWriteRepository _trainingWriteRepository;

        public TrainingService(ITrainingReadRepository trainingReadRepository, ITrainingWriteRepository trainingWriteRepository)
        {
            _trainingReadRepository = trainingReadRepository;
            _trainingWriteRepository = trainingWriteRepository;
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            return await _trainingReadRepository.GetByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<Training>> GetAllTrainingsAsync()
        {
            return await _trainingReadRepository.GetAll().ToListAsync();
        }

        public async Task AddTrainingAsync(Training training)
        {
            await _trainingWriteRepository.AddAsync(training);
            await _trainingWriteRepository.SaveAsync();
        }

        public async Task UpdateTrainingAsync(Training training)
        {
            _trainingWriteRepository.Update(training);
            await _trainingWriteRepository.SaveAsync();
        }

        public async Task DeleteTrainingAsync(int id)
        {
            await _trainingWriteRepository.RemoveAsync(id.ToString());
            await _trainingWriteRepository.SaveAsync();
        }
    }
}
