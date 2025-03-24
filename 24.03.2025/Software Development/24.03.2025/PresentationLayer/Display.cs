using BusinessLogicLayer.Controllers;
using DataLayer.Data.Models;

namespace PresentationLayer
{
    public class Display
    {
        private DriverController driverController;
        private TeamController teamController;

        public Display(DriverController driverController, 
            TeamController teamController)
        {
            this.teamController = teamController;
            this.driverController = driverController;
        }

        public async Task ShowMenu()
        {
            Console.WriteLine("Welcome to Formula1 app!");
            Console.WriteLine();

            Menu();
            int command = int.Parse(Console.ReadLine());

            while (command != 0)
            {
                if (command == 1)
                {
                    var allTeams = await this.teamController.GetAllTeams();

                    if (allTeams.Count() == 0)
                    {
                        Console.WriteLine("No teams in DB!");
                    }
                    else
                    {
                        Console.WriteLine("Teams in DB in format: [Team Name] " +
                            "[Team Country] [Team Foundation Year]");

                        Console.WriteLine();

                        foreach (Team team in allTeams)
                        {
                            Console.WriteLine($"[{team.TeamName}] [{team.Country}] " +
                                $"[{team.FoundationYear}]");
                        }
                    }
                }
                else if (command == 2)
                {
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine());

                    var team = await this.teamController.GetTeamById(id);

                    if (team == null)
                    {
                        Console.WriteLine("Team with such id not found!");
                    }
                    else
                    {
                        Console.WriteLine("Team in format: [Team Name] " +
                           "[Team Country] [Team Foundation Year]");

                        Console.WriteLine();

                        Console.WriteLine($"[{team.TeamName}] [{team.Country}] " +
                               $"[{team.FoundationYear}]");
                    }
                }
                else if (command == 3)
                {
                    Console.Write("Enter team country: ");
                    string country = Console.ReadLine();

                    var teams = await this.teamController.GetTeamsByCountry(country);

                    if (teams.Count() == 0)
                    {
                        Console.WriteLine("No teams in DB!");
                    }
                    else
                    {
                        Console.WriteLine("Teams in DB in format: [Team Name] " +
                            "[Team Country] [Team Foundation Year]");

                        Console.WriteLine();

                        foreach (Team team in teams)
                        {
                            Console.WriteLine($"[{team.TeamName}] [{team.Country}] " +
                                $"[{team.FoundationYear}]");
                        }
                    }
                }
                else if (command == 4)
                {
                    var team = await this.teamController.GetOldestTeam();

                    if (team == null)
                    {
                        Console.WriteLine("Team with such id not found!");
                    }
                    else
                    {
                        Console.WriteLine("Team in format: [Team Name] " +
                           "[Team Country] [Team Foundation Year]");

                        Console.WriteLine();

                        Console.WriteLine($"[{team.TeamName}] [{team.Country}] " +
                               $"[{team.FoundationYear}]");
                    }
                }
                else if (command == 5)
                {
                    var allDrivers = await this.driverController.GetAllDrivers();

                    if (allDrivers.Count() == 0)
                    {
                        Console.WriteLine("No drivers in DB!");
                    }
                    else
                    {
                        Console.WriteLine("Drivers in DB in format: [Driver First Name] " +
                            "[Driver Last Name] [Driver Birth Date] [Driver Nationality] " +
                            "[Driver Team Name]");

                        Console.WriteLine();

                        foreach (Driver driver in allDrivers)
                        {
                            Console.WriteLine($"[{driver.FirstName}] [{driver.LastName}] " +
                                $"[{driver.BirthDate}] [{driver.Nationality}] " +
                                $"[{driver.Team.TeamName}]");
                        }
                    }

                }
                else if (command == 6)
                {

                }
                else if (command == 7)
                {

                }
                else if (command == 8)
                {

                }

                Console.WriteLine();
                Menu();
                command = int.Parse(Console.ReadLine());
            }
        }

        private void Menu()
        {
            Console.WriteLine("0. End App!");
            Console.WriteLine("1. Get all teams");
            Console.WriteLine("2. Get a team by id");
            Console.WriteLine("3. Get teams by a given country");
            Console.WriteLine("4. Get oldest team");
            Console.WriteLine("5. Get all drivers");
            Console.WriteLine("6. Get a driver by id");
            Console.WriteLine("7. Get a driver by last name");
            Console.WriteLine("8. Get drivers by a given nationality");
        }
    }
}
