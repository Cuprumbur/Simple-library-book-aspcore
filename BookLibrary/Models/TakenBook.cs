using System;
using System.ComponentModel;

namespace BookLibrary.Models
{
    [DisplayName("Учет книг")]
    public class TakenBook
    {
        public int TakenBookId { get; set; }
        public int ReaderId { get; set; }

        [DisplayName("Читатель")]
        public Reader Reader { get; set; }

        public int BookId { get; set; }

        [DisplayName("Книга")]
        public Book Book { get; set; }

        [DisplayName("Дата выдачи")]
        public DateTime DateIssue { get; set; }

        [DisplayName("Дата возврата")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("Возвращена")]
        public bool IsReturned { get; set; }
    }
}