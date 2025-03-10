namespace MarketVaultOOP.Models
{
    public class Product(int id, string name, decimal price, double stock)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public double Stock { get; set; } = stock;

        public override string ToString()
        {
            return $"Product => ID: {Id}, Name: {Name}, Price: {Price:C}, Stock: {Stock}";
        }
    }
}
