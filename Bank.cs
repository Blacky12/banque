class Bank
{
    Dictionary<string,IBankAccount> Accounts {get;} = new Dictionary<string,IBankAccount>();
    public string ?Name{get; set;}

    public void AddAccount(IBankAccount account)
    {
        Accounts.Add(account.Number, account);
        if (account is CurrentAccount currentAccount)
        {
            currentAccount.NegativeBalanceEvent += HandleNegativeBalance;
        }
    }
    public void DeleteAccount(string number)
    {
        Accounts.Remove(number);
    }

    public void ShowAccount(CurrentAccount account)
    {
        Console.WriteLine($"Le compte courant de {account.Owner} à un solde de {account.GetBalance()} EUR");
    }

    public void HandleNegativeBalance(Account account)
    {
        Console.WriteLine($"Le compte {account.Number} est passée en négatif");
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
