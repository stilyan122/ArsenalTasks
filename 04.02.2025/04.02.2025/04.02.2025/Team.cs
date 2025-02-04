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
        private ILog logForHistory;
        private ILog logForPrint;

        public Team(string name, ILog logForHistory, ILog logForPrint)
        {
            this.Name = name;
            this.logForHistory = logForHistory;
            this.logForPrint = logForPrint;
            this.players = new();
            this.logForHistory.Log($"Team {name} has been created at {DateTime.Now}.");
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
            this.logForHistory.Log($"Player {player.Name} joined team {this.Name} at {DateTime.Now}.");
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player != null)
            {
                players.Remove(player);
                this.logForHistory.Log($"Player {playerName} left team {this.Name} at {DateTime.Now}.");
            }
            else
            {
                Console.WriteLine("Remove player failed! The team does not contain such player");
            }
        }

        public void PrintTeam(string filePath)
        {
            this.logForPrint.Log($"Team: {this.Name}");

            foreach (var player in this.players)
            {
                this.logForPrint.Log($"Player in team: {player.Name} at {player.Position}");
            }

            this.logForPrint.Save(filePath);
        }

        public void PrintTeamHistory(string filePath)
        {
            this.logForHistory.Save(filePath);
        }
    }
}
