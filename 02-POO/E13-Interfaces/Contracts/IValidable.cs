namespace Formation.E13.Interfaces.Contracts;

/// <summary>Contract for objects that can validate themselves.</summary>
public interface IValidable
{
    bool EstValide();
    IReadOnlyList<string> ObtenirErreurs();
}
