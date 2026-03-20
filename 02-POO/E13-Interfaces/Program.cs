// Concepts : interfaces, implémentation multiple, injection via interface, IComparable<T>
// .NET 8 — Top-level statements

using Formation.E13.Interfaces.Contracts;
using Formation.E13.Interfaces.Models;
using Formation.E13.Interfaces.Services;

Console.WriteLine("=== Épisode 13 — Interfaces ===\n");

// ============================================================
// 1. Implémentation de plusieurs interfaces
// ============================================================
Console.WriteLine("--- 1. Rapport (IExportable + IValidable) ---");

var rapport = new Rapport("Bilan Q1 2026", "Alice Martin", "Les ventes ont progressé de 12%.");

if (rapport.EstValide())
{
    Console.WriteLine("  Rapport valide ✓");
    Console.WriteLine("\n  Export CSV :");
    Console.WriteLine(rapport.ExporterEnCsv());
    Console.WriteLine("\n  Export JSON :");
    Console.WriteLine(rapport.ExporterEnJson());
    Console.WriteLine($"\n  Formats supportés : {((IExportable)rapport).ObtenirFormatSupporte()}");
}
else
{
    Console.WriteLine("  Rapport invalide ✗");
    foreach (var erreur in rapport.ObtenirErreurs())
        Console.WriteLine($"    - {erreur}");
}

// ============================================================
// 2. Rapport invalide
// ============================================================
Console.WriteLine("\n--- 2. Rapport invalide ---");
var rapportInvalide = new Rapport("", "");

if (!rapportInvalide.EstValide())
{
    Console.WriteLine("  Erreurs détectées :");
    foreach (var erreur in rapportInvalide.ObtenirErreurs())
        Console.WriteLine($"    ✗ {erreur}");
}

// ============================================================
// 3. Injection de dépendance via interface
// ============================================================
Console.WriteLine("\n--- 3. Notification via interface (interchangeable) ---");

// Any INotifiable can be passed — calling code does not know the concrete type
EnvoyerNotification(new NotificateurConsole(), "alice@corp.fr", "Rapport disponible", "Votre rapport Q1 est prêt.");
EnvoyerNotification(new NotificateurEmail("smtp.corp.fr"), "bob@corp.fr", "Rapport disponible", "Votre rapport Q1 est prêt.");
EnvoyerNotification(new NotificateurEmail("smtp.corp.fr", disponible: false), "charlie@corp.fr", "Test", "Ceci ne sera pas envoyé.");

static void EnvoyerNotification(INotifiable notificateur, string dest, string sujet, string msg)
{
    if (notificateur.EstDisponible)
        notificateur.Notifier(dest, sujet, msg);
    else
        Console.WriteLine($"\n  ✗ Notificateur indisponible pour {dest}");
}

// ============================================================
// 4. Trier des objets via IComparable<T>
// ============================================================
Console.WriteLine("\n--- 4. IComparable<T> — tri naturel ---");

var rapports = new List<Rapport>
{
    new("Bilan Q3", "Emma", "Contenu Q3"),
    new("Bilan Q1", "Alice", "Contenu Q1"),
    new("Bilan Q4", "Bob", "Contenu Q4"),
    new("Bilan Q2", "Charlie", "Contenu Q2"),
};

var triésParTitre = rapports.OrderBy(r => r.Titre).ToList();
Console.WriteLine("  Rapports triés par titre :");
foreach (var r in triésParTitre)
    Console.WriteLine($"    - {r.Titre} (par {r.Auteur})");
