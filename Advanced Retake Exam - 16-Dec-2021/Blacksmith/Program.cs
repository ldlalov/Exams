using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
            Dictionary<int, string> weepons = new Dictionary<int, string>();
            weepons.Add(70,"Gladius");
            weepons.Add(80, "Shamshir");
            weepons.Add(90, "Katana");
            weepons.Add(110, "Sabre");
            weepons.Add(150, "Broadsword");

            Dictionary<string, int> readyWeapons = new Dictionary<string, int>();
            readyWeapons.Add("Gladius", 0);
            readyWeapons.Add("Shamshir", 0);
            readyWeapons.Add("Katana", 0);
            readyWeapons.Add("Sabre", 0);
            readyWeapons.Add("Broadsword", 0);

            while (steel.Count>0 && carbon.Count>0)
            {
                int currSteel = steel.Dequeue();
                int currCarbon = carbon.Pop();
                if (weepons.ContainsKey(currSteel + currCarbon))
                {
                    readyWeapons[weepons[currSteel + currCarbon]]++;
                }
                else
                {
                    carbon.Push(currCarbon + 5);
                }
            }
            if (readyWeapons.Any(x => x.Value > 0))
            {
                Console.WriteLine($"You have forged {readyWeapons.Sum(x => x.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count==0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
            if (carbon.Count==0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }
            if (readyWeapons.Any(x => x.Value > 0))
            {
                foreach (var weapon in readyWeapons.Where(x => x.Value>0).OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{weapon.Key}: {weapon.Value}");
                }
            }
        }
    }
}
