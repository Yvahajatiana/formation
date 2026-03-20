# Épisode 18 — DIP : Dependency Inversion Principle

## Objectifs pédagogiques

- Comprendre les deux niveaux : haut niveau (logique métier) et bas niveau (infrastructure)
- Inverser la dépendance via une interface
- Pratiquer l'injection de dépendances par constructeur
- Voir comment DIP permet la testabilité et la flexibilité

## Le principe

> "Les modules de haut niveau ne doivent pas dépendre des modules de bas niveau.
> Les deux doivent dépendre d'abstractions.
> Les abstractions ne doivent pas dépendre des détails. Les détails doivent dépendre des abstractions."
> — Robert C. Martin

## Visualisation

```
AVANT DIP :
ServiceUtilisateur ──dépend──→ DepotUtilisateurSQL  (concret)

APRÈS DIP :
ServiceUtilisateur ──dépend──→ IDepotUtilisateur  (abstraction)
                                      ↑
                     DepotUtilisateurSQL ──implémente──┘
                     DepotUtilisateurMemoire ──implémente──┘
                     DepotUtilisateurFichier ──implémente──┘
```

## Injection de dépendances par constructeur

```csharp
// The service receives its repository as a parameter — it does not create it itself
public class ServiceUtilisateur
{
    private readonly IDepotUtilisateur _depot;

    public ServiceUtilisateur(IDepotUtilisateur depot) => _depot = depot;
}

// In production
var service = new ServiceUtilisateur(new DepotUtilisateurSql("connection string"));

// In test
var service = new ServiceUtilisateur(new DepotUtilisateurMemoire());
// → no real database needed to test business logic
```

## DIP et les conteneurs IoC

En production, l'injection est souvent gérée par un conteneur IoC (Inversion of Control) comme `Microsoft.Extensions.DependencyInjection` :

```csharp
builder.Services.AddScoped<IDepotUtilisateur, DepotUtilisateurSql>();
builder.Services.AddScoped<ServiceUtilisateur>();
// Le conteneur injecte automatiquement les dépendances
```

## Points d'attention

- DIP ≠ injection de dépendances (ID) : DIP est le principe, ID est la technique pour l'appliquer
- Ne pas abuser des interfaces : pas besoin d'une interface pour chaque classe, seulement aux frontières architecturales (infrastructure, services externes)

## Pour aller plus loin

- [Injection de dépendances .NET — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/architecture/modern-web-apps-azure/architectural-principles)
- Partie suivante : **Design Patterns GOF (E19–E24)**
