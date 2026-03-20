using Formation.E13.Interfaces.Contracts;

namespace Formation.E13.Interfaces.Services;

/// <summary>Notifies via the console (test/demo implementation).</summary>
public class NotificateurConsole : INotifiable
{
    public bool EstDisponible => true;

    public void Notifier(string destinataire, string sujet, string message)
    {
        Console.WriteLine($"\n  ╔══ Notification Console ══╗");
        Console.WriteLine($"  ║  À        : {destinataire}");
        Console.WriteLine($"  ║  Sujet    : {sujet}");
        Console.WriteLine($"  ║  Message  : {message}");
        Console.WriteLine($"  ╚══════════════════════════╝");
    }
}
