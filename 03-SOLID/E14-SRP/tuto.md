# Épisode 14 — SRP : Single Responsibility Principle

## Objectifs pédagogiques

- Comprendre ce que signifie "une seule raison de changer"
- Identifier les classes qui font trop de choses
- Refactoriser vers des classes à responsabilité unique
- Comprendre comment SRP facilite les tests et la maintenance

## Le principe

> "Une classe ne devrait avoir qu'une seule raison de changer." — Robert C. Martin

Chaque classe, module ou fonction doit être responsable d'**une seule chose**. Si vous pouvez décrire ce que fait votre classe avec "et", c'est probablement qu'elle fait trop.

## Contre-exemple typique

```csharp
// ❌ Classe qui fait TOUT — plusieurs raisons de changer
public class GestionnaireCommande
{
    public void TraiterCommande(Commande c)
    {
        // Validation (raison 1 de changer : règles métier évoluent)
        if (c.Quantite <= 0) throw new Exception("Invalide");

        // Accès base de données (raison 2 : schéma BDD change)
        using var conn = new SqlConnection("...");
        conn.Execute("UPDATE stock SET qty = qty - @qty", new { qty = c.Quantite });

        // Envoi d'email (raison 3 : template ou serveur SMTP change)
        new SmtpClient().Send(new MailMessage(...));

        // Logging (raison 4 : format de log change)
        File.AppendAllText("log.txt", $"{DateTime.Now}: Commande {c.Id}");
    }
}
```

## Bonne pratique

Chaque responsabilité devient une classe distincte :

```
ValidateurCommande    → règles métier seulement
GestionnaireStock     → stock seulement
NotificateurCommande  → notifications seulement
TraiteurCommande      → coordination du workflow seulement
```

## Bénéfices concrets

| Situation | Avant SRP | Après SRP |
|---|---|---|
| Changer le template d'email | Modifier `TraiteurCommande` (risque) | Modifier `NotificateurCommande` seulement |
| Tester la validation | Besoin d'une BDD et d'un SMTP | Test unitaire pur, pas de dépendances |
| Ajouter un nouveau canal de notification | Modifier une grosse classe | Créer une nouvelle classe |

## Points d'attention

- SRP ne signifie pas "une classe = une méthode" — une classe peut avoir plusieurs méthodes si elles servent la même responsabilité
- L'orchestrateur (`TraiteurCommande`) est lui-même à responsabilité unique : coordonner le workflow

## Pour aller plus loin

- [SOLID principles — Documentation Microsoft](https://learn.microsoft.com/fr-fr/dotnet/architecture/modern-web-apps-azure/architectural-principles)
- Épisode suivant : **E15 — OCP : Open/Closed Principle**
