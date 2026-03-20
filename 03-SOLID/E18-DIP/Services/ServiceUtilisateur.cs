namespace Formation.E18.DIP.Services;
using Formation.E18.DIP.Contracts;
using Formation.E18.DIP.Models;

/// <summary>
/// High-level module: user business logic.
/// Depends on the IDepotUtilisateur abstraction — never on a concrete implementation.
/// </summary>
public class ServiceUtilisateur
{
    private readonly IDepotUtilisateur _depot;

    // Constructor injection — the concrete type is decided externally
    public ServiceUtilisateur(IDepotUtilisateur depot) => _depot = depot;

    public Utilisateur Inscrire(string nom, string email)
    {
        if (string.IsNullOrWhiteSpace(nom)) throw new ArgumentException("Nom obligatoire.");
        if (!email.Contains('@')) throw new ArgumentException("Email invalide.");

        var utilisateur = new Utilisateur(0, nom, email, DateTime.Now);
        _depot.Ajouter(utilisateur);
        Console.WriteLine($"  ✓ {nom} inscrit(e) avec succès ({email})");
        return utilisateur;
    }

    public void AfficherTousLesUtilisateurs()
    {
        var utilisateurs = _depot.TousLesUtilisateurs();
        if (utilisateurs.Count == 0)
        {
            Console.WriteLine("  Aucun utilisateur inscrit.");
            return;
        }

        Console.WriteLine($"  {"ID",-4} {"Nom",-20} {"Email",-30} {"Inscrit le"}");
        Console.WriteLine(new string('─', 70));
        foreach (var u in utilisateurs)
            Console.WriteLine($"  {u.Id,-4} {u.Nom,-20} {u.Email,-30} {u.DateInscription:dd/MM/yyyy}");
    }

    public Utilisateur? Rechercher(string email) => _depot.TrouverParEmail(email);
}
