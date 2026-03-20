# Épisode 01 — Variables et types primitifs

## Objectifs pédagogiques

- Comprendre ce qu'est une variable et comment la déclarer en C#
- Connaître les types primitifs les plus courants
- Savoir utiliser l'interpolation de chaînes
- Distinguer variable et constante

## Concepts clés

### Déclaration de variable

Une variable est un espace mémoire nommé qui stocke une valeur. En C#, on déclare une variable en indiquant son **type** puis son **nom** :

```csharp
int age = 25;
string prenom = "Marie";
bool estActif = true;
```

### Les types numériques

| Type | Taille | Plage | Usage typique |
|------|--------|-------|---------------|
| `int` | 32 bits | -2,1 milliards à +2,1 milliards | Compteurs, indices |
| `long` | 64 bits | ±9,2 × 10¹⁸ | Très grands entiers |
| `double` | 64 bits | ±5 × 10⁻³²⁴ à ±1,7 × 10³⁰⁸ | Calculs scientifiques |
| `decimal` | 128 bits | 28-29 chiffres significatifs | Calculs financiers |
| `float` | 32 bits | ±1,5 × 10⁻⁴⁵ à ±3,4 × 10³⁸ | Graphisme 3D |

> **Règle d'or :** Utilisez `decimal` pour tout ce qui touche à l'argent. Jamais `double` pour des prix.

### Interpolation de chaînes

Plutôt que de concaténer avec `+` ou d'utiliser `string.Format`, C# 6+ propose l'interpolation :

```csharp
string nom = "Dupont";
int age = 25;

// À éviter
string msg1 = "Bonjour " + nom + ", vous avez " + age + " ans.";

// Recommandé
string msg2 = $"Bonjour {nom}, vous avez {age} ans.";

// Avec format numérique
decimal prix = 19.99m;
Console.WriteLine($"Prix : {prix:C2}");  // affiche : Prix : 19,99 €
```

### Constantes

Une constante est une valeur connue à la compilation qui ne changera jamais :

```csharp
const decimal TauxTva = 0.20m;
const int JoursParSemaine = 7;
```

### Inférence de type avec `var`

Le mot-clé `var` délègue au compilateur le soin de déduire le type :

```csharp
var nom = "Marie";   // string
var count = 42;      // int
var ratio = 3.14;    // double
```

`var` ne produit **pas** un type dynamique — le type est fixé à la compilation. Utilisez-le quand le type est évident, évitez-le sinon.

### Séparateurs numériques

C# 7+ permet d'insérer des `_` dans les littéraux numériques pour la lisibilité :

```csharp
long population = 8_100_000_000L;
double vitesseLumiere = 299_792_458.0;
```

## Points d'attention (erreurs fréquentes)

- Oublier le suffixe `m` pour les littéraux `decimal` (`19.99` est un `double`, `19.99m` est un `decimal`)
- Confondre `=` (affectation) et `==` (comparaison)
- Utiliser `double` pour des calculs financiers → pertes de précision garanties
- Déclarer une variable sans l'initialiser avant usage (le compilateur le signale)

## Pour aller plus loin

- [Types valeur C# — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/builtin-types/value-types)
- [Interpolation de chaînes — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/tokens/interpolated)
- Épisode suivant : **E02 — Saisie utilisateur et conversion de type**
