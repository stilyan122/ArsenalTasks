namespace MarketVault
{
    using Microsoft.Data.SqlClient;
    using System.Xml.Linq;

    public class DbManager
    {
        // Change connection string according to yours
        private string connectionString = 
            @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection;
        private SqlCommand command;

        public DbManager()
        {
            this.connection = new(connectionString);
            if (!this.connectionString.Contains("Database"))
            {
                this.connectionString += "Database=MarketVault";
            }
        }

        private void ExecuteNonQueryWithoutParameters(string query)
        {
            using (this.connection)
            {
                this.connection.Open();
                this.command = new(query, connection);
                this.command.ExecuteNonQuery();
            }
        }

        private void ExecuteNonQueryWithParameters(string query, List<string> parameters,
            List<object> values)
        {
            using (this.connection)
            {
                this.connection.Open();
                this.command = new(query, connection);

                for (int i = 0; i < parameters.Count; i++)
                {
                    this.command.Parameters.AddWithValue(parameters[i], values[i]);
                }

                this.command.ExecuteNonQuery();
            }
        }

        private bool DatabaseExists()
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT COUNT(*) FROM sys.databases WHERE name = MarketVault";
                this.command = new(query, this.connection);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private int? GetCategoryId(string name)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT CategoryID FROM Categories WHERE CategoryName = @categoryName";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@categoryName", name);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        private int? GetProductId(string name)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT ProductId FROM Products WHERE ProductName = @productName";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@productName", name);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        private int? GetSupplierId(string name)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT SupplierId FROM Suppliers WHERE SupplierName = @supplierName";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@supplierName", name);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        private int? GetCustomerId(string name)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT CustomerId FROM Customers WHERE FullName = @fullName";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@fullName", name);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        private int? GetEmployeeId(string name)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT EmployeeId FROM Employees WHERE FullName = @fullName";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@fullName", name);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        private int? GetOrderId(int orderNumber)
        {
            using (this.connection)
            {
                this.connection.Open();
                string query = "SELECT OrderId FROM Orders WHERE OrderNumber = @orderNumber";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@orderNumber", orderNumber);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }

        public bool CreateDB()
        {
            if (!this.DatabaseExists())
            {
                string query = @"CREATE DATABASE MarketVault;

                            USE MarketVault;";

                this.ExecuteNonQueryWithoutParameters(query);

                return true;
            }

            return false;
        }

        public bool CreateTables()
        {
            if (this.DatabaseExists())
            {
                string query = @"CREATE TABLE Categories (
                            CategoryID INT PRIMARY KEY IDENTITY,
                            CategoryName NVARCHAR(100) NOT NULL
                        );

                        CREATE TABLE Products (
                            ProductID INT PRIMARY KEY IDENTITY,
                            ProductName NVARCHAR(255) NOT NULL,
                            Price DECIMAL(10,2) NOT NULL,
                            Stock DECIMAL(10,2) NOT NULL,
                            CategoryID INT,
                            FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
                        );

                        CREATE TABLE Suppliers (
                            SupplierID INT PRIMARY KEY IDENTITY,
                            SupplierName NVARCHAR(255) NOT NULL,
                            ContactEmail NVARCHAR(255)
                        );

                        CREATE TABLE ProductSuppliers (
                            ProductID INT,
                            SupplierID INT,
                            PRIMARY KEY (ProductID, SupplierID),
                            FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
                            FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
                        );

                        CREATE TABLE Customers (
                            CustomerID INT PRIMARY KEY IDENTITY,
                            FullName NVARCHAR(255) NOT NULL,
                            Phone NVARCHAR(20) NOT NULL,
                            Email NVARCHAR(255) UNIQUE
                        );

                        CREATE TABLE Employees (
                            EmployeeID INT PRIMARY KEY IDENTITY,
                            FullName NVARCHAR(255) NOT NULL,
                            Position NVARCHAR(100),
                            Salary DECIMAL(10,2)
                        );

                        CREATE TABLE Orders (
                            OrderID INT PRIMARY KEY IDENTITY,
                            OrderDate DATETIME DEFAULT GETDATE(),
                            OrderNumber INT,
                            CustomerID INT,
                            EmployeeID INT,
                            FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
                            FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
                        );

                        CREATE TABLE OrderDetails (
                            OrderID INT,
                            ProductID INT,
                            Quantity DECIMAL(10,2) NOT NULL,
                            PRIMARY KEY (OrderID, ProductID),
                            FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
                            FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                        );

                        CREATE TABLE Payments (
                            PaymentID INT PRIMARY KEY IDENTITY,
                            OrderID INT UNIQUE,
                            PaymentMethod NVARCHAR(50),
                            AmountPaid DECIMAL(10,2) NOT NULL,
                            FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
                        );
                        ";

                this.ExecuteNonQueryWithoutParameters(query);
                return true;
            }

            return false;
        }

        public bool InsertCategory(string name)
        {
            if (DatabaseExists())
            {
                string query = "INSERT INTO Categories (CategoryName) VALUES (@name)";

                List<string> parameters = new() { "@name" };
                List<object> values = new() { name };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertProduct(string name, decimal price, decimal stock, string categoryName)
        {
            int? categoryId = GetCategoryId(categoryName);
            if (DatabaseExists() &&  categoryId != null)
            {
                string query = "INSERT INTO Products (ProductName, Price, Stock, CategoryID) " +
                    "VALUES (@productName, @price, @stock, @categoryId)";

                List<string> parameters = new() { "@productName", "@price", "@stock", @"categoryId" };
                List<object> values = new() { name, price, stock, categoryId};

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertCustomer(string fullName, string phone, string email)
        {
            if (DatabaseExists())
            {
                string query = "INSERT INTO Customers (FullName, Phone, Email) " +
                    "VALUES (@fullName, @phone, @email)";

                List<string> parameters = new() { "@fullName", "@phone", "@email" };
                List<object> values = new() { fullName, phone, email };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertEmployee(string fullName, string position, decimal salary)
        {
            if (DatabaseExists())
            {
                string query = "INSERT INTO Employees (FullName, Position, Salary) " +
                    "VALUES (@fullName, @position, @salary)";

                List<string> parameters = new() { "@fullName", "@position", "@salary" };
                List<object> values = new() { fullName, position, salary };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertSupplier(string name, string email)
        {
            if (DatabaseExists())
            {
                string query = "INSERT INTO Suppliers (SupplierName, ContactEmail) " +
                    "VALUES (@supplierName, @contactEmail)";

                List<string> parameters = new() { "@supplierName", "@contactEmail"};
                List<object> values = new() { name, email };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertProductSupplier(string productName, string supplierName)
        {
            int? productId = GetProductId(productName);
            int? supplierId = GetSupplierId(supplierName);
            if (DatabaseExists() && productId != null && supplierId != null)
            {
                string query = "INSERT INTO ProductSuppliers (ProductID, SupplierID) " +
                    "VALUES (@productId, @supplierId)";

                List<string> parameters = new() { "@productId", "@supplierId" };
                List<object> values = new() { productId, supplierId };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertOrder(int orderNumber, string customerName, string employeeName, DateTime date)
        {
            int? customerId = GetCustomerId(customerName);
            int? employeeId = GetEmployeeId(employeeName);

            if (DatabaseExists() && customerId != null && employeeId != null)
            {
                string query = "INSERT INTO Orders (OrderNumber, CustomerID, EmployeeID, OrderDate) " +
                    "VALUES (@orderNumber, @customerId, @employeeId, @date)";

                List<string> parameters = new() { "@orderNumber", "@customerId", "@employeeId", "@date" };
                List<object> values = new() { orderNumber, customerId, employeeId, date };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertOrderDetails(string productName, int orderNumber, decimal quantity)
        {
            int? productId = GetProductId(productName);
            int? orderId = GetOrderId(orderNumber);

            if (DatabaseExists() && productId != null && orderId != null)
            {
                string query = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity) " +
                    "VALUES (@orderId, @productId, @quantity)";

                List<string> parameters = new() { "@orderId", "@productId", "@quantity" };
                List<object> values = new() { orderId, productId, quantity };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }

        public bool InsertPayment(int orderNumber, string paymentMethod, decimal amountPaid)
        {
            int? orderId = GetOrderId(orderNumber);

            if (DatabaseExists() && orderId != null)
            {
                string query = "INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid) " +
                    "VALUES (@orderId, @paymentMethod, @amountPaid)";

                List<string> parameters = new() { "@orderId", "@paymentMethod", "@amountPaid" };
                List<object> values = new() { orderId, paymentMethod, amountPaid };

                this.ExecuteNonQueryWithParameters(query, parameters, values);

                return true;
            }

            return false;
        }
    }
}
