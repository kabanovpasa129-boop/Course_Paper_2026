using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Сотрудник")]
    public class Сотрудник
    {
        [Key]
        [Column("ID_сотрудника")]
        public int Id { get; set; }

        [Column("Фамилия")]
        public string Фамилия { get; set; }

        [Column("Имя")]
        public string Имя { get; set; }

        [Column("Отчество")]
        public string Отчество { get; set; }

        [Column("Должность")]
        public string Должность { get; set; }

        [Column("Телефон")]
        public string Телефон { get; set; }
    }
}