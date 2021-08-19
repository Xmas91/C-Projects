using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class BubbleSort
    {
        static void Main()
        {
            int[] num = { 4, 9, 5, 1, 0 };

            Console.WriteLine("Base Array: ");
            foreach (int z in num)
                Console.Write(z + " ");

            for (int a = 0; a <= num.Length - 2; a++)
            {
                for (int b = 0; b <= num.Length - 2; b++)
                {
                    if (num[b] > num [b+1])
                    {
                        int x = num[b + 1];
                        num[b + 1] = num[b];
                        num[b] = x;
                    }
                }
            }
            Console.WriteLine("\n\nBubble Sorted Array: ");
            foreach (int z in num)
                Console.Write(z + " ");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
