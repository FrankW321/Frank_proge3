using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yl_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var opponent_random = new Random();
            int opponent_number = opponent_random.Next(1, 50);
            int player_number = 0;
            int cycles = 0;
            Console.WriteLine(opponent_number + " - This is the opponent's number \n");
            Console.WriteLine("Guess the number between 1-50...");
            string line;

            do
            {
                Console.Write("Your guess: ");
                line = Console.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    cycles++;

                    Int32.TryParse(line, out player_number);
                    if (player_number == opponent_number)
                    {
                        break;
                    }
                    else if (player_number > opponent_number)
                    {
                        Console.WriteLine("Incorrect! Your number is larger.");
                        if (player_number > 50)
                        {
                            Console.WriteLine("The number is between 1-50, not higher, try again");
                        }
                    }
                    else if (player_number < opponent_number)
                    {
                        Console.WriteLine("Incorrect! Your number is smaller.");
                        if (player_number < 1)
                        {
                            Console.WriteLine("The number is between 1-50, not lower, try again");
                        }
                    }
                }

                Console.WriteLine();
            } while (!string.IsNullOrEmpty(line));

            Console.WriteLine("\n----------");
            if (player_number == opponent_number)
            {
                Console.WriteLine("Congratulations you are CORRECT!!!");
            }
            else
            {
                Console.WriteLine("You were sadly INCORRECT!");
            }
            Console.WriteLine("The correct number was: " + opponent_number);
            Console.WriteLine("Number of tries: " + cycles);
        }
    }
}
