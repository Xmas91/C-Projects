using System;

namespace EasyProjects
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int i, fact = 1, number = 0;

            while (number <= 0)
            {
                Console.Write("Enter a Number: ");
                number = int.Parse(Console.ReadLine());

                if (number <= 0)
                { Console.Write("Will not take any number < 0!\n\n"); }
            }

                for (i = 0; i <= number; i++)
                {
                    if (i == 0)
                    { Console.Write("\n0! = 1"); }
                    else
                    { fact = fact * i;
                      Console.Write("\n" + i + "! = " + fact);
                    }
                }
            Console.ReadKey();
        }
    }
}
