namespace Formation.E11.Polymorphisme.Models;

public class Triangle : Forme
{
    public double CoteA { get; }
    public double CoteB { get; }
    public double CoteC { get; }

    public Triangle(string nom, double a, double b, double c, string couleur = "Noir")
        : base(nom, couleur)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Ces trois côtés ne forment pas un triangle valide.");
        CoteA = a; CoteB = b; CoteC = c;
    }

    public override double CalculerPerimetre() => CoteA + CoteB + CoteC;

    // Heron's formula
    public override double CalculerSurface()
    {
        double s = CalculerPerimetre() / 2;
        return Math.Sqrt(s * (s - CoteA) * (s - CoteB) * (s - CoteC));
    }
}
