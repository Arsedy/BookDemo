using BookDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDemo.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "To Kill a Mocking)", Author = "Harper Lee", YearPublished = 1960 },
                new Book { Id = 2, Title = "1984", Author = "George Orwell", YearPublished = 1949 },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", YearPublished = 1925 }
                );
        }
    }
}
