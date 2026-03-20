namespace Formation.E10.Heritage.Models;

/// <summary>Bird — derives from Animal, adds flying behavior.</summary>
public class Oiseau : Animal
{
    public double EnvergureEnCm { get; }
    public bool PeutVoler { get; }

    public Oiseau(string nom, int ageEnMois, double envergureEnCm, bool peutVoler = true)
        : base(nom, "Oiseau", ageEnMois)
    {
        EnvergureEnCm = envergureEnCm;
        PeutVoler = peutVoler;
    }

    public override string Crier() => "Cui-cui !";

    public override string SeDeplacer() =>
        PeutVoler ? $"vole avec une envergure de {EnvergureEnCm} cm" : "marche (ne vole pas)";
}
