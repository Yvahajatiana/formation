namespace Formation.E15.OCP.Services;
using Formation.E15.OCP.Contracts;

/// <summary>
/// Caisse fermée à la modification : elle n'a pas besoin de changer
/// quand on ajoute un nouveau type de remise.
/// </summary>
public class Caisse
{
    private readonly ICalculateurRemise _calculateur;

    public Caisse(ICalculateurRemise calculateur) => _calculateur = calculateur;

    public void AfficherDevis(string produit, decimal prixOriginal)
    {
        decimal remise = _calculateur.CalculerRemise(prixOriginal);
        decimal prixFinal = prixOriginal - remise;

        Console.WriteLine($"\n  Produit        : {produit}");
        Console.WriteLine($"  Stratégie      : {_calculateur.Description}");
        Console.WriteLine($"  Prix original  : {prixOriginal:C2}");
        Console.WriteLine($"  Remise         : -{remise:C2}");
        Console.WriteLine($"  Prix final     : {prixFinal:C2}");
    }
}
