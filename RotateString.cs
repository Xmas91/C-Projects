using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class RotateString
    {
        static void Main()
        {
            Console.WriteLine("Please give us a sentence to rotate: ");
            string word = Console.ReadLine();
            Console.WriteLine("And now a number to move them over by: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("\n{0}  ->  {1}", word, rotateString(word, num));

            Console.ReadKey();
        }

        public static string rotateString(string word, int num)
        {
            string newWord = "";

            if (num > 0)
                newWord = word.Substring(word.Length - num) + word.Substring(0, word.Length - num);
            else if (num < 0)
                newWord = word.Substring(-num) + word.Substring(0, -num);
            
            else
                newWord = word;

            return (newWord);
        }
    }
}
