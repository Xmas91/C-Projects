using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProjects
{
    class RemoveDuplicates
    {
        static void Main()
        {
            int[] arr1 = { 1, 2, 2, 3 };
            int[] arr2 = { 1, 2, 1, 2, 3 };
            int[] arr3 = { 1, 1, 1, 1, 1 };
            int[] arr4 = { 1, 2, 3 };
            int[] arr5 = { 1, 2, 3, 2, 1 };
            int count = 1;

            printArray(arr1, count);
            printArray(removeDuplicates(arr1), count);
            Console.WriteLine("");
            count++;
            printArray(arr2, count);
            printArray(removeDuplicates(arr2), count);
            Console.WriteLine("");
            count++;
            printArray(arr3, count);
            printArray(removeDuplicates(arr3), count);
            Console.WriteLine("");
            count++;
            printArray(arr4, count);
            printArray(removeDuplicates(arr4), count);
            Console.WriteLine("");
            count++;
            printArray(arr5, count);
            printArray(removeDuplicates(arr5), count);
            Console.WriteLine("");

            Console.ReadKey();
        }

        public static int[] removeDuplicates(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            int size = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                int count = 0;

                for (int j = 0; j < size; j++)
                {
                    if (value == newArr[j])
                        count++;
                }
                if (count == 0)
                    newArr[size++] = value;
            }
            Array.Resize(ref newArr, size);
            return (newArr);
        }

        public static void printArray(int[] arr, int count)
        {
            Console.Write("Array " + count + ": {");
            foreach (int x in arr)
            {
                Console.Write(" " + x);
            }
            Console.Write(" }\n");
        }

    }
}
