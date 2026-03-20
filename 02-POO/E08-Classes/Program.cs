// Concepts : classes, objets, propriétés, méthodes d'instance, constructeurs, membres statiques
// .NET 8 — Top-level statements

using Formation.E08.Classes.Models;

Console.WriteLine("=== Épisode 08 — Classes et Objets ===\n");

// ============================================================
// 1. Création d'instances (objets)
// ============================================================
Console.WriteLine("--- 1. Création de personnes ---");

var alice = new Personne("Alice", "Martin", 28, "alice@example.com");
var bob = new Personne("Bob", "Dupont", 17);  // email optionnel

Console.WriteLine(alice.SePresenter());
Console.WriteLine(bob.SePresenter());
Console.WriteLine();

// Accès aux propriétés
Console.WriteLine($"  Nom complet d'Alice : {alice.NomComplet}");
Console.WriteLine($"  Bob est majeur : {bob.EstMajeur}");

alice.FeterAnniversaire();
Console.WriteLine($"  Représentation : {alice}");

// ============================================================
// 2. Membres statiques
// ============================================================
Console.WriteLine("\n--- 2. Véhicules et membre statique ---");

var voiture1 = new Vehicule("Renault", "Clio", 2020);
var voiture2 = new Vehicule("Peugeot", "208", 2023);
var voiture3 = new Vehicule("Toyota", "Yaris", 2022);

Console.WriteLine($"  Véhicules créés jusqu'ici : {Vehicule.NombreVehiculesCreés}");

voiture1.Demarrer();
voiture1.Conduire(45.5m);
voiture1.Conduire(23.0m);
voiture1.Arreter();

Console.WriteLine($"  {voiture1}");

// Tenter de conduire sans démarrer
voiture2.Conduire(10m);

// ============================================================
// 3. Collection d'objets
// ============================================================
Console.WriteLine("\n--- 3. Liste de personnes ---");

List<Personne> equipe =
[
    new Personne("Sophie", "Bernard", 32, "sophie@corp.fr"),
    new Personne("Thomas", "Leroy", 24),
    new Personne("Emma", "Petit", 19, "emma@corp.fr"),
    new Personne("Lucas", "Moreau", 15),
];

var majeursAvecEmail = equipe
    .Where(p => p.EstMajeur && !string.IsNullOrEmpty(p.Email))
    .OrderBy(p => p.Nom)
    .ToList();

Console.WriteLine("  Membres majeurs avec email :");
foreach (var personne in majeursAvecEmail)
{
    Console.WriteLine($"    → {personne.NomComplet} ({personne.Age} ans) — {personne.Email}");
}
