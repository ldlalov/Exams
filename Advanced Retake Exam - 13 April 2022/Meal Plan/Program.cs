using System;
using System.Collections.Generic;
using System.Linq;

namespace Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> mealsCals = new Dictionary<string, int>();
            mealsCals.Add("salad", 350);
            mealsCals.Add("soup", 490);
            mealsCals.Add("pasta", 680);
            mealsCals.Add("steak", 790);
            int numbOfMeals = meals.Count;
            int leftMealCal = 0;
            int currentCal = calories.Pop();

            while (currentCal > 0 && meals.Count > 0)
            {
                leftMealCal = mealsCals[meals.Dequeue()];
                currentCal -= leftMealCal;

                if (currentCal<=0 && calories.Count>0)
                {
                    currentCal += calories.Pop();
                }
            }
            if (meals.Count == 0)
            {
                calories.Push(currentCal);
            }


            if (calories.Count > 0)
            {
                Console.WriteLine($"John had {numbOfMeals - meals.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numbOfMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
