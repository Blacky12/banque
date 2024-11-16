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
        Console.WriteLine($"Le compte courant de {account.Owner} à un solde de {account.GetBalance()} EUR");
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
