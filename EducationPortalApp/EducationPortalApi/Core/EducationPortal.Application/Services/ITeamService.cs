using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Services
{
    public interface ITeamService
    {
        Task<Team> GetTeamByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task AddTeamAsync(Team team);
        Task UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
    }
}
