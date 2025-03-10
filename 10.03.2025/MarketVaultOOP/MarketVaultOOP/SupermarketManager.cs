using MarketVaultOOP.Models;

namespace MarketVaultOOP
{
    public class SupermarketManager
    {
        private List<Product> products = new List<Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Order> orders = new List<Order>();

        public void AddProduct(Product product)
        {
            try
            {
                product.Id = this.products.Count + 1;
                products.Add(product);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot add product! Try again!");
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                customer.Id = this.customers.Count + 1;
                customers.Add(customer);
                Console.WriteLine("Customer added successfully!");
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot add customer! Try again!");
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                order.OrderId = this.orders.Count + 1;
                orders.Add(order);
                Console.WriteLine("Order added successfully!");
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot add order! Try again!");
            }
        }

        public void ShowProducts()
        {
            if (this.products.Count > 0)
            {
                Console.WriteLine("Products in DB:");
                products.ForEach(p => Console.WriteLine(p.ToString()));
            }
            else
            {
                Console.WriteLine("No products in DB");
            }
        }

        public void ShowOrders()
        {
            if (this.orders.Count > 0)
            {
                Console.WriteLine("Orders in DB:");
                orders.ForEach(o => Console.WriteLine(o.ToString()));
            }
            else
            {
                Console.WriteLine("No orders in DB");
            }
        }

        public void ShowCustomers()
        {
            if (this.customers.Count > 0)
            {
                Console.WriteLine("Customers in DB:");
                customers.ForEach(c => Console.WriteLine(c.ToString()));
            }
            else
            {
                Console.WriteLine("No customers in DB");
            }
        }

        public Customer? GetCustomer(string customerName) => this.customers
            .FirstOrDefault(c => c.Name == customerName);

        public Product? GetProduct(string productName) => this.products
            .FirstOrDefault(c => c.Name == productName);

        public void UpdateProduct(Product product, string newName, decimal newPrice,
            double newStock)
        {
            product.Price = newPrice;
            product.Stock = newStock;
            product.Name = newName;
        }

        public void UpdateCustomer(Customer customer, string newName, string newEmail,
            string newPhone)
        {
            customer.Name = newName;
            customer.Email = newEmail;
            customer.Phone = newPhone;
        }

        public IEnumerable<Product> FilterProducts(Predicate<Product> filter)
            => this.products.Where(p => filter(p));

        public IEnumerable<Customer> FilterCustomers(Predicate<Customer> filter)
            => this.customers.Where(c => filter(c));

        public void ProcessOrders(Action<List<Order>> ordersAction)
        {
            ordersAction(this.orders);
        }
    }
}
