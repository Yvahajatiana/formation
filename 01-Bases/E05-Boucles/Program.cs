// Concepts : for, while, do/while, foreach, break, continue, boucles imbriquées
// .NET 8 — Top-level statements

// ============================================================
// 1. Boucle for — nombre d'itérations connu à l'avance
// ============================================================
Console.WriteLine("=== 1. Compte à rebours (for) ===");
for (int i = 10; i >= 0; i--)
{
    Console.Write(i == 0 ? "Décollage !" : $"{i}... ");
}
Console.WriteLine("\n");

// ============================================================
// 2. Boucle while — condition testée AVANT chaque itération
// ============================================================
Console.WriteLine("=== 2. Devine le nombre (while) ===");
int nombreSecret = new Random().Next(1, 11); // entre 1 et 10
int tentatives = 0;
bool trouve = false;

while (!trouve)
{
    Console.Write("Proposez un nombre entre 1 et 10 : ");
    if (!int.TryParse(Console.ReadLine(), out int proposition))
    {
        Console.WriteLine("  Saisie invalide, réessayez.");
        continue; // passe directement à l'itération suivante
    }

    tentatives++;

    if (proposition == nombreSecret)
    {
        Console.WriteLine($"  Bravo ! Trouvé en {tentatives} tentative(s) !");
        trouve = true;
    }
    else
    {
        string indice = proposition < nombreSecret ? "trop petit" : "trop grand";
        Console.WriteLine($"  Raté — {indice}. Essayez encore.");

        if (tentatives >= 5)
        {
            Console.WriteLine($"  Vous avez épuisé vos 5 tentatives. C'était le {nombreSecret}.");
            break; // sortie forcée de la boucle
        }
    }
}

Console.WriteLine();

// ============================================================
// 3. Boucle do/while — condition testée APRÈS chaque itération
// ============================================================
Console.WriteLine("=== 3. Calculatrice répétable (do/while) ===");
bool continuer;
do
{
    Console.Write("Entrez deux entiers séparés par un espace : ");
    string[] parties = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

    if (parties.Length == 2
        && int.TryParse(parties[0], out int a)
        && int.TryParse(parties[1], out int b))
    {
        Console.WriteLine($"  {a} + {b} = {a + b}");
        Console.WriteLine($"  {a} - {b} = {a - b}");
        Console.WriteLine($"  {a} × {b} = {a * b}");
        if (b != 0) Console.WriteLine($"  {a} ÷ {b} = {(double)a / b:F4}");
    }
    else
    {
        Console.WriteLine("  Saisie invalide. Entrez deux entiers séparés par un espace.");
    }

    Console.Write("Continuer ? (O pour oui) : ");
    continuer = Console.ReadKey().Key == ConsoleKey.O;
    Console.WriteLine("\n");
} while (continuer);

// ============================================================
// 4. Boucles imbriquées — table de multiplication
// ============================================================
Console.WriteLine("=== 4. Table de multiplication 1-5 × 1-10 ===");
Console.Write("     ");
for (int j = 1; j <= 10; j++) Console.Write($"{j,4}");
Console.WriteLine();
Console.WriteLine(new string('-', 45));

for (int i = 1; i <= 5; i++)
{
    Console.Write($"{i,4} |");
    for (int j = 1; j <= 10; j++)
    {
        Console.Write($"{i * j,4}");
    }
    Console.WriteLine();
}
