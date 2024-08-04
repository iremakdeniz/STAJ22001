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
    public class TeamService : ITeamService
    {
        private readonly ITeamReadRepository _teamReadRepository;
        private readonly ITeamWriteRepository _teamWriteRepository;

        public TeamService(ITeamReadRepository teamReadRepository, ITeamWriteRepository teamWriteRepository)
        {
            _teamReadRepository = teamReadRepository;
            _teamWriteRepository = teamWriteRepository;
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _teamReadRepository.GetByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamReadRepository.GetAll().ToListAsync();
        }

        public async Task AddTeamAsync(Team team)
        {
            await _teamWriteRepository.AddAsync(team);
            await _teamWriteRepository.SaveAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            _teamWriteRepository.Update(team);
            await _teamWriteRepository.SaveAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamWriteRepository.RemoveAsync(id.ToString());
            await _teamWriteRepository.SaveAsync();
        }
    }
}
