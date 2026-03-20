# Épisode 07 — Méthodes et fonctions

## Objectifs pédagogiques

- Déclarer et appeler des méthodes statiques
- Comprendre les paramètres, valeurs de retour et `void`
- Utiliser la surcharge de méthode
- Simplifier le code avec les expression-bodied members
- Utiliser les paramètres optionnels et nommés

## Concepts clés

### Anatomie d'une méthode

```csharp
static int Additionner(int a, int b)  // signature
{
    return a + b;                      // corps
}
```

- `static` : méthode de classe (pas d'instance requise)
- `int` : type de retour (`void` si pas de retour)
- `Additionner` : nom (PascalCase par convention)
- `int a, int b` : paramètres

### Expression-bodied members (C# 6+)

Pour les méthodes dont le corps tient en une expression :

```csharp
// Équivalents :
static int Carre(int n) { return n * n; }
static int Carre(int n) => n * n;        // expression-bodied
```

### Surcharge (overloading)

Plusieurs méthodes avec le même nom mais des **signatures différentes** :

```csharp
static int Additionner(int a, int b) => a + b;
static double Additionner(double a, double b) => a + b;
static int Additionner(int a, int b, int c) => a + b + c;
```

Le compilateur choisit automatiquement la bonne surcharge selon les arguments.

### Paramètres optionnels et nommés

```csharp
static void Afficher(string nom, int age = 0, string ville = "Inconnue")
{
    Console.WriteLine($"{nom}, {age} ans, {ville}");
}

// Appels valides :
Afficher("Alice");                        // age=0, ville="Inconnue"
Afficher("Bob", 25);                      // ville="Inconnue"
Afficher(nom: "Charlie", ville: "Lyon");  // paramètres nommés (ordre libre)
```

### Valeur de retour vs void

```csharp
// Retourne une valeur — utilisable dans une expression
static int Carre(int n) => n * n;
int resultat = Carre(5); // resultat = 25

// void — exécute une action, ne retourne rien
static void Afficher(string message) => Console.WriteLine(message);
```

## Points d'attention (erreurs fréquentes)

- Oublier `return` dans une méthode non-void (erreur de compilation)
- Surcharger par type de retour seulement → impossible, C# n'utilise pas le type de retour pour distinguer les surcharges
- Paramètres optionnels : les paramètres sans valeur par défaut doivent venir en **premier**
- Ne pas confondre *paramètre* (dans la déclaration) et *argument* (lors de l'appel)

## Pour aller plus loin

- [Méthodes — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/methods)
- [Membres expression-bodied — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)
- Épisode suivant : **E08 — Introduction aux classes et objets (POO)**
