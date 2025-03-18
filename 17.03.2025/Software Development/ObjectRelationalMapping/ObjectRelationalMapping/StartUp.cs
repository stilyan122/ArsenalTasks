using ObjectRelationalMapping.Queries;

namespace ObjectRelationalMapping
{
    public class StartUp
    {
        public static async Task Main()
        {
            PrintMenu();

            int command = int.Parse(Console.ReadLine());
            while (command != 0)
            {
                if (command == 1)
                {
                    await InsertQueries.InsertEmployeeAsync();
                }
                else if (command == 2)
                {
                    await InsertQueries.InsertRouteAsync();
                }
                else if (command == 3)
                {
                    await InsertQueries.InsertTicketAsync();
                }
                else if (command == 4)
                {
                    await InsertQueries.InsertTrackAsync();
                }
                else if (command == 5)
                {
                    await InsertQueries.InsertTrainAsync();
                }
                else if (command == 6)
                {
                    await UpdateQueries.UpdateEmployeeAsync();
                }
                else if (command == 7)
                {
                    await UpdateQueries.UpdateRouteAsync();
                }
                else if (command == 8)
                {
                    await UpdateQueries.UpdateTicketAsync();
                }
                else if (command == 9)
                {
                    await UpdateQueries.UpdateTrackAsync();
                }
                else if (command == 10)
                {
                    await UpdateQueries.UpdateTrainAsync();
                }
                else if (command == 11)
                {
                    await DeleteQueries.DeleteEmployeeAsync();
                }
                else if (command == 12)
                {
                    await DeleteQueries.DeleteRouteAsync();
                }
                else if (command == 13)
                {
                    await DeleteQueries.DeleteTicketAsync();
                }
                else if (command == 14)
                {
                    await DeleteQueries.DeleteTrackAsync();
                }
                else if (command == 15)
                {
                    await DeleteQueries.DeleteTrainAsync();
                }
                else if (command == 16)
                {
                    await SelectQueries.FilterEmployeesByPosition();
                }
                else if (command == 17)
                {
                    await SelectQueries.FilterEmployeesByTrainId();
                }
                else if (command == 18)
                {
                    await SelectQueries.FilterEmployeesByName();
                }
                else if (command == 19)
                {
                    await SelectQueries.FilterRoutesByDepartureStation();
                }
                else if (command == 20)
                {
                    await SelectQueries.FilterRoutesByArrivalStation();
                }
                else if (command == 21)
                {
                    await SelectQueries.FilterRoutesByTrainId();
                }
                else if (command == 22)
                {
                    await SelectQueries.FilterTicketsByTrainId();
                }
                else if (command == 23)
                {
                    await SelectQueries.FilterTicketsBySeat();
                }
                else if (command == 24)
                {
                    await SelectQueries.FilterTicketsByPriceRange();
                }
                else if (command == 25)
                {
                    await SelectQueries.FilterTracksByTrainId();
                }
                else if (command == 26)
                {
                    await SelectQueries.FilterTracksByStationName();
                }
                else if (command == 27)
                {
                    await SelectQueries.FilterTracksByTrackNumber();
                }
                else if (command == 28)
                {
                    await SelectQueries.FilterTrainsByCapacity();
                }
                else if (command == 29)
                {
                    await SelectQueries.FilterTrainsByTrainNumber();
                }
                else if (command == 30)
                {
                    await SelectQueries.FilterTrainsByNumberOfEmployees();
                }

                PrintMenu();
                command = int.Parse(Console.ReadLine());
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to app! Enter commands (numbers)!");
            Console.WriteLine("0. End app");
            Console.WriteLine("1. Insert employee");
            Console.WriteLine("2. Insert route");
            Console.WriteLine("3. Insert ticket");
            Console.WriteLine("4. Insert track");
            Console.WriteLine("5. Insert train");
            Console.WriteLine("6. Update employee");
            Console.WriteLine("7. Update route");
            Console.WriteLine("8. Update ticket");
            Console.WriteLine("9. Update track");
            Console.WriteLine("10. Update train");
            Console.WriteLine("11. Delete employee");
            Console.WriteLine("12. Delete route");
            Console.WriteLine("13. Delete ticket");
            Console.WriteLine("14. Delete track");
            Console.WriteLine("15. Delete train");
            Console.WriteLine("16. Select employees by given position");
            Console.WriteLine("17. Select employees by train id");
            Console.WriteLine("18. Select employess by name");
            Console.WriteLine("19. Select routes by departure station");
            Console.WriteLine("20. Select routes by arrival station");
            Console.WriteLine("21. Select routes by train id");
            Console.WriteLine("22. Select tickets by train id");
            Console.WriteLine("23. Select tickets by seat");
            Console.WriteLine("24. Select tickets by price range");
            Console.WriteLine("25. Select tracks by train id");
            Console.WriteLine("26. Select tracks by station name");
            Console.WriteLine("27. Select tracks by track number");
            Console.WriteLine("28. Select trains by capacity");
            Console.WriteLine("29. Select trains by train number");
            Console.WriteLine("30. Select trains by number of employees");
        }
    }
}