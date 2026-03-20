// Principe D — Dependency Inversion Principle (DIP)
// "Les modules de haut niveau ne doivent pas dépendre des modules de bas niveau.
//  Les deux doivent dépendre d'abstractions."
// .NET 8 — Top-level statements

using Formation.E18.DIP.Contracts;
using Formation.E18.DIP.Infrastructure;
using Formation.E18.DIP.Services;

Console.WriteLine("=== Épisode 18 — DIP : Dependency Inversion Principle ===\n");

/*
 * AVANT DIP — couplage fort :
 *
 * public class ServiceUtilisateur
 * {
 *   private readonly DepotUtilisateurMemoire _depot = new(); // coupled to a concrete implementation
 *
 *   // Cannot change the implementation without modifying the class
 *   // Cannot test without instantiating DepotUtilisateurMemoire
 * }
 *
 * APRÈS DIP — couplage faible via abstraction :
 * ServiceUtilisateur dépend de IDepotUtilisateur.
 * L'implémentation concrète est injectée depuis l'extérieur.
 */

// ============================================================
// 1. With in-memory repository
// ============================================================
Console.WriteLine("--- 1. Service avec dépôt en mémoire ---");

IDepotUtilisateur depotMemoire = new DepotUtilisateurMemoire();
var service = new ServiceUtilisateur(depotMemoire);

service.Inscrire("Alice Martin", "alice@example.com");
service.Inscrire("Bob Dupont", "bob@example.com");
service.Inscrire("Charlie Leroy", "charlie@example.com");

Console.WriteLine("\n  Liste des utilisateurs :");
service.AfficherTousLesUtilisateurs();

var utilisateurTrouve = service.Rechercher("bob@example.com");
Console.WriteLine($"\n  Recherche 'bob@example.com' : {utilisateurTrouve?.Nom ?? "Non trouvé"}");

// ============================================================
// 2. Change implementation — ServiceUtilisateur does NOT change
// ============================================================
Console.WriteLine("\n--- 2. Même service, dépôt différent (fichier) ---");

IDepotUtilisateur depotFichier = new DepotUtilisateurFichier("utilisateurs.json");
var serviceFichier = new ServiceUtilisateur(depotFichier); // same code, different implementation

serviceFichier.Inscrire("Emma Petit", "emma@example.com");
serviceFichier.Inscrire("Lucas Moreau", "lucas@example.com");

Console.WriteLine("\n  Liste depuis le dépôt fichier :");
serviceFichier.AfficherTousLesUtilisateurs();

Console.WriteLine("\n  ServiceUtilisateur n'a pas été modifié pour changer d'implémentation ✓");
Console.WriteLine("  C'est le principe DIP : le module de haut niveau est découplé du bas niveau.");
