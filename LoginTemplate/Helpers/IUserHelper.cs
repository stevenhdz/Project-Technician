using LoginTemplate.Data.Entities;
using LoginTemplate.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTemplate.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserAsync(string email);

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

    }
}
