using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yl_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputX = 0;
            int inputY = 0;
            bool nextTurn = true;
            bool firstRun = true;
            string line;
            string currentPlayer = "X";
            string rowDivider = "   -------------";
            int matches,
                matchesCol,
                matchesDiag,
                matchesDiagOther;
            var rows = new List<List<string>>();

            for (int i = 0; i < 3; i++)
            {
                rows.Add(new List<string>() { " ", " ", " " });
            }

            Console.Clear();
            Console.WriteLine("Place your coordinates followingly: x, y \n");
            Console.WriteLine("x(rows), y(columns) \n");
            printTable(1, 1, " ");

            do
            {

                if (!firstRun)
                {
                    if (nextTurn)
                    {
                        Console.Clear();
                        Console.WriteLine("Place your coordinates followingly: x, y \n");
                        Console.WriteLine("x(rows), y(columns) \n");
                        printTable(inputY, inputX, currentPlayer);
                        checkMatches();

                        if (currentPlayer == "X")
                        {
                            currentPlayer = "O";
                        }
                        else
                        {
                            currentPlayer = "X";
                        }
                    }
                    else
                    {
                        nextTurn = true;
                    }
                }
                else
                {
                    firstRun = false;
                }

                Console.Write("\n\nPlayer" + currentPlayer + ": ");

                line = Console.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    Int32.TryParse(line[0].ToString(), out inputX);
                    Int32.TryParse(line[2].ToString(), out inputY);

                    Console.WriteLine();

                    if (inputY < 1 || inputX < 1 || inputY > 3 || inputX > 3)
                    {
                        nextTurn = false;
                        continue;
                    }

                    if (rows[inputX - 1][inputY - 1] != " ")
                    {
                        Console.WriteLine("That field is already set!");
                        nextTurn = false;
                        continue;
                    }
                }
            } while (!string.IsNullOrEmpty(line));
            
            void printTable(int y, int x, string player)
            {
                Console.Write("         y\n");
                Console.Write(rowDivider);

                rows[x - 1][y - 1] = player;
                for (int i = 1; i <= 3; i++)
                {
                    if (i != 2) {
                        Console.Write("\n   | ");
                    }
                    else { 
                    Console.Write("\n x | ");
                    }
                    for (int j = 1; j <= 3; j++)
                    {
                        Console.Write(rows[i - 1][j - 1]);
                        Console.Write(" | ");
                    }

                    Console.Write("\n" + rowDivider);
                }

            }

            void checkMatches()
            {
                matchesDiag = matchesDiagOther = 0;
                for (int i = 1; i <= 3; i++)
                {
                    matches = matchesCol = 0;

                    for (int j = 1; j <= 3; j++)
                    {
                        if (rows[i - 1][j - 1] == currentPlayer)
                        {
                            matches++;
                        }
                        if (rows[j - 1][i - 1] == currentPlayer)
                        {
                            matchesCol++;
                        }
                    }

                    if (rows[i - 1][i - 1] == currentPlayer)
                    {
                        matchesDiag++;
                    }

                    if (rows[i - 1][3 - i] == currentPlayer)
                    {
                        matchesDiagOther++;
                    }

                    if (matches == 3 || matchesCol == 3 || matchesDiag == 3 || matchesDiagOther == 3)
                    {
                        Console.WriteLine("\nPlayer " + currentPlayer + " WON THE GAME!");
                        System.Environment.Exit(1);
                    }
                }
            }
        }
    }
}

