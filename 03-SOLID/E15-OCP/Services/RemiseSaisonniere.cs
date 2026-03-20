namespace Formation.E15.OCP.Services;
using Formation.E15.OCP.Contracts;

/// <summary>
/// New discount added WITHOUT modifying existing code.
/// This is the Open/Closed principle in action.
/// </summary>
public class RemiseSaisonniere : ICalculateurRemise
{
    private readonly string _saison;
    private readonly decimal _taux;

    public string Nom => "Saisonnière";
    public string Description => $"Promotion {_saison} — {_taux:P0} de remise";

    public RemiseSaisonniere(string saison, decimal taux)
    {
        _saison = saison;
        _taux = taux;
    }

    public decimal CalculerRemise(decimal prix) => prix * _taux;
}
