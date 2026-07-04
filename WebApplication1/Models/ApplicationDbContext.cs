using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Заявка> Заявки { get; set; }
        public DbSet<Сотрудник> Сотрудники { get; set; }
        public DbSet<Учётная_запись> Учётная_запись { get; set; }
    }
}