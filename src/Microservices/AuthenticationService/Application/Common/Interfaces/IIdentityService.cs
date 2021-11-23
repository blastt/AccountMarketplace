using Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<string> GetUserIdAsync(string userName);
        Task<bool> IsEmailExist(string email);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string email);

        Task<Result> DeleteUserAsync(string userId);
        Task<SignInResult> CheckPasswordSignInAsync(string userId, string password);
        Task<IList<string>> GetUserRoles(string userId);
    }
}
