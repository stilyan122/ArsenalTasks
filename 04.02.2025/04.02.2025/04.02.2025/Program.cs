using _04._02._2025;

ILog txtLogger = new TextLogger();
ILog xlsxLog = new XlsxLogger();

bool running = true;

List<Team> teams = new();
List<Player> players = new();

while (running)
{
    string? command = Console.ReadLine();
    string[]? commandArgs = command?.Split(' ');

    switch (commandArgs[0])
    {
        case "create_team":
            try
            {
                Team team = new Team(commandArgs[1]);
                teams.Add(team);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Cannot create team! Invalid number of parameters. {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Cannot create team! Invalid arguments. {ex.Message}");
            }
            break;
        case "create_player":
            try
            {
                Player player = new Player(commandArgs[2], commandArgs[1]);
                players.Add(player);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Cannot create player! Invalid number of parameters. {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Cannot create player! Invalid arguments. {ex.Message}");
            }
            break;
        case "add_player":
            try
            {
                Team? teamToAdd = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                if (teamToAdd == null)
                {
                    Console.WriteLine("Team not found!");
                    continue;
                }

                Player? playerToAdd = players.FirstOrDefault(t => t.Name == commandArgs[2] &&
                    t.Position == commandArgs[3]);

                if (playerToAdd == null)
                {
                    Console.WriteLine("Player not found!");
                    continue;
                }

                teamToAdd.AddPlayer(playerToAdd);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Cannot find team or player! Invalid number of parameters. {ex.Message}");
            }
            
            break;
        case "remove_player":
            try
            {
                Team teamToRemove = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                if (teamToRemove == null)
                {
                    Console.WriteLine("Team not found!");
                    continue;
                }

                teamToRemove.RemovePlayer(commandArgs[2]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Cannot find team! Invalid number of parameters. {ex.Message}");
            }
            break;
        case "print_team":
            try
            {
                Team teamToPrint = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                if (teamToPrint == null)
                {
                    Console.WriteLine("Team not found!");
                    continue;
                }

                string filePathToPrint = commandArgs[2];
                string typeOfLogger = commandArgs[3];

                if (typeOfLogger == "txt")
                {
                    teamToPrint.PrintTeam(filePathToPrint, txtLogger);
                }
                else
                {
                    teamToPrint.PrintTeam(filePathToPrint, xlsxLog);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number of parameters! " + ex.Message);
            }
            break;
        case "print_log_txt":
            try
            {
                Team teamToPrintLog = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                if (teamToPrintLog == null)
                {
                    Console.WriteLine("Team not found!");
                    continue;
                }

                string filePath = commandArgs[2];
                teamToPrintLog.PrintTeamHistory(filePath, txtLogger);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number of parameters! " + ex.Message);
            }
            break;
        case "print_log_excel":
            try
            {
                Team teamToPrintLog = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                if (teamToPrintLog == null)
                {
                    Console.WriteLine("Team not found!");
                    continue;
                }

                string filePath = commandArgs[2];
                teamToPrintLog.PrintTeamHistory(filePath, xlsxLog);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid number of parameters! " + ex.Message);
            }
            break;
        case "exit":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
}