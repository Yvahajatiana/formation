// Concepts : switch statement, regroupement de cas, pattern matching de type (C# 7+)
// .NET 8 — Top-level statements

Console.WriteLine("=== Gestionnaire de support technique ===\n");
Console.WriteLine("Sélectionnez votre problème :");
Console.WriteLine("  1. Mon ordinateur ne démarre pas");
Console.WriteLine("  2. Internet ne fonctionne pas");
Console.WriteLine("  3. Imprimante hors service");
Console.WriteLine("  4. Mot de passe oublié");
Console.WriteLine("  5. Logiciel qui plante");
Console.WriteLine("  9. Autre problème");
Console.Write("\nVotre choix : ");

if (!int.TryParse(Console.ReadLine(), out int choix))
{
    Console.WriteLine("Entrée invalide.");
    return;
}

// --- switch statement classique avec regroupement de cas ---
Console.WriteLine("\n=== Instructions de résolution ===");

switch (choix)
{
    case 1:
        Console.WriteLine("PC ne démarre pas :");
        Console.WriteLine("  1. Vérifiez que le câble d'alimentation est branché");
        Console.WriteLine("  2. Appuyez sur le bouton Power pendant 10 secondes");
        Console.WriteLine("  3. Si rien ne se passe, contactez le support matériel");
        break;

    case 2:
        Console.WriteLine("Problème réseau :");
        Console.WriteLine("  1. Redémarrez votre box/routeur (débrancher 30 secondes)");
        Console.WriteLine("  2. Vérifiez le câble Ethernet ou le Wi-Fi");
        Console.WriteLine("  3. Testez sur un autre appareil pour isoler le problème");
        break;

    case 3:
        Console.WriteLine("Imprimante hors service :");
        Console.WriteLine("  1. Vérifiez qu'elle est allumée et connectée");
        Console.WriteLine("  2. Supprimez les tâches bloquées dans la file d'impression");
        Console.WriteLine("  3. Relancez le service 'Spouleur d'impression' (services.msc)");
        break;

    case 4:
        Console.WriteLine("Mot de passe oublié :");
        Console.WriteLine("  1. Utilisez la procédure de réinitialisation par email");
        Console.WriteLine("  2. Si compte AD : contactez le service RH pour réinitialisation");
        break;

    case 5:
        Console.WriteLine("Logiciel qui plante :");
        Console.WriteLine("  1. Fermez et relancez l'application");
        Console.WriteLine("  2. Vérifiez les mises à jour disponibles");
        Console.WriteLine("  3. Désinstallez et réinstallez si le problème persiste");
        break;

    case 9:
        Console.WriteLine("Autre problème :");
        Console.WriteLine("  Veuillez décrire votre problème par email à support@entreprise.fr");
        Console.WriteLine("  Un technicien vous contactera sous 2 heures ouvrées.");
        break;

    default:
        Console.WriteLine($"Le choix {choix} ne correspond à aucune option du menu.");
        Console.WriteLine("Veuillez relancer le programme et choisir entre 1, 2, 3, 4, 5 ou 9.");
        break;
}

// --- Priorité du ticket ---
string priorite = choix switch
{
    1 => "CRITIQUE",
    2 or 3 => "HAUTE",
    4 or 5 => "MOYENNE",
    9 => "STANDARD",
    _ => "INCONNUE"
};

Console.WriteLine($"\nPriorité du ticket : {priorite}");
Console.WriteLine("Ticket enregistré. Référence : TKT-" + DateTime.Now.ToString("yyyyMMddHHmm"));
