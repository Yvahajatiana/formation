namespace Formation.E16.LSP.Models;

/// <summary>Base class representing any bird.</summary>
public abstract class Oiseau
{
    public string Nom { get; }
    protected Oiseau(string nom) => Nom = nom;

    public abstract string SeDeplacer();
    public abstract string Crier();

    public override string ToString() => $"[{GetType().Name}] {Nom}";
}
