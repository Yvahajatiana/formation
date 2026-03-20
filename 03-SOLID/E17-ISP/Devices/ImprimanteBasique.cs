namespace Formation.E17.ISP.Devices;
using Formation.E17.ISP.Contracts;

/// <summary>
/// Simple printer — implements only IImprimable.
/// ISP: not forced to implement Scanner or Fax.
/// </summary>
public class ImprimanteBasique : IImprimable
{
    private readonly string _modele;

    public ImprimanteBasique(string modele) => _modele = modele;

    public bool EstPrete => true;

    public void Imprimer(string document)
    {
        Console.WriteLine($"  🖨️  [{_modele}] Impression de : {document}");
    }
}
