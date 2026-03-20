// Concepts : polymorphisme, classes abstraites, méthodes abstraites, dispatch dynamique
// .NET 8 — Top-level statements

using Formation.E11.Polymorphisme.Models;

Console.WriteLine("=== Épisode 11 — Polymorphisme ===\n");

// ============================================================
// 1. Création de formes diverses via référence de base
// ============================================================
List<Forme> formes =
[
    new Cercle("Grand cercle", 10.0, "Rouge"),
    new Rectangle("Rectangle bleu", 5.0, 8.0, "Bleu"),
    new Rectangle("Carré vert", 6.0, 6.0, "Vert"),
    new Cercle("Petit cercle", 3.5, "Jaune"),
    new Triangle("Triangle isocèle", 5.0, 5.0, 6.0, "Orange"),
];

// ============================================================
// 2. Polymorphisme en action — même appel, résultats différents
// ============================================================
Console.WriteLine("--- Description de chaque forme ---");
foreach (Forme forme in formes)
{
    forme.Afficher(); // the correct Afficher() is called based on the real type
    Console.WriteLine();
}

// ============================================================
// 3. Agrégats sur la collection hétérogène
// ============================================================
Console.WriteLine("--- Statistiques globales ---");
double surfaceTotale = formes.Sum(f => f.CalculerSurface());
double surfaceMax = formes.Max(f => f.CalculerSurface());
Forme formeMaxSurface = formes.MaxBy(f => f.CalculerSurface())!;

Console.WriteLine($"  Nombre de formes     : {formes.Count}");
Console.WriteLine($"  Surface totale       : {surfaceTotale:F2} unités²");
Console.WriteLine($"  Plus grande surface  : {formeMaxSurface.Nom} ({surfaceMax:F2} unités²)");

// ============================================================
// 4. Filtrage par type avec pattern matching
// ============================================================
Console.WriteLine("\n--- Filtres par type ---");

var cercles = formes.OfType<Cercle>().ToList();
Console.WriteLine($"  Cercles ({cercles.Count}) :");
foreach (var c in cercles)
    Console.WriteLine($"    {c.Nom} — rayon {c.Rayon}, diamètre {c.Diametre:F2}");

var carres = formes.OfType<Rectangle>().Where(r => r.EstCarre).ToList();
Console.WriteLine($"\n  Carrés ({carres.Count}) :");
foreach (var r in carres)
    Console.WriteLine($"    {r.Nom} — côté {r.Largeur}");
