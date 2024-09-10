using Microsoft.EntityFrameworkCore;

namespace LibrarySystems.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {}
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}
}