using System;

namespace Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            string car = Console.ReadLine();
            string[,] track = new string[dimentions, dimentions];
            for (int raw = 0; raw < dimentions; raw++)
            {
                string[] currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int coll = 0; coll < dimentions; coll++)
                {
                    track[raw, coll] = currentRow[coll].ToString();
                }
            }

            int craw = 0;
            int ccoll = 0;
            int passed = 0;
            if (track[craw, ccoll] == "T")
            {
                passed += 30;
                int[] recievedCoords = T(track, craw, ccoll);
                craw = recievedCoords[0];
                ccoll = recievedCoords[1];

            }
            if (track[craw, ccoll] == "F")
            {
                track[craw, ccoll] = "C";
                passed += 10;
                Console.WriteLine($"Racing car {car} finished the stage!");
                Console.WriteLine($"Distance covered {passed} km.");
                Print(track);
                return;
            }
            track[craw, ccoll] = "C";

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        track[craw, ccoll] = ".";
                        craw--;
                        if (track[craw,ccoll] == ".")
                        {
                            passed += 10;
                        }
                        if (track[craw,ccoll] == "T")
                        {
                            passed += 30;
                            int[] recievedCoords = T(track, craw, ccoll);
                            craw = recievedCoords[0];
                            ccoll = recievedCoords[1];

                        }
                        if (track[craw,ccoll] == "F")
                        {
                            track[craw, ccoll] = "C";
                            passed += 10;
                            Console.WriteLine($"Racing car {car} finished the stage!");
                            Console.WriteLine($"Distance covered {passed} km.");
                            Print(track);
                            return;
                        }
                        track[craw, ccoll] = "C";
                        break;

                    case "down":
                        track[craw, ccoll] = ".";
                        craw++;
                        if (track[craw, ccoll] == ".")
                        {
                            passed += 10;
                        }
                        if (track[craw, ccoll] == "T")
                        {
                            passed += 30;
                            int[] recievedCoords = T(track, craw, ccoll);
                            craw = recievedCoords[0];
                            ccoll = recievedCoords[1];

                        }
                        if (track[craw, ccoll] == "F")
                        {
                            track[craw, ccoll] = "C";
                            passed += 10;
                            Console.WriteLine($"Racing car {car} finished the stage!");
                            Console.WriteLine($"Distance covered {passed} km.");
                            Print(track);
                            return;
                        }
                        track[craw, ccoll] = "C";
                        break;

                    case "left":
                        track[craw, ccoll] = ".";
                        ccoll--;
                        if (track[craw, ccoll] == ".")
                        {
                            passed += 10;
                        }
                        if (track[craw, ccoll] == "T")
                        {
                            passed += 30;
                            int[] recievedCoords = T(track, craw, ccoll);
                            craw = recievedCoords[0];
                            ccoll = recievedCoords[1];

                        }
                        if (track[craw, ccoll] == "F")
                        {
                            track[craw, ccoll] = "C";
                            passed += 10;
                            Console.WriteLine($"Racing car {car} finished the stage!");
                            Console.WriteLine($"Distance covered {passed} km.");
                            Print(track);
                            return;
                        }
                        track[craw, ccoll] = "C";
                        break;

                    case "right":
                        track[craw, ccoll] = ".";
                        ccoll++;
                        if (track[craw, ccoll] == ".")
                        {
                            passed += 10;
                        }
                        if (track[craw, ccoll] == "T")
                        {
                            passed += 30;
                            int[] recievedCoords = T(track, craw, ccoll);
                            craw = recievedCoords[0];
                            ccoll = recievedCoords[1];

                        }
                        if (track[craw, ccoll] == "F")
                        {
                            track[craw, ccoll] = "C";
                            passed += 10;
                            Console.WriteLine($"Racing car {car} finished the stage!");
                            Console.WriteLine($"Distance covered {passed} km.");
                            Print(track);
                            return;
                        }
                        track[craw, ccoll] = "C";
                        break;
                }
            }
            Console.WriteLine($"Racing car {car} DNF.");
            Console.WriteLine($"Distance covered {passed} km.");
            Print(track);
        }
        static int[] T(string[,] field, int craw, int ccoll)
        {
            int[] coords = new int[2];
            field[craw, ccoll] = ".";
            for (int raw = 0; raw < field.GetLength(0); raw++)
            {
                for (int coll = 0; coll < field.GetLength(1); coll++)
                {
                    if (field[raw, coll] == "T")
                    {
                        field[raw, coll] = ".";
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
