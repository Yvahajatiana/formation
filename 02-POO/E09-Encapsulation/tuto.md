# Épisode 09 — Encapsulation

## Objectifs pédagogiques

- Comprendre pourquoi cacher l'état interne d'un objet
- Maîtriser les modificateurs d'accès : `public`, `private`, `protected`, `internal`
- Contrôler les modifications via des propriétés et des méthodes
- Garantir la cohérence de l'état d'un objet à tout moment

## Concepts clés

### Principe

L'encapsulation consiste à **cacher les détails internes** d'une classe et à n'exposer que ce qui est nécessaire. L'objet contrôle son propre état ; personne ne peut le corrompre de l'extérieur.

```csharp
// MAUVAIS — champ public modifiable librement
public class Compte { public decimal Solde; }
var c = new Compte();
c.Solde = -999999m; // n'importe qui peut mettre un solde négatif !

// BON — encapsulé
public class Compte
{
    private decimal _solde;
    public decimal Solde => _solde; // lecture seule de l'extérieur

    public void Deposer(decimal montant)
    {
        if (montant <= 0) throw new ArgumentException("Montant invalide.");
        _solde += montant; // modification contrôlée
    }
}
```

### Modificateurs d'accès

| Modificateur | Accessible depuis |
|---|---|
| `public` | Partout |
| `private` | Seulement dans la classe |
| `protected` | Classe et classes dérivées |
| `internal` | Même assembly |
| `private protected` | Classe + dérivées du même assembly |

### Propriétés vs champs

```csharp
// Propriété en lecture seule
public decimal Solde => _solde;

// Propriété avec setter privé
public int Age { get; private set; }

// Propriété avec validation dans le setter
private decimal _taux;
public decimal Taux
{
    get => _taux;
    set
    {
        if (value < 0 || value > 1)
            throw new ArgumentOutOfRangeException(nameof(value));
        _taux = value;
    }
}
```

### IReadOnlyList pour exposer des collections sans risque

```csharp
private readonly List<string> _historique = [];
// Expose une vue en lecture seule — on ne peut pas modifier la liste originale
public IReadOnlyList<string> Historique => _historique.AsReadOnly();
```

## Points d'attention (erreurs fréquentes)

- Exposer des champs publics → l'état peut être corrompu par n'importe qui
- Propriété avec getter ET setter publics sans validation → autant mettre un champ public
- Retourner une `List<T>` publique → le code externe peut la modifier (`.Add()`, `.Clear()`) sans que la classe le sache

## Pour aller plus loin

- [Encapsulation — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/object-oriented/)
- [Modificateurs d'accès — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
- Épisode suivant : **E10 — Héritage**
