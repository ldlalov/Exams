using System;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] wall = new string[dimentions, dimentions];
            for (int raw = 0; raw < dimentions; raw++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int coll = 0; coll < dimentions; coll++)
                {
                    wall[raw, coll] = currentRow[coll].ToString();
                }
            }
            int[] coordinates = new int[2];
            for (int raw = 0; raw < wall.GetLength(0); raw++)
            {
                for (int coll = 0; coll < wall.GetLength(1); coll++)
                {
                    if (wall[raw, coll] == "V")
                    {
                        coordinates[0] = raw;
                        coordinates[1] = coll;
                        wall[raw, coll] = "*";
                    }
                }
            }
            int countOfHoles = 1;
            int countOfRods = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        wall[coordinates[0], coordinates[1]] = "*";
                        coordinates[0] -= 1;
                        if (coordinates[0] < 0)
                        {
                            coordinates[0] += 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitRod(wall, coordinates))
                        {
                            countOfRods++;
                            coordinates[0] += 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitCable(wall, coordinates))
                        {
                            countOfHoles++;
                            wall[coordinates[0], coordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                            Print(wall);
                            return;
                        }
                        else if (wall[coordinates[0], coordinates[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{coordinates[0]}, {coordinates[1]}]!");
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        wall[coordinates[0], coordinates[1]] = "V";
                        countOfHoles++;

                        break;
                    case "down":
                        wall[coordinates[0], coordinates[1]] = "*";
                        coordinates[0] += 1;
                        if (coordinates[0] >= wall.GetLength(0))
                        {
                            coordinates[0] -= 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitRod(wall, coordinates))
                        {
                            countOfRods++;
                            coordinates[0] -= 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitCable(wall, coordinates))
                        {
                            countOfHoles++;
                                wall[coordinates[0], coordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                            Print(wall);
                            return;
                        }
                        else if (wall[coordinates[0], coordinates[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{coordinates[0]}, {coordinates[1]}]!");
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        wall[coordinates[0], coordinates[1]] = "V";
                        countOfHoles++;

                        break;
                    case "left":
                        wall[coordinates[0], coordinates[1]] = "*";
                        coordinates[1] -= 1;
                        if (coordinates[1] < 0)
                        {
                            coordinates[1] += 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitRod(wall, coordinates))
                        {
                            countOfRods++;
                            coordinates[1] += 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitCable(wall, coordinates))
                        {
                            countOfHoles++;
                            wall[coordinates[0], coordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                            Print(wall);
                            return;
                        }
                        else if (wall[coordinates[0], coordinates[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{coordinates[0]}, {coordinates[1]}]!");
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        wall[coordinates[0], coordinates[1]] = "V";
                        countOfHoles++;

                        break;
                    case "right":
                        wall[coordinates[0], coordinates[1]] = "*";
                        coordinates[1] += 1;
                        if (coordinates[1] >= wall.GetLength(1))
                        {
                            coordinates[1] -= 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitRod(wall, coordinates))
                        {
                            countOfRods++;
                            coordinates[1] -= 1;
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        else if (HitCable(wall, coordinates))
                        {
                            countOfHoles++;
                            wall[coordinates[0], coordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                            Print(wall);
                            return;
                        }
                        else if (wall[coordinates[0], coordinates[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{coordinates[0]}, {coordinates[1]}]!");
                            wall[coordinates[0], coordinates[1]] = "V";
                            continue;
                        }
                        wall[coordinates[0], coordinates[1]] = "V";
                        countOfHoles++;
                        break;
                }
            }
            Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            Print(wall);
        }

        static bool HitRod(string[,] wall, int[] coordinates)
        {

            if (wall[coordinates[0], coordinates[1]] == "R")
            {
                Console.WriteLine("Vanko hit a rod!");
                return true;
            }
            return false;
        }
        static bool HitCable(string[,] wall, int[] coordinates)
        {

            if (wall[coordinates[0], coordinates[1]] == "C")
            {
                return true;
            }
            return false;
        }
        static void Print(string[,] wall)
        {
            for (int raw = 0; raw < wall.GetLength(0); raw++)
            {
                for (int coll = 0; coll < wall.GetLength(1); coll++)
                {
                    Console.Write(wall[raw, coll]);
                }
                Console.WriteLine();
            }

        }
    }
}