// Concepts : classes abstraites, méthodes abstraites, template method pattern (basique)
// .NET 8 — Top-level statements

using Formation.E12.Abstraction.Models;

Console.WriteLine("=== Épisode 12 — Abstraction ===\n");

// Employe est abstraite — on ne peut pas écrire : new Employe(...)
// Les instances sont toujours des types concrets

var alice = new EmployeTempsPlein("Martin", "Alice", "Développeuse senior", 4500m);
var bob = new EmployeTempsPlein("Dupont", "Bob", "Chef de projet", 5200m);

var charlie = new Freelance("Leroy", "Charlie", "Designer UX", tauxHoraire: 75m);
charlie.EnregistrerHeures(35);
charlie.EnregistrerHeures(12.5);

var emma = new Freelance("Petit", "Emma", "Consultante data", tauxHoraire: 95m);
emma.EnregistrerHeures(60);

Console.WriteLine("\n=== Calcul de la masse salariale ===");

// Store everything in a list of the abstract class
List<Employe> equipe = [alice, bob, charlie, emma];

foreach (var employe in equipe)
{
    employe.AfficherFichePaie(); // dynamic dispatch to the correct implementation
}

decimal masseSalariale = equipe.Sum(e => e.CalculerSalaire());
Console.WriteLine($"\n  Masse salariale totale (brut) : {masseSalariale:C2}");
Console.WriteLine($"  Nombre d'employés : {equipe.Count}");
Console.WriteLine($"  dont CDI      : {equipe.OfType<EmployeTempsPlein>().Count()}");
Console.WriteLine($"  dont Freelance: {equipe.OfType<Freelance>().Count()}");
