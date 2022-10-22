using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string[,] armory = new string[dimentions, dimentions];
            for (int raw = 0; raw < dimentions; raw++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int coll = 0; coll < dimentions; coll++)
                {
                    armory[raw, coll] = currentRow[coll].ToString();
                }
            }
            int craw = 0;
            int ccoll = 0;
            for (int raw = 0; raw < armory.GetLength(0); raw++)
            {
                for (int coll = 0; coll < armory.GetLength(1); coll++)
                {
                    if (armory[raw, coll] == "A")
                    {
                        craw = raw;
                        ccoll = coll;
                    }
                }
            }
            int coins = 0;
            string command;
            while ((command = Console.ReadLine()) != null)
            {
                switch (command)
                {
                    case "up":
                        armory[craw, ccoll] = "-";
                        craw--;
                        if (Valid(armory, craw, ccoll))
                        {
                            if (char.IsDigit(armory[craw, ccoll][0]))
                            {
                                coins += int.Parse(armory[craw, ccoll]);
                            }
                            else if (armory[craw, ccoll] == "M")
                            {
                                craw = M(armory, craw, ccoll)[0];
                                ccoll = M(armory, craw, ccoll)[1];
                            }
                            armory[craw, ccoll] = "A";
                        }
                        break;
                    case "down":
                        armory[craw, ccoll] = "-";
                        craw++;
                        if (Valid(armory, craw, ccoll))
                        {
                            if (char.IsDigit(armory[craw, ccoll][0]))
                            {
                                coins += int.Parse(armory[craw, ccoll]);
                            }
                            else if (armory[craw, ccoll] == "M")
                            {
                                craw = M(armory, craw, ccoll)[0];
                                ccoll = M(armory, craw, ccoll)[1];
                            }
                            armory[craw, ccoll] = "A";
                        }

                        break;
                    case "left":
                        armory[craw, ccoll] = "-";
                        ccoll--;
                        if (Valid(armory, craw, ccoll))
                        {
                            if (char.IsDigit(armory[craw, ccoll][0]))
                            {
                                coins += int.Parse(armory[craw, ccoll]);
                            }
                            else if (armory[craw, ccoll] == "M")
                            {
                                craw = M(armory, craw, ccoll)[0];
                                ccoll = M(armory, craw, ccoll)[1];
                            }
                            armory[craw, ccoll] = "A";
                        }

                        break;
                    case "right":
                        armory[craw, ccoll] = "-";
                        ccoll++;
                        if (Valid(armory, craw, ccoll))
                        {
                            if (char.IsDigit(armory[craw, ccoll][0]))
                            {
                                coins += int.Parse(armory[craw, ccoll]);
                            }
                            else if (armory[craw, ccoll] == "M")
                            {
                                craw = M(armory, craw, ccoll)[0];
                                ccoll = M(armory, craw, ccoll)[1];
                            }
                            armory[craw, ccoll] = "A";
                        }

                        break;
                }
                if (coins >= 65)
                {
                    break;
                }
                if (!Valid(armory,craw,ccoll))
                {
                    break;
                }
            }
            if (coins<65)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {coins} gold coins.");
            Print(armory);
        }
        static bool Valid(string[,] pond, int raw, int coll)
        {
            if (raw >= 0 && raw < pond.GetLength(0) && coll >= 0 && coll < pond.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static int[] M(string[,] field, int craw, int ccoll)
        {
            int[] coords = new int[2];
            field[craw, ccoll] = "-";
            for (int raw = 0; raw < field.GetLength(0); raw++)
            {
                for (int coll = 0; coll < field.GetLength(1); coll++)
                {
                    if (field[raw, coll] == "M")
                    {
                        field[raw, coll] = "A";
                        coords[0] = raw;
                        coords[1] = coll;
                    }
                }
            }
            return coords;

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
