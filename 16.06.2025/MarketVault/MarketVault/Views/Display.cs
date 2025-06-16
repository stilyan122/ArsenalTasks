using MarketVault.Core.Services;
using MarketVault.Core;
using MarketVault.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using MarketVault.Infrastructure.Constants.Application;
using MarketVault.Infrastructure.Models;

namespace MarketVault.Views
{
    public class Display
    {
        private readonly ApplicationDbContext context;
        private readonly ProductService _productService;
        private readonly EmployeeService _employeeService ;
        private readonly OrderService _orderService;
        private readonly ProductOrderService _productOrderService;
        private readonly ProductSupplierService _productSupplierService;
        private readonly CategoryService _categoryService;
        private readonly SupplierService _supplierService;
        private readonly CustomerService _customerService;

        public Display()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseSqlServer(DbContextContants.ConnectionString)
                       .Options;

            this.context = new ApplicationDbContext(options);

            this._productService = new ProductService(context);
            this._employeeService = new EmployeeService(context);
            this._orderService = new OrderService(context);
            this._productOrderService = new ProductOrderService(context);
            this._productSupplierService = new ProductSupplierService(context);
            this._categoryService = new CategoryService(context);
            this._supplierService = new SupplierService(context);
            this._customerService = new CustomerService(context);
        }

        public async Task RunSeederAsync()
        {
            try
            {
                var initializer = new DbInitializer(
                    _productService,
                    _employeeService,
                    _orderService,
                    _productOrderService,
                    _productSupplierService,
                    _categoryService,
                    _supplierService,
                    _customerService
                );

                await initializer.InitializeDataFromFiles();
                Console.WriteLine("DB Initialized");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing DB!");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.WriteLine("=== MarketVault Console ===");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. List Categories");
                Console.WriteLine("3. Categories by Total Stock");
                Console.WriteLine("4. Add Customer");
                Console.WriteLine("5. List Customers");
                Console.WriteLine("6. Customers with No Orders");
                Console.WriteLine("7. Add Product");
                Console.WriteLine("8. List Products");
                Console.WriteLine("9. Products by Category");
                Console.WriteLine("10. Products Below Stock");
                Console.WriteLine("11. Never-Ordered Products");
                Console.WriteLine("12. Products In Order");
                Console.WriteLine("13. Add Supplier");
                Console.WriteLine("14. List Suppliers");
                Console.WriteLine("15. Suppliers for Product");
                Console.WriteLine("16. Suppliers with No Products");
                Console.WriteLine("17. Add Order");
                Console.WriteLine("18. List Orders");
                Console.WriteLine("19. Orders by Customer");
                Console.WriteLine("20. Orders by Order Date");
                Console.WriteLine("21. Products by Supplier");
                Console.WriteLine("22. Suppliers by Email Domain");
                Console.WriteLine("23. Update Category");
                Console.WriteLine("24. Delete Category");
                Console.WriteLine("25. Update Product");
                Console.WriteLine("26. Delete Product");
                Console.WriteLine("27. Update Customer");
                Console.WriteLine("28. Delete Customer");
                Console.WriteLine("29. Update Supplier");
                Console.WriteLine("30. Delete Supplier");
                Console.WriteLine("31. Update Employee");
                Console.WriteLine("32. Delete Employee");
                Console.WriteLine("33. Update Order");
                Console.WriteLine("34. Delete Order");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1": 
                            await AddCategory(); 
                            break;
                        case "2": 
                            await ListCategories(); 
                            break;
                        case "3": 
                            await ListCategoriesByStock(); 
                            break;
                        case "4": 
                            await AddCustomer(); 
                            break;
                        case "5": 
                            await ListCustomers(); 
                            break;
                        case "6": 
                            await ListCustomersNoOrders(); 
                            break;
                        case "7": 
                            await AddProduct(); 
                            break;
                        case "8": 
                            await ListProducts(); 
                            break;
                        case "9": 
                            await ListProductsByCategory(); 
                            break;
                        case "10": 
                            await ListProductsBelowStock(); 
                            break;
                        case "11": 
                            await ListNeverOrderedProducts(); 
                            break;
                        case "12": 
                            await ListProductsInOrder(); 
                            break;
                        case "13": 
                            await AddSupplier(); 
                            break;
                        case "14": 
                            await ListSuppliers(); 
                            break;
                        case "15": 
                            await ListSuppliersForProduct(); 
                            break;
                        case "16": 
                            await ListSuppliersNoProducts(); 
                            break;
                        case "17": 
                            await AddOrder(); 
                            break;
                        case "18": 
                            await ListOrders(); 
                            break;
                        case "19": 
                            await ListOrdersByCustomer(); 
                            break;
                        case "20": 
                            await ListOrdersByWeekday(); 
                            break;
                        case "21":
                            await ListProductsBySupplier();
                            break;
                        case "22":
                            await ListSuppliersByEmailDomain();
                            break;
                        case "23":
                            await UpdateCategory();
                            break;
                        case "24":
                            await DeleteCategory();
                            break;
                        case "25": 
                            await UpdateProduct(); 
                            break;
                        case "26": 
                            await DeleteProduct(); 
                            break;
                        case "27": 
                            await UpdateCustomer(); 
                            break;
                        case "28": 
                            await DeleteCustomer(); 
                            break;
                        case "29": 
                            await UpdateSupplier(); 
                            break;
                        case "30": 
                            await DeleteSupplier(); 
                            break;
                        case "31": 
                            await UpdateEmployee(); 
                            break;
                        case "32": 
                            await DeleteEmployee(); 
                            break;
                        case "33": 
                            await UpdateOrder(); 
                            break;
                        case "34": 
                            await DeleteOrder(); 
                            break;
                        case "0": return;
                        default:
                            Console.WriteLine("Invalid choice."); 
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception! {ex.Message}");
                }
                Console.WriteLine();
            }
        }

        private async Task AddCategory()
        {
            Console.Write("Enter Category Name: ");
            var name = Console.ReadLine();

            await _categoryService.AddCategoryAsync(new Category
            {
                Name = name
            });

            Console.WriteLine("Category added.");
        }

        private async Task ListCategories()
        {
            var list = await _categoryService.GetAllCategoriesAsync();

            Console.WriteLine("Categories in DB:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var c in list)
            {
                Console.WriteLine($"{c.CategoryId}: {c.Name}");
            }
        }

        private async Task ListCategoriesByStock()
        {
            var list = await _categoryService.GetCategoriesByTotalStockAsync();

            Console.WriteLine("Categories ordered by total stock:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var c in list)
            {
                Console.WriteLine($"{c.Name} – Total Stock: {c.Products.Sum(p => p.Quantity)}");
            }
        }

        private async Task AddCustomer()
        {
            Console.Write("Enter Customer Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Customer Email: ");
            var email = Console.ReadLine();

            await _customerService.AddCustomerAsync(new Customer
            {
                Name = name,
                Email = email
            });

            Console.WriteLine("Customer added.");
        }

        private async Task ListCustomers()
        {
            var list = await _customerService.GetAllCustomersAsync();

            Console.WriteLine("Customers in DB:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var c in list)
            {
                Console.WriteLine($"{c.CustomerId}: {c.Name} ({c.Email})");
            }
        }

        private async Task ListCustomersNoOrders()
        {
            var list = await _customerService.GetCustomersWithNoOrdersAsync();

            Console.WriteLine("Customers with no orders:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var c in list)
            {
                Console.WriteLine($"{c.Name} ({c.Email})");
            }
        }

        private async Task AddProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            var price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Product Quantity: ");
            var quantity = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Product CategoryId: ");
            var categoryId = int.Parse(Console.ReadLine()!);

            await _productService.AddProductAsync(new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                CategoryId = categoryId
            });

            Console.WriteLine("Product added.");
        }

        private async Task ListProducts()
        {
            var list = await _productService.GetAllProductsAsync();

            Console.WriteLine("Products in DB:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine($"{p.ProductId}: {p.Name} – {p.Price:C} ({p.Quantity})");
            }
        }

        private async Task ListProductsByCategory()
        {
            Console.Write("Enter CategoryId: ");
            var categoryId = int.Parse(Console.ReadLine()!);

            var list = await _productService.GetProductsByCategoryAsync(categoryId);

            Console.WriteLine($"Products in Category {categoryId}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine($"{p.Name} – {p.Category.Name}");
            }
        }

        private async Task ListProductsBelowStock()
        {
            Console.Write("Enter Threshold: ");
            var threshold = int.Parse(Console.ReadLine()!);

            var list = await _productService.GetProductsBelowStockAsync(threshold);

            Console.WriteLine($"Products with stock below {threshold}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine($"{p.Name} – {p.Quantity}");
            }
        }

        private async Task ListNeverOrderedProducts()
        {
            var list = await _productService.GetProductsNeverOrderedAsync();

            Console.WriteLine("Products never ordered:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine(p.Name);
            }
        }

        private async Task ListProductsInOrder()
        {
            Console.Write("Enter OrderId: ");
            var orderId = int.Parse(Console.ReadLine()!);

            var list = await _productService.GetProductsInOrderAsync(orderId);

            Console.WriteLine($"Products in Order {orderId}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine(p.Name);
            }
        }

        private async Task AddSupplier()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Contact Number: ");
            var phone = Console.ReadLine();

            await _supplierService.AddSupplierAsync(new Supplier
            {
                Name = name,
                Email = email,
                ContactNumber = phone
            });

            Console.WriteLine("Supplier added.");
        }

        private async Task ListSuppliers()
        {
            var list = await _supplierService.GetAllSuppliersAsync();

            Console.WriteLine("Suppliers in DB:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var s in list)
            {
                Console.WriteLine($"{s.SupplierId}: {s.Name} ({s.Email})");
            }
        }

        private async Task ListSuppliersForProduct()
        {
            Console.Write("Enter ProductId: ");
            var pid = int.Parse(Console.ReadLine()!);

            var list = await _supplierService.GetSuppliersByProductAsync(pid);

            Console.WriteLine($"Suppliers for Product {pid}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var s in list)
            {
                Console.WriteLine(s.Name);
            }
        }

        private async Task ListSuppliersNoProducts()
        {
            var list = await _supplierService.GetSuppliersWithNoProductsAsync();

            Console.WriteLine("Suppliers with no products:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var s in list)
            {
                Console.WriteLine(s.Name);
            }
        }

        private async Task AddOrder()
        {
            Console.Write("CustomerId: ");
            var cid = int.Parse(Console.ReadLine()!);

            Console.Write("EmployeeId: ");
            var eid = int.Parse(Console.ReadLine()!);

            Console.Write("OrderDate (yyyy-MM-dd): ");
            var dt = DateTime.Parse(Console.ReadLine()!);

            await _orderService.AddOrderAsync(new Order
            {
                CustomerId = cid,
                EmployeeId = eid,
                OrderDate = dt
            });

            Console.WriteLine("Order added.");
        }

        private async Task ListOrders()
        {
            var list = await _orderService.GetAllOrdersAsync();

            Console.WriteLine("Orders in DB:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var o in list)
            {
                Console.WriteLine($"{o.OrderId}: {o.Customer.Name} on {o.OrderDate:d}");
            }
        }

        private async Task ListOrdersByCustomer()
        {
            Console.Write("Enter CustomerId: ");
            var cid = int.Parse(Console.ReadLine()!);

            var list = await _orderService.GetCustomerOrdersAsync(cid);

            Console.WriteLine($"Orders by Customer {cid}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var o in list)
            {
                Console.WriteLine($"{o.OrderId}: {o.OrderDate:d}");
            }
        }

        private async Task ListOrdersByWeekday()
        {
            var list = await _orderService.GetOrdersOrderedByDateAsync();

            Console.WriteLine("Orders ordered by date:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var o in list)
            {
                Console.WriteLine($"{o.OrderId}: {o.OrderDate:dddd}");
            }
        }

        private async Task ListProductsBySupplier()
        {
            Console.Write("Enter SupplierId: ");
            var sid = int.Parse(Console.ReadLine()!);

            var list = await _productService.GetProductsBySupplierAsync(sid);

            Console.WriteLine($"Products supplied by {sid}:");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var p in list)
            {
                Console.WriteLine($"{p.ProductId}: {p.Name}");
            }
        }

        private async Task ListSuppliersByEmailDomain()
        {
            Console.Write("Enter email domain: ");
            var domain = Console.ReadLine();

            var list = await _supplierService.GetSuppliersByEmailDomainAsync(domain);

            Console.WriteLine($"Suppliers with domain '{domain}':");
            if (!list.Any())
            {
                Console.WriteLine("None");
            }

            foreach (var s in list)
            {
                Console.WriteLine($"{s.SupplierId}: {s.Name} ({s.Email})");
            }
        }

        private async Task UpdateCategory()
        {
            Console.Write("Enter CategoryId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var cats = await _categoryService.GetAllCategoriesAsync();
            var cat = cats.FirstOrDefault(c => c.CategoryId == id);
            if (cat == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New name (current: {cat.Name}): ");
            cat.Name = Console.ReadLine();
            await _categoryService.UpdateCategoryAsync(cat);

            Console.WriteLine("Category updated.");
        }

        private async Task DeleteCategory()
        {
            Console.Write("Enter CategoryId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _categoryService.DeleteCategoryAsync(id);
            Console.WriteLine("Category deleted.");
        }

        private async Task UpdateProduct()
        {
            Console.Write("Enter ProductId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var products = await _productService.GetAllProductsAsync();
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New name (current: {p.Name}): ");
            p.Name = Console.ReadLine();

            Console.Write($"New price (current: {p.Price}): ");
            p.Price = decimal.Parse(Console.ReadLine()!);

            Console.Write($"New qty (current: {p.Quantity}): ");
            p.Quantity = int.Parse(Console.ReadLine()!);

            await _productService.UpdateProductAsync(p);
            Console.WriteLine("Product updated.");
        }

        private async Task DeleteProduct()
        {
            Console.Write("Enter ProductId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _productService.DeleteProductAsync(id);
            Console.WriteLine("Product deleted.");
        }

        private async Task UpdateCustomer()
        {
            Console.Write("Enter CustomerId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var list = await _customerService.GetAllCustomersAsync();
            var c = list.FirstOrDefault(x => x.CustomerId == id);
            if (c == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New name (current: {c.Name}): ");
            c.Name = Console.ReadLine();

            Console.Write($"New email (current: {c.Email}): ");
            c.Email = Console.ReadLine();

            await _customerService.UpdateCustomerAsync(c);
            Console.WriteLine("Customer updated.");
        }

        private async Task DeleteCustomer()
        {
            Console.Write("Enter CustomerId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _customerService.DeleteCustomerAsync(id);
            Console.WriteLine("Customer deleted.");
        }

        private async Task UpdateSupplier()
        {
            Console.Write("Enter SupplierId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var list = await _supplierService.GetAllSuppliersAsync();
            var s = list.FirstOrDefault(x => x.SupplierId == id);
            if (s == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New name (current: {s.Name}): ");
            s.Name = Console.ReadLine();

            Console.Write($"New email (current: {s.Email}): ");
            s.Email = Console.ReadLine();

            Console.Write($"New phone (current: {s.ContactNumber}): ");
            s.ContactNumber = Console.ReadLine();

            await _supplierService.UpdateSupplierAsync(s);
            Console.WriteLine("Supplier updated.");
        }

        private async Task DeleteSupplier()
        {
            Console.Write("Enter SupplierId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _supplierService.DeleteSupplierAsync(id);
            Console.WriteLine("Supplier deleted.");
        }

        private async Task UpdateEmployee()
        {
            Console.Write("Enter EmployeeId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var list = await _employeeService.GetAllEmployeesAsync();
            var e = list.FirstOrDefault(x => x.EmployeeId == id);
            if (e == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New name (current: {e.Name}): ");
            e.Name = Console.ReadLine();

            Console.Write($"New position (current: {e.Position}): ");
            e.Position = Console.ReadLine();

            Console.Write($"New salary (current: {e.Salary}): ");
            e.Salary = decimal.Parse(Console.ReadLine()!);

            await _employeeService.UpdateEmployeeAsync(e);
            Console.WriteLine("Employee updated.");
        }

        private async Task DeleteEmployee()
        {
            Console.Write("Enter EmployeeId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _employeeService.DeleteEmployeeAsync(id);
            Console.WriteLine("Employee deleted.");
        }

        private async Task UpdateOrder()
        {
            Console.Write("Enter OrderId to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            var list = await _orderService.GetAllOrdersAsync();
            var o = list.FirstOrDefault(x => x.OrderId == id);
            if (o == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            Console.Write($"New CustomerId (current: {o.CustomerId}): ");
            o.CustomerId = int.Parse(Console.ReadLine()!);

            Console.Write($"New EmployeeId (current: {o.EmployeeId}): ");
            o.EmployeeId = int.Parse(Console.ReadLine()!);

            Console.Write($"New Date (yyyy-MM-dd) (current: {o.OrderDate:yyyy-MM-dd}): ");
            o.OrderDate = DateTime.Parse(Console.ReadLine()!);

            await _orderService.UpdateOrderAsync(o);
            Console.WriteLine("Order updated.");
        }

        private async Task DeleteOrder()
        {
            Console.Write("Enter OrderId to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) return;

            await _orderService.DeleteOrderAsync(id);
            Console.WriteLine("Order deleted.");
        }
    }
}
