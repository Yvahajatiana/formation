namespace Formation.E15.OCP.Services;
using Formation.E15.OCP.Contracts;

public class RemiseFidelite : ICalculateurRemise
{
    private readonly int _anneesAnciennete;

    public string Nom => "Fidélité";
    public string Description => $"Client fidèle ({_anneesAnciennete} an(s)) — remise progressive";

    public RemiseFidelite(int anneesAnciennete) => _anneesAnciennete = anneesAnciennete;

    public decimal CalculerRemise(decimal prix)
    {
        // Progressive discount: +2% per year of seniority, capped at 20%
        decimal taux = Math.Min(_anneesAnciennete * 0.02m, 0.20m);
        return prix * taux;
    }
}
