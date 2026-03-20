namespace Formation.E10.Heritage.Models;

/// <summary>Base class representing an animal.</summary>
public class Animal
{
    public string Nom { get; }
    public string Espece { get; }
    protected int AgeEnMois { get; }

    public Animal(string nom, string espece, int ageEnMois)
    {
        Nom = nom;
        Espece = espece;
        AgeEnMois = ageEnMois;
    }

    // virtual = can be overridden in a derived class
    public virtual string Crier() => "...";
    public virtual string SeDeplacer() => "se déplace";
    public virtual string SeDecrire() =>
        $"{Espece} '{Nom}' ({AgeEnMois} mois) — cri : {Crier()}, déplacement : {SeDeplacer()}";

    public override string ToString() => $"[{GetType().Name}] {Nom}";
}
