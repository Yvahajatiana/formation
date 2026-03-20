# Épisode 02 — Saisie utilisateur et conversion de type

## Objectifs pédagogiques

- Lire une saisie clavier avec `Console.ReadLine()`
- Convertir une chaîne en type numérique avec `TryParse`
- Valider les entrées utilisateur et fournir un retour clair
- Gérer le cas `null` avec l'opérateur `??`

## Concepts clés

### Console.ReadLine()

`Console.ReadLine()` retourne une `string?` (nullable string en .NET 6+). L'opérateur `??` permet de fournir une valeur par défaut si le résultat est `null` :

```csharp
string saisie = Console.ReadLine() ?? string.Empty;
```

### TryParse — la conversion sûre

N'utilisez **jamais** `int.Parse()` directement sur une saisie utilisateur : si l'entrée n'est pas un nombre, vous obtenez une exception. Utilisez `TryParse` :

```csharp
// Retourne true si la conversion réussit, false sinon
// La valeur convertie est placée dans la variable 'age' via le paramètre out
if (int.TryParse(saisieAge, out int age))
{
    Console.WriteLine($"Âge valide : {age}");
}
else
{
    Console.WriteLine("Entrée invalide.");
}
```

Le mot-clé `out` signifie que la méthode va écrire dans cette variable (déclarée inline ici, syntaxe C# 7+).

### Validation des entrées

Toujours valider l'entrée avant de l'utiliser :

1. **Format correct ?** — `TryParse` retourne `false`
2. **Valeur dans la plage acceptable ?** — vérification métier
3. **Chaîne non vide ?** — `string.IsNullOrWhiteSpace()`

### Gestion des décimaux culturels

Le séparateur décimal varie selon les cultures : `.` en anglais, `,` en français. Pour une saisie portable, spécifier la culture :

```csharp
decimal.TryParse(saisie, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valeur)
```

## Points d'attention (erreurs fréquentes)

- Utiliser `int.Parse()` sans try/catch sur une entrée utilisateur
- Oublier de tester le retour de `TryParse` (`bool`)
- Ne pas gérer le cas où `Console.ReadLine()` retourne `null`
- Comparer une chaîne à `""` plutôt qu'utiliser `string.IsNullOrWhiteSpace()`

## Pour aller plus loin

- [TryParse — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/api/system.int32.tryparse)
- [CultureInfo — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/api/system.globalization.cultureinfo)
- Épisode suivant : **E03 — Conditionnelles if/else et switch expression**
