using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for(int i = 0; i<=10; i++)
            {
                for(int j = 0; j<=10; j++)
                {
                    Console.WriteLine("{0} x {1} = {2}", i, j, i * j);
                }

                Console.WriteLine("---------------");
            }
            */
            int i = 5;
            do
            {
                Console.WriteLine("Execution");

            } while (i > 5);
            Console.ReadKey();
        }
    }
}
