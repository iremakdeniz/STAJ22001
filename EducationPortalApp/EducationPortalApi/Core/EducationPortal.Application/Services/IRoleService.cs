using EducationPortal.Application.DTOs;
using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Services
{
    public interface IRoleService
    {
        Task<Role> GetRole(int id);
        Task AddRole(Role role);
        Task UpdateRole(Role role);
        Task DeleteRole(int id);
        Task UpdateUserRole(Guid userId,Role role);
    }
}
