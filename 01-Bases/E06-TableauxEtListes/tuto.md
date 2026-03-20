# Épisode 06 — Tableaux, listes et dictionnaires

## Objectifs pédagogiques

- Déclarer et utiliser un tableau de taille fixe
- Utiliser `List<T>` pour une collection dynamique
- Stocker des paires clé/valeur avec `Dictionary<K, V>`
- Effectuer des requêtes simples avec LINQ

## Concepts clés

### Tableaux

```csharp
// Déclaration avec taille fixe
int[] notes = new int[5];
notes[0] = 15;

// Initialisation directe (collection expression .NET 8)
string[] jours = ["Lundi", "Mardi", "Mercredi"];

// Propriétés utiles
Console.WriteLine(jours.Length); // 3
```

Un tableau a une taille **fixe** définie à la création. Il ne peut ni grandir ni rétrécir.

### List<T>

```csharp
List<string> noms = ["Alice", "Bob"];
noms.Add("Charlie");      // ajout en fin
noms.Insert(0, "Zoé");   // ajout à l'index 0
noms.Remove("Bob");       // suppression par valeur
noms.RemoveAt(1);         // suppression par index
bool existe = noms.Contains("Alice"); // true
int nb = noms.Count;      // nombre d'éléments
```

`List<T>` est la collection la plus utilisée en C#. Préférez-la aux tableaux sauf contrainte de performance.

### Dictionary<TKey, TValue>

```csharp
Dictionary<string, int> ages = new()
{
    ["Alice"] = 30,
    ["Bob"] = 25
};

ages["Charlie"] = 28; // ajout ou mise à jour

// Lecture sécurisée
if (ages.TryGetValue("Alice", out int age))
    Console.WriteLine(age); // 30
```

### LINQ — Language Integrated Query

```csharp
List<int> nombres = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

var pairs = nombres.Where(n => n % 2 == 0);        // filtre
var triés = nombres.OrderByDescending(n => n);      // tri décroissant
var transformés = nombres.Select(n => n * n);       // transformation
int somme = nombres.Sum();                           // agrégation
double moy = nombres.Average();
```

## Points d'attention (erreurs fréquentes)

- `IndexOutOfRangeException` : accès à un index hors des limites du tableau
- Modifier une liste pendant un `foreach` → `InvalidOperationException`
- Lire une clé inexistante dans un dictionnaire avec `dict[cle]` → `KeyNotFoundException` ; utilisez `TryGetValue`
- Oublier `.ToList()` après une requête LINQ (l'exécution est différée)

## Pour aller plus loin

- [Collections en C# — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/collections)
- [LINQ — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/)
- Épisode suivant : **E07 — Méthodes et fonctions**
