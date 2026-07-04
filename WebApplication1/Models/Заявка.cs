using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Заявка")]
    public class Заявка
    {
        [Key]
        [Column("ID_заявки")]
        public int Id { get; set; }

        [Column("Фамилия_клиента")]
        public string Фамилия { get; set; }

        [Column("Имя_клиента")]
        public string Имя { get; set; }

        [Column("Отчество_клиента")]
        public string Отчество { get; set; }

        [Column("Телефон_клиента")]
        public string Телефон { get; set; }

        [Column("Комментарий")]
        public string Комментарий { get; set; }

        [Column("Дата_создания")]
        public DateTime Дата_создания { get; set; }

        [Column("Статус")]
        public string Статус { get; set; } = "Новая";
    }
}