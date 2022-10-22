using System;
using System.Collections.Generic;
using System.Drawing;

namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] pond = new string[dimentions, dimentions];
            for (int r = 0; r < dimentions; r++)
            {
                string[] currentRow = Console.ReadLine().Split();
                for (int c = 0; c < dimentions; c++)
                {
                    pond[r, c] = currentRow[c].ToString();
                }
            }
            int[] pos = new int[2];
            for (int r = 0; r < pond.GetLength(0); r++)
            {
                for (int c = 0; c < pond.GetLength(1); c++)
                {
                    if (pond[r, c] == "B")
                    {
                        pos[0] = r;
                        pos[1] = c;
                        pond[r, c] = "-";
                    }
                }
            }
                int raw = pos[0];
                int coll = pos[1];

            List<string> branches = new List<string>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (BranchCount(pond) == 0)
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        pond[raw, coll] = "-";
                        raw--;
                        if (Valid(pond,raw,coll))
                        {
                            if (Char.IsLower(pond[raw, coll][0]))
                            {
                                branches.Add(pond[raw,coll]);
                            }
                            else if (pond[raw,coll] == "F")
                            {
                                pond[raw, coll] = "-";
                                if (raw == 0)
                                {
                                    raw = pond.GetLength(0)-1;
                                }
                                else
                                {
                                    raw = 0;
                                }
                                if (Char.IsLower(pond[raw, coll][0]))
                                {
                                    branches.Add(pond[raw, coll]);
                                }
                                pond[raw, coll] = "B";
                            }
                                pond[raw, coll] = "B";
                        }
                        else
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                            raw++;
                            pond[raw, coll] = "B";
                        }
                        break;
                    case "down":
                        pond[raw, coll] = "-";
                        raw++;
                        if (Valid(pond, raw, coll))
                        {
                            if (Char.IsLower(pond[raw, coll][0]))
                            {
                                branches.Add(pond[raw, coll]);
                            }
                            else if (pond[raw, coll] == "F")
                            {
                                pond[raw, coll] = "-";
                                if (raw == 0)
                                {
                                    raw = pond.GetLength(0)-1;
                                }
                                else
                                {
                                    raw = 0;
                                }
                                if (Char.IsLower(pond[raw, coll][0]))
                                {
                                    branches.Add(pond[raw, coll]);
                                }
                                pond[raw, coll] = "B";
                            }
                                pond[raw, coll] = "B";
                        }
                        else
                        {
                            raw--;
                            pond[raw, coll] = "B";
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                        }

                        break;
                    case "left":
                        pond[raw, coll] = "-";
                        coll--;
                        if (Valid(pond, raw, coll))
                        {
                            if (Char.IsLower(pond[raw, coll][0]))
                            {
                                branches.Add(pond[raw, coll]);
                            }
                            else if (pond[raw, coll] == "F")
                            {
                                pond[raw, coll] = "-";
                                if (raw == 0)
                                {
                                    raw = pond.GetLength(0)-1;
                                }
                                else
                                {
                                    raw = 0;
                                }
                                if (Char.IsLower(pond[raw, coll][0]))
                                {
                                    branches.Add(pond[raw, coll]);
                                }
                                pond[raw, coll] = "B";
                            }
                                pond[raw, coll] = "B";
                        }
                        else
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                            coll++;
                            pond[raw, coll] = "B";
                        }
                        break;
                    case "right":
                        pond[raw, coll] = "-";
                        coll++;
                        if (Valid(pond, raw, coll))
                        {
                            if (Char.IsLower(pond[raw, coll][0]))
                            {
                                branches.Add(pond[raw, coll]);
                            }
                            else if (pond[raw, coll] == "F")
                            {
                                pond[raw, coll] = "-";
                                if (raw == 0)
                                {
                                    raw = pond.GetLength(0) - 1;
                                }
                                else
                                {
                                    raw = 0;
                                }
                                if (Char.IsLower(pond[raw, coll][0]))
                                {
                                    branches.Add(pond[raw, coll]);
                                }
                                pond[raw, coll] = "B";
                            }
                            pond[raw, coll] = "B";
                        }
                        else
                        {
                            if (branches.Count>0)
                            {
                            branches.RemoveAt(branches.Count - 1);
                            }
                            coll--;
                            pond[raw, coll] = "B";
                        }
                        break;
                }
            }
            if (BranchCount(pond) == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {BranchCount(pond)} branches left.");
            }
            Print(pond);
            
        }
        static bool Valid(string[,] pond, int raw, int coll)
        {
            if (raw >= 0 && raw < pond.GetLength(0) && coll >= 0 && coll < pond.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static int BranchCount(string[,] pond)
        {
            int count = 0;
            foreach (var item in pond)
            {
                if (char.IsLower(item[0]))
{
                    count++;
                }
            }
            return count;
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
