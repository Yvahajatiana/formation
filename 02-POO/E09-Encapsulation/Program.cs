// Concepts : encapsulation, champs privés, propriétés, protection de l'état interne
// .NET 8 — Top-level statements

using Formation.E09.Encapsulation.Models;

Console.WriteLine("=== Épisode 09 — Encapsulation ===\n");

var compte = new CompteBancaire("Alice Martin", "FR76-0001-2345", soldeInitial: 1000m);

Console.WriteLine($"Compte créé : {compte}");
Console.WriteLine();

// Opérations légitimes
compte.Deposer(500m);
compte.Deposer(250m);
compte.Retirer(200m);

// Tentative de retrait excessif (refusée)
compte.Retirer(2000m);

// Encore un retrait valide
compte.Retirer(150m);

// Affichage de l'historique
compte.AfficherHistorique();

// Démonstration : le code ci-dessous NE COMPILE PAS (encapsulation protège _solde)
// compte._solde = 999999m;   // ERREUR : '_solde' est inaccessible
// compte.Solde = 0m;         // ERREUR : 'Solde' n'a pas de setter

Console.WriteLine("\n--- Test de validation ---");
try
{
    compte.Deposer(-100m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"  Exception capturée : {ex.Message}");
}
