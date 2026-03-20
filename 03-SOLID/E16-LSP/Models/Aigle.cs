namespace Formation.E16.LSP.Models;

public class Aigle : OiseauVolant
{
    public Aigle(string nom) : base(nom, vitesseMaxKmH: 320) { }

    public override string Voler() => $"{Nom} plane majestueusement à {VitesseMaxKmH} km/h";
    public override string Crier() => "Krii !";
}
