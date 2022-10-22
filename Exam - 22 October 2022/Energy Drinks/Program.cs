using System;
using System.Collections.Generic;
using System.Linq;

namespace Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> coffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int totalCoffeine = 0;
            while (coffeine.Count>0 && drinks.Count>0)
            {
            int currCoffeine = coffeine.Pop();
            int currDrink = drinks.Dequeue();
                int calculated = currCoffeine * currDrink;
                if (calculated + totalCoffeine <= 300)
                {
                    totalCoffeine += calculated;
                }
                else
                {
                    drinks.Enqueue(currDrink);
                    totalCoffeine -= 30;
                    if (totalCoffeine < 0)
                    {
                        totalCoffeine = 0;
                    }
                }
            }
            if (drinks.Count>0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {totalCoffeine} mg caffeine.");
        }
    }
}
