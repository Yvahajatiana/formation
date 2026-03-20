# Épisode 03 — Conditionnelles

## Objectifs pédagogiques

- Contrôler le flux d'exécution avec `if`, `else if`, `else`
- Utiliser l'opérateur ternaire pour les cas binaires simples
- Maîtriser le `switch expression` moderne de C# 8+
- Combiner conditions avec `&&` et `||`

## Concepts clés

### if / else if / else

Structure de base pour les décisions :

```csharp
if (condition1)
{
    // exécuté si condition1 est vraie
}
else if (condition2)
{
    // exécuté si condition2 est vraie
}
else
{
    // exécuté dans tous les autres cas
}
```

**Règle :** les conditions sont évaluées dans l'ordre ; dès qu'une est vraie, les suivantes sont ignorées.

### Opérateur ternaire

Pour les cas simples à deux branches :

```csharp
// Syntaxe : condition ? valeur_si_vrai : valeur_si_faux
string statut = age >= 18 ? "Majeur" : "Mineur";
```

À utiliser uniquement quand les deux alternatives sont courtes et lisibles. Pour tout autre cas, préférez `if/else`.

### switch expression (C# 8+)

Plus concis et expressif que le `switch` classique pour retourner une valeur :

```csharp
string mention = note switch
{
    >= 16 => "Très bien",
    >= 14 => "Bien",
    >= 12 => "Assez bien",
    >= 10 => "Passable",
    _     => "Insuffisant"  // _ est le cas par défaut
};
```

Les bras sont évalués dans l'ordre ; le `_` correspond à "toute autre valeur".

### Opérateurs logiques

| Opérateur | Signification | Court-circuit |
|-----------|---------------|---------------|
| `&&` | ET logique | Oui (si gauche = false, droite ignorée) |
| `\|\|` | OU logique | Oui (si gauche = true, droite ignorée) |
| `!` | NON logique | — |

## Points d'attention (erreurs fréquentes)

- Imbriquer trop de `if/else` : préférez le `switch expression` ou la technique des *early return*
- Comparer des `string` avec `==` : fonctionne en C# (contrairement à Java) grâce à la surcharge d'opérateur
- Confondre `&&` et `&` : `&` évalue toujours les deux opérandes (pas de court-circuit)
- Oublier le `break` dans un `switch` classique

## Pour aller plus loin

- [switch expression — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/switch-expression)
- [Opérateurs de comparaison — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/comparison-operators)
- Épisode suivant : **E04 — switch statement et pattern matching**
