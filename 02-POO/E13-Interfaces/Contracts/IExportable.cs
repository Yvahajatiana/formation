namespace Formation.E13.Interfaces.Contracts;

/// <summary>Contract for any object that can be exported in different formats.</summary>
public interface IExportable
{
    string ExporterEnCsv();
    string ExporterEnJson();

    // Default implementation (C# 8+) — implementors can override it
    string ObtenirFormatSupporte() => "CSV, JSON";
}
