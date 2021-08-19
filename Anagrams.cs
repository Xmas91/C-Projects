using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProjects
{
    class Anagrams
    {
        static void Main()
        {
            string[] firstWord = { "abc", "abc", "Dynamite", "dynamite", "Eleven plus two", "eleven minus one", "Dormitory", "dormitory", "Signature", "signature" };
            string[] secondWord = { "cba", "abb", "May it end", "And my time", "Twelve plus one", "Twelve plus two", "Dirty room", "Rid my tomb", "A true sign", "Teas run big" };

            Console.WriteLine("First word            Second word             anagrams");
            Console.WriteLine("----------            -----------             ---------");
            for (int i = 0; i < firstWord.Length; i++)
                Console.WriteLine("{0, -22} {1, -23} {2, -15}", firstWord[i], secondWord[i], areAnagrams(firstWord[i], secondWord[i]));
            
            Console.ReadKey();
        }
        public static string fixString (string s)
        {
            string result = "";

            foreach (char c in s)
            {
                if (!char.IsWhiteSpace(c))
                {
                    result += char.ToLower(c);
                }
            }
            return (result);
        }
        public static int countOcc (string s, char c)
        {
            int charCount = 0;

            foreach (char z in s)
                if (c == z)
                    charCount++;
            return (charCount);
        }
        static bool areAnagrams(string one, string two)
        {
            string oneFix = fixString(one);
            string twoFix = fixString(two);
            bool anagram = false;

            if (oneFix.Length != twoFix.Length)
                return (false);

            for (int i = 0; i < oneFix.Length; i++)
            {
                if (countOcc(oneFix, oneFix[i]) != countOcc(twoFix, oneFix[i]))
                {
                    anagram = false;
                    break;
                }
                else
                    anagram = true;
            }

            return (anagram);
        }
    }
}
