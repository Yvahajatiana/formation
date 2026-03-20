# Épisode 12 — Abstraction

## Objectifs pédagogiques

- Comprendre l'abstraction comme mécanisme de simplification
- Distinguer classe abstraite et interface
- Utiliser le *Template Method* pattern implicitement
- Forcer un contrat tout en partageant du code commun

## Concepts clés

### Pourquoi l'abstraction ?

L'abstraction permet de **masquer la complexité** et de ne montrer que l'essentiel. Une classe abstraite dit : « Tout employé a un salaire, mais comment le calculer dépend de chaque type d'employé. »

### Classe abstraite vs Interface

| | Classe abstraite | Interface |
|---|---|---|
| Peut contenir du code | ✅ Oui | ✅ (depuis C# 8 — default implementations) |
| Peut avoir des champs | ✅ Oui | ❌ Non |
| Héritage | Simple uniquement | Multiple possible |
| Instanciable directement | ❌ Non | ❌ Non |
| Quand l'utiliser | Hiérarchie + code partagé | Contrat pur, découplage |

### Template Method (pattern implicite)

La méthode `AfficherFichePaie()` dans `Employe` définit l'**algorithme général** (calculer, afficher en-tête, cotisations, net) mais délègue à `CalculerSalaire()` le détail :

```csharp
public virtual void AfficherFichePaie()
{
    decimal salaire = CalculerSalaire(); // appel polymorphique
    // ... affichage commun
}
```

C'est le *Template Method* : la structure est fixée dans la base, les détails varient dans les dérivées.

## Points d'attention (erreurs fréquentes)

- Tout mettre dans des classes abstraites alors qu'une interface suffirait → couplage inutile
- Ajouter des méthodes abstraites dans une classe abstraite déjà utilisée sans fournir d'implémentation par défaut → toutes les classes dérivées cassent (breaking change)

## Pour aller plus loin

- [Classes abstraites — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
- Épisode suivant : **E13 — Interfaces**
