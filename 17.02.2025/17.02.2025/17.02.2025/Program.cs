using DBLayer;
using LogLayer;
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        DatabaseHandler dbHandler = new DatabaseHandler();

        ILogger txtLogger = new TxtLogger();
        ILogger excelLogger = new ExcelLogger();

        CommandHandler commandHandler = new CommandHandler(dbHandler, txtLogger, excelLogger);

        while (true)
        {
            try
            {
                Console.WriteLine("Enter a command (or type 'END' to exit):");
                string[] commandInput = Console.ReadLine().Split(" ");

                if (commandInput[0]?.ToLower() == "end")
                {
                    break;
                }

                commandHandler.ExecuteCommand(commandInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in app! Please try again!");
            }
        }
    }
}
