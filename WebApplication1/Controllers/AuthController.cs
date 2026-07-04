using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var учетка = await _context.Учётная_запись
                .Include(u => u.Сотрудник)
                .FirstOrDefaultAsync(u => u.Логин == login.Логин && u.Пароль == login.Пароль);

            if (учетка == null)
                return Unauthorized(new { message = "Неверный логин или пароль" });

            var сотрудник = учетка.Сотрудник;

            return Ok(new
            {
                message = "Успешный вход",
                role = учетка.Роль,
                login = учетка.Логин,
                name = сотрудник.Фамилия + " " + сотрудник.Имя
            });
        }
    }
}