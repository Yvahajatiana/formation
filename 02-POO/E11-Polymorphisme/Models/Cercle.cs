namespace Formation.E11.Polymorphisme.Models;

public class Cercle : Forme
{
    public double Rayon { get; }
    public double Diametre => Rayon * 2;

    public Cercle(string nom, double rayon, string couleur = "Noir") : base(nom, couleur)
    {
        if (rayon <= 0) throw new ArgumentException("Le rayon doit être positif.", nameof(rayon));
        Rayon = rayon;
    }

    public override double CalculerSurface() => Math.PI * Rayon * Rayon;
    public override double CalculerPerimetre() => 2 * Math.PI * Rayon;

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine($"    Rayon      : {Rayon:F2} unités");
        Console.WriteLine($"    Diamètre   : {Diametre:F2} unités");
    }
}
