using System.Text;

namespace MarketVaultOOP.Models
{
    public class Order(int orderId, Customer customer, List<Product> products)
    {
        public int OrderId { get; set; } = orderId;
        public Customer Customer { get; set; } = customer;
        public List<Product> Products { get; set; } = products;
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Order => ID: {OrderId}, Date: {OrderDate.ToString()}. ");
            stringBuilder.AppendLine("Order products:");
            Products.ForEach(p => stringBuilder.AppendLine(p.ToString()));

            return stringBuilder.ToString();
        }
    }
}
