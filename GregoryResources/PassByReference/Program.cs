using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassByReference
{
    class Program
    {

        static void doIt(int a, int[] intArray)
        {
            Console.WriteLine("2: a={0}, intArray[{1},{2}]",
                        a, intArray[0], intArray[1]);
            a = 22;
            intArray[1] = 77;
            Console.WriteLine("4: a={0}, intArray[{1},{2}]", a, intArray[0], intArray[1]);
            intArray = new int[2];
            Console.WriteLine("6: a={0}, intArray[{1},{2}]", a, intArray[0], intArray[1]);

        }

        static void Main(string[] args)
        {
            int[] ia1 = new int[2];
            ia1[0] = 2;
            ia1[1] = 5;
            int v1 = 7;
            Console.WriteLine("1: v1={0}, ia[{1},{2}]", v1, ia1[0], ia1[1]);
            doIt(v1, ia1);
            Console.WriteLine("8: v1={0}, ia[{1},{2}]", v1, ia1[0], ia1[1]);
            Console.ReadKey();
        }
    }
}
