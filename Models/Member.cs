namespace LibrarySystems.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public List<Book> BorrowedBooks { get; set; } = new List<Book>(); // Initialize collection
    }
}
