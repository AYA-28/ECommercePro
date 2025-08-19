using ECommerce.Core.DTO;
using ECommerce.Core.Entities;
using ECommerce.Core.Repository;
using ECommerce.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;

        public AuthService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<int> RegisterAsync(RegisterDto dto)
        {
            var existing = await _repo.GetByUsernameAsync(dto.Username);
            if (existing != null)
                return 0;

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = "Customer"
            };

            await _repo.AddAsync(user);
            return user.Id;
        }

        public async Task<UserDto?> LoginAsync(string username, string password)
        {
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null || user.Password != password)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }
    }

}
