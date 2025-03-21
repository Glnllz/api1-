using api1.Interfaces;
using api1.Model;
using api1.Requests;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersLoginsController
    {
        private readonly IUsersLoginsService _usersLoginsService;

        public UsersLoginsController(IUsersLoginsService usersLoginsService)
        { 
            _usersLoginsService = usersLoginsService;
        }

        [HttpGet]
        [Route("getAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await _usersLoginsService.GetAllUserAsync();
        }

        [HttpPost]
        [Route("createNewUserAndLogin")]
        public async Task<IActionResult> CreateNewUserAndLogin(CreateNewUserAndLogin data)
        {
            return await _usersLoginsService.CreateNewUserAndLoginAsync(data);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest data)
        {
            return await _usersLoginsService.LoginAsync(data);
        }

        [HttpPut]
        [Route("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserRequest data)
        {
            return await _usersLoginsService.UpdateUserAsync(userId, data);
        }

        [HttpDelete]
        [Route("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            return await _usersLoginsService.DeleteUserAsync(userId);
        }

        [HttpGet("checkLoginUnique/{login}")]
        public async Task<IActionResult> CheckLoginUnique(string login)
        {
            return await _usersLoginsService.CheckLoginUniqueAsync(login);
        }
    }
}
