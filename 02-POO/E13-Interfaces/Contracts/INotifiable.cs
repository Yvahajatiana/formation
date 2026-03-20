namespace Formation.E13.Interfaces.Contracts;

/// <summary>Contract for any service that can send notifications.</summary>
public interface INotifiable
{
    void Notifier(string destinataire, string sujet, string message);
    bool EstDisponible { get; }
}
