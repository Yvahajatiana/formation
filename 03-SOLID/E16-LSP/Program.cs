// Principe L — Liskov Substitution Principle (LSP)
// "Les objets d'une classe dérivée doivent pouvoir remplacer les objets de la classe de base
//  sans altérer la correction du programme."
// .NET 8 — Top-level statements

using Formation.E16.LSP.Models;

Console.WriteLine("=== Épisode 16 — LSP : Liskov Substitution Principle ===\n");

/*
 * VIOLATION DE LSP — anti-pattern classique :
 *
 * public class Pingouin : OiseauVolant          // Pingouin hérite de OiseauVolant
 * {
 *   public override string Voler()
 *     => throw new NotSupportedException("Les pingouins ne volent pas !");
 *                                               // ← VIOLATION : le code qui appelle Voler()
 *                                               //   sur un OiseauVolant peut planter
 *                                               //   à cause d'un Pingouin.
 * }
 *
 * Conséquence : tout code utilisant OiseauVolant doit vérifier le type réel
 * → else if (oiseau is Pingouin) → c'est le signe d'une violation LSP.
 *
 * SOLUTION : Pingouin hérite d'Oiseau, pas d'OiseauVolant.
 */

// ============================================================
// 1. Flying birds — substitutable among themselves
// ============================================================
Console.WriteLine("--- 1. Oiseaux volants (OiseauVolant) ---");

List<OiseauVolant> oisVolants =
[
    new Aigle("Bruno"),
    new Moineau("Pico"),
    new Aigle("Zeus"),
];

foreach (OiseauVolant oiseau in oisVolants)
{
    // Call to Voler() always valid — LSP respected
    Console.WriteLine($"  {oiseau.Voler()} — cri : {oiseau.Crier()}");
}

// ============================================================
// 2. All birds — Penguin included via base class Oiseau
// ============================================================
Console.WriteLine("\n--- 2. Tous les oiseaux (Oiseau) ---");

List<Oiseau> tousLesOiseaux =
[
    new Aigle("Bruno"),
    new Moineau("Pico"),
    new Pingouin("Tux"),
    new Pingouin("Happy"),
];

foreach (Oiseau oiseau in tousLesOiseaux)
{
    // SeDeplacer() is valid for all — each moves in its own way
    Console.WriteLine($"  {oiseau} : {oiseau.SeDeplacer()} — cri : {oiseau.Crier()}");
}

// ============================================================
// 3. Demonstrating substitutability
// ============================================================
Console.WriteLine("\n--- 3. Substituabilité en action ---");

static void FaireVolerLaFlotte(IEnumerable<OiseauVolant> flotte)
{
    Console.WriteLine("  Décollage de la flotte :");
    foreach (var oiseau in flotte)
        Console.WriteLine($"    → {oiseau.Voler()}"); // Always safe — LSP guaranteed
}

FaireVolerLaFlotte(oisVolants);

// A Pingouin CANNOT be passed to FaireVolerLaFlotte — compile error
// FaireVolerLaFlotte([new Pingouin("Tux")]); // ← not an OiseauVolant
Console.WriteLine("\n  Le compilateur empêche de passer un Pingouin à FaireVolerLaFlotte ✓");
