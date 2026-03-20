using Formation.E13.Interfaces.Contracts;

namespace Formation.E13.Interfaces.Services;

/// <summary>Simulates sending an email (demonstration version).</summary>
public class NotificateurEmail : INotifiable
{
    private readonly string _serveurSmtp;
    public bool EstDisponible { get; private set; }

    public NotificateurEmail(string serveurSmtp, bool disponible = true)
    {
        _serveurSmtp = serveurSmtp;
        EstDisponible = disponible;
    }

    public void Notifier(string destinataire, string sujet, string message)
    {
        if (!EstDisponible)
        {
            Console.WriteLine($"  ✗ Email impossible : serveur SMTP {_serveurSmtp} indisponible.");
            return;
        }
        Console.WriteLine($"  ✓ Email envoyé via {_serveurSmtp}");
        Console.WriteLine($"    À : {destinataire} | Sujet : {sujet}");
    }
}
