using EducationPortal.Application.Repositories;
using EducationPortal.Application.Services;
using EducationPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Persistance.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        public RoleService(IRoleReadRepository roleReadRepository, IRoleWriteRepository roleWriteRepository, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _roleReadRepository = roleReadRepository;
            _roleWriteRepository = roleWriteRepository;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<Role> GetRole(int id)
        {
            return await _roleReadRepository.GetByIdAsync(id.ToString());
        }

        public async Task AddRole(Role role)
        {
            await _roleWriteRepository.AddAsync(role);
            await _roleWriteRepository.SaveAsync();
        }

        public async Task UpdateRole(Role role)
        {
            _roleWriteRepository.Update(role);
            await _roleWriteRepository.SaveAsync();
        }

        public async Task DeleteRole(int id)
        {
            await _roleWriteRepository.RemoveAsync(id.ToString());
            await _roleWriteRepository.SaveAsync();
        }

        public async Task UpdateUserRole(Guid userId,Role role)
        {
            var user = await _userReadRepository.GetByIdAsync(userId.ToString());
            if (user != null)
            {
                user.Id = role.Id;
                _userWriteRepository.Update(user);
                await _userWriteRepository.SaveAsync();
            }
        }
    }
}
