using System;
using System.Collections.Generic;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] field = new string[dimentions, dimentions];
            for (int raw = 0; raw < dimentions; raw++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int coll = 0; coll < dimentions; coll++)
                {
                    field[raw,coll] = currentRow[coll].ToString();
                }
            }
            int points = 0;
            int[] coordinates = new int[2];
            string command;
            for (int raw = 0; raw < field.GetLength(0); raw++)
            {
                for (int coll = 0; coll < field.GetLength(1); coll++)
                {
                    if (field[raw,coll] == "M")
                    {
                        coordinates[0] = raw;
                        coordinates[1] = coll;
                    }
                }
            }
            while ((command = Console.ReadLine()) != "End")
            {
                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    Print(field);
                    return;
                }
                switch (command)
                {
                    case "up":
                        if (coordinates[0] - 1 >= 0)
                        {
                            field[coordinates[0], coordinates[1]] = "-";
                            coordinates[0] -= 1;
                            if (CheckDigit(field, coordinates))
                            {
                                points += int.Parse(field[coordinates[0], coordinates[1]]);
                            }
                            if (field[coordinates[0], coordinates[1]] == "S")
                            {
                                S(field, coordinates);
                                points -= 3;
                                continue;
                            }
                            field[coordinates[0], coordinates[1]] = "M";
                        }
                        else
                        {
                            Dont();
                        }
                        break;
                    case "down":
                        if (coordinates[0] + 1 <= field.GetLength(0) - 1)
                        {
                            field[coordinates[0], coordinates[1]] = "-";
                            coordinates[0] += 1;
                            if (CheckDigit(field, coordinates))
                            {
                                points += int.Parse(field[coordinates[0], coordinates[1]]);
                            }
                            if (field[coordinates[0], coordinates[1]] == "S")
                            {
                                S(field, coordinates);
                                points -= 3;
                                continue;
                            }
                            field[coordinates[0], coordinates[1]] = "M";
                        }
                        else
                        {
                            Dont();
                        }
                        break;
                    case "left":
                        if (coordinates[1] - 1 >= 0)
                        {
                            field[coordinates[0], coordinates[1]] = "-";
                            coordinates[1] -= 1;
                            if (CheckDigit(field, coordinates))
                            {
                                points += int.Parse(field[coordinates[0], coordinates[1]]);
                            }
                            if (field[coordinates[0], coordinates[1]] == "S")
                            {
                                S(field, coordinates);
                                points -= 3;
                                continue;
                            }
                            field[coordinates[0], coordinates[1]] = "M";
                        }
                        else
                        {
                            Dont();
                        }
                        break;
                    case "right":
                        if (coordinates[1] + 1 <= field.GetLength(1) - 1)
                        {
                            field[coordinates[0], coordinates[1]] = "-";
                            coordinates[1] += 1;
                            if (CheckDigit(field, coordinates))
                            {
                                points += int.Parse(field[coordinates[0], coordinates[1]]);
                            }
                            if (field[coordinates[0], coordinates[1]] == "S")
                            {
                                S(field, coordinates);
                                points -= 3;
                                continue;
                            }
                            field[coordinates[0], coordinates[1]] = "M";
                        }
                        else
                        {
                            Dont();
                        }
                        break;
                }
            }
            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
                if (points<25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            Print(field);
        }
        static bool CheckDigit(string[,] field, int[] coordinates)
        {
            if (Char.IsDigit(char.Parse(field[coordinates[0], coordinates[1]])))
            {
                return true;
            }
            return false;
        }
        static void S(string[,] field, int[] coordinates)
        {
                field[coordinates[0], coordinates[1]] = "-";
                for (int raw = 0; raw < field.GetLength(0); raw++)
                {
                    for (int coll = 0; coll < field.GetLength(1); coll++)
                    {
                        if (field[raw, coll] == "S")
                        {
                            coordinates[0] = raw;
                            coordinates[1] = coll;
                            field[raw, coll] = "M";
                        }
                    }
                }

        }
        static void Dont()
        {
            Console.WriteLine("Don't try to escape the playing field!");
        }
        static void Print(string[,] field)
        {
            for (int raw = 0; raw < field.GetLength(0); raw++)
            {
                for (int coll = 0; coll < field.GetLength(1); coll++)
                {
                    Console.Write(field[raw, coll]);
                }
                Console.WriteLine();
            }

        }
    }
}
