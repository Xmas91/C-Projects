using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int n, number = 0, first = 0 , second = 1; 

            while (number <= 0)
            {
                Console.Write("Please enter a number for this Fibonacci sequence: ");
                number = int.Parse(Console.ReadLine());

                if (number <= 0)
                { Console.Write("\nWill not take any number that is 0 or less!\n\n"); }
            }
            for (int i = 0; i < number; i++)
            {
                if (i == 0)
                { Console.WriteLine((i + 1) + ") " + first); }
                else if (i == 1)
                { Console.WriteLine((i + 1) + ") " + second); }

                else
                {
                    n = first + second;
                    first = second;
                    second = n;

                    Console.WriteLine((i + 1) + ") " + n);
                }
            }
            Console.ReadKey();
        }
    }
}
