using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumProjects
{
    class OverlappingRectangles
    {
        static void Main()
        {
            var rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                
                int x1 = rand.Next(1, 15);
                int y1 = rand.Next(1, 15);
                int x2 = rand.Next(1, 15);
                int y2 = rand.Next(1, 15);
                int x3 = rand.Next(1, 15);
                int y3 = rand.Next(1, 15);
                int x4 = rand.Next(1, 15);
                int y4 = rand.Next(1, 15);

                Console.WriteLine("------------------------------------------------------\n");
                Console.WriteLine("Rectangle A Corners: ({0}, {1}), ({2}, {3})", x1, y1, x2, y2);
                Console.WriteLine("Rectangle B Corners: ({0}, {1}), ({2}, {3})", x3, y3, x4, y4);

                if (x2 < x1)
                {
                    int z = x1;
                    x1 = x2;
                    x2 = z;
                    z = y1;
                    y1 = y2;
                    y2 = z;
                }
                if (x4 < x3)
                {
                    int z = x3;
                    x3 = x4;
                    x4 = z;
                    z = y3;
                    y3 = y4;
                    y4 = z;
                }

                Console.WriteLine("\n\nRectangle A Corners: ({0}, {1}), ({2}, {3})", x1, y1, x2, y2);
                Console.WriteLine("Rectangle B Corners: ({0}, {1}), ({2}, {3})", x3, y3, x4, y4);

                Console.WriteLine("\n\nDoes Rectangle A intersect with Rectangle B?  {0}\n", rectanglesOverlap(x1, y1, x2, y2, x3, y3, x4, y4));
            }
            Console.WriteLine("------------------------------------------------------\n");
            Console.ReadKey();
        }
        public static bool rectanglesOverlap(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            if (x1 == x2 || y1 == y2 || x3 == x4 || y3 == y4)
            {
                Console.Write("\n~Invalid Rectangle~");
                return (false);
            }
            else if ((x1 < x4) && (x2 > x3) && (y1 < y4) && (y2 > y3))
                return (true);
            else
                return (false);
        }

    }
}
