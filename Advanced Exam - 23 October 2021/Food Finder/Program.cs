using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vowels = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<string> consonants = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Dictionary<string, HashSet<string>> matches = new Dictionary<string, HashSet<string>>();
            matches.Add("pear", new HashSet<string>());
            matches.Add("flour", new HashSet<string>());
            matches.Add("pork", new HashSet<string>());
            matches.Add("olive", new HashSet<string>());
            while (vowels.Count > 0 && consonants.Count > 0)
            {
            string currVowel = vowels.Dequeue();
            string currConsonant = consonants.Pop();

                foreach (var item in matches)
                {
                    string test = item.Key.ToString();
                    if (test.Contains(currVowel))
                    {
                        matches[item.Key].Add(currVowel);
                    }
                    if (test.Contains(currConsonant))
                    {
                        matches[item.Key].Add(@currConsonant);
                    }
                }
                vowels.Enqueue(currVowel);
            }
            int count = 0;
            foreach (var item in matches)
            {
                if (item.Key.Length == item.Value.Count)
                {
                    count++;
                }
            }
            Console.WriteLine($"Words found: {count}");
            foreach (var item in matches)
            {
                if (item.Key.Length == item.Value.Count)
                {
                    Console.WriteLine(item.Key);
                }

            }
        }
    }
}
