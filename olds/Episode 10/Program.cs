using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] jours = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            for (int i = 0;i<jours.Length;i++)
            {
                Console.WriteLine("Jour indice {0} est {1}", i, jours[i]);

            }

            Console.WriteLine("Affichage jours avec LIST");
            List<string> jourList = new List<string> { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi"};
            jourList.Add("Samedi - Rajout");
            jourList.Add("Dimache - Rajout");

            foreach(string jour in jourList)
            {
                Console.WriteLine("Jour {0}", jour);
            }

            Console.Read();
        }
    }
}
