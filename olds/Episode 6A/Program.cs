using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_6A
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int j = 1;
            while (i<=10)
            {
                while (j <= 10)
                {
                    Console.WriteLine(" {0} x {1} = {2}", i, j, i * j);
                    j++;
                }
                Console.WriteLine("--------------------");
                j = 1;
                i++;
            }

            Console.ReadKey();
        }
    }
}
