# Épisode 15 — OCP : Open/Closed Principle

## Objectifs pédagogiques

- Comprendre pourquoi modifier du code existant est risqué
- Concevoir des abstractions extensibles sans modification
- Appliquer OCP via les interfaces et l'injection de stratégies
- Voir le lien entre OCP et le Strategy pattern

## Le principe

> "Les entités logicielles (classes, modules, fonctions) doivent être ouvertes à l'extension mais fermées à la modification." — Bertrand Meyer

**Ouvert à l'extension** : on peut ajouter de nouveaux comportements.
**Fermé à la modification** : sans changer le code existant qui fonctionne.

## Contre-exemple

```csharp
// ❌ Chaque nouveau type de remise nécessite de modifier cette méthode
public decimal CalculerRemise(string type, decimal prix) => type switch
{
    "standard" => 0m,
    "fidele"   => prix * 0.10m,
    "vip"      => prix * 0.25m,
    // Pour ajouter "saisonnier", on MODIFIE ce code → risque de régression
    _ => throw new ArgumentException("Type inconnu")
};
```

## Solution OCP

```csharp
// ✅ Interface fermée — ne change jamais
public interface ICalculateurRemise
{
    decimal CalculerRemise(decimal prix);
}

// ✅ Extension par nouvelle classe — zéro modification du code existant
public class RemiseSaisonniere : ICalculateurRemise
{
    public decimal CalculerRemise(decimal prix) => prix * 0.30m;
}
```

## Lien avec le Strategy Pattern

OCP s'implémente souvent via le Strategy Pattern : on injecte le comportement variable (la stratégie de remise) plutôt que de le coder en dur.

## Points d'attention

- OCP n'est pas "ne jamais modifier du code" — parfois corriger un bug nécessite une modification. OCP vise les **extensions** de fonctionnalités.
- Appliquer OCP dès le départ sur tout serait sur-ingénierie. Appliquez-le quand vous voyez un point d'extension récurrent.

## Pour aller plus loin

- Épisode suivant : **E16 — LSP : Liskov Substitution Principle**
