namespace BookLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}