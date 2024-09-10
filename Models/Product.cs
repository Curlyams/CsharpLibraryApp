public class Product 
{
    required public int ProductId { get; set; }
    required public string Name { get; set; }

    public decimal Price { get; set; } = 0.00m;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}