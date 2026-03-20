namespace Formation.E10.Heritage.Models;

/// <summary>Dog — derives from Animal and specializes its behaviors.</summary>
public class Chien : Animal
{
    public string Race { get; }

    // Constructor calls the parent constructor via base()
    public Chien(string nom, string race, int ageEnMois)
        : base(nom, "Chien", ageEnMois)
    {
        Race = race;
    }

    // override redefines the behavior of the parent class
    public override string Crier() => "Woof !";
    public override string SeDeplacer() => "court en remuant la queue";

    // Method specific to Chien (not in Animal)
    public void Rapporter(string objet) =>
        Console.WriteLine($"  {Nom} rapporte le/la {objet} avec enthousiasme !");

    public override string SeDecrire() =>
        base.SeDecrire() + $", race : {Race}";
}
