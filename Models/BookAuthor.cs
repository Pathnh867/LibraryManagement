using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BookAuthor
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Key, Column(Order = 1)]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}