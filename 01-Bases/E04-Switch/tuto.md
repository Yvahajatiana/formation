# Épisode 04 — switch statement et pattern matching

## Objectifs pédagogiques

- Maîtriser le `switch` classique avec `case`, `break`, `default`
- Regrouper plusieurs cas avec `case X: case Y:`
- Comprendre la différence entre `switch statement` et `switch expression`
- Découvrir le pattern matching de base

## Concepts clés

### switch statement

Le `switch` évalue une expression et saute au `case` correspondant :

```csharp
switch (valeur)
{
    case 1:
        // code pour valeur == 1
        break;
    case 2:
    case 3:
        // code pour valeur == 2 OU 3 (regroupement)
        break;
    default:
        // si aucun case ne correspond
        break;
}
```

**Le `break` est obligatoire** à la fin de chaque case (contrairement à C/C++, C# ne tolère pas le fall-through implicite).

### switch expression vs switch statement

| | switch statement | switch expression |
|---|---|---|
| Syntaxe | `switch (x) { case 1: ... }` | `x switch { 1 => ... }` |
| Retourne une valeur | Non | Oui |
| `break` requis | Oui | Non |
| Usage | Actions à exécuter | Valeur à calculer |

### Pattern avec `or` (C# 9+)

```csharp
// switch expression avec pattern or
string type = code switch
{
    1 or 2 or 3 => "Faible",
    4 or 5      => "Moyen",
    _           => "Élevé"
};
```

## Points d'attention (erreurs fréquentes)

- Oublier le `break` → erreur de compilation en C# (pas d'erreur silencieuse)
- Tenter un `switch` sur un type non supporté (avant C# 7, seuls les types scalaires étaient supportés)
- Écrire du code inaccessible après un `return` dans un `case`
- Confondre `switch statement` (actions) et `switch expression` (valeur)

## Pour aller plus loin

- [switch statement — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)
- [Pattern matching — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/pattern-matching)
- Épisode suivant : **E05 — Boucles for, while, do/while, foreach**
