namespace Formation.E08.Classes.Models;

/// <summary>Représente une personne avec ses informations de base.</summary>
public class Personne
{
    // Auto-implemented properties with getter/setter
    public string Prenom { get; }
    public string Nom { get; }
    public int Age { get; private set; }
    public string Email { get; set; }

    // Calculated property (no setter — derived value)
    public string NomComplet => $"{Prenom} {Nom}";
    public bool EstMajeur => Age >= 18;

    // Main constructor
    public Personne(string prenom, string nom, int age, string email = "")
    {
        if (string.IsNullOrWhiteSpace(prenom))
            throw new ArgumentException("Le prénom est obligatoire.", nameof(prenom));
        if (string.IsNullOrWhiteSpace(nom))
            throw new ArgumentException("Le nom est obligatoire.", nameof(nom));
        if (age < 0 || age > 150)
            throw new ArgumentOutOfRangeException(nameof(age), "L'âge doit être entre 0 et 150.");

        Prenom = prenom;
        Nom = nom;
        Age = age;
        Email = email;
    }

    // Instance method — action specific to the object
    public void FeterAnniversaire()
    {
        Age++;
        Console.WriteLine($"  Joyeux anniversaire {Prenom} ! Vous avez maintenant {Age} an(s).");
    }

    public string SePresenter() =>
        $"Bonjour, je m'appelle {NomComplet}. " +
        $"J'ai {Age} an(s) et je suis {(EstMajeur ? "majeur(e)" : "mineur(e)")}.";

    // Override ToString for readable display
    public override string ToString() => $"Personne[{NomComplet}, {Age} ans, {(string.IsNullOrEmpty(Email) ? "sans email" : Email)}]";
}
