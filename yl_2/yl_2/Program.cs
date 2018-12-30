using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yl_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int empty = 0;
            Console.WriteLine("Type numbers till satisfied, when done hit ENTER");
            List<int> list = new List<int>();
            do
            {
                Console.Write("Input Nr: ");
                line = Console.ReadLine();

                if (!string.IsNullOrEmpty(line))
                {
                    Int32.TryParse(line, out empty);
                    list.Add(empty);
                }
                
            } while (!string.IsNullOrEmpty(line));
            Console.Write("Empty input detected, doing calculations... \n");

            Console.WriteLine("--------------------");
            list.ForEach(i => Console.Write("{0}, ", i));
            Console.WriteLine("\n--------------------");
            Console.WriteLine("Sum: " + list.Sum());
            Console.WriteLine("Min: " + list.Min());
            Console.WriteLine("Max: " + list.Max());
        }
    }
}
