using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ЗаявкаController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ЗаявкаController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/заявка
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var заявки = await _context.Заявки
                .OrderByDescending(x => x.Дата_создания)
                .ToListAsync();
            return Ok(заявки);
        }

        // GET: api/заявка/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var заявка = await _context.Заявки.FindAsync(id);
            if (заявка == null)
                return NotFound();

            return Ok(заявка);
        }

        // POST: api/заявка
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Заявка заявка)
        {
            if (заявка == null)
                return BadRequest("Данные заявки не заполнены");

            заявка.Дата_создания = DateTime.Now;
            заявка.Статус = "Новая";

            try
            {
                _context.Заявки.Add(заявка);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Получаем полную информацию об ошибке
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += " | Inner: " + ex.InnerException.Message;

                return BadRequest(new { error = errorMessage });
            }

            return Ok(new { message = "Заявка успешно отправлена", id = заявка.Id });
        }

        // PUT: api/заявка/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            var заявка = await _context.Заявки.FindAsync(id);
            if (заявка == null)
                return NotFound();

            заявка.Статус = request.Статус;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/заявка/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var заявка = await _context.Заявки.FindAsync(id);
            if (заявка == null)
                return NotFound();

            _context.Заявки.Remove(заявка);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class UpdateStatusRequest
    {
        public string Статус { get; set; }
    }
}