// Concepts : héritage, base, virtual, override, protected, GetType(), is, as
// .NET 8 — Top-level statements

using Formation.E10.Heritage.Models;

Console.WriteLine("=== Épisode 10 — Héritage ===\n");

// ============================================================
// 1. Création d'instances de classes dérivées
// ============================================================
Console.WriteLine("--- 1. Description des animaux ---");

var rex = new Chien("Rex", "Berger Allemand", 36);
var mimi = new Chat("Mimi", 24, estCastre: true);
var tweety = new Oiseau("Tweety", 12, envergureEnCm: 25);
var piou = new Oiseau("Piou", 8, envergureEnCm: 60, peutVoler: false);

Console.WriteLine($"  {rex.SeDecrire()}");
Console.WriteLine($"  {mimi.SeDecrire()}");
Console.WriteLine($"  {tweety.SeDecrire()}");
Console.WriteLine($"  {piou.SeDecrire()}");

// ============================================================
// 2. Méthodes spécifiques aux sous-classes
// ============================================================
Console.WriteLine("\n--- 2. Comportements spécifiques ---");
rex.Rapporter("balle");
mimi.Ronronner();

// ============================================================
// 3. Polymorphisme de base — liste de Animal
// ============================================================
Console.WriteLine("\n--- 3. Polymorphisme via référence de base ---");

List<Animal> animaux = [rex, mimi, tweety, piou];

foreach (Animal animal in animaux)
{
    // The correct Crier() is called thanks to dynamic dispatch (virtual/override)
    Console.WriteLine($"  {animal.Nom} dit : {animal.Crier()}");
}

// ============================================================
// 4. Opérateurs is et as — identification du type réel
// ============================================================
Console.WriteLine("\n--- 4. Pattern matching avec is ---");

foreach (Animal animal in animaux)
{
    if (animal is Chien chien)
        Console.WriteLine($"  {animal.Nom} est un chien de race {chien.Race}");
    else if (animal is Chat chat && chat.EstCastre)
        Console.WriteLine($"  {animal.Nom} est un chat castré");
    else if (animal is Oiseau oiseau)
        Console.WriteLine($"  {animal.Nom} est un oiseau — " +
                          (oiseau.PeutVoler ? "vole" : "ne vole pas"));
}

// Use Animal reference to show runtime type checks
Animal tweetyRef = tweety;
Console.WriteLine($"\n  Type réel de tweety : {tweetyRef.GetType().Name}");
Console.WriteLine($"  tweety is Animal  : {tweetyRef is Animal}");
Console.WriteLine($"  tweety is Chien   : {tweetyRef is Chien}");
