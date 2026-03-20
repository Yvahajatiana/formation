namespace Formation.E17.ISP.Contracts;

public interface IImprimable
{
    void Imprimer(string document);
    bool EstPrete { get; }
}
