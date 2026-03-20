// Concepts : tableaux (array), List<T>, Dictionary<K,V>, LINQ de base
// .NET 8 — Top-level statements

// ============================================================
// 1. Tableaux — taille fixe, accès par index
// ============================================================
Console.WriteLine("=== 1. Tableaux ===");

// Syntaxe collection expression .NET 8
int[] temperatures = [12, 18, 22, 25, 19, 15, 10];
string[] jours = ["Lun", "Mar", "Mer", "Jeu", "Ven", "Sam", "Dim"];

for (int i = 0; i < temperatures.Length; i++)
{
    string tendance = i == 0 ? "  " :
                     temperatures[i] > temperatures[i - 1] ? "↑" : "↓";
    Console.WriteLine($"  {jours[i]} : {temperatures[i],3}°C {tendance}");
}

int tempMax = temperatures.Max();
int tempMin = temperatures.Min();
Console.WriteLine($"\n  Max : {tempMax}°C  |  Min : {tempMin}°C  |  Moy : {temperatures.Average():F1}°C");

// ============================================================
// 2. List<T> — taille dynamique
// ============================================================
Console.WriteLine("\n=== 2. Liste dynamique ===");

List<string> courses = ["Pommes", "Pain", "Lait", "Fromage"];
courses.Add("Oeufs");
courses.Remove("Pain");

Console.WriteLine("Liste de courses :");
foreach (string article in courses)
{
    Console.WriteLine($"  ✓ {article}");
}

Console.WriteLine($"\n  Nombre d'articles : {courses.Count}");
Console.WriteLine($"  Contient 'Lait' : {courses.Contains("Lait")}");

// Trier une liste
courses.Sort();
Console.WriteLine($"\n  Triée : {string.Join(", ", courses)}");

// ============================================================
// 3. Dictionary<K, V> — association clé/valeur
// ============================================================
Console.WriteLine("\n=== 3. Dictionnaire ===");

Dictionary<string, decimal> prix = new()
{
    ["Pomme"] = 2.50m,
    ["Banane"] = 1.80m,
    ["Cerise"] = 5.99m,
    ["Poire"] = 3.20m
};

prix["Mangue"] = 4.50m; // ajout d'une nouvelle entrée

foreach (var (fruit, tarif) in prix)
{
    Console.WriteLine($"  {fruit,-10} : {tarif:C2}");
}

if (prix.TryGetValue("Banane", out decimal prixBanane))
{
    Console.WriteLine($"\n  Le prix de la banane est {prixBanane:C2}");
}

// ============================================================
// 4. LINQ — requêtes sur collections
// ============================================================
Console.WriteLine("\n=== 4. LINQ ===");

List<int> nombres = [3, 7, 2, 9, 4, 11, 6, 8, 1, 5, 12, 15];

var nombresPairs = nombres.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
var nombresPlusDeHuit = nombres.Where(n => n > 8).ToList();
double moyenne = nombres.Average();

Console.WriteLine($"  Nombres pairs triés    : {string.Join(", ", nombresPairs)}");
Console.WriteLine($"  Nombres > 8            : {string.Join(", ", nombresPlusDeHuit)}");
Console.WriteLine($"  Moyenne                : {moyenne:F2}");
Console.WriteLine($"  Somme                  : {nombres.Sum()}");
Console.WriteLine($"  Premier pair > 5       : {nombres.First(n => n % 2 == 0 && n > 5)}");
