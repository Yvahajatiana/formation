// Concepts : if/else, else if, opérateur ternaire, switch expression (C# 8+)
// .NET 8 — Top-level statements

Console.WriteLine("=== Calculatrice de remise ===\n");

Console.Write("Entrez le montant de votre commande (€) : ");
string saisie = Console.ReadLine() ?? string.Empty;

if (!decimal.TryParse(saisie, System.Globalization.NumberStyles.Any,
    System.Globalization.CultureInfo.InvariantCulture, out decimal montant) || montant < 0)
{
    Console.WriteLine("Montant invalide. Veuillez saisir un nombre positif.");
    return;
}

Console.Write("Êtes-vous membre du programme fidélité ? (O/N) : ");
bool estMembre = Console.ReadKey().Key == ConsoleKey.O;
Console.WriteLine();

// --- if / else if / else ---
decimal tauxRemise;
string categorieCommande;

if (montant >= 500)
{
    categorieCommande = "Commande Premium";
    tauxRemise = estMembre ? 0.25m : 0.20m;
}
else if (montant >= 200)
{
    categorieCommande = "Commande Standard";
    tauxRemise = estMembre ? 0.15m : 0.10m;
}
else if (montant >= 50)
{
    categorieCommande = "Petite commande";
    tauxRemise = estMembre ? 0.05m : 0m;
}
else
{
    categorieCommande = "Commande mini";
    tauxRemise = 0m;
}

decimal remise = montant * tauxRemise;
decimal total = montant - remise;

// --- switch expression (C# 8+) pour la mention ---
string mention = tauxRemise switch
{
    >= 0.20m => "Excellente remise !",
    >= 0.10m => "Bonne remise.",
    > 0m     => "Petite remise.",
    _        => "Pas de remise cette fois."
};

// --- Opérateur ternaire pour le statut membre ---
string statutMembre = estMembre ? "Membre fidélité" : "Client standard";

Console.WriteLine("\n=== Récapitulatif de commande ===");
Console.WriteLine($"Statut          : {statutMembre}");
Console.WriteLine($"Catégorie       : {categorieCommande}");
Console.WriteLine($"Montant initial : {montant:C2}");
Console.WriteLine($"Remise ({tauxRemise:P0})   : -{remise:C2}");
Console.WriteLine($"Total à payer   : {total:C2}");
Console.WriteLine($"Info            : {mention}");
