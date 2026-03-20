namespace Formation.E18.DIP.Contracts;
using Formation.E18.DIP.Models;

/// <summary>Storage abstraction — the high-level module depends on this.</summary>
public interface IDepotUtilisateur
{
    void Ajouter(Utilisateur utilisateur);
    Utilisateur? TrouverParId(int id);
    Utilisateur? TrouverParEmail(string email);
    IReadOnlyList<Utilisateur> TousLesUtilisateurs();
}
