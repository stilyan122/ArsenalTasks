namespace MarketVault
{
    using Microsoft.Data.SqlClient;
    using System.Text;

    public class DbManager
    {
        // Change connection string according to yours
        private string connectionString = @"Data Source=.;" +
            "Integrated Security=True;Trust Server Certificate=True;" +
            "Initial Catalog=master;";
        private SqlConnection connection;
        private SqlCommand command;

        #region ExecuteMethods
        private void ExecuteNonQueryWithoutParameters(string query)
        {
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                this.command = new(query, connection);
                using (this.command)
                {
                    this.command.ExecuteNonQuery();
                }
            }
        }

        private void ExecuteNonQueryWithParameters(string query, List<string> parameters,
            List<object> values)
        {
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                this.command = new(query, connection);

                using (this.command)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        this.command.Parameters.AddWithValue(parameters[i], values[i]);
                    }

                    this.command.ExecuteNonQuery();
                }
            }
        }

        private string ExecuteReader(string query, List<string> columns, StringBuilder sb)
        {
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                this.command = new(query, connection);

                using (this.command)
                {
                    foreach (string column in columns)
                    {
                        sb.Append("[" + column + "] ");
                    }

                    sb.AppendLine();

                    // ==== - length equal to all columns length + [ ] count + whitespaces count
                    string equalSigns = new('=', (columns.Sum(c => c.Length + 2)) + columns.Count - 1);

                    sb.AppendLine(equalSigns);

                    SqlDataReader reader = this.command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        sb.Clear();
                        sb.AppendLine("No results found!");
                        return sb.ToString().Trim();
                    }

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < columns.Count; i++)
                            {
                                sb.Append("[" + reader[i] + "] ");
                            }
                            sb.AppendLine();
                        }
                    }

                    sb.AppendLine(equalSigns);
                }
            }

            return sb.ToString().Trim();
        }

        private string ExecuteReaderWithParameters(string query, List<string> columns, StringBuilder sb,
            Dictionary<string, object> parameters)
        {
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                this.command = new(query, connection);

                using (this.command)
                {
                    foreach (var parameter in parameters)
                    {
                        this.command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }

                    foreach (string column in columns)
                    {
                        sb.Append("[" + column + "] ");
                    }

                    sb.AppendLine();

                    // ==== - length equal to all columns length + [ ] count + whitespaces count
                    string equalSigns = new('=', (columns.Sum(c => c.Length + 2)) + columns.Count - 1);

                    sb.AppendLine(equalSigns);

                    SqlDataReader reader = this.command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        sb.Clear();
                        sb.AppendLine("No results found!");
                        return sb.ToString().Trim();
                    }

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < columns.Count; i++)
                            {
                                sb.Append("[" + reader[i] + "] ");
                            }
                            sb.AppendLine();
                        }
                    }

                    sb.AppendLine(equalSigns);
                }
            }

            return sb.ToString().Trim();
        }

        #endregion

        #region DBMethods

        private bool DatabaseExists()
        {
            try
            {
                using (this.connection = new SqlConnection(this.connectionString))
                {
                    this.connection.Open();
                    string query = "SELECT COUNT(*) FROM sys.databases WHERE name = 'MarketVault'";
                    this.command = new(query, this.connection);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception)
            {

            }

            return false;
        }

        public bool UseDB()
        {
            if (this.DatabaseExists())
            {
                if (this.connectionString.Contains("Initial Catalog"))
                {
                    this.connectionString = 
                        this.connectionString.Replace("Initial Catalog=master",
                        "Initial Catalog=MarketVault");
                }
                else
                {
                    this.connectionString += "Initial Catalog=MarketVault";
                }

                return true;
            }

            return false;
        }

        #endregion

        #region GetIdMethods
        private int? GetCategoryId(string name)
        {
            using (this.connection = new SqlConnection(this.connectionString))
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
            using (this.connection = new SqlConnection(this.connectionString))
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
            using (this.connection = new SqlConnection(this.connectionString))
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
            using (this.connection = new SqlConnection(this.connectionString))
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
            using (this.connection = new SqlConnection(this.connectionString))
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
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                string query = "SELECT OrderId FROM Orders WHERE OrderNumber = @orderNumber";

                this.command = new(query, this.connection);

                this.command.Parameters.AddWithValue("@orderNumber", orderNumber);

                object result = this.command.ExecuteScalar();

                return result != null ? (int?)result : null;
            }
        }
        #endregion

        #region CreateMethods

        public bool CreateDB()
        {
            if (!this.DatabaseExists())
            {
                string query = @"CREATE DATABASE MarketVault;";

                if (!this.connectionString.Contains("Initial Catalog"))
                {
                    this.connectionString += "Initial Catalog=MarketVault";
                }

                this.ExecuteNonQueryWithoutParameters(query);

                return true;
            }

            return false;
        }

        public bool CreateTables()
        {
            if (this.DatabaseExists())
            {
                string query = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories')
                        BEGIN
                            CREATE TABLE Categories (
                                CategoryID INT PRIMARY KEY IDENTITY,
                                CategoryName NVARCHAR(100) NOT NULL
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
                        BEGIN
                            CREATE TABLE Products (
                                ProductID INT PRIMARY KEY IDENTITY,
                                ProductName NVARCHAR(255) NOT NULL,
                                Price DECIMAL(10,2) NOT NULL,
                                Stock DECIMAL(10,2) NOT NULL,
                                CategoryID INT,
                                FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Suppliers')
                        BEGIN
                            CREATE TABLE Suppliers (
                                SupplierID INT PRIMARY KEY IDENTITY,
                                SupplierName NVARCHAR(255) NOT NULL,
                                ContactEmail NVARCHAR(255)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProductSuppliers')
                        BEGIN
                            CREATE TABLE ProductSuppliers (
                                ProductID INT,
                                SupplierID INT,
                                PRIMARY KEY (ProductID, SupplierID),
                                FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
                                FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Customers')
                        BEGIN
                            CREATE TABLE Customers (
                                CustomerID INT PRIMARY KEY IDENTITY,
                                FullName NVARCHAR(255) NOT NULL,
                                Phone NVARCHAR(20) NOT NULL,
                                Email NVARCHAR(255) UNIQUE
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Employees')
                        BEGIN
                            CREATE TABLE Employees (
                                EmployeeID INT PRIMARY KEY IDENTITY,
                                FullName NVARCHAR(255) NOT NULL,
                                Position NVARCHAR(100),
                                Salary DECIMAL(10,2)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Orders')
                        BEGIN
                            CREATE TABLE Orders (
                                OrderID INT PRIMARY KEY IDENTITY,
                                OrderDate DATETIME DEFAULT GETDATE(),
                                OrderNumber INT,
                                CustomerID INT,
                                EmployeeID INT,
                                FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
                                FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OrderDetails')
                        BEGIN
                            CREATE TABLE OrderDetails (
                                OrderID INT,
                                ProductID INT,
                                Quantity DECIMAL(10,2) NOT NULL,
                                PRIMARY KEY (OrderID, ProductID),
                                FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
                                FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Payments')
                        BEGIN
                            CREATE TABLE Payments (
                                PaymentID INT PRIMARY KEY IDENTITY,
                                OrderID INT UNIQUE,
                                PaymentMethod NVARCHAR(50),
                                AmountPaid DECIMAL(10,2) NOT NULL,
                                FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
                            );
                        END";

                this.ExecuteNonQueryWithoutParameters(query);
                return true;
            }

            return false;
        }

        #endregion

        #region InsertMethods
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
            if (DatabaseExists() && categoryId != null)
            {
                string query = "INSERT INTO Products (ProductName, Price, Stock, CategoryID) " +
                    "VALUES (@productName, @price, @stock, @categoryId)";

                List<string> parameters = new() { "@productName", "@price", "@stock", @"categoryId" };
                List<object> values = new() { name, price, stock, categoryId };

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

                List<string> parameters = new() { "@supplierName", "@contactEmail" };
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
        #endregion

        #region GetAllMethods

        public string GetAllCategories()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT c.CategoryName FROM Categories AS c;";
            List<string> columns = new() { "Category Name" };

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllCustomers()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT c.FullName, c.Phone, c.Email FROM Customers AS c;";
            List<string> columns = new() { "Full Name", "Phone Number", "Email" };

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllEmployees()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT e.FullName, e.Position, e.Salary FROM Employees AS e;";
            List<string> columns = new() { "Full Name", "Position", "Salary" };

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllOrdersWithEmployeesAndCustomers()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT o.OrderDate, o.OrderNumber, c.FullName AS 'Customer Name', " +
                "c.Phone AS 'Customer Phone', c.Email AS 'Customer Email',e.FullName AS 'Employee Name'," +
                "e.Position AS 'Employee Position', e.Salary AS 'Employee Salary' " +
                "FROM Orders AS o JOIN Customers AS c ON o.CustomerID = c.CustomerID " +
                "JOIN Employees AS e ON o.EmployeeID = e.EmployeeID;";

            List<string> columns = new() { "Order Date", "Order Number", "Customer Full Name",
                "Customer Phone Number", "Customer Email", "Employee Full Name", 
                "Employee Position", "Employee Salary"};

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllOrderDetailsWithEmployeesAndProducts()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT o.OrderDate, o.OrderNumber," +
                "c.FullName AS 'Customer Name', c.Phone AS 'Customer Phone', " +
                "c.Email AS 'Customer Email', e.FullName AS 'Employee Name'," +
                "e.Position AS 'Employee Position', e.Salary AS 'Employee Salary', " +
                "od.Quantity, p.ProductName, p.Price AS 'Product Price', p.Stock AS 'Product Stock'," +
                "ca.CategoryName FROM Orders AS o JOIN Customers AS c " +
                "ON o.CustomerID = c.CustomerID JOIN Employees AS e " +
                "ON o.EmployeeID = e.EmployeeID JOIN OrderDetails AS od " +
                "ON od.OrderID = o.OrderID JOIN Products AS p ON p.ProductID = od.ProductID" +
                " JOIN Categories AS ca ON p.CategoryID = ca.CategoryID;";

            List<string> columns = new() { "Order Date", "Order Number", "Customer Full Name",
                "Customer Phone Number", "Customer Email", "Employee Full Name",
                "Employee Position", "Employee Salary", "Order Quantity", "Product Name",
                "Product Price", "Product Stock", "Product Category Name"};

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllPaidOrders()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT p.PaymentMethod, p.AmountPaid, " +
                "o.OrderNumber, o.OrderDate FROM Payments AS p JOIN Orders AS o " +
                "ON p.OrderID = o.OrderID;";

            List<string> columns = new() { "Payment Method", "Amount Paid", "Order Number",
                "Order Date"};

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllSuppliers()
        {
            StringBuilder sb = new StringBuilder();

            string query = "SELECT s.SupplierName, s.ContactEmail FROM Suppliers AS s;";

            List<string> columns = new() { "Supplier Name", "Supplier Email" };

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllSuppliedProducts()
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT p.ProductName, p.Price AS 'Product price',
                    p.Stock AS 'Product Stock', s.SupplierName, 
                    s.ContactEmail AS 'Supplier Email'
                    FROM ProductSuppliers AS ps
                    JOIN Products AS p
                    ON ps.ProductID = p.ProductID
                    JOIN Suppliers AS s
                    ON ps.SupplierID = s.SupplierID;";

            List<string> columns = new() { "Product Name", "Product Price",
                "Product Stock", "Supplier Full Name", "Supplier Email" };

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllProductsWithCategories()
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT p.ProductName, p.Price, 
                    p.Stock, c.CategoryName
                    FROM Products AS p
                    JOIN Categories AS c
                    ON p.CategoryID = c.CategoryID;";

            List<string> columns = new() { "Product Name", "Product Price",
                "Product Stock", "Category Name"};

            string output = ExecuteReader(query, columns, sb);

            return output;
        }

        public string GetAllProductsWithBiggerPrice(decimal price)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT p.ProductName,
                    p.Price, p.Stock, c.CategoryName
                    FROM Products AS p
                    JOIN Categories AS c
                    ON p.CategoryID = c.CategoryID
                    WHERE p.Price >= @price;";

            List<string> columns = new() { "Product Name", "Product Price",
                "Product Stock", "Category Name"};

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@price", price }
            };

            string output = ExecuteReaderWithParameters(query, columns, sb, parameters);

            return output;
        }

        public string GetAllOrdersWithGivenPaymentMethod(string paymentMethod)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT p.PaymentMethod, p.AmountPaid,
                    o.OrderNumber, o.OrderDate
                    FROM Payments AS p
                    JOIN Orders AS o
                    ON p.OrderID = o.OrderId
                    WHERE p.PaymentMethod = @paymentMethod;";

            List<string> columns = new() { "Payment Method", "Amount Paid",
                "Order Number", "Order Date" };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@paymentMethod", paymentMethod }
            };

            string output = ExecuteReaderWithParameters(query, columns, sb, parameters);

            return output;
        }

        public string GetAllEmployeesWithGivenPosition(string position)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT e.FullName, e.Salary
                        FROM Employees AS e
                        WHERE e.Position = @position;";

            List<string> columns = new() { "Full Name", "Salary" };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@position", position }
            };

            string output = ExecuteReaderWithParameters(query, columns, sb, parameters);

            return output;
        }

        public string GetAllOrdersWithLowerQuantity(decimal quantity)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT od.Quantity, p.ProductName,
	                   p.Price, p.Stock, 
	                   o.OrderDate, o.OrderNumber
                FROM OrderDetails AS od
                JOIN Products AS p
                ON p.ProductID = od.ProductID
                JOIN Orders AS o
                ON o.OrderID = od.OrderID
                WHERE od.Quantity <= @quantity;";

            List<string> columns = new() { "Quantity", "Product Name",
                "Product Price", "Product Stock", "Order Date", "Order Number" };

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@quantity", quantity }
            };

            string output = ExecuteReaderWithParameters(query, columns, sb, parameters);

            return output;
        }
        
        #endregion
    }
}
