using System.Text;

namespace MarketVaultOOP.Models
{
    public class Customer(int id, string name, string email, string phone)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public List<Order> Orders { get; set; } = new List<Order>();

        public void AddOrder(Order order) => this.Orders.Add(order);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Customer => ID: {Id} Name: {Name} " +
                $"Email: {Email} Phone: {Phone}");
            this.Orders.ForEach(o => stringBuilder.AppendLine(o.ToString()));

            return stringBuilder.ToString();
        }
    }
}
