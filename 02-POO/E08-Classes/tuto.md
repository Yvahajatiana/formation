# Épisode 08 — Classes et Objets

## Objectifs pédagogiques

- Comprendre la différence entre classe (plan) et objet (instance)
- Déclarer des propriétés, des méthodes et des constructeurs
- Utiliser des membres statiques vs membres d'instance
- Manipuler des collections d'objets avec LINQ

## Concepts clés

### Classe vs Objet

Une **classe** est le plan de construction ; un **objet** (ou instance) est le résultat concret :

```csharp
// Définition de la classe (le plan)
public class Personne
{
    public string Nom { get; }
    public int Age { get; }
    public Personne(string nom, int age) { Nom = nom; Age = age; }
}

// Instanciation (création d'objets)
var alice = new Personne("Alice", 28); // objet 1
var bob = new Personne("Bob", 17);     // objet 2
```

### Propriétés

Préférer les propriétés aux champs publics :

```csharp
public string Nom { get; }              // lecture seule (set uniquement dans le constructeur)
public int Age { get; private set; }    // modifiable seulement depuis la classe
public string Email { get; set; }       // lecture/écriture publique
public bool EstMajeur => Age >= 18;     // calculée (expression-bodied)
```

### Constructeur

Le constructeur initialise l'objet et valide les données d'entrée :

```csharp
public Personne(string nom, int age)
{
    if (string.IsNullOrWhiteSpace(nom))
        throw new ArgumentException("Le nom est obligatoire.");
    Nom = nom;
    Age = age;
}
```

### Membres statiques

Un membre `static` appartient à la **classe**, pas aux instances :

```csharp
public class Vehicule
{
    private static int _compteur = 0;
    public static int Compteur => _compteur;

    public Vehicule() { _compteur++; } // chaque nouvelle instance incrémente
}

Console.WriteLine(Vehicule.Compteur); // accès via la classe, pas via un objet
```

### ToString()

Surchargez toujours `ToString()` pour un affichage lisible en débogage :

```csharp
public override string ToString() => $"Personne[{Nom}, {Age} ans]";
```

## Points d'attention (erreurs fréquentes)

- Exposer des champs publics au lieu de propriétés — perte de contrôle sur les modifications
- Ne pas valider les paramètres du constructeur — état incohérent possible
- Confondre membre statique (classe) et membre d'instance (objet)
- Oublier de surcharger `ToString()` → affichage inutile du nom complet de type

## Pour aller plus loin

- [Classes — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/types/classes)
- [Propriétés — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/properties)
- Épisode suivant : **E09 — Encapsulation**
