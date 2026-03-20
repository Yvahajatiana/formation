namespace Formation.E16.LSP.Models;

/// <summary>
/// The penguin is a bird but CANNOT fly.
/// LSP: it inherits from Oiseau (not OiseauVolant) — no Voler() implementation
/// that would throw an exception or return a meaningless value.
/// </summary>
public class Pingouin : Oiseau
{
    public double VitesseNageKmH { get; }

    public Pingouin(string nom, double vitesseNageKmH = 36) : base(nom)
    {
        VitesseNageKmH = vitesseNageKmH;
    }

    public override string SeDeplacer() => Nager();
    public override string Crier() => "Wak wak !";

    public string Nager() => $"{Nom} nage à {VitesseNageKmH} km/h";
}
