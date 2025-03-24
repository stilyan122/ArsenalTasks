using BusinessLogicLayer.Controllers;
using DataLayer.Data;
using PresentationLayer;
using System.ComponentModel.DataAnnotations;

namespace _24._03._2025
{
    public class StartUp()
    {
        public async static Task Main(string[] args)
        {
            var context = new TeamsContext();

            var driverController = new DriverController(context);
            var teamController = new TeamController(context);

            var display = new Display(driverController, teamController);

            await display.ShowMenu();
        }
    }
}
