using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
	public class WishList
	{
		[Key]
		public int ID_WishList { get; set; }
		[ForeignKey("User")]
		public string? ID_User { get; set; }
		public ICollection<WishList_Book>? WishList_Book { get; set; }
	}
}
