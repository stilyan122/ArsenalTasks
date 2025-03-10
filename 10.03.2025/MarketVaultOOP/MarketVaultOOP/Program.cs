using MarketVaultOOP;
using MarketVaultOOP.Models;

Console.WriteLine("Welcome to app!");
Console.WriteLine("0: End app");
Console.WriteLine("1: Show all products in DB");
Console.WriteLine("2: Show all orders in DB");
Console.WriteLine("3: Show all customer in DB");
Console.WriteLine("4: Add a product in DB");
Console.WriteLine("5: Add an order in DB");
Console.WriteLine("6: Add a customer in DB");
Console.WriteLine("7: Edit a product in DB");
Console.WriteLine("8: Edit a customer in DB");
Console.WriteLine("9: Show all products which have lower or equal price than given");
Console.WriteLine("10: Show all products which have higher or equal price than given");
Console.WriteLine("11: Show all products which are available to be ordered");
Console.WriteLine("12: Show all products which have been ordered by a certain customer");
Console.WriteLine("13: Show certain customer info");
Console.WriteLine("14: Show certain product info");
Console.WriteLine("15: Show top 3 most ordered products (along with times ordered)");
Console.WriteLine("16: Show all customers with certain product in their orders");

int command = int.Parse(Console.ReadLine());
SupermarketManager manager = new();

while (command != 0)
{
	if (command == 1)
	{
		manager.ShowProducts();
	}
	else if (command == 2)
	{
		manager.ShowOrders();
	}
	else if (command == 3)
	{
		manager.ShowCustomers();
	}
	else if (command == 4)
	{
		Console.Write("Enter name: ");
		string name = Console.ReadLine();

		Console.Write("Enter price: ");
		decimal price = decimal.Parse(Console.ReadLine());

		Console.Write("Enter stock: ");
		double stock = double.Parse(Console.ReadLine());

		Product product = new(0, name, price, stock);
		manager.AddProduct(product);
	}
	else if (command == 5)
	{
        Console.Write("Enter customer name: ");
		string customerName = Console.ReadLine();

		Customer? customer = manager.GetCustomer(customerName);

		if (customer == null)
		{
            Console.WriteLine("Invalid customer name!");
            command = int.Parse(Console.ReadLine());
			continue;
        }

        Console.WriteLine("Enter product names (until END command): ");
        string productName = Console.ReadLine();

		List<Product> orderedProducts = new List<Product>();

		while (productName.ToUpper() != "END")
		{
			Product? product = manager.GetProduct(productName);

			if (product == null)
			{
                Console.WriteLine("Invalid product name!");
            }
			else if (product.Stock - 1 < 0)
			{
                Console.WriteLine("Cannot order this product! It's not available!");
			}
			else
			{
				orderedProducts.Add(product);
				product.Stock--;
			}

            productName = Console.ReadLine();
        }

        Order order = new Order(0, customer, orderedProducts);
		customer.AddOrder(order);
		manager.AddOrder(order);
	}
	else if (command == 6)
	{
        Console.Write("Enter name: ");
		string customerName = Console.ReadLine();

        Console.Write("Enter customer email: ");
        string customerEmail = Console.ReadLine();

        Console.Write("Enter customer phone: ");
        string customerPhone = Console.ReadLine();

        Customer customer = new Customer(0, customerName, customerEmail, customerPhone);
		manager.AddCustomer(customer);
	}
	else if (command == 7)
	{
        Console.Write("Enter product name: ");
		string productName = Console.ReadLine();

		Product? product = manager.GetProduct(productName);

		if (product == null)
		{
            Console.WriteLine("Invalid product");
            command = int.Parse(Console.ReadLine());
			continue;
        }

        Console.WriteLine("Properties:");
        Console.WriteLine(product.ToString());

        Console.Write("Product new name: ");
		string newName = Console.ReadLine();

        Console.Write("Product new price: ");
        decimal newPrice = decimal.Parse(Console.ReadLine());

        Console.Write("Product new stock: ");
        double newStock = double.Parse(Console.ReadLine());

		manager.UpdateProduct(product, newName, newPrice, newStock);
    }
    else if (command == 8)
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Customer? customer = manager.GetCustomer(customerName);

        if (customer == null)
        {
            Console.WriteLine("Invalid customer");
            command = int.Parse(Console.ReadLine());
            continue;
        }

        Console.WriteLine("Properties:");
        Console.WriteLine(customer.ToString());

        Console.Write("Customer new name: ");
        string newName = Console.ReadLine();

        Console.Write("Customer new email: ");
        string newEmail = Console.ReadLine();

        Console.Write("Customer new phone: ");
        string newPhone = Console.ReadLine();

        manager.UpdateCustomer(customer, newName, newEmail, newPhone);
    }
	else if (command == 9)
	{
		decimal price = decimal.Parse(Console.ReadLine());
		var products = manager
			.FilterProducts(p => p.Price <= price)
			.ToList();

		products.ForEach(p => Console.WriteLine(p.ToString()));
	}
    else if (command == 10)
    {
        decimal price = decimal.Parse(Console.ReadLine());
        var products = manager
            .FilterProducts(p => p.Price >= price)
            .ToList();

        products.ForEach(p => Console.WriteLine(p.ToString()));
    }
	else if (command == 11)
	{
		var available = manager
			.FilterProducts(p => p.Stock > 0)
			.ToList();

        available.ForEach(p => Console.WriteLine(p));
	}
	else if (command == 12)
	{
		Console.Write("Enter customer name: ");
		string customerName = Console.ReadLine();

		Customer? customer = manager.GetCustomer(customerName);

		if (customer == null) 
		{
            Console.WriteLine("Cannot find customer!");
            command = int.Parse(Console.ReadLine());
			continue;
        }

		var ordered = customer.Orders.SelectMany(o => o.Products).ToList();
		ordered.ForEach(o => Console.WriteLine(o.ToString()));
	}
    else if (command == 13) 
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Customer? customer = manager.GetCustomer(customerName);

        if (customer == null)
        {
            Console.WriteLine("Cannot find customer!");
            command = int.Parse(Console.ReadLine());
            continue;
        }

        Console.WriteLine(customer.ToString());
    }
    else if (command == 14)
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();

        Product? product = manager.GetProduct(productName);

        if (product == null)
        {
            Console.WriteLine("Invalid product");
            command = int.Parse(Console.ReadLine());
            continue;
        }

        Console.WriteLine(product.ToString());
    }
    else if (command == 15)
    {
        Dictionary<Product, long> orders = new Dictionary<Product, long>();
        manager.ProcessOrders(o =>
        {
            foreach (var order in o)
            {
                foreach (var product in order.Products)
                {
                    if (orders.ContainsKey(product))
                    {
                        orders[product]++;
                    }
                    else
                    {
                        orders.Add(product, 1);
                    }
                }
            }
        });

        var top3Products = orders.OrderByDescending(o => o.Value).Take(3)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        foreach (var kvp in top3Products)
        {
            Console.WriteLine($"{kvp.Key} ({kvp.Value} time/s)");
        }
    }
    else if (command == 16)
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();

        Product? product = manager.GetProduct(productName);

        if (product == null)
        {
            Console.WriteLine("Invalid product");
            command = int.Parse(Console.ReadLine());
            continue;
        }

        var customers = manager.FilterCustomers(c => c.Orders.Any(o => o
            .Products.Any(p => p.Name == product.Name))).ToList();

        customers.ForEach(c => Console.WriteLine(c));
    }

    command = int.Parse(Console.ReadLine());
}