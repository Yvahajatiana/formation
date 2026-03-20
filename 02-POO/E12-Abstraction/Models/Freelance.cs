namespace Formation.E12.Abstraction.Models;

/// <summary>Independent contractor — paid hourly.</summary>
public class Freelance : Employe
{
    public decimal TauxHoraire { get; }
    public double HeuresTravaillees { get; private set; }

    public Freelance(string nom, string prenom, string specialite, decimal tauxHoraire)
        : base(nom, prenom, specialite)
    {
        if (tauxHoraire <= 0) throw new ArgumentException("Le taux horaire doit être positif.");
        TauxHoraire = tauxHoraire;
    }

    public void EnregistrerHeures(double heures)
    {
        if (heures <= 0) throw new ArgumentException("Le nombre d'heures doit être positif.");
        HeuresTravaillees += heures;
        Console.WriteLine($"  {Prenom} {Nom} : {heures}h enregistrées (total : {HeuresTravaillees}h)");
    }

    public override decimal CalculerSalaire() => TauxHoraire * (decimal)HeuresTravaillees;

    public override void AfficherFichePaie()
    {
        Console.WriteLine($"  (Freelance — {HeuresTravaillees}h à {TauxHoraire:C2}/h)");
        base.AfficherFichePaie();
    }
}
