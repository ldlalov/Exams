using System;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"-Player: {Name}{Environment.NewLine}");
            sb.Append($"--Position: {Position}{Environment.NewLine}");
            sb.Append($"--Rating: {Rating}{Environment.NewLine}");
            sb.Append($"--Games played: {Games}");
            return sb.ToString();
        }
        public bool CheckRating()
        {
            if (Rating>80)
            {
                return true;
            }
            return false;
        }
    }
}
