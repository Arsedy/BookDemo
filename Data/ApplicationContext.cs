using BookDemo.Data.Config;
using BookDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace BookDemo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public  DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
