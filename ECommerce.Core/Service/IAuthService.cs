using ECommerce.Core.DTO;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Service
{
    public interface IAuthService
    {
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByUsernameAsync(string username);
        Task<int> RegisterAsync(RegisterDto dto);
        Task<UserDto?> LoginAsync(string username, string password);
    }
}
