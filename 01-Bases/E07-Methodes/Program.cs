// Concepts : méthodes statiques, paramètres, retour, surcharge, expression-bodied, local functions
// .NET 8 — Top-level statements

Console.WriteLine("=== Démonstration des méthodes ===\n");

// --- 1. Méthode avec valeur de retour ---
Console.WriteLine("--- Calculs mathématiques ---");
int nombre = SaisirEntier("Entrez un nombre entier : ");
Console.WriteLine($"  Carré       : {Carre(nombre)}");
Console.WriteLine($"  Cube        : {Puissance(nombre, 3)}");
Console.WriteLine($"  Valeur abs. : {ValeurAbsolue(nombre)}");

// --- 2. Surcharge de méthode ---
Console.WriteLine("\n--- Surcharge (Additionner) ---");
Console.WriteLine($"  int + int     : {Additionner(3, 7)}");
Console.WriteLine($"  double + double : {Additionner(3.14, 2.71)}");
Console.WriteLine($"  3 entiers     : {Additionner(1, 2, 3)}");

// --- 3. Paramètres optionnels et nommés ---
Console.WriteLine("\n--- Paramètres optionnels ---");
AfficherProfil("Alice");
AfficherProfil("Bob", 30);
AfficherProfil(nom: "Charlie", age: 25, ville: "Lyon");

// --- 4. Calculatrice de notes ---
Console.WriteLine("\n--- Calculatrice de notes ---");
List<decimal> notes = SaisirNotes();

if (notes.Count == 0)
{
    Console.WriteLine("Aucune note saisie.");
    return;
}

AfficherBilanNotes(notes);

// ============================================================
// Déclarations des méthodes (local functions en top-level)
// ============================================================

static int SaisirEntier(string invite)
{
    Console.Write(invite);
    return int.TryParse(Console.ReadLine(), out int valeur) ? valeur : 0;
}

// Expression-bodied method (corps en une ligne)
static int Carre(int n) => n * n;
static double Puissance(int base_, int exp) => Math.Pow(base_, exp);
static int ValeurAbsolue(int n) => n < 0 ? -n : n;

// Surcharge : même nom, signatures différentes
static int Additionner(int a, int b) => a + b;
static double Additionner(double a, double b) => a + b;
static int Additionner(int a, int b, int c) => a + b + c;

// Paramètres optionnels (valeur par défaut)
static void AfficherProfil(string nom, int age = 0, string ville = "Non renseignée")
{
    string ageStr = age > 0 ? $"{age} ans" : "âge non renseigné";
    Console.WriteLine($"  {nom,-10} | {ageStr,-20} | {ville}");
}

static List<decimal> SaisirNotes()
{
    var notes = new List<decimal>();
    bool continuer;

    do
    {
        Console.Write($"  Note {notes.Count + 1} (0-20) : ");
        if (decimal.TryParse(Console.ReadLine(), out decimal note) && note >= 0 && note <= 20)
        {
            notes.Add(note);
            Console.WriteLine($"  ✓ Note {note:F2} enregistrée.");
        }
        else
        {
            Console.WriteLine("  ✗ Valeur invalide (entrez un nombre entre 0 et 20).");
        }

        Console.Write("  Ajouter une autre note ? (O/N) : ");
        continuer = Console.ReadKey().Key == ConsoleKey.O;
        Console.WriteLine();
    } while (continuer);

    return notes;
}

static void AfficherBilanNotes(List<decimal> notes)
{
    decimal moyenne = notes.Average();
    string mention = ObtenirMention(moyenne);

    Console.WriteLine("\n=== Bilan ===");
    for (int i = 0; i < notes.Count; i++)
    {
        Console.WriteLine($"  Note {i + 1,2} : {notes[i],5:F2} / 20");
    }
    Console.WriteLine(new string('─', 30));
    Console.WriteLine($"  Moyenne : {moyenne,5:F2} / 20  →  {mention}");
    Console.WriteLine($"  Max     : {notes.Max(),5:F2} / 20");
    Console.WriteLine($"  Min     : {notes.Min(),5:F2} / 20");
}

// switch expression dans une méthode
static string ObtenirMention(decimal moyenne) => moyenne switch
{
    >= 16m => "Très bien  🏆",
    >= 14m => "Bien       ✅",
    >= 12m => "Assez bien 👍",
    >= 10m => "Passable   📋",
    _      => "Insuffisant ❌"
};
