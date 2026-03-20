namespace Formation.E14.SRP.Models;

public record Commande(
    int Id,
    string Client,
    string Produit,
    int Quantite,
    decimal PrixUnitaire
)
{
    public decimal MontantTotal => Quantite * PrixUnitaire;
}
