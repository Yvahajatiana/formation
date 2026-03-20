// Principe S — Single Responsibility Principle (SRP)
// "Une classe ne doit avoir qu'une seule raison de changer."
// .NET 8 — Top-level statements

using Formation.E14.SRP.Models;
using Formation.E14.SRP.Services;

Console.WriteLine("=== Épisode 14 — SRP : Single Responsibility Principle ===\n");

/*
 * AVANT SRP — une seule classe fait tout (validation, stock, notification) :
 *
 * class TraiteurCommandeMonolithique {
 *   public void Traiter(Commande c) {
 *     // Validation...
 *     // Mise à jour du stock...
 *     // Envoi d'email...
 *     // Logging...
 *     // tout dans une seule méthode de 200 lignes
 *   }
 * }
 *
 * Problème : si la logique d'email change, on modifie la classe de validation.
 * Si le stock change, on risque de casser la notification. Chaque changement
 * crée un risque de régression sur les autres responsabilités.
 *
 * APRÈS SRP — chaque classe a une responsabilité unique :
 */

var validateur = new ValidateurCommande();
var stock = new GestionnaireStock();
var notificateur = new NotificateurCommande();
var traiteur = new TraiteurCommande(validateur, stock, notificateur);

// Valid order
var commande1 = new Commande(1001, "Alice Martin", "Laptop Pro", 2, 1299.99m);
traiteur.Traiter(commande1);

// Invalid order (negative quantity)
var commande2 = new Commande(1002, "Bob Dupont", "Souris ergonomique", -5, 29.99m);
traiteur.Traiter(commande2);

// Order with insufficient stock
var commande3 = new Commande(1003, "Charlie Leroy", "Clavier mécanique", 100, 89.99m);
traiteur.Traiter(commande3);

// Valid order — second purchase
var commande4 = new Commande(1004, "Emma Petit", "Souris ergonomique", 3, 29.99m);
traiteur.Traiter(commande4);

Console.WriteLine("\n=== Stock restant après traitement ===");
foreach (var produit in new[] { "Laptop Pro", "Souris ergonomique", "Clavier mécanique" })
{
    Console.WriteLine($"  {produit,-25} : {stock.ObtenirStock(produit)} unité(s)");
}
