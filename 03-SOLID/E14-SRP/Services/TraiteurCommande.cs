namespace Formation.E14.SRP.Services;
using Formation.E14.SRP.Models;

/// <summary>
/// Orchestre le traitement d'une commande en déléguant à des services spécialisés.
/// Sa seule responsabilité est la coordination du workflow.
/// </summary>
public class TraiteurCommande
{
    private readonly ValidateurCommande _validateur;
    private readonly GestionnaireStock _stock;
    private readonly NotificateurCommande _notificateur;

    public TraiteurCommande(
        ValidateurCommande validateur,
        GestionnaireStock stock,
        NotificateurCommande notificateur)
    {
        _validateur = validateur;
        _stock = stock;
        _notificateur = notificateur;
    }

    public bool Traiter(Commande commande)
    {
        Console.WriteLine($"\n  Traitement de la commande #{commande.Id}...");

        // Step 1: validation
        var (estValide, erreurs) = _validateur.Valider(commande);
        if (!estValide)
        {
            _notificateur.NotifierEchec(commande, erreurs);
            return false;
        }

        // Step 2: stock check
        if (!_stock.VerifierDisponibilite(commande.Produit, commande.Quantite))
        {
            _notificateur.NotifierStockInsuffisant(commande);
            return false;
        }

        // Step 3: stock deduction
        _stock.DeduireStock(commande.Produit, commande.Quantite);

        // Step 4: confirmation
        _notificateur.NotifierConfirmation(commande);
        return true;
    }
}
