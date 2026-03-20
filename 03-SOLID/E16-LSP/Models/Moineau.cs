namespace Formation.E16.LSP.Models;

public class Moineau : OiseauVolant
{
    public Moineau(string nom) : base(nom, vitesseMaxKmH: 45) { }
    public override string Crier() => "Cui-cui !";
}
