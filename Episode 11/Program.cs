using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombre = SaisieDonnee();
            int carre = Carre(nombre);
            Affichage(carre);
            Console.ReadKey();
        }

        public static int Carre(int nombre)
        {
            int auCarre = nombre * nombre;
            return auCarre;
        }

        private static int SaisieDonnee()
        {
            Console.WriteLine("Ampidiro ny nombre: ");
            int nombre;
            int.TryParse(Console.ReadLine(), out nombre);
            return nombre;
        }

        private static void Affichage(int nombre)
        {
            Console.WriteLine("Le carre: {0}", nombre);
        }
    }
}
