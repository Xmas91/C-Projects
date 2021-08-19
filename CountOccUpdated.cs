using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class CountOccUpdated
    {
        static void Main()
        {
            Console.WriteLine("Please give me a word to test: ");
            string word = Console.ReadLine();
            Console.WriteLine("\nNow give me a letter to count in your word: ");
            char c = char.Parse(Console.ReadLine());

            word = word.ToLower();
            c = char.ToLower(c);

            Console.WriteLine("Word: " + word);
            Console.WriteLine("Letter: " + c);
            Console.WriteLine("Count: " + countNum(word, c));



            Console.ReadKey();
        }
        public static int countNum(string word, char c)
        {
            int count = 0;

            foreach (char x in word)
            {
                if (x == c)
                    count++;
            }
            return (count);
        }
    }
}
