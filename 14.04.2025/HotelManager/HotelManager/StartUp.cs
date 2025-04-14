using HotelManager.Controllers;
using HotelManager.Data;
using HotelManager.View;
using System.Text;

namespace HotelManager
{
    public class StartUp
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var context = new HotelManagerContext();
            var controller = new HotelController(context);
            var display = new Display(controller);

            await display.Menu();
        }
    }
}