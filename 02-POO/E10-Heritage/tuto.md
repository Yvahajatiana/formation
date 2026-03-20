# Épisode 10 — Héritage

## Objectifs pédagogiques

- Créer une hiérarchie de classes avec `:`
- Comprendre `virtual` et `override`
- Appeler le constructeur parent avec `base()`
- Utiliser `is` et `as` pour identifier le type réel d'un objet

## Concepts clés

### Syntaxe de l'héritage

```csharp
public class Animal { }         // classe de base
public class Chien : Animal { } // Chien hérite de Animal
```

Un `Chien` **est un** `Animal` — il hérite de toutes ses propriétés et méthodes publiques/protégées.

### virtual et override

```csharp
public class Animal
{
    public virtual string Crier() => "..."; // peut être redéfini
}

public class Chien : Animal
{
    public override string Crier() => "Woof !"; // redéfinit le comportement
}
```

Sans `virtual`, la méthode ne peut pas être redéfinie dans les dérivées.

### Constructeur et base()

```csharp
public class Chien : Animal
{
    public string Race { get; }

    public Chien(string nom, string race, int age)
        : base(nom, "Chien", age) // appelle le constructeur d'Animal
    {
        Race = race;
    }
}
```

### protected — accessible aux dérivées

```csharp
public class Animal
{
    protected int AgeEnMois { get; } // accessible dans Chien, Chat, etc.
}
```

### Pattern matching : is

```csharp
Animal animal = new Chien("Rex", "Berger", 24);

if (animal is Chien chien) // vérifie le type ET caste en même temps
{
    Console.WriteLine(chien.Race); // accès aux membres spécifiques à Chien
}
```

## Points d'attention (erreurs fréquentes)

- Oublier `virtual` sur la méthode parent → le `override` sera une simple **cache** (shadowing), pas un vrai override
- Utiliser `new` au lieu d'`override` — le comportement polymorphique est perdu
- Hiérarchies trop profondes (> 3 niveaux) → difficiles à maintenir, préférer la composition
- Ne pas appeler `base()` quand le constructeur parent fait un travail d'initialisation important

## Pour aller plus loin

- [Héritage — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Polymorphisme — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- Épisode suivant : **E11 — Polymorphisme**
