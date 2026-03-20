namespace Formation.E15.OCP.Services;
using Formation.E15.OCP.Contracts;

public class RemiseStandard : ICalculateurRemise
{
    public string Nom => "Standard";
    public string Description => "Client standard — pas de remise";
    public decimal CalculerRemise(decimal prix) => 0m;
}
