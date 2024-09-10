namespace LibrarySystems.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Initialize with default value
        public string Author { get; set; } = string.Empty; // Initialize with default value
        public string ISBN { get; set; }  = string.Empty;// Initialize with default value
        public bool isAvailable { get; set; } = true;
        public DateTime? BorrowDate { get; set; }
        public int? MemberId { get; set; }
    }
}
