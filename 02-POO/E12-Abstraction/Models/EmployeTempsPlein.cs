namespace Formation.E12.Abstraction.Models;

/// <summary>Full-time permanent employee with fixed monthly salary.</summary>
public class EmployeTempsPlein : Employe
{
    public decimal SalaireMensuelBrut { get; }

    public EmployeTempsPlein(string nom, string prenom, string poste, decimal salaireMensuelBrut)
        : base(nom, prenom, poste)
    {
        if (salaireMensuelBrut < 1767.00m) // approximate SMIC 2024
            throw new ArgumentException("Le salaire ne peut pas être inférieur au SMIC.");
        SalaireMensuelBrut = salaireMensuelBrut;
    }

    public override decimal CalculerSalaire() => SalaireMensuelBrut;
}
