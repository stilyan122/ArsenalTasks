using ObjectRelationalMapping.Data.Models;

namespace ObjectRelationalMapping
{
    public static class InsertQueries
    {
        public static async Task InsertEmployeeAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Position: ");
                string position = Console.ReadLine();

                Console.Write("Enter Train ID (or leave empty): ");
                int? trainId = int.TryParse(Console.ReadLine(), out int tid) ? tid : (int?)null;

                var employee = new Employee { Name = name, Position = position, TrainId = trainId };

                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee added successfully!");
            }
        }

        public static async Task InsertTicketAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();

                Console.Write("Enter Seat Number: ");
                string seatNumber = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Train ID (or leave empty): ");
                int? trainId = int.TryParse(Console.ReadLine(), out int tid) ? tid : (int?)null;

                Console.Write("Enter Route ID (or leave empty): ");
                int? routeId = int.TryParse(Console.ReadLine(), out int rid) ? rid : (int?)null;

                var ticket = new Ticket
                {
                    PassengerName = passengerName,
                    SeatNumber = seatNumber,
                    Price = price,
                    TrainId = trainId,
                    RouteId = routeId
                };

                await context.Tickets.AddAsync(ticket);
                await context.SaveChangesAsync();
                Console.WriteLine("Ticket added successfully!");
            }
        }

        public static async Task InsertTrackAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Station Name: ");
                string stationName = Console.ReadLine();

                Console.Write("Enter Track Number: ");
                int trackNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Train ID (or leave empty): ");
                int? trainId = int.TryParse(Console.ReadLine(), out int tid) ? tid : (int?)null;

                var track = new Track
                {
                    StationName = stationName,
                    TrackNumber = trackNumber,
                    TrainId = trainId
                };

                await context.Tracks.AddAsync(track);
                await context.SaveChangesAsync();
                Console.WriteLine("Track added successfully!");
            }
        }

        public static async Task InsertTrainAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train Number: ");
                string trainNumber = Console.ReadLine();

                Console.Write("Enter Capacity: ");
                int capacity = int.Parse(Console.ReadLine());

                var train = new Train
                {
                    TrainNumber = trainNumber,
                    Capacity = capacity
                };

                await context.Trains.AddAsync(train);
                await context.SaveChangesAsync();
                Console.WriteLine("Train added successfully!");
            }
        }

        public static async Task InsertRouteAsync()
        {
            using (var context = new RailwayStationDbContext())
            {
                Console.Write("Enter Train ID (or leave empty): ");
                int? trainId = int.TryParse(Console.ReadLine(), out int tid) ? tid : (int?)null;

                Console.Write("Enter Departure Station: ");
                string departureStation = Console.ReadLine();

                Console.Write("Enter Arrival Station: ");
                string arrivalStation = Console.ReadLine();

                Console.Write("Enter Departure Time (yyyy-MM-dd HH:mm, or leave empty): ");
                DateTime? departureTime = DateTime.TryParse(Console.ReadLine(), out DateTime depTime) ? depTime : (DateTime?)null;

                Console.Write("Enter Arrival Time (yyyy-MM-dd HH:mm, or leave empty): ");
                DateTime? arrivalTime = DateTime.TryParse(Console.ReadLine(), out DateTime arrTime) ? arrTime : (DateTime?)null;

                var route = new Route
                {
                    TrainId = trainId,
                    DepartureStation = departureStation,
                    ArrivalStation = arrivalStation,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime
                };

                await context.Routes.AddAsync(route);
                await context.SaveChangesAsync();
                Console.WriteLine("Route added successfully!");
            }
        }
    }
}
