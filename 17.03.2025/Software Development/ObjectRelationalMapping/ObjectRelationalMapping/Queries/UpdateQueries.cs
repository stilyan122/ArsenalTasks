using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.Data.Models;

namespace ObjectRelationalMapping.Queries
{
    public static class UpdateQueries
    {
        public static async Task UpdateEmployeeAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Employee ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var employee = await context.Employees.FindAsync(id);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found!");
                    return;
                }

                Console.Write("Enter new Employee Name (leave empty to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    employee.Name = name;

                Console.Write("Enter new Position (leave empty to keep current): ");
                string position = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(position))
                    employee.Position = position;

                Console.Write("Enter new Train ID (or leave empty): ");
                if (int.TryParse(Console.ReadLine(), out int tid))
                {
                    employee.TrainId = tid;
                }

                await context.SaveChangesAsync();
                Console.WriteLine("Employee updated successfully!");
            }
        }

        public static async Task UpdateTicketAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Ticket ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var ticket = await context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

                if (ticket == null)
                {
                    Console.WriteLine("Ticket not found!");
                    return;
                }

                Console.Write("Enter new Train ID (leave empty to keep current): ");
                if (int.TryParse(Console.ReadLine(), out int trainId))
                {
                    ticket.TrainId = trainId;
                }

                Console.Write("Enter new Seat Number (leave empty to keep current): ");
                string seat = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(seat))
                {
                    ticket.SeatNumber = seat;
                }

                Console.Write("Enter new Passenger Name (leave empty to keep current): ");
                string passengerName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(passengerName))
                {
                    ticket.PassengerName = passengerName;
                }

                Console.Write("Enter new Price (leave empty to keep current): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    ticket.Price = price;
                }

                await context.SaveChangesAsync();
                Console.WriteLine("Ticket updated successfully!");
            }
        }

        public static async Task UpdateTrackAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Track ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var track = await context.Tracks.FindAsync(id);
                if (track == null)
                {
                    Console.WriteLine("Track not found!");
                    return;
                }

                Console.Write("Enter new Station Name (leave empty to keep current): ");
                string stationName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(stationName)) track.StationName = stationName;

                Console.Write("Enter new Track Number (leave empty to keep current): ");
                if (int.TryParse(Console.ReadLine(), out int trackNumber))
                {
                    track.TrackNumber = trackNumber;
                }

                Console.Write("Enter new Train ID (or leave empty): ");
                if (int.TryParse(Console.ReadLine(), out int trainId))
                {
                    track.TrainId = trainId;
                }

                await context.SaveChangesAsync();
                Console.WriteLine("Track updated successfully!");
            }
        }

        public static async Task UpdateRouteAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Route ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var route = await context.Routes.FirstOrDefaultAsync(r => r.Id == id);

                if (route == null)
                {
                    Console.WriteLine("Route not found!");
                    return;
                }

                Console.Write("Enter new Departure Station (leave empty to keep current): ");
                string departureStation = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(departureStation))
                {
                    route.DepartureStation = departureStation;
                }

                Console.Write("Enter new Arrival Station (leave empty to keep current): ");
                string arrivalStation = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(arrivalStation))
                {
                    route.ArrivalStation = arrivalStation;
                }

                Console.Write("Enter new Departure Time (leave empty to keep current, format: yyyy-MM-dd HH:mm): ");
                string departureTimeInput = Console.ReadLine();
                if (DateTime.TryParse(departureTimeInput, out DateTime departureTime))
                {
                    route.DepartureTime = departureTime;
                }

                Console.Write("Enter new Arrival Time (leave empty to keep current, format: yyyy-MM-dd HH:mm): ");
                string arrivalTimeInput = Console.ReadLine();
                if (DateTime.TryParse(arrivalTimeInput, out DateTime arrivalTime))
                {
                    route.ArrivalTime = arrivalTime;
                }

                Console.Write("Enter new Train ID (leave empty to keep current): ");
                if (int.TryParse(Console.ReadLine(), out int trainId))
                {
                    route.TrainId = trainId;
                }

                await context.SaveChangesAsync();
                Console.WriteLine("Route updated successfully!");
            }
        }

        public static async Task UpdateTrainAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var train = await context.Trains.FirstOrDefaultAsync(t => t.Id == id);

                if (train == null)
                {
                    Console.WriteLine("Train not found!");
                    return;
                }

                Console.Write("Enter new Train Number (leave empty to keep current): ");
                string trainNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(trainNumber))
                {
                    train.TrainNumber = trainNumber;
                }

                Console.Write("Enter new Capacity (leave empty to keep current): ");
                if (int.TryParse(Console.ReadLine(), out int capacity))
                {
                    train.Capacity = capacity;
                }

                await context.SaveChangesAsync();
                Console.WriteLine("Train updated successfully!");
            }
        }

    }
}
