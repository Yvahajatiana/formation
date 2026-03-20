using Formation.E13.Interfaces.Contracts;

namespace Formation.E13.Interfaces.Models;

/// <summary>
/// Report that implements both IExportable and IValidable.
/// Demonstrates implementing multiple interfaces.
/// </summary>
public class Rapport : IExportable, IValidable
{
    public string Titre { get; }
    public string Auteur { get; }
    public DateTime DateCreation { get; }
    public string Contenu { get; set; }

    public Rapport(string titre, string auteur, string contenu = "")
    {
        Titre = titre;
        Auteur = auteur;
        DateCreation = DateTime.Now;
        Contenu = contenu;
    }

    // Implementation of IExportable
    public string ExporterEnCsv() =>
        $"\"Titre\",\"Auteur\",\"Date\",\"Contenu\"\n" +
        $"\"{Titre}\",\"{Auteur}\",\"{DateCreation:yyyy-MM-dd}\",\"{Contenu}\"";

    public string ExporterEnJson() =>
        "{\n" +
        $"  \"titre\": \"{Titre}\",\n" +
        $"  \"auteur\": \"{Auteur}\",\n" +
        $"  \"date\": \"{DateCreation:yyyy-MM-dd}\",\n" +
        $"  \"contenu\": \"{Contenu}\"\n" +
        "}";

    // Implementation of IValidable
    public bool EstValide() => ObtenirErreurs().Count == 0;

    public IReadOnlyList<string> ObtenirErreurs()
    {
        var erreurs = new List<string>();
        if (string.IsNullOrWhiteSpace(Titre)) erreurs.Add("Le titre est obligatoire.");
        if (string.IsNullOrWhiteSpace(Auteur)) erreurs.Add("L'auteur est obligatoire.");
        if (string.IsNullOrWhiteSpace(Contenu)) erreurs.Add("Le contenu est vide.");
        return erreurs.AsReadOnly();
    }
}
