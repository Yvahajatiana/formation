namespace Formation.E12.Abstraction.Models;

/// <summary>
/// Abstract class — defines the common contract for all employees.
/// Contains shared logic AND abstract methods to implement.
/// </summary>
public abstract class Employe
{
    public string Nom { get; }
    public string Prenom { get; }
    public string Poste { get; }

    protected Employe(string nom, string prenom, string poste)
    {
        Nom = nom;
        Prenom = prenom;
        Poste = poste;
    }

    // Abstract method — each employee type calculates its salary differently
    public abstract decimal CalculerSalaire();

    // Concrete shared method — same logic for all
    public virtual void AfficherFichePaie()
    {
        decimal salaire = CalculerSalaire();
        decimal cotisations = salaire * 0.22m;
        decimal net = salaire - cotisations;

        Console.WriteLine($"\n  ┌─ Fiche de paie : {Prenom} {Nom} ({Poste}) ─┐");
        Console.WriteLine($"  │  Salaire brut   : {salaire,10:C2}          │");
        Console.WriteLine($"  │  Cotisations    : {cotisations,10:C2} (22%)   │");
        Console.WriteLine($"  │  Salaire net    : {net,10:C2}          │");
        Console.WriteLine($"  └────────────────────────────────────────────┘");
    }
}
