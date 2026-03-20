namespace Formation.E10.Heritage.Models;

/// <summary>Cat — derives from Animal.</summary>
public class Chat : Animal
{
    public bool EstCastre { get; }

    public Chat(string nom, int ageEnMois, bool estCastre = false)
        : base(nom, "Chat", ageEnMois)
    {
        EstCastre = estCastre;
    }

    public override string Crier() => "Miaou !";
    public override string SeDeplacer() => "se faufile silencieusement";

    public void Ronronner() =>
        Console.WriteLine($"  {Nom} ronronne... Prrrr");
}
