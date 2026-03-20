// Concepts : types primitifs, déclaration et initialisation de variables, interpolation de chaînes
// .NET 8 — Top-level statements

// --- Types entiers ---
int age = 25;
long population = 8_100_000_000L; // séparateurs numériques pour la lisibilité

// --- Types décimaux ---
decimal prix = 19.99m;
double pi = 3.141_592_653_589;
float temperature = 36.6f;

// --- Type booléen ---
bool estMajeur = age >= 18;

// --- Chaînes de caractères ---
string prenom = "Marie";
string nom = "Dupont";
string nomComplet = $"{prenom} {nom}"; // interpolation de chaîne (C# 6+)

// --- Constantes (valeur non modifiable) ---
const decimal TauxTva = 0.20m;
decimal prixTtc = prix * (1 + TauxTva);

// --- Inférence de type avec var ---
var message = "Bonjour"; // le compilateur déduit string
var annee = 2026;        // le compilateur déduit int

// --- Affichage ---
Console.WriteLine("=== Informations personnelles ===");
Console.WriteLine($"Nom complet   : {nomComplet}");
Console.WriteLine($"Âge           : {age} ans");
Console.WriteLine($"Majeur        : {estMajeur}");

Console.WriteLine("\n=== Calculs ===");
Console.WriteLine($"Prix HT       : {prix:C2}");
Console.WriteLine($"TVA ({TauxTva:P0})  : {prix * TauxTva:C2}");
Console.WriteLine($"Prix TTC      : {prixTtc:C2}");

Console.WriteLine("\n=== Données diverses ===");
Console.WriteLine($"Population mondiale : {population:N0} habitants");
Console.WriteLine($"Pi (approx.)        : {pi:F6}");
Console.WriteLine($"Température         : {temperature:F1}°C");
Console.WriteLine($"Message             : {message}, {annee}");
