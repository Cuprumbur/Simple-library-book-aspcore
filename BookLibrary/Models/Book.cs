using System.ComponentModel;

namespace BookLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Обложка")]
        public string Preview { get; set; }

        public int AuthorId { get; set; }

        [DisplayName("Автор")]
        public Author Author { get; set; }

        public int GenreId { get; set; }

        [DisplayName("Жанр")]
        public Genre Genre { get; set; }
    }
}