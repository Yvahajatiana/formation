// Principe I — Interface Segregation Principle (ISP)
// "Les clients ne doivent pas être forcés de dépendre d'interfaces qu'ils n'utilisent pas."
// .NET 8 — Top-level statements

using Formation.E17.ISP.Contracts;
using Formation.E17.ISP.Devices;

Console.WriteLine("=== Épisode 17 — ISP : Interface Segregation Principle ===\n");

/*
 * VIOLATION ISP — interface "fat" :
 *
 * public interface IAppareilBureau
 * {
 *   void Imprimer(string doc);
 *   string Scanner(string source);
 *   void EnvoyerFax(string numero, string doc);
 *   void PhotocopierRecto();
 *   void PhotocopierRectoVerso();
 * }
 *
 * public class ImprimanteBasique : IAppareilBureau
 * {
 *   public void Imprimer(string doc) { ... }
 *   public string Scanner(string s) => throw new NotSupportedException(); // FORCED
 *   public void EnvoyerFax(...) => throw new NotSupportedException();     // FORCED
 *   // ... empty implementations or throwing exceptions
 * }
 *
 * APRÈS ISP : granular interfaces — each client uses only what it needs.
 */

var imprimanteSimple = new ImprimanteBasique("Canon LBP");
var imprimanteMulti = new ImprimanteMultifonction("HP LaserJet Pro");

// ============================================================
// 1. Usage via IImprimable interface only
// ============================================================
Console.WriteLine("--- 1. Service d'impression (IImprimable) ---");

static void LancerImpression(IImprimable imprimante, string doc)
{
    if (!imprimante.EstPrete)
    {
        Console.WriteLine("  ✗ Imprimante non disponible.");
        return;
    }
    imprimante.Imprimer(doc);
}

LancerImpression(imprimanteSimple, "Rapport mensuel.pdf");
LancerImpression(imprimanteMulti, "Contrat signé.pdf");

// ============================================================
// 2. Scan — only available on machines that support it
// ============================================================
Console.WriteLine("\n--- 2. Service de scan (IScanner) ---");

static string NumériserDocument(IScanner scanner, string source)
{
    string resultat = scanner.Scanner(source);
    Console.WriteLine($"  Contenu numérisé : {resultat}");
    return resultat;
}

// imprimanteSimple CANNOT be passed here — it does not implement IScanner
// NumériserDocument(imprimanteSimple, "..."); // Compile error ✓ ISP in action

NumériserDocument(imprimanteMulti, "Facture papier.pdf");

// ============================================================
// 3. Fax — only for multifunction devices
// ============================================================
Console.WriteLine("\n--- 3. Service de fax (IFax) ---");

static void EnvoyerParFax(IFax fax, string numero, string doc) =>
    fax.EnvoyerFax(numero, doc);

EnvoyerParFax(imprimanteMulti, "+33 1 23 45 67 89", "Bon de commande");

Console.WriteLine("\n  L'imprimante basique ne peut ni scanner ni envoyer de fax ✓");
Console.WriteLine("  Le compilateur enforce ce contrat — pas besoin de vérification à l'exécution.");
