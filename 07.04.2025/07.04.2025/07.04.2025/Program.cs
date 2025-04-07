using Presentation;

namespace _07._04._2025
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var view = new Display();
            await view.ShowMenu();
        }
    }
}