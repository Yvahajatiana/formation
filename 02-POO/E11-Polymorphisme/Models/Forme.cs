namespace Formation.E11.Polymorphisme.Models;

/// <summary>Abstract class representing a geometric shape.</summary>
public abstract class Forme
{
    public string Nom { get; }
    public string Couleur { get; set; }

    protected Forme(string nom, string couleur = "Noir")
    {
        Nom = nom;
        Couleur = couleur;
    }

    // Abstract methods — MUST be overridden in subclasses
    public abstract double CalculerSurface();
    public abstract double CalculerPerimetre();

    // Virtual method with default implementation
    public virtual void Afficher()
    {
        Console.WriteLine($"  {Nom} ({Couleur})");
        Console.WriteLine($"    Surface    : {CalculerSurface():F4} unités²");
        Console.WriteLine($"    Périmètre  : {CalculerPerimetre():F4} unités");
    }

    public override string ToString() => $"{GetType().Name}({Nom})";
}
