using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Models;

namespace Library.Models
{
    public class WishList_Book
    {
        [Key]
        public int ID_WishList_Book { get; set; }

        [ForeignKey("WishList")]
        public int ID_WishList { get; set; }
        public WishList? WishList { get; set; }

        [ForeignKey("Book")]
        public string? ISBN { get; set; }
        public Book? Book { get; set; }
    }
}
