using MarketVault.Core.Services;
using MarketVault.Infrastructure.Models;

namespace MarketVault.Core
{
    public class DbInitializer
    {
        private readonly ProductService _productService;
        private readonly EmployeeService _employeeService;
        private readonly OrderService _orderService;
        private readonly ProductOrderService _productOrderService;
        private readonly ProductSupplierService _productSupplierService;
        private readonly CategoryService _categoryService;
        private readonly SupplierService _supplierService;
        private readonly CustomerService _customerService;

        public DbInitializer(
            ProductService productService,
            EmployeeService employeeService,
            OrderService orderService,
            ProductOrderService productOrderService,
            ProductSupplierService productSupplierService,
            CategoryService categoryService,
            SupplierService supplierService,
            CustomerService customerService)
        {
            _productService = productService;
            _employeeService = employeeService;
            _orderService = orderService;
            _productOrderService = productOrderService;
            _productSupplierService = productSupplierService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _customerService = customerService;
        }

        public async Task InitializeDataFromFiles()
        {
            if (!(await _categoryService.GetAllCategoriesAsync()).Any())
                await AddCategoriesFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/categories.txt");

            if (!(await _supplierService.GetAllSuppliersAsync()).Any())
                await AddSuppliersFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/suppliers.txt");

            if (!(await _productService.GetAllProductsAsync()).Any())
                await AddProductsFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/products.txt");

            if (!(await _customerService.GetAllCustomersAsync()).Any())
                await AddCustomersFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/customers.txt");

            if (!(await _employeeService.GetAllEmployeesAsync()).Any())
                await AddEmployeesFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/employees.txt");

            if (!(await _orderService.GetAllOrdersAsync()).Any())
                await AddOrdersFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/orders.txt");

            if (!(await _productOrderService.GetAllProductOrdersAsync()).Any())
                await AddProductOrdersFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/productsOrders.txt");

            if (!(await _productSupplierService.GetAllProductSuppliersAsync()).Any())
                await AddProductSuppliersFromFile("../../../../MarketVault.Infrastructure/ConfigurationalData/productsSuppliers.txt");
        }

        private async Task AddProductsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);
            
            foreach (var line in lines)
            {
                var values = line.Split(',');

                var product = new Product
                {
                    Name = values[0],
                    Price = decimal.Parse(values[1]),
                    Quantity = int.Parse(values[2]),
                    CategoryId = int.Parse(values[3])
                };

                await _productService.AddProductAsync(product);
            }
        }

        private async Task AddEmployeesFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var employee = new Employee
                {
                    Name = values[0],
                    Position = values[1],
                    Salary = decimal.Parse(values[2])
                };

                await _employeeService.AddEmployeeAsync(employee);
            }
        }

        private async Task AddOrdersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); 

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var order = new Order
                {
                    OrderDate = DateTime.Parse(values[0]),
                    CustomerId = int.Parse(values[1]),
                    EmployeeId = int.Parse(values[2]),
                };

                await _orderService.AddOrderAsync(order);
            }
        }

        private async Task AddProductOrdersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); 

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var productOrder = new ProductOrder
                {
                    ProductId = int.Parse(values[0]),
                    OrderId = int.Parse(values[1]),
                    Quantity = int.Parse(values[2])
                };

                await _productOrderService.AddProductOrderAsync(productOrder);
            }
        }

        private async Task AddProductSuppliersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var productSupplier = new ProductSupplier
                {
                    ProductId = int.Parse(values[0]),
                    SupplierId = int.Parse(values[1]),
                    DeliveryPrice = decimal.Parse(values[2]),
                    DeliveryDate = DateTime.Parse(values[3])
                };

                await _productSupplierService.AddProductSupplierAsync(productSupplier);
            }
        }

        private async Task AddCategoriesFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); 

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var category = new Category
                {
                    Name = values[0]
                };

                await _categoryService.AddCategoryAsync(category);
            }
        }

        private async Task AddSuppliersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); 

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var supplier = new Supplier
                {
                    Name = values[0],
                    ContactNumber = values[1],
                    Email = values[2]
                };

                await _supplierService.AddSupplierAsync(supplier);
            }
        }

        private async Task AddCustomersFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); 

            foreach (var line in lines)
            {
                var values = line.Split(',');

                var customer = new Customer
                {
                    Name = values[0],
                    Email = values[1]
                };

                await _customerService.AddCustomerAsync(customer);
            }
        }
    }
}
