class Bank
{
    Dictionary<string,IBankAccount> Accounts {get;} = new Dictionary<string,IBankAccount>();
    public string Name{get; set;}

    public void AddAccount(IBankAccount account)
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
                totalBalance += account.Balance;
            }
        }

        return totalBalance;
    }

    public List<IBankAccount> GetAllAccounts()
    {
        return Accounts.Values.ToList();
    }
}
