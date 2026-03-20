namespace Formation.E15.OCP.Contracts;

/// <summary>Contrat pour le calcul d'une remise commerciale.</summary>
public interface ICalculateurRemise
{
    string Nom { get; }
    string Description { get; }
    decimal CalculerRemise(decimal prixOriginal);
}
