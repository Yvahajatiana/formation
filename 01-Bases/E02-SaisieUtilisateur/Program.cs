// Concepts : saisie clavier, conversion de type, TryParse, validation d'entrée
// .NET 8 — Top-level statements

Console.WriteLine("=== Formulaire d'inscription ===\n");

// --- Saisie d'une chaîne ---
Console.Write("Entrez votre prénom : ");
string prenom = Console.ReadLine() ?? string.Empty;

if (string.IsNullOrWhiteSpace(prenom))
{
    Console.WriteLine("Le prénom est obligatoire. Arrêt du programme.");
    return;
}

// --- Saisie et conversion d'un entier avec TryParse ---
Console.Write("Entrez votre âge : ");
string saisieAge = Console.ReadLine() ?? string.Empty;

if (!int.TryParse(saisieAge, out int age))
{
    Console.WriteLine("L'âge doit être un nombre entier. Arrêt du programme.");
    return;
}

if (age < 0 || age > 150)
{
    Console.WriteLine($"L'âge {age} n'est pas réaliste. Arrêt du programme.");
    return;
}

// --- Saisie et conversion d'un décimal ---
Console.Write("Entrez votre taille en mètres (ex: 1.75) : ");
string saisieTaille = Console.ReadLine() ?? string.Empty;

if (!decimal.TryParse(saisieTaille, System.Globalization.NumberStyles.Any,
    System.Globalization.CultureInfo.InvariantCulture, out decimal taille))
{
    Console.WriteLine("La taille doit être un nombre décimal (utilisez le point). Arrêt du programme.");
    return;
}

// --- Calcul et affichage ---
string categorie = age switch
{
    < 12       => "Enfant",
    < 18       => "Adolescent",
    < 65       => "Adulte",
    _          => "Senior"
};

Console.WriteLine("\n=== Récapitulatif ===");
Console.WriteLine($"Prénom    : {prenom}");
Console.WriteLine($"Âge       : {age} an(s) — {categorie}");
Console.WriteLine($"Taille    : {taille:F2} m");
Console.WriteLine($"IMC (sans poids, illustration) : taille² = {taille * taille:F4} m²");
