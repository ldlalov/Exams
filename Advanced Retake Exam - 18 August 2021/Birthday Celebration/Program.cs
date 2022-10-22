using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int wasted = 0;  
            int currGuest = guests.Dequeue();
            while (plates.Count >0 && guests.Count>0)
            {
                if (guests.Count>0 && currGuest<=0)
                {
                    currGuest = guests.Dequeue();
                }
                
                int currPlate = plates.Pop();
                if(currPlate > currGuest) 
                {
                    wasted += currPlate - currGuest;
                    currGuest = 0;
                }
                else
                {
                    currGuest -= currPlate;
                }

            }
            if (plates.Count>0)
            {       
                int[] rev = new int[plates.Count];

                for (int i = plates.Count - 1; i >= 0; i--)
                {
                    rev[i]= plates.Pop();
                }
                Console.WriteLine($"Plates: {string.Join(" ", rev)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }
        }
    }
}
