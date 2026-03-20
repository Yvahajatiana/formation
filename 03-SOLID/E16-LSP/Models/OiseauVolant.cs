namespace Formation.E16.LSP.Models;

/// <summary>
/// Specialization: a bird CAPABLE of flying.
/// The ability to fly is isolated here — not in the base Oiseau class.
/// </summary>
public abstract class OiseauVolant : Oiseau
{
    public double VitesseMaxKmH { get; }

    protected OiseauVolant(string nom, double vitesseMaxKmH) : base(nom)
    {
        VitesseMaxKmH = vitesseMaxKmH;
    }

    public virtual string Voler() => $"{Nom} vole à {VitesseMaxKmH} km/h";
    public override string SeDeplacer() => Voler();
}
