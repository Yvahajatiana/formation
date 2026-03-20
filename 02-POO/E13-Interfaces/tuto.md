# Épisode 13 — Interfaces

## Objectifs pédagogiques

- Définir et implémenter des interfaces
- Comprendre la différence avec les classes abstraites
- Implémenter plusieurs interfaces sur une même classe
- Utiliser les interfaces pour l'injection de dépendances

## Concepts clés

### Définition d'une interface

```csharp
public interface IExportable
{
    string ExporterEnCsv();  // contrat — pas d'implémentation
    string ExporterEnJson();

    // Depuis C# 8 : implémentation par défaut (optionnel)
    string ObtenirFormat() => "CSV, JSON";
}
```

### Implémentation

```csharp
public class Rapport : IExportable, IValidable // plusieurs interfaces possibles
{
    public string ExporterEnCsv() => "..."; // obligatoire
    public string ExporterEnJson() => "..."; // obligatoire
    // IValidable...
}
```

### Interface = contrat = découplage

Le code qui utilise `INotifiable` ne sait pas si c'est un email, SMS ou console :

```csharp
void Notifier(INotifiable service, string msg)
{
    service.Notifier("alice@exemple.com", "Sujet", msg);
    // peu importe l'implémentation concrète
}
```

Ce principe est la base de l'**injection de dépendances** et du code testable.

### Interface vs Classe abstraite

Utilisez une **interface** quand :
- Vous définissez un contrat pur (capacité/comportement)
- Vous avez besoin d'implémenter plusieurs contrats
- Vous voulez découpler fortement deux composants

Utilisez une **classe abstraite** quand :
- Vous partagez du code entre des classes de la même hiérarchie
- Vous avez besoin de stocker un état commun (champs)

## Points d'attention (erreurs fréquentes)

- Créer des interfaces « fat » avec trop de méthodes → à découper (voir ISP en E17)
- Implémenter une interface sans utiliser sa référence → on perd le bénéfice du découplage
- Modifier une interface existante → breaking change pour tous les implémenteurs ; utilisez les default implementations ou créez une nouvelle interface

## Pour aller plus loin

- [Interfaces — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/types/interfaces)
- [Injection de dépendances — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/core/extensions/dependency-injection)
- Partie suivante : **Principes SOLID (E14–E18)**
