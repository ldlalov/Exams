using System;
using System.Drawing;

namespace Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] forest = new string[dimentions, dimentions];
            for (int raw = 0; raw < dimentions; raw++)
            {
                string[] currentRow = Console.ReadLine().Split();
                for (int coll = 0; coll < dimentions; coll++)
                {
                    forest[raw, coll] = currentRow[coll].ToString();
                }
            }
            int black = 0;
            int summer = 0;
            int white = 0;
            int eated = 0;
            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Collect")
                {
                    int raw = int.Parse(cmd[1]);
                    int coll = int.Parse(cmd[2]);
                    if (Valid(forest, raw, coll))
                    {
                        string found = forest[raw, coll].ToString();
                        switch (found)
                        {
                            case "B":
                                black++;
                                forest[raw, coll] = "-";
                                break;
                            case "S":
                                summer++;
                                forest[raw, coll] = "-";
                                break;
                            case "W":
                                white++;
                                forest[raw, coll] = "-";
                                break;
                        }
                    }
                }
                if (cmd[0] == "Wild_Boar")
                {
                    int raw = int.Parse(cmd[1]);
                    int coll = int.Parse(cmd[2]);
                    switch (cmd[3])
                    {
                        case "up":
                            while (Valid(forest, raw, coll))
                            {
                                string found = forest[raw, coll].ToString();
                                if (found != "-")
                                {
                                    eated++;
                                    forest[raw, coll] = "-";
                                }
                                raw -= 2;
                            }
                            break;

                        case "down":
                            while (Valid(forest, raw, coll))
                            {
                                string found = forest[raw, coll].ToString();
                                if (found != "-")
                                {
                                    eated++;
                                    forest[raw, coll] = "-";
                                }
                                raw += 2;
                            }
                            break;

                        case "left":
                            while (Valid(forest, raw, coll))
                            {
                                string found = forest[raw, coll].ToString();
                                if (found != "-")
                                {
                                    eated++;
                                    forest[raw, coll] = "-";
                                }
                                coll -= 2;
                            }
                            break;

                        case "right":
                            while (Valid(forest, raw, coll))
                            {
                                string found = forest[raw, coll].ToString();
                                if (found != "-")
                                {
                                    eated++;
                                    forest[raw, coll] = "-";
                                }
                                coll += 2;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eated} truffles.");
            Print(forest);
        }
        static bool Valid(string[,] forest, int raw, int coll)
        {
            if (raw >= 0 && raw < forest.GetLength(0) && coll >= 0 && coll < forest.GetLength(1))
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
                    Console.Write($"{wall[raw, coll]} ");
                }
                Console.WriteLine();
            }

        }

    }
}
