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
            int[] intsOne = { 1, 3, 5, 7, 9 };
            int[] intsTwo = { 3, 6, 7, 9, 1, 2 };
            Console.Write("intsOne: ");
            for (int i = 0; i < intsOne.Length; i++)
            {
                Console.Write(intsOne[i] + ", ");
            }
            Console.WriteLine("");
            Console.Write("intsTwo: ");
            for (int i = 0; i < intsTwo.Length; i++)
            {
                Console.Write(intsTwo[i] + ", ");
            }
            Console.WriteLine("");
            Console.Write("Common: ");
            for (int i = 0; i < intsOne.Length; i++)
            {
                for (int j = 0; j < intsOne.Length; j++)
                {
                    if (intsOne[i] == intsTwo[j])
                    {
                        Console.Write(intsOne[i] + ", ");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
