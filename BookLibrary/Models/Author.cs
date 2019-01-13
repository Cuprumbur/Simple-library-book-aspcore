using System.ComponentModel;

namespace BookLibrary.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DisplayName("Полное имя")]
        public string FullName => $"{FirstName} {Patronymic} {LastName } ";
    }
}