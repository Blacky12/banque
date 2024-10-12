using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        var personne1 = new Person { Id = 1 ,FirstName = "Nicolas", LastName = "Ferbeck", BirthDate = DateTime.Parse("23/11/93") };
    }
}

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate{ get; set; }

}

class CurrentAccount
{
    public string Number;
    double Balance {get;}
    double CreditLine;
    Person Owner;

    public void Withdraw(double amount)
    {
        
    }
    public void Deposit(double amount)
    {
        Console.WriteLine("Combien d'argent voulez-vous déposer");
    }
}

class Bank
{
    Dictionary<string,CurrentAccount> Account {get;}
    public string Name;

    public void AddAccount(CurrentAccount account)
    {

    }
    public void DeleteAccount(string number)
    {

    }
}