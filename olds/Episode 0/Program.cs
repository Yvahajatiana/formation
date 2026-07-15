using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int Age;
            Age = 18;

            decimal Longueur = 1.60M;

            string Prenom = "Razafy";
            string Nom = "Rakoto";

            string NomComplet = Nom + " " + Prenom;

            int Addition, a,b;

            a = 10;
            b = 15;

            Addition = a + b;

            Debug.WriteLine(Addition);

            Console.WriteLine("Totaliny: {0}", Addition);

            Console.WriteLine("Ny anarany dia: {0}", NomComplet);
            Console.WriteLine("Ny taonany dia: {0} ary ny halavany dia {1} metatra",Age,Longueur);
            Console.ReadKey();
        }
    }
}
