using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int Age;
            bool Contunue = false;

            do
            {
                Console.Write("Ampidiro ny taona-nao: ");
                int.TryParse(Console.ReadLine(), out Age);

                if (Age < 12)
                {
                    Console.WriteLine("Zaza");
                }
                else if (Age >= 12 && Age <= 18)
                {
                    Console.WriteLine("Miala sakana");
                }
                else if (Age > 18 && Age <= 35)
                {
                    Console.WriteLine("Tanora herotrerony");
                }
                else
                {
                    Console.WriteLine("Olon-dehibe");
                }

                Console.WriteLine("Mbola anohy ve, raha hanohy dia tsindrio ny Entre");
                var touche = Console.ReadKey().Key;

                Contunue = (touche == ConsoleKey.Enter);

            } while (Contunue);

            Console.WriteLine("Tapitra");
            Console.ReadKey();
        }
    }
}
