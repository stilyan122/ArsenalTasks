namespace MarketVault
{
    public class CommandManager
    {
        private DbManager dbManager;

        public CommandManager(DbManager manager)
        {
            this.dbManager = manager;
        }

        public void StartApp()
        {
            Console.WriteLine("Welcome to MarketVault App!");
            Console.WriteLine("Please choose from the following commands:");
            Console.WriteLine("0: End App");
            Console.WriteLine("1: Initialize DB");
            Console.WriteLine("2: Initialize Tables in DB");
            Console.WriteLine("3: Use MarketVault DB");
            Console.WriteLine("4: Insert Category in DB");
            Console.WriteLine("5: Insert Product in DB");
            Console.WriteLine("6: Insert Customer in DB");
            Console.WriteLine("7: Insert Employee in DB");
            Console.WriteLine("8: Insert Supplier in DB");
            Console.WriteLine("9: Insert ProductSupplier in DB");
            Console.WriteLine("10: Insert Order in DB");
            Console.WriteLine("11: Insert Order Details in DB");
            Console.WriteLine("12: Insert Payment in DB");

            int number = -1;
            while (number != 0)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            bool result1 = this.dbManager.CreateDB();
                            if (result1)
                            {
                                Console.WriteLine("Database MarketVault successfully initialized!");
                            }
                            else
                            {
                                Console.WriteLine("Database MarketVault already exists!");
                            }
                            break;
                        case 2:
                            bool result2 =  this.dbManager.CreateTables();
                            if (result2)
                            {
                                Console.WriteLine("Tables in MarketVault successfully initialized!");
                            }
                            else
                            {
                                Console.WriteLine("No db created! Please create your DB!");
                            }
                            break;
                        case 3:
                            bool result3 = this.dbManager.UseDB();
                            if (result3)
                            {
                                Console.WriteLine("DB MarketVault successfully used!");
                            }
                            else
                            {
                                Console.WriteLine("Cannot use DB! Make sure it exists!");
                            }
                            break;
                        case 4:
                            bool result4 = this.InsertCategory();
                            if (result4)
                            {
                                Console.WriteLine("Category successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Category cannot be inserted");
                            }
                            break;
                        case 5:
                            bool result5 = this.InsertProduct();
                            if (result5)
                            {
                                Console.WriteLine("Product successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Product cannot be inserted");
                            }
                            break;
                        case 6:
                            bool result6 = this.InsertCustomer();
                            if (result6)
                            {
                                Console.WriteLine("Customer successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Customer cannot be inserted");
                            }
                            break;
                        case 7:
                            bool result7 = this.InsertEmployee();
                            if (result7)
                            {
                                Console.WriteLine("Employee successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Employee cannot be inserted");
                            }
                            break;
                        case 8:
                            bool result8 = this.InsertSupplier();
                            if (result8)
                            {
                                Console.WriteLine("Supplier successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Supplier cannot be inserted");
                            }
                            break;
                        case 9:
                            bool result9 = this.InsertProductSupplier();
                            if (result9)
                            {
                                Console.WriteLine("ProductSupplier successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("ProductSupplier cannot be inserted");
                            }
                            break;
                        case 10:
                            bool result10 = this.InsertOrder();
                            if (result10)
                            {
                                Console.WriteLine("Order successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Order cannot be inserted");
                            }
                            break;
                        case 11:
                            bool result11 = this.InsertOrderDetails();
                            if (result11)
                            {
                                Console.WriteLine("Order Details successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Order Details cannot be inserted");
                            }
                            break;
                        case 12:
                            bool result12 = this.InsertPayment();
                            if (result12)
                            {
                                Console.WriteLine("Payment successfully inserted!");
                            }
                            else
                            {
                                Console.WriteLine("Payment cannot be inserted");
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format, try again");
                }
            }
        }

        #region InsertCommands
        private bool InsertCategory()
        {
            try
            {
                Console.Write("Type category name: ");
                return this.dbManager.InsertCategory(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertProduct()
        {
            try
            {
                Console.Write("Type product name: ");
                string name = Console.ReadLine();
                Console.Write("Type product price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Type product stock: ");
                decimal stock = decimal.Parse(Console.ReadLine());
                Console.Write("Type product category name: ");
                string categoryName = Console.ReadLine();
                return this.dbManager.InsertProduct(name, price, stock, categoryName);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertCustomer()
        {
            try
            {
                Console.Write("Type customer full name: ");
                string name = Console.ReadLine();
                Console.Write("Type customer phone number: ");
                string phone = Console.ReadLine();
                Console.Write("Type customer email number: ");
                string email = Console.ReadLine();
                return this.dbManager.InsertCustomer(name, phone, email);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertEmployee()
        {
            try
            {
                Console.Write("Type employee full name: ");
                string name = Console.ReadLine();
                Console.Write("Type employee position: ");
                string position = Console.ReadLine();
                Console.Write("Type employee salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                return this.dbManager.InsertEmployee(name, position, salary);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertSupplier()
        {
            try
            {
                Console.Write("Type supplier full name: ");
                string name = Console.ReadLine();
                Console.Write("Type supplier position: ");
                string email = Console.ReadLine();
                return this.dbManager.InsertSupplier(name, email);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertProductSupplier()
        {
            try
            {
                Console.Write("Type product name: ");
                string productName = Console.ReadLine();
                Console.Write("Type supplier name: ");
                string supplierName = Console.ReadLine();
                return this.dbManager.InsertProductSupplier(productName, supplierName);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertOrder()
        {
            try
            {
                Console.Write("Type order number: ");
                int orderNumber = int.Parse(Console.ReadLine());
                Console.Write("Type customer name: ");
                string customerName = Console.ReadLine();
                Console.Write("Type employee name: ");
                string employeeName = Console.ReadLine();
                Console.Write("Type date made (yyyy-MM-dd) format: ");
                DateTime dateMade = DateTime.Parse(Console.ReadLine());
                return this.dbManager.InsertOrder(orderNumber, customerName, employeeName, dateMade);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertOrderDetails()
        {
            try
            {
                Console.Write("Type product name: ");
                string productName = Console.ReadLine();
                Console.Write("Type order number: ");
                int orderNumber = int.Parse(Console.ReadLine());
                Console.Write("Type order quantity: ");
                decimal quantity = decimal.Parse(Console.ReadLine());
                return this.dbManager.InsertOrderDetails(productName, orderNumber, quantity);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        private bool InsertPayment()
        {
            try
            {
                Console.Write("Type order number: ");
                int orderNumber = int.Parse(Console.ReadLine());
                Console.Write("Type payment method: ");
                string paymentMethod = Console.ReadLine();
                Console.Write("Type amount paid: ");
                decimal amountPaid = decimal.Parse(Console.ReadLine());
                return this.dbManager.InsertPayment(orderNumber, paymentMethod, amountPaid);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number of parameters or parameters format!");
            }

            return true;
        }
        #endregion
    }
}
