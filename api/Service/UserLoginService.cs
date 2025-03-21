using api1.DataBaseContext;
using api1.Interfaces;
using api1.Model;
using api1.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api1.Service
{
    public class UserLoginService : IUsersLoginsService
    {
        private readonly ContextDb _context;
        private readonly ILogger<UserLoginService> _logger;

        public UserLoginService(ContextDb context, ILogger<UserLoginService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> CreateNewUserAndLoginAsync(CreateNewUserAndLogin data)
        {
            try
            {
                if (data == null)
                {
                    return new BadRequestObjectResult(new { message = "Данные не могут быть null", status = false });
                }

                // Проверяем уникальность логина
                var loginExists = await _context.Logins.AnyAsync(l => l.Login == data.Login);
                if (loginExists)
                {
                    return new BadRequestObjectResult(new { message = "Логин уже занят", status = false });
                }

                // Создаем нового пользователя
                var user = new Users()
                {
                    Name = data.Name ?? throw new ArgumentNullException(nameof(data.Name)),
                    Description = data.Description,
                    Role_id = 1, // Роль по умолчанию
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // Создаем запись в таблице Logins
                var login = new Logins()
                {
                    User_id = user.id_User,
                    Login = data.Login ?? throw new ArgumentNullException(nameof(data.Login)),
                    Password = data.Password ?? throw new ArgumentNullException(nameof(data.Password)),
                };

                await _context.Logins.AddAsync(login);
                await _context.SaveChangesAsync();

                // Возвращаем успешный результат
                return new OkObjectResult(new { status = true, userId = user.id_User });
            }
            catch (Exception ex)
            {
                // Логируем ошибку и возвращаем 500
                _logger.LogError(ex, "Ошибка при создании пользователя и логина");
                return new StatusCodeResult(500);
            }
        }

        // Остальные методы остаются без изменений, но добавьте валидацию и используйте _logger вместо Console.WriteLine
    


public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            return new OkObjectResult(new
            {
                data = new { users = users },
                status = true
            });
        }

        public async Task<IActionResult> LoginAsync(LoginRequest data)
        {
            var login = await _context.Logins
                .Include(l => l.Users)
                .ThenInclude(u => u.Role) // Include the related Role data
                .FirstOrDefaultAsync(l => l.Login == data.Login && l.Password == data.Password);

            if (login == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = "Неверный логин или пароль",
                    status = false
                });
            }
            //го
            return new OkObjectResult(new
            {
                user = new
                {
                    Login = login.Login,
                    Password = login.Password, // Возвращаем пароль
                    Name = login.Users.Name, // Возвращаем имя
                    Description = login.Users.Description, // Возвращаем описание
                    RoleName = login.Users.Role.Name // Возвращаем роль
                },
                status = true
            });
        }

        public async Task<IActionResult> UpdateUserAsync(int userId, UpdateUserRequest data)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult(new
                {
                    message = "Пользователь не найден",
                    status = false
                });
            }

            user.Name = data.Name;
            user.Description = data.Description;
            user.Role_id = data.Role_id;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            // Логируем ID пользователя
            Console.WriteLine($"Попытка удаления пользователя с ID: {userId}");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                // Логируем, что пользователь не найден
                Console.WriteLine($"Пользователь с ID {userId} не найден");
                return new NotFoundObjectResult(new
                {
                    message = "Пользователь не найден",
                    status = false
                });
            }

            // Удаляем пользователя
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            // Логируем успешное удаление
            Console.WriteLine($"Пользователь с ID {userId} успешно удален");
            return new OkObjectResult(new
            {
                status = true
            });
        }
        public async Task<IActionResult> CheckLoginUniqueAsync(string login)
        {
            var existingLogin = await _context.Logins.FirstOrDefaultAsync(l => l.Login == login);
            if (existingLogin != null)
            {
                return new OkObjectResult(new { isUnique = false }); // Логин занят
            }

            return new OkObjectResult(new { isUnique = true }); // Логин свободен
        }

    }
}