namespace Formation.E15.OCP.Services;
using Formation.E15.OCP.Contracts;

public class RemiseVip : ICalculateurRemise
{
    public string Nom => "VIP";
    public string Description => "Client VIP — remise fixe de 25%";
    public decimal CalculerRemise(decimal prix) => prix * 0.25m;
}
