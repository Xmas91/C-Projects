using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProjects
{
    class SecondSmallest
    {
        static void Main()
        {
            int[] arr1 = { 2, 3, 2, 2, 1 };
            int[] arr2 = { 1, 1, 1, 2, 2 };
            int[] arr3 = { 2, 7, 9, 8, 2 };
            int[] arr4 = { 3, 3, 3, 3, 3 };

            Console.Write("Array 1: ");
            for (int i = 0; i < arr1.Length; i++)
                Console.Write("{0} ", arr1[i]);
            Console.WriteLine("\nSecond smallest number in Array: " + secondSmallest(arr1));

            Console.Write("\nArray 2: ");
            for (int i = 0; i < arr2.Length; i++)
                Console.Write("{0} ", arr2[i]);
            Console.WriteLine("\nSecond smallest number in Array: " + secondSmallest(arr2));

            Console.Write("\nArray 3: ");
            for (int i = 0; i < arr3.Length; i++)
                Console.Write("{0} ", arr3[i]);
            Console.WriteLine("\nSecond smallest number in Array: " + secondSmallest(arr3));

            Console.Write("\nArray 4: ");
            for (int i = 0; i < arr4.Length; i++)
                Console.Write("{0} ", arr4[i]);
            Console.WriteLine("\nSecond smallest number in Array: " + secondSmallest(arr4));

            Console.ReadKey();
        }
        public static int secondSmallest (int[] arr)
        {
            if (arr == null)
                return (0);

            int firstSmall = arr[0];
            int secondSmall = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (firstSmall > arr[i])
                    firstSmall = arr[i];
                else if (arr[i] > firstSmall)
                    secondSmall = arr[i];
            } //This part above is to set second smallest to the largest number so the check below would work
            for (int i = 0; i < arr.Length; i++)
            {
                if (secondSmall > arr[i] && arr[i] != firstSmall)
                    secondSmall = arr[i];
            }

            return (secondSmall);
        }
    }
}
