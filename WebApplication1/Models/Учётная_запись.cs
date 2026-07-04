using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Учётная_запись")]
    public class Учётная_запись
    {
        [Key]
        [Column("ID_учётной_записи")]
        public int Id { get; set; }

        [Column("ID_сотрудника")]
        public int ID_сотрудника { get; set; }

        [Column("Логин")]
        public string Логин { get; set; }

        [Column("Пароль")]
        public string Пароль { get; set; }

        [Column("Роль")]
        public string Роль { get; set; }

        [ForeignKey("ID_сотрудника")]
        public Сотрудник Сотрудник { get; set; }
    }
}