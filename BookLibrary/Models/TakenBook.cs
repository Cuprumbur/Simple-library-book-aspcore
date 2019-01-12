using System;

namespace BookLibrary.Models
{
    public class TakenBook
    {
        public int TakenBookId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}