using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.Data.Models;

namespace ObjectRelationalMapping.Queries
{
    public static class SelectQueries
    {
        public static async Task FilterEmployeesByPosition()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter position to filter by: ");
                string position = Console.ReadLine();

                var employees = await context.Employees
                    .Where(e => e.Position.Contains(position))
                    .ToListAsync();

                if (employees.Any())
                {
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found with the specified position.");
                }
            }
        }

        public static async Task FilterEmployeesByTrainId()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to filter by: ");
                if (!int.TryParse(Console.ReadLine(), out int trainId))
                {
                    Console.WriteLine("Invalid Train ID.");
                    return;
                }

                var employees = await context.Employees
                    .Where(e => e.TrainId == trainId)
                    .ToListAsync();

                if (employees.Any())
                {
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found for the specified Train ID.");
                }
            }
        }

        public static async Task FilterEmployeesByName()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter employee name to filter by: ");
                string name = Console.ReadLine();

                var employees = await context.Employees
                    .Where(e => e.Name.Contains(name))
                    .ToListAsync();

                if (employees.Any())
                {
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found with the specified name.");
                }
            }
        }

        public static async Task FilterRoutesByDepartureStation()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Departure Station to filter by: ");
                string station = Console.ReadLine();

                var routes = await context.Routes
                    .Where(r => r.DepartureStation.Contains(station))
                    .ToListAsync();

                if (routes.Any())
                {
                    foreach (var route in routes)
                    {
                        Console.WriteLine($"ID: {route.Id}, Departure: {route.DepartureStation}, Arrival: {route.ArrivalStation}");
                    }
                }
                else
                {
                    Console.WriteLine("No routes found for the specified departure station.");
                }
            }
        }

        public static async Task FilterRoutesByArrivalStation()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Arrival Station to filter by: ");
                string station = Console.ReadLine();

                var routes = await context.Routes
                    .Where(r => r.ArrivalStation.Contains(station))
                    .ToListAsync();

                if (routes.Any())
                {
                    foreach (var route in routes)
                    {
                        Console.WriteLine($"ID: {route.Id}, Departure: {route.DepartureStation}, Arrival: {route.ArrivalStation}");
                    }
                }
                else
                {
                    Console.WriteLine("No routes found for the specified arrival station.");
                }
            }
        }

        public static async Task FilterRoutesByTrainId()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to filter by: ");
                if (!int.TryParse(Console.ReadLine(), out int trainId))
                {
                    Console.WriteLine("Invalid Train ID.");
                    return;
                }

                var routes = await context.Routes
                    .Where(r => r.TrainId == trainId)
                    .ToListAsync();

                if (routes.Any())
                {
                    foreach (var route in routes)
                    {
                        Console.WriteLine($"ID: {route.Id}, Departure: {route.DepartureStation}, Arrival: {route.ArrivalStation}");
                    }
                }
                else
                {
                    Console.WriteLine("No routes found for the specified Train ID.");
                }
            }
        }

        public static async Task FilterTicketsByTrainId()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to filter by: ");
                if (!int.TryParse(Console.ReadLine(), out int trainId))
                {
                    Console.WriteLine("Invalid Train ID.");
                    return;
                }

                var tickets = await context.Tickets
                    .Where(t => t.TrainId == trainId)
                    .ToListAsync();

                if (tickets.Any())
                {
                    foreach (var ticket in tickets)
                    {
                        Console.WriteLine($"ID: {ticket.Id}, Train ID: {ticket.TrainId}, Seat: {ticket.SeatNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tickets found for the specified Train ID.");
                }
            }
        }

        public static async Task FilterTicketsBySeat()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Seat Number to filter by: ");
                string seat = Console.ReadLine();

                var tickets = await context.Tickets
                    .Where(t => t.SeatNumber.Contains(seat))
                    .ToListAsync();

                if (tickets.Any())
                {
                    foreach (var ticket in tickets)
                    {
                        Console.WriteLine($"ID: {ticket.Id}, Train ID: {ticket.TrainId}, Seat: {ticket.SeatNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tickets found for the specified seat.");
                }
            }
        }

        public static async Task FilterTicketsByPriceRange()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter minimum price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
                {
                    Console.WriteLine("Invalid price.");
                    return;
                }

                Console.Write("Enter maximum price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
                {
                    Console.WriteLine("Invalid price.");
                    return;
                }

                var tickets = await context.Tickets
                    .Where(t => t.Price >= minPrice && t.Price <= maxPrice)
                    .ToListAsync();

                if (tickets.Any())
                {
                    foreach (var ticket in tickets)
                    {
                        Console.WriteLine($"ID: {ticket.Id}, Price: {ticket.Price}, Seat: {ticket.SeatNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tickets found in the specified price range.");
                }
            }
        }

        public static async Task FilterTracksByTrainId()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to filter by: ");
                if (!int.TryParse(Console.ReadLine(), out int trainId))
                {
                    Console.WriteLine("Invalid Train ID.");
                    return;
                }

                var tracks = await context.Tracks
                    .Where(t => t.TrainId == trainId)
                    .ToListAsync();

                if (tracks.Any())
                {
                    foreach (var track in tracks)
                    {
                        Console.WriteLine($"ID: {track.Id}, Station: {track.StationName}, Track Number: {track.TrackNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tracks found for the specified Train ID.");
                }
            }
        }

        public static async Task FilterTracksByStationName()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Station Name to filter by: ");
                string stationName = Console.ReadLine();

                var tracks = await context.Tracks
                    .Where(t => t.StationName.Contains(stationName))
                    .ToListAsync();

                if (tracks.Any())
                {
                    foreach (var track in tracks)
                    {
                        Console.WriteLine($"ID: {track.Id}, Station: {track.StationName}, Track Number: {track.TrackNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tracks found for the specified station.");
                }
            }
        }

        public static async Task FilterTracksByTrackNumber()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Track Number to filter by: ");
                if (!int.TryParse(Console.ReadLine(), out int trackNumber))
                {
                    Console.WriteLine("Invalid Track Number.");
                    return;
                }

                var tracks = await context.Tracks
                    .Where(t => t.TrackNumber == trackNumber)
                    .ToListAsync();

                if (tracks.Any())
                {
                    foreach (var track in tracks)
                    {
                        Console.WriteLine($"ID: {track.Id}, Station: {track.StationName}, Track Number: {track.TrackNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("No tracks found for the specified Track Number.");
                }
            }
        }

        public static async Task FilterTrainsByCapacity()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter minimum capacity: ");
                if (!int.TryParse(Console.ReadLine(), out int minCapacity))
                {
                    Console.WriteLine("Invalid capacity.");
                    return;
                }

                var trains = await context.Trains
                    .Where(t => t.Capacity >= minCapacity)
                    .ToListAsync();

                if (trains.Any())
                {
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"ID: {train.Id}, Train Number: {train.TrainNumber}, Capacity: {train.Capacity}");
                    }
                }
                else
                {
                    Console.WriteLine("No trains found with the specified capacity.");
                }
            }
        }

        public static async Task FilterTrainsByTrainNumber()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train Number to filter by: ");
                string trainNumber = Console.ReadLine();

                var trains = await context.Trains
                    .Where(t => t.TrainNumber.Contains(trainNumber))
                    .ToListAsync();

                if (trains.Any())
                {
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"ID: {train.Id}, Train Number: {train.TrainNumber}, Capacity: {train.Capacity}");
                    }
                }
                else
                {
                    Console.WriteLine("No trains found for the specified Train Number.");
                }
            }
        }

        public static async Task FilterTrainsByNumberOfEmployees()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter minimum number of employees: ");
                if (!int.TryParse(Console.ReadLine(), out int minEmployees))
                {
                    Console.WriteLine("Invalid number.");
                    return;
                }

                var trains = await context.Trains
                    .Include(t => t.Employees)
                    .Where(t => t.Employees.Count >= minEmployees)
                    .ToListAsync();

                if (trains.Any())
                {
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"ID: {train.Id}, Train Number: {train.TrainNumber}, Employees: {train.Employees.Count}");
                    }
                }
                else
                {
                    Console.WriteLine("No trains found with the specified number of employees.");
                }
            }
        }
    }
}
