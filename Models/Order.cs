using System.Net.Http.Headers;

public class Order 
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<Product > Products { get; set; } = new List<Product>();
}