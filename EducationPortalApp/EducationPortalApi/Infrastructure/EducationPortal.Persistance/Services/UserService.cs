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
    public class UserService:IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UserService(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userReadRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userReadRepository.GetAll().ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userWriteRepository.RemoveAsync(id.ToString());
            await _userWriteRepository.SaveAsync();
        }
    }
}
