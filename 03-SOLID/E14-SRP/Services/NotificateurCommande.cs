namespace Formation.E14.SRP.Services;
using Formation.E14.SRP.Models;

/// <summary>Responsabilité unique : envoyer des notifications liées aux commandes.</summary>
public class NotificateurCommande
{
    public void NotifierConfirmation(Commande commande)
    {
        Console.WriteLine($"\n  📧 Email de confirmation envoyé à {commande.Client}");
        Console.WriteLine($"     Commande #{commande.Id} — {commande.Produit} × {commande.Quantite}");
        Console.WriteLine($"     Total : {commande.MontantTotal:C2}");
    }

    public void NotifierEchec(Commande commande, IReadOnlyList<string> raisons)
    {
        Console.WriteLine($"\n  ⚠️  Commande #{commande.Id} rejetée pour {commande.Client}");
        foreach (var raison in raisons)
            Console.WriteLine($"     - {raison}");
    }

    public void NotifierStockInsuffisant(Commande commande)
    {
        Console.WriteLine($"\n  ⛔ Stock insuffisant pour la commande #{commande.Id}");
        Console.WriteLine($"     {commande.Produit} — quantité demandée : {commande.Quantite}");
    }
}
