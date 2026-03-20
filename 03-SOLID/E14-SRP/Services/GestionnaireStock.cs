namespace Formation.E14.SRP.Services;
using Formation.E14.SRP.Models;

/// <summary>Responsabilité unique : gérer le stock des produits.</summary>
public class GestionnaireStock
{
    private readonly Dictionary<string, int> _stock = new()
    {
        ["Laptop Pro"] = 50,
        ["Souris ergonomique"] = 200,
        ["Clavier mécanique"] = 75,
    };

    public bool VerifierDisponibilite(string produit, int quantite)
    {
        return _stock.TryGetValue(produit, out int disponible) && disponible >= quantite;
    }

    public void DeduireStock(string produit, int quantite)
    {
        if (_stock.ContainsKey(produit))
        {
            _stock[produit] -= quantite;
            Console.WriteLine($"  Stock mis à jour : {produit} → {_stock[produit]} restant(s)");
        }
    }

    public int ObtenirStock(string produit) =>
        _stock.TryGetValue(produit, out int qty) ? qty : 0;
}
