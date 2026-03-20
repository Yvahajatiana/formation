namespace Formation.E14.SRP.Services;
using Formation.E14.SRP.Models;

/// <summary>Responsabilité unique : valider les règles métier d'une commande.</summary>
public class ValidateurCommande
{
    public (bool EstValide, IReadOnlyList<string> Erreurs) Valider(Commande commande)
    {
        var erreurs = new List<string>();

        if (string.IsNullOrWhiteSpace(commande.Client))
            erreurs.Add("Le client est obligatoire.");
        if (string.IsNullOrWhiteSpace(commande.Produit))
            erreurs.Add("Le produit est obligatoire.");
        if (commande.Quantite <= 0)
            erreurs.Add("La quantité doit être supérieure à zéro.");
        if (commande.PrixUnitaire <= 0)
            erreurs.Add("Le prix unitaire doit être supérieur à zéro.");
        if (commande.MontantTotal > 50_000m)
            erreurs.Add("Les commandes dépassant 50 000 € nécessitent une validation manuelle.");

        return (erreurs.Count == 0, erreurs.AsReadOnly());
    }
}
