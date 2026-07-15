using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_12
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal average;
            List<decimal> notes;

            notes = SaisieNote();

            if (notes.Count == 0)
            {
                Console.WriteLine("\nTsy napiditra naoty ianao");
            }
            else
            {
                average = NoteAverage(notes);
                PrintNote(average, notes);
            }            
            
            Console.Read();
        }

        static List<decimal> SaisieNote()
        {
            List<decimal> Notes = new List<decimal>();
            bool Continue = false;

            do
            {
                decimal note;
                Console.Write("\nAmpidiro ny naoty: ");
                if(decimal.TryParse(Console.ReadLine(), out note))
                {
                    Notes.Add(note);
                    Console.WriteLine("Tafiditra soamantsara ny tarehimarika nampidirinao");
                }
                else
                {
                    Console.WriteLine("Hamarino tsara azafady tompoko ny tarehimarika nampidirinao");
                }

                Console.Write("Tsindrio ny Y raha mbola hanohy: ");
                Continue = Console.ReadKey().Key == ConsoleKey.Y;
            } while (Continue);


            return Notes;
        }

        static decimal NoteAverage(List<decimal> notes)
        {


            decimal sum = 0.0M;

            foreach (decimal note in notes)
            {
                sum = sum + note;
            }

            decimal average = (sum) / notes.Count;

            return average;
        }

        static void PrintNote(decimal average, List<decimal> notes)
        {
            int i = 1;
            Console.WriteLine("\nLisitry ny naoty:");

            foreach(decimal note in notes)
            {
                Console.WriteLine("Note {0}: {1}", i,note);
                i++;
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Ny moyenne dia {0}", average);
        }
    }
}
