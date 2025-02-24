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
                            bool result3 = this.dbManager.CreateTables();
                            if (result3)
                            {
                                Console.WriteLine("Tables in MarketVault successfully initialized!");
                            }
                            else
                            {
                                Console.WriteLine("No db created! Please create your DB!");
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
    }
}
