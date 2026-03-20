namespace Formation.E09.Encapsulation.Models;

/// <summary>
/// Compte bancaire encapsulé : le solde ne peut jamais être négatif
/// et n'est jamais accessible en écriture directe de l'extérieur.
/// </summary>
public class CompteBancaire
{
    // Private field — inaccessible from outside
    private decimal _solde;
    private readonly List<string> _historique = [];

    public string Titulaire { get; }
    public string NumeroCompte { get; }

    // Read-only property — exposes _solde without allowing direct modification
    public decimal Solde => _solde;
    public IReadOnlyList<string> Historique => _historique.AsReadOnly();

    public CompteBancaire(string titulaire, string numeroCompte, decimal soldeInitial = 0m)
    {
        if (string.IsNullOrWhiteSpace(titulaire))
            throw new ArgumentException("Le titulaire est obligatoire.", nameof(titulaire));
        if (soldeInitial < 0)
            throw new ArgumentException("Le solde initial ne peut pas être négatif.", nameof(soldeInitial));

        Titulaire = titulaire;
        NumeroCompte = numeroCompte;
        _solde = soldeInitial;
        Enregistrer($"Ouverture du compte — solde initial : {soldeInitial:C2}");
    }

    public void Deposer(decimal montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant du dépôt doit être strictement positif.", nameof(montant));

        _solde += montant;
        Enregistrer($"Dépôt : +{montant:C2} → solde : {_solde:C2}");
        Console.WriteLine($"  ✓ Dépôt de {montant:C2} effectué. Solde : {_solde:C2}");
    }

    public bool Retirer(decimal montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant du retrait doit être strictement positif.", nameof(montant));

        if (montant > _solde)
        {
            Console.WriteLine($"  ✗ Retrait refusé : solde insuffisant. Disponible : {_solde:C2}, demandé : {montant:C2}");
            return false;
        }

        _solde -= montant;
        Enregistrer($"Retrait : -{montant:C2} → solde : {_solde:C2}");
        Console.WriteLine($"  ✓ Retrait de {montant:C2} effectué. Solde restant : {_solde:C2}");
        return true;
    }

    public void AfficherHistorique()
    {
        Console.WriteLine($"\n  Historique du compte {NumeroCompte} — {Titulaire}");
        Console.WriteLine(new string('─', 55));
        foreach (string entree in _historique)
            Console.WriteLine($"  {entree}");
        Console.WriteLine(new string('─', 55));
        Console.WriteLine($"  Solde actuel : {_solde:C2}");
    }

    private void Enregistrer(string operation)
    {
        _historique.Add($"[{DateTime.Now:HH:mm:ss}] {operation}");
    }

    public override string ToString() => $"[{NumeroCompte}] {Titulaire} — Solde : {_solde:C2}";
}
