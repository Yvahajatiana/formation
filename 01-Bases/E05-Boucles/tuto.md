# Épisode 05 — Boucles

## Objectifs pédagogiques

- Choisir la bonne boucle selon la situation
- Maîtriser `for`, `while`, `do/while` et `foreach`
- Utiliser `break` et `continue` pour contrôler le flux
- Comprendre les boucles imbriquées

## Concepts clés

### for — itérations comptées

```csharp
for (initialisation; condition; incrément)
{
    // corps
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

Utilisez `for` quand vous connaissez **à l'avance** le nombre d'itérations.

### while — condition avant

```csharp
while (condition)
{
    // exécuté tant que condition est vraie
}
```

Utilisez `while` quand le nombre d'itérations est inconnu et que la boucle peut ne jamais s'exécuter.

### do/while — condition après

```csharp
do
{
    // exécuté au moins une fois
} while (condition);
```

Utilisez `do/while` quand le corps doit s'exécuter **au moins une fois** (menu, validation de saisie).

### foreach — itération sur une collection

```csharp
string[] fruits = ["Pomme", "Banane", "Cerise"];
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

### break et continue

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 3) continue; // passe à l'itération suivante (saute i=3)
    if (i == 7) break;    // sort de la boucle (arrête à i=7)
    Console.WriteLine(i); // affiche 0,1,2,4,5,6
}
```

## Points d'attention (erreurs fréquentes)

- Boucle infinie : oublier d'incrémenter la variable de contrôle dans `while`
- Off-by-one : `i < 10` itère de 0 à 9 (10 fois) ; `i <= 10` itère de 0 à 10 (11 fois)
- Modifier une collection pendant un `foreach` → `InvalidOperationException`
- Préférer `foreach` à `for` quand on n'a pas besoin de l'index

## Pour aller plus loin

- [Instructions d'itération — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/statements/iteration-statements)
- Épisode suivant : **E06 — Tableaux et listes**
