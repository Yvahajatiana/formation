# Épisode 16 — LSP : Liskov Substitution Principle

## Objectifs pédagogiques

- Comprendre ce que "substituable" signifie concrètement
- Identifier les violations de LSP (exceptions dans les overrides, préconditions renforcées)
- Concevoir une hiérarchie qui respecte LSP
- Utiliser la composition quand l'héritage violerait LSP

## Le principe

> "Si S est un sous-type de T, alors tout objet de type T peut être remplacé par un objet de type S sans altérer la correction du programme." — Barbara Liskov

En pratique : une sous-classe doit **honorer le contrat** de sa classe parent.

## Violation classique

```csharp
// ❌ Pingouin hérite d'OiseauVolant mais ne peut pas voler
public class Pingouin : OiseauVolant
{
    public override string Voler()
        => throw new NotSupportedException(); // VIOLATION
}

// Le code appelant est obligé de tester le type → signe d'une violation LSP
foreach (OiseauVolant oiseau in flotte)
{
    if (oiseau is not Pingouin) // test défensif = code fragile
        oiseau.Voler();
}
```

## Solution

Restructurer la hiérarchie pour que chaque sous-type respecte le contrat :

```
Oiseau (abstrait)
├── OiseauVolant (abstrait) → Aigle, Moineau, Perroquet
└── Pingouin                → nage, marche, mais ne vole pas
```

## Règles LSP concrètes

1. **Préconditions** : une sous-classe ne peut pas exiger plus que la classe parent
2. **Postconditions** : une sous-classe doit garantir au moins ce que la classe parent garantit
3. **Exceptions** : une sous-classe ne peut pas lever de nouvelles exceptions non prévues par le parent

## Pour aller plus loin

- Épisode suivant : **E17 — ISP : Interface Segregation Principle**
