namespace Formation.E18.DIP.Infrastructure;
using Formation.E18.DIP.Contracts;
using Formation.E18.DIP.Models;

/// <summary>In-memory implementation — useful for tests and demos.</summary>
public class DepotUtilisateurMemoire : IDepotUtilisateur
{
    private readonly List<Utilisateur> _utilisateurs = [];
    private int _prochainId = 1;

    public void Ajouter(Utilisateur utilisateur)
    {
        // Check for duplicate emails
        if (_utilisateurs.Any(u => u.Email == utilisateur.Email))
            throw new InvalidOperationException($"L'email {utilisateur.Email} est déjà utilisé.");
        _utilisateurs.Add(utilisateur with { Id = _prochainId++ });
    }

    public Utilisateur? TrouverParId(int id) =>
        _utilisateurs.FirstOrDefault(u => u.Id == id);

    public Utilisateur? TrouverParEmail(string email) =>
        _utilisateurs.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public IReadOnlyList<Utilisateur> TousLesUtilisateurs() => _utilisateurs.AsReadOnly();
}
