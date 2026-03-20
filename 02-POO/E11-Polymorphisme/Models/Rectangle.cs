namespace Formation.E11.Polymorphisme.Models;

public class Rectangle : Forme
{
    public double Largeur { get; }
    public double Hauteur { get; }
    public bool EstCarre => Largeur == Hauteur;

    public Rectangle(string nom, double largeur, double hauteur, string couleur = "Noir")
        : base(nom, couleur)
    {
        if (largeur <= 0) throw new ArgumentException("La largeur doit être positive.");
        if (hauteur <= 0) throw new ArgumentException("La hauteur doit être positive.");
        Largeur = largeur;
        Hauteur = hauteur;
    }

    public override double CalculerSurface() => Largeur * Hauteur;
    public override double CalculerPerimetre() => 2 * (Largeur + Hauteur);

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine($"    Dimensions : {Largeur:F2} × {Hauteur:F2} unités");
        if (EstCarre) Console.WriteLine($"    → C'est un carré !");
    }
}
