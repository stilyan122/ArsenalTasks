using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.Data.Models;

namespace ObjectRelationalMapping.Queries
{
    public static class DeleteQueries
    {
        public static async Task DeleteEmployeeAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Employee ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                {
                    Console.WriteLine("Employee not found!");
                    return;
                }

                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
                Console.WriteLine("Employee deleted successfully!");
            }
        }

        public static async Task DeleteRouteAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Route ID to delete: ");
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

                context.Routes.Remove(route);
                await context.SaveChangesAsync();
                Console.WriteLine("Route deleted successfully!");
            }
        }

        public static async Task DeleteTicketAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Ticket ID to delete: ");
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

                context.Tickets.Remove(ticket);
                await context.SaveChangesAsync();
                Console.WriteLine("Ticket deleted successfully!");
            }
        }

        public static async Task DeleteTrackAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Track ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID!");
                    return;
                }

                var track = await context.Tracks.FirstOrDefaultAsync(t => t.Id == id);

                if (track == null)
                {
                    Console.WriteLine("Track not found!");
                    return;
                }

                context.Tracks.Remove(track);
                await context.SaveChangesAsync();
                Console.WriteLine("Track deleted successfully!");
            }
        }

        public static async Task DeleteTrainAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID to delete: ");
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

                context.Trains.Remove(train);
                await context.SaveChangesAsync();
                Console.WriteLine("Train deleted successfully!");
            }
        }

    }
}
