# Épisode 11 — Polymorphisme

## Objectifs pédagogiques

- Comprendre le polymorphisme par sous-typage
- Distinguer classe abstraite et classe concrète
- Maîtriser `abstract` pour forcer l'implémentation dans les sous-classes
- Exploiter le dispatch dynamique pour un code générique

## Concepts clés

### Polymorphisme

Le polymorphisme permet de traiter des objets de types différents **de façon uniforme** via une référence de base :

```csharp
List<Forme> formes = [new Cercle("C1", 5), new Rectangle("R1", 3, 4)];

foreach (Forme f in formes)
{
    // C# appelle le bon CalculerSurface() selon le type réel — pas le type déclaré
    Console.WriteLine(f.CalculerSurface());
}
```

### Classe abstraite

Une classe `abstract` ne peut pas être instanciée directement. Elle définit un contrat que les sous-classes **doivent** implémenter :

```csharp
public abstract class Forme
{
    public abstract double CalculerSurface();   // pas d'implémentation ici
    public abstract double CalculerPerimetre();

    public virtual void Afficher()              // implémentation par défaut (overrideable)
    {
        Console.WriteLine($"Surface : {CalculerSurface():F2}");
    }
}
```

### abstract vs virtual

| | `abstract` | `virtual` |
|---|---|---|
| Implémentation dans la base | Non | Oui |
| Override dans les dérivées | Obligatoire | Facultatif |
| Classe doit être `abstract` | Oui | Non |

### OfType<T>() — filtrage par type

```csharp
List<Forme> formes = [...];
IEnumerable<Cercle> cercles = formes.OfType<Cercle>(); // ne garde que les Cercle
```

## Points d'attention (erreurs fréquentes)

- Instancier une classe abstraite → erreur de compilation
- Oublier d'implémenter une méthode abstraite dans une sous-classe → erreur de compilation
- Caster avec `(Cercle)forme` sans vérification préalable → `InvalidCastException` si le type est incorrect ; préférer `is` ou `OfType<T>()`

## Pour aller plus loin

- [Polymorphisme — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- [Classes et membres abstraits — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
- Épisode suivant : **E12 — Abstraction et interfaces**
