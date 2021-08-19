using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class RemoveDigitsUpdated
    {
        static void Main()
        {
            Console.WriteLine("Present me a word with numbers mixed in and I shall remove them: ");
            string word = Console.ReadLine();

            Console.WriteLine("\nYour messy word: " + word);
            Console.WriteLine("My clean version: " + digDelete(word));

            Console.ReadKey();
        }
        public static string digDelete(string word)
        {
            string result = "";

            foreach (char x in word)
            {
                switch (x)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        break;

                    default:
                        result += x;
                        break;
                }
            }

            return (result);
           
        }
    }
}
