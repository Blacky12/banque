using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        // Point a retenir quand nous avons des setteur privé et un constructeur dans la classe
        // pas besoin d'initialiser chaque variable de la classe pour les assigner
        // exemple var person1 = new Person{Id=1,etc}
        // Alors que quand nons avons un constructeur on peu avec des parenthese assigner directement
        // sans spécifier la variable
        // Création des objets Person via le constructeur
        var person1 = new Person(1, "Nicolas", "Ferbeck", new DateTime(1993, 11, 23));
        var person2 = new Person(2, "Sandra", "Housse", new DateTime(1995, 05, 30));


        // Création des comptes via l'interface IBankAccount
        IBankAccount account1 = new CurrentAccount("1", 0, 2000, person1);
        IBankAccount account2 = new CurrentAccount("2", 0, 2000, person1);
        IBankAccount account3 = new CurrentAccount("3", 0, 2000, person2);

        // (Optionnel) Gestion des comptes via la banque
        var maBanque = new Bank() { Name = "Ifosup" };
        maBanque.AddAccount(account1);
        maBanque.AddAccount(account2);
        maBanque.AddAccount(account3);

        // Test des fonctionnalités du compteµ
        try
        {
            account1.Deposit(50); //Dépot
            account1.Deposit(50);
            // account1.Deposit(-200); // Va prendre l'erreur
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }
        try
        {
            account1.Withdraw(1000);
            // account1.Withdraw(-50); // Retrait
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }

        account1.ApplyInterest(); // Application des intérêts

        // Affichage des résultats
        Console.WriteLine($"Le solde est de {account1.Balance} EUR");
        Console.WriteLine($"Propriétaire du compte: {account1.Owner}");



        Console.WriteLine($"Nombre total de comptes dans la banque {maBanque.Name}: {maBanque.GetAllAccounts().Count()} comptes ");
    }
}