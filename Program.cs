using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Program
{
        static void Main()
    {
        var person1 = new Person
        {
            Id = 1,
            FirstName = "Nicolas",
            LastName = "Ferbeck",
            BirthDate = DateTime.Parse("23/11/93")
        };
        var person2 = new Person
        {
            Id = 2,
            FirstName = "Sandra",
            LastName = "Housse",
            BirthDate = DateTime.Parse("28/05/94")
        };

        var account1 = new CurrentAccount
        {
            Number = "1",
            CreditLine = 500.0,
            Owner = person1
        };
        var account2 = new CurrentAccount
        {
            Number = "2",
            CreditLine = 300.0,
            Owner = person2
        };
        var account3 = new CurrentAccount
        {
            Number = "3",
            CreditLine = 1000,
            Owner = person1
        };

        var maBanque = new Bank();
        maBanque.AddAccount(account1);
        maBanque.AddAccount(account2);
        maBanque.AddAccount(account3);

        double totalBalance = maBanque.GetTotalBalance(person1);
        Console.WriteLine($"La somme des compte de {person1.FirstName} {person1.LastName} à un sole de {totalBalance} EUR");
    }
}

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate{ get; set; }

    public override string  ToString()
    {
        return $"{FirstName} {LastName}";
    }

}

class CurrentAccount
{
    public string Number{get;set;}
    public double Balance {get;}
    public double CreditLine{get;set;}
    public Person Owner{get;set;}

    public void Withdraw(double amount)
    {
        CreditLine -= amount;
    }
    public void Deposit(double amount)
    {
        CreditLine += amount;
    }
}

class Bank
{
    Dictionary<string,CurrentAccount> Accounts {get;} = new Dictionary<string,CurrentAccount>();
    public string Name{get; set;}

    public void AddAccount(CurrentAccount account)
    {
        Accounts.Add(account.Number, account);
    }
    public void DeleteAccount(string number)
    {
        Accounts.Remove(number);
    }

    public void ShowAccount(CurrentAccount account)
    {
        Console.WriteLine($"Le compte courant de {account.Owner} à un solde de {account.CreditLine} EUR");
    }
    public double GetTotalBalance(Person person)
    {
        double totalBalance = 0.0;

        foreach (var account in Accounts.Values)
        {
            if (account.Owner == person)
            {
                totalBalance += account.CreditLine;
            }
        }

        return totalBalance;
    }
}