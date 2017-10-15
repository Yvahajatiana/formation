using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int Choice;

            Console.Write("Ampidiro ny safidinao (1-5): ");
            int.TryParse(Console.ReadLine(), out Choice);

            if (Choice == 1)
            {
                Console.WriteLine("Nisafidy ny Ray ianao");
            }
            else if (Choice == 2)
            {
                Console.WriteLine("Nisafidy ny Roa ianao");
            }
            else if (Choice == 3)
            {
                Console.WriteLine("Nisafidy ny Telo ianao");
            }
            else if (Choice == 4)
            {
                Console.WriteLine("Nisafidy ny Efatra ianao");
            }
            else if (Choice == 5)
            {
                Console.WriteLine("Nisafidy ny Dimy ianao");
            }
            else
            {
                Console.WriteLine("Hamarino ny safidinao");
            }
            Console.ReadKey();
        }
    }
}
