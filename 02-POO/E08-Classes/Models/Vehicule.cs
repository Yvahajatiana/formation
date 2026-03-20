namespace Formation.E08.Classes.Models;

/// <summary>Représente un véhicule motorisé.</summary>
public class Vehicule
{
    public string Marque { get; }
    public string Modele { get; }
    public int Annee { get; }
    public decimal Kilometrage { get; private set; }
    public bool EstDemarre { get; private set; }

    // Static field — shared between all instances
    private static int _nombreVehiculesCreés = 0;
    public static int NombreVehiculesCreés => _nombreVehiculesCreés;

    public Vehicule(string marque, string modele, int annee)
    {
        Marque = marque;
        Modele = modele;
        Annee = annee;
        Kilometrage = 0;
        EstDemarre = false;
        _nombreVehiculesCreés++;
    }

    public void Demarrer()
    {
        if (EstDemarre)
        {
            Console.WriteLine($"  {Marque} {Modele} est déjà démarré.");
            return;
        }
        EstDemarre = true;
        Console.WriteLine($"  Vroom ! {Marque} {Modele} démarre.");
    }

    public void Conduire(decimal km)
    {
        if (!EstDemarre)
        {
            Console.WriteLine($"  Impossible de conduire : le véhicule n'est pas démarré.");
            return;
        }
        if (km <= 0) throw new ArgumentException("La distance doit être positive.", nameof(km));
        Kilometrage += km;
        Console.WriteLine($"  Vous avez parcouru {km} km. Kilométrage total : {Kilometrage} km.");
    }

    public void Arreter()
    {
        EstDemarre = false;
        Console.WriteLine($"  {Marque} {Modele} s'arrête.");
    }

    public override string ToString() => $"{Annee} {Marque} {Modele} — {Kilometrage} km";
}
