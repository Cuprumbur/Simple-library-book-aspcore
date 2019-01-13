using System.ComponentModel;

namespace BookLibrary.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [DisplayName("Жанр")]
        public string Name { get; set; }
    }
}