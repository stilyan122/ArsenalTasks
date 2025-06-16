using MarketVault.Views;

namespace MarketVault
{
    public class StartUp
    {
        static async Task Main()
        {
            var display = new Display();
            await display.RunSeederAsync();
            await display.RunAsync();
        }
    }
}
