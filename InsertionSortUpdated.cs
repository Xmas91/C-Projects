using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProjects
{
    class InsertionSortUpdated
    {
        static void Main()
        {
            int[] num = { 7, 19, 17, 2, 29, 5, 3, 11, 13, 23 };
            Console.Write("Array before insertion sort: ");
            printArray(num);
            Console.Write("Array after insertion sort: ");
            printArray(insertSort(num));

            Console.ReadKey();
        }
        public static void printArray (int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("\n");
        }
        static int[] insertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];
                int j = i - 1;

                while (j >= 0)
                {
                    if (arr[j] > x)
                        arr[j + 1] = arr[j];
                    else
                        break;

                    j--;
                }
                arr[j + 1] = x;
            }
            return (arr);
        }
    }
}
