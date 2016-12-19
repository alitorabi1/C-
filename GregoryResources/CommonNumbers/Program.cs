using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intsOne = { 1, 1, 3, 5, 7, 9 };
            int[] intsTwo = { 3, 6, 7, 9, 1, 1, 2 };

            foreach (int one in intsOne)
            {
                bool found = false;
                foreach (int two in intsTwo)
                {
                    if (one == two)
                    {
                        found = true;
                        // break for speed
                    }
                }
                if (found)
                {
                    Console.Write(one + ", ");
                }
                
            }
            Console.ReadKey();
        }
    }
}
