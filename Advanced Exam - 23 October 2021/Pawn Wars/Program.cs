using System;
using System.ComponentModel;

namespace Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = 8;
            string[,] board = new string[dimentions, dimentions];
            for (int raw = dimentions-1; raw >=0; raw--)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int coll = 0; coll < dimentions; coll++)
                {
                    board[raw, coll] = currentRow[coll].ToString();
                }
            }
            int wraw = 0;
            int wcoll = 0;
            int braw = 0;
            int bcoll = 0;
            for (int raw = 0; raw < board.GetLength(0); raw++)
            {
                for (int coll = 0; coll < board.GetLength(1); coll++)
                {
                    if (board[raw, coll] == "w")
                    {
                        wraw = raw;
                        wcoll = coll;
                    }
                }
            }
            for (int raw = 0; raw < board.GetLength(0); raw++)
            {
                for (int coll = 0; coll < board.GetLength(1); coll++)
                {
                    if (board[raw, coll] == "b")
                    {
                        braw = raw;
                        bcoll = coll;
                    }
                }
            }

            while (braw >0 && wraw < 7)
            {
                //white
                if (Valid(board, wraw + 1, wcoll - 1))
                {
                    if (board[wraw + 1, wcoll - 1] == "b")
                    {
                        board[wraw + 1, wcoll - 1] = "w";
                        Console.WriteLine($"Game over! White capture on {CastIntToString(wcoll - 1)}{wraw + 2}.");
                        return;
                    }
                }
                if (Valid(board, wraw + 1, wcoll + 1))
                {
                    if (board[wraw + 1, wcoll + 1] == "b")
                    {
                        board[wraw + 1, wcoll + 1] = "w";
                        Console.WriteLine($"Game over! White capture on {CastIntToString(wcoll + 1)}{wraw + 2}.");
                        return;
                    }

                }
                if (Valid(board, wraw + 1, wcoll))
                {
                    board[wraw, wcoll] = "-";
                    wraw++;
                    board[wraw, wcoll] = "w";
                }
                {
                }

                //black
                if (Valid(board, braw - 1, bcoll - 1))
                {
                    if (board[braw - 1, bcoll - 1] == "w")
                    {
                        board[braw - 1, bcoll - 1] = "b";
                        Console.WriteLine($"Game over! Black capture on {CastIntToString(bcoll - 1)}{braw}.");
                        return;
                    }
                }
                if (Valid(board, braw - 1, bcoll + 1))
                {
                    if (board[braw - 1, bcoll + 1] == "w")
                    {
                        Console.WriteLine($"Game over! Black capture on {CastIntToString(bcoll + 1)}{braw}.");
                        board[braw - 1, bcoll + 1] = "b";
                        return;
                    }
                }
                if (Valid(board, braw - 1, bcoll))
                {
                    board[braw, bcoll] = "-";
                    braw--;
                    board[braw, bcoll] = "b";

                }
                {
                }
            }
            if (braw == 0)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {CastIntToString(bcoll)}1.");
            }
            else
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {CastIntToString(wcoll)}8.");
            }


        }
        static bool Valid(string[,] pond, int raw, int coll)
        {
            if (raw >= 0 && raw < pond.GetLength(0) && coll >= 0 && coll < pond.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static string CastIntToString(int numb)
        {
            switch (numb)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                default:
                    break;
            }
            return null;
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
