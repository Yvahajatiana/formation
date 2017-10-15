using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int Choice;

            Console.Write("Ampidiro ny safidinao:");
            int.TryParse(Console.ReadLine(),out Choice);

            switch (Choice)
            {
                case 1:
                    Console.WriteLine("Nisafidy ny iray ianao");
                    break;
                case 2:
                    Console.WriteLine("Nisafidy ny roa ianao");
                    break;
                case 3:
                    Console.WriteLine("Nisafidy ny Telo ianao");
                    break;
                case 4:
                    Console.WriteLine("Nisafidy ny Efatra ianao");
                    break;
                case 5:
                    Console.WriteLine("Nisafidy ny Dimy ianao");
                    break;
                default:
                    Console.WriteLine("Hamarino ny safidinao");
                    break;
            }
            Console.ReadKey();
        }
    }
}
