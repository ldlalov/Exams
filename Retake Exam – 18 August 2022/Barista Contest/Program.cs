using System;
using System.Collections.Generic;
using System.Linq;

namespace Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
                Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)); ;
            Dictionary<int, string> coffeeDrinks = new Dictionary<int, string>();
            coffeeDrinks.Add(50, "Cortado");
                coffeeDrinks.Add(75, "Espresso");
                coffeeDrinks.Add(100, "Capuccino");
                coffeeDrinks.Add(150, "Americano");
                coffeeDrinks.Add(200, "Latte");
            Dictionary<string, int> preparedDrinks = new Dictionary<string, int>();
            preparedDrinks.Add("Cortado", 0);
            preparedDrinks.Add("Espresso", 0);
            preparedDrinks.Add("Capuccino", 0);
            preparedDrinks.Add("Americano", 0);
            preparedDrinks.Add("Latte", 0);
            while (coffee.Count > 0 && milk.Count > 0)
            {
                int coffeeQty = coffee.Dequeue();
                int milkQty = milk.Pop();
                if (coffeeDrinks.ContainsKey(coffeeQty + milkQty))
                {
                    preparedDrinks[coffeeDrinks[coffeeQty + milkQty]]++;
                }
                else
                {
                    milk.Push(milkQty - 5);
                }

            }
            if (coffee.Count==0 && milk.Count==0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            if (coffee.Count>0 || milk.Count>0)
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if (coffee.Count>0)
            {
            Console.WriteLine($"Coffee left: {string.Join(", ",coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }
            if (milk.Count>0)
            {
            Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }
            foreach (var drink in preparedDrinks.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                if (drink.Value>0)
                {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }
        }
    }
}
