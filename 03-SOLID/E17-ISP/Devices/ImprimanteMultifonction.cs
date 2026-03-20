namespace Formation.E17.ISP.Devices;
using Formation.E17.ISP.Contracts;

/// <summary>
/// Multifunction printer — implements all interfaces.
/// Each interface is cohesive and independent.
/// </summary>
public class ImprimanteMultifonction : IImprimable, IScanner, IFax
{
    private readonly string _modele;

    public ImprimanteMultifonction(string modele) => _modele = modele;

    public bool EstPrete => true;

    public void Imprimer(string document) =>
        Console.WriteLine($"  🖨️  [{_modele}] Impression de : {document}");

    public string Scanner(string source)
    {
        Console.WriteLine($"  📄 [{_modele}] Scan de : {source}");
        return $"[Contenu scanné depuis {source}]";
    }

    public void EnvoyerFax(string numero, string document)
    {
        Console.WriteLine($"  📠 [{_modele}] Fax vers {numero} : {document}");
    }
}
