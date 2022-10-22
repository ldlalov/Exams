using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get;private set; }
        public char Group { get; set; }
        public IReadOnlyCollection<Player> Players => players;

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                sb.Append("Invalid player's information.");
            }
            else if (OpenPositions==0)
            {
                sb.Append("There are no more open positions.");
            }
            else if (!player.CheckRating())
            {
                sb.Append("Invalid player's rating.");
            }
            else
            {
                players.Add(player);
                OpenPositions--;
                sb.Append($"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.");
                //Count++;
            }
            return sb.ToString();
        }
        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name == name)
                {
                    players.Remove(players[i]);
                    i--;
                    //Count--;
                    OpenPositions++;
                    return true;
                }
            }
            return false;
        }
        public int RemovePlayerByPosition(string position)
        {

            int count = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Position == position)
                {
                    players.Remove(players[i]);
                    i--;
                    count++;
                    //Count--;
                    OpenPositions++;
                }
            }
            return count;

        }
        public Player RetirePlayer(string name)
        {
            foreach (Player player in players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return (player);
                }
            }
            return null;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.Players.Where(x => x.Retired != true))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Active players competing for Team  from Group {Group}:");
            //foreach (var player in players)
            //{
            //    if (player.Retired == false)
            //    {
            //        sb.AppendLine(player.ToString());
            //    }
            //}
            //return sb.ToString().TrimEnd();
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> awarded = new List<Player>();
            foreach (var player in players)
            {
                if (player.Games>=games)
                {
                    awarded.Add(player);
                }
            }
            return awarded;
        }
    }
}
