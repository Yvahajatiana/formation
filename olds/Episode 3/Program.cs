using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name;
            string AgeString;
            int Age;

            Console.Write("Ampidiro ny anaranao: ");
            Name = Console.ReadLine();
            Console.Write("Ary ny taonanao: ");
            AgeString = Console.ReadLine();
            int.TryParse(AgeString, out Age);
            Console.WriteLine("Ny anaranao dia i {0} {1} taona", Name, Age);
            Console.ReadKey();
        }
    }
}
