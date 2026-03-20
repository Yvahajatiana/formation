# Épisode 17 — ISP : Interface Segregation Principle

## Objectifs pédagogiques

- Identifier les interfaces "fat" qui forcent des implémentations inutiles
- Découper une interface en interfaces granulaires et cohérentes
- Comprendre comment ISP réduit le couplage
- Voir comment ISP et LSP se complètent

## Le principe

> "Les clients ne doivent pas être forcés de dépendre d'interfaces qu'ils n'utilisent pas." — Robert C. Martin

## Contre-exemple

```csharp
// ❌ Interface fat — force tous les implémenteurs à tout implémenter
public interface IAppareilBureau
{
    void Imprimer(string doc);
    string Scanner(string source);
    void EnvoyerFax(string numero, string doc);
}

// L'imprimante basique est forcée d'implémenter Scanner et Fax
public class ImprimanteBasique : IAppareilBureau
{
    public void Imprimer(string doc) { /* ok */ }
    public string Scanner(string s) => throw new NotSupportedException(); // absurde
    public void EnvoyerFax(string n, string d) => throw new NotSupportedException(); // absurde
}
```

## Solution ISP

```csharp
// ✅ Interfaces granulaires
public interface IImprimable { void Imprimer(string doc); }
public interface IScanner    { string Scanner(string source); }
public interface IFax        { void EnvoyerFax(string numero, string doc); }

// Imprimante simple : seulement ce dont elle a besoin
public class ImprimanteBasique : IImprimable { ... }

// Multifonction : tout ce qu'elle supporte
public class ImprimanteMultifonction : IImprimable, IScanner, IFax { ... }
```

## Bénéfices

- Code appelant ne dépend que des méthodes qu'il utilise réellement
- Pas d'implémentations vides ou levant `NotSupportedException`
- Les interfaces sont plus faciles à tester (moins de méthodes à simuler)

## Pour aller plus loin

- Épisode suivant : **E18 — DIP : Dependency Inversion Principle**
