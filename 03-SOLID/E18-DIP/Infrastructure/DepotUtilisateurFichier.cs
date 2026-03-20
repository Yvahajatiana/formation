namespace Formation.E18.DIP.Infrastructure;
using Formation.E18.DIP.Contracts;
using Formation.E18.DIP.Models;

/// <summary>
/// Alternative (simulated) implementation — demonstrates substitutability
/// without changing ServiceUtilisateur.
/// In production, System.Text.Json would be used for serialization.
/// </summary>
public class DepotUtilisateurFichier : IDepotUtilisateur
{
    private readonly string _cheminFichier;
    private readonly List<Utilisateur> _cache = [];
    private int _prochainId = 1;

    public DepotUtilisateurFichier(string cheminFichier)
    {
        _cheminFichier = cheminFichier;
        Console.WriteLine($"  [DepotFichier] Initialisé → {_cheminFichier}");
    }

    public void Ajouter(Utilisateur utilisateur)
    {
        _cache.Add(utilisateur with { Id = _prochainId++ });
        Console.WriteLine($"  [DepotFichier] Écrit dans {_cheminFichier} : {utilisateur.Email}");
    }

    public Utilisateur? TrouverParId(int id) => _cache.FirstOrDefault(u => u.Id == id);
    public Utilisateur? TrouverParEmail(string email) =>
        _cache.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    public IReadOnlyList<Utilisateur> TousLesUtilisateurs() => _cache.AsReadOnly();
}
