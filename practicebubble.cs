using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class practicebubble
    {
        static void Main()
        {
            int[] num = { -2, 4, 6, 13, 0 };

            Console.Write("Base Array: ");
            foreach (int a in num)
                Console.Write(a + " ");

            for (int b = 0; b <= num.Length - 2; b++)
            {
                for (int c = 0; c <= num.Length - 2; c++)
                {
                    if (num[c] > num[c+1])
                    {
                        int d = num[c + 1];
                        num[c + 1] = num[c];
                        num[c] = d;
                    }
                }
            }
            Console.Write("\n\nSorted Array: ");
            foreach (int a in num)
                Console.Write(a + " ");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
