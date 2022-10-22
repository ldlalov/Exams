using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> white = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
            Queue<int> grey = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
            Dictionary<int, string> locations = new Dictionary<int, string>();
            locations.Add(40, "Sink");
            locations.Add(50, "Oven");
            locations.Add(60, "Countertop");
            locations.Add(70, "Wall");
            Dictionary<string, int> readyLocations = new Dictionary<string, int>();
            readyLocations.Add("Sink", 0);
            readyLocations.Add("Oven", 0);
            readyLocations.Add("Countertop", 0);
            readyLocations.Add("Wall", 0);
            readyLocations.Add("Floor", 0);
            while (white.Count > 0 && grey.Count > 0)
            {
                int w = white.Pop();
                int g = grey.Dequeue();
                if (w == g)
                {

                    int combine = w + g;
                        if (locations.ContainsKey(combine))
                        {
                        readyLocations[locations[combine]]++;
                        }
                        else
                        {
                            readyLocations["Floor"]++;
                        }
                }
                else
                {
                    white.Push(w / 2);
                    grey.Enqueue(g);
                }
            }
            if (white.Count>0)
            {
                Console.WriteLine($"White tiles left: {String.Join(", ", white)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (grey.Count>0)
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", grey)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            foreach (var l in readyLocations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (l.Value>0)
                {
                    Console.WriteLine($"{l.Key}: {l.Value}");
                }
            }
        }
    }
}
