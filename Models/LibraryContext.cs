using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            // WishlistBook Configuration 
            builder.Entity<WishList_Book>()
                  .HasKey(wp => wp.ID_WishList_Book);

            builder.Entity<WishList_Book>()
                .HasOne(wp => wp.WishList)
                .WithMany(w => w.WishList_Book)
                .HasForeignKey(wp => wp.ID_WishList)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WishList_Book>()
                .HasOne(wp => wp.Book)
                .WithMany(b => b.WishList_Book)
                .HasForeignKey(wp => wp.ISBN)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BooksAuthors { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<WishList_Book> WishListBooks { get; set; }

    }

}
