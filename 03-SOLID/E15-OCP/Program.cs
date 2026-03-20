// Principe O — Open/Closed Principle (OCP)
// "Une entité logicielle doit être ouverte à l'extension, mais fermée à la modification."
// .NET 8 — Top-level statements

using Formation.E15.OCP.Contracts;
using Formation.E15.OCP.Services;

Console.WriteLine("=== Épisode 15 — OCP : Open/Closed Principle ===\n");

/*
 * AVANT OCP — un seul switch/if gérant tous les types de remise :
 *
 * public decimal CalculerRemise(string typeClient, decimal prix) {
 *   if (typeClient == "standard") return 0;
 *   else if (typeClient == "fidele") return prix * 0.10m;
 *   else if (typeClient == "vip") return prix * 0.25m;
 *   // Pour ajouter "saisonniere", on MODIFIE cette méthode → risque de régression
 * }
 *
 * APRÈS OCP — chaque type de remise est une classe séparée.
 * Pour ajouter RemiseSaisonniere, on crée une nouvelle classe → zéro modification du code existant.
 */

const decimal PRIX_PRODUIT = 350.00m;

// The different discount strategies
List<ICalculateurRemise> strategies =
[
    new RemiseStandard(),
    new RemiseFidelite(anneesAnciennete: 3),
    new RemiseFidelite(anneesAnciennete: 10),
    new RemiseVip(),
    new RemiseSaisonniere("Soldes d'été", 0.30m),  // added without touching Caisse or other classes
];

var caisse = new Caisse(new RemiseStandard()); // initialized with a default strategy

Console.WriteLine($"=== Simulation pour un produit à {PRIX_PRODUIT:C2} ===");
foreach (var strategie in strategies)
{
    // Strategy can be changed on the fly (Strategy pattern + OCP)
    var caisseAvecStrategie = new Caisse(strategie);
    caisseAvecStrategie.AfficherDevis("Laptop Pro X1", PRIX_PRODUIT);
}

Console.WriteLine("\n=== Comparaison des remises ===");
Console.WriteLine($"  {"Stratégie",-25} {"Remise",-12} {"Prix final",-12}");
Console.WriteLine(new string('─', 50));

foreach (var s in strategies)
{
    decimal remise = s.CalculerRemise(PRIX_PRODUIT);
    Console.WriteLine($"  {s.Nom,-25} {remise,-12:C2} {PRIX_PRODUIT - remise,-12:C2}");
}
