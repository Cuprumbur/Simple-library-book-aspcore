namespace BookLibrary.Models
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public int LibraryCard { get; set; }
    }
}