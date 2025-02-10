using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._02._2025
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private List<string> history = new();

        public Team(string name)
        {
            this.Name = name;
            this.players = new();
            this.history.Add($"Team {name} has been created at {DateTime.Now}.");
        }

        public string Name { 
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid team name!");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
            this.history.Add($"Player {player.Name} joined team {this.Name} at {DateTime.Now}.");
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player != null)
            {
                players.Remove(player);
                this.history.Add($"Player {playerName} left team {this.Name} at {DateTime.Now}.");
            }
            else
            {
                Console.WriteLine("Remove player failed! The team does not contain such player");
            }
        }

        public void PrintTeam(string filePath, ILog logForPrint)
        {
            logForPrint.Log("Print");
            logForPrint.Log($"Team {this.Name}");

            foreach (var player in this.players)
            {
                logForPrint.Log($"{player.Name} is at position {player.Position}");
            }

            logForPrint.Save(filePath);
        }

        public void PrintTeamHistory(string filePath, ILog logForHistory)
        {
            logForHistory.Log("History");
            logForHistory.Log($"Team {this.Name}");

            foreach (var line in this.history)
            {
                logForHistory.Log(line);
            }
            logForHistory.Save(filePath);
        }
    }
}
