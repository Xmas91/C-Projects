using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProjects
{
    class RomanNumerals
    {
        static void Main()
        {
            int number = 1;

            while (number < 4000)
            {
                toRoman(number);
                number++;
            }
            Console.ReadKey();
        }

        public static void toRoman(int x)
        {
            Console.Write(x);

            int spot = 0;
            string firstRom = "", secondRom = "", thirdRom = "", fourthRom = "";

            while (x > 0)
            {
                spot++;

                int digit = x % 10; 
                
                switch (digit)
                {
                    case 1:
                        {
                            if (spot == 1)
                            { firstRom += "I"; }
                            else if (spot == 2)
                            { secondRom += "X"; }
                            else if (spot == 3)
                            { thirdRom += "C"; }
                            else
                            { fourthRom += "M"; }
                            break;
                        }
                    case 2:
                        {
                            if (spot == 1)
                            { firstRom += "II"; }
                            else if (spot == 2)
                            { secondRom += "XX"; }
                            else if (spot == 3)
                            { thirdRom += "CC"; }
                            else
                            { fourthRom += "MM"; }
                            break;
                        }
                    case 3:
                        {
                            if (spot == 1)
                            { firstRom += "III"; }
                            else if (spot == 2)
                            { secondRom += "XXX"; }
                            else if (spot == 3)
                            { thirdRom += "CCC"; }
                            else
                            { fourthRom += "MMM"; }
                            break;
                        }
                    case 4:
                        {
                            if (spot == 1)
                            { firstRom += "IV"; }
                            else if (spot == 2)
                            { secondRom += "XL"; }
                            else if (spot == 3)
                            { thirdRom += "CD"; }
                            break;
                        }
                    case 5:
                        {
                            if (spot == 1)
                            { firstRom += "V"; }
                            else if (spot == 2)
                            { secondRom += "L"; }
                            else if (spot == 3)
                            { thirdRom += "D"; }
                            break;
                        }
                    case 6:
                        {
                            if (spot == 1)
                            { firstRom += "VI"; }
                            else if (spot == 2)
                            { secondRom += "LX"; }
                            else if (spot == 3)
                            { thirdRom += "DC"; }
                            break;
                        }
                    case 7:
                        {
                            if (spot == 1)
                            { firstRom += "VII"; }
                            else if (spot == 2)
                            { secondRom += "LXX"; }
                            else if (spot == 3)
                            { thirdRom += "DCC"; }
                            break;
                        }
                    case 8:
                        {
                            if (spot == 1)
                            { firstRom += "VIII"; }
                            else if (spot == 2)
                            { secondRom += "LXXX"; }
                            else if (spot == 3)
                            { thirdRom += "DCCC"; }
                            break;
                        }
                    case 9:
                        {
                            if (spot == 1)
                            { firstRom += "IX"; }
                            else if (spot == 2)
                            { secondRom += "XC"; }
                            else if (spot == 3)
                            { thirdRom += "CM"; }
                            break;
                        }
                }
                x /= 10;
            }
            Console.WriteLine(" = " + fourthRom + thirdRom + secondRom + firstRom);
        }
    }
}
