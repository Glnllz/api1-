using api1.Model;
using api1.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace api1.Interfaces
{
    public interface IUsersLoginsService
    {
        Task<IActionResult> GetAllUserAsync();
        Task<IActionResult> CreateNewUserAndLoginAsync(CreateNewUserAndLogin data);
        Task<IActionResult> LoginAsync(LoginRequest data);
        Task<IActionResult> UpdateUserAsync(int userId, UpdateUserRequest data);
        Task<IActionResult> DeleteUserAsync(int userId);
        Task<IActionResult> CheckLoginUniqueAsync(string login); // Новый метод

    }
}
