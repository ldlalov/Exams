using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Dictionary<string, List<int>> products = new Dictionary<string, List<int>>();
            products.Add("Croissant", new List<int> { 50, 50 });
            products.Add("Muffin", new List<int> { 40, 60 });
            products.Add("Baguette", new List<int> { 30, 70 });
            products.Add("Bagel", new List<int> { 20, 80 });
            Dictionary<string, int> preparedProducts = new Dictionary<string, int>();
            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double percentsWater = CalculateWater(currentWater, currentFlour);
                double percentsFluor = 100 - percentsWater;
                if (products.Any(x => x.Value[0] == percentsWater && x.Value[1] == percentsFluor))
                {
                    foreach (var product in products)
                    {
                        if (product.Value[0] == percentsWater && product.Value[1] == percentsFluor)
                        {
                            if (!preparedProducts.ContainsKey(product.Key))
                            {
                            preparedProducts.Add(product.Key,0);
                            }
                            preparedProducts[product.Key]++;
                        }
                    }

                }
                else
                {
                    currentFlour -= currentWater;
                    flour.Push(currentFlour);
                    if (!preparedProducts.ContainsKey("Croissant"))
                    {
                    preparedProducts.Add("Croissant",1);
                    }
                    else
                    {
                        preparedProducts["Croissant"]++;
                    }
                }
            }
            foreach (var product in preparedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (water.Count>0)
            {
            Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine($"Water left: None");
            }
            if (flour.Count>0)
            {
            Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine($"Flour left: None");
            }
        }
        static double CalculateWater(double water, double flour)
        {
            return (water * 100 / (water + flour));
        }
    }
}
