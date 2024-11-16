using System.ComponentModel.DataAnnotations;

class CurrentAccount : Account
{
    public CurrentAccount(string number, double initialBalance, double creditLine, Person owner)
    : base(number, initialBalance, creditLine, owner)
    {

    }
    public override void Withdraw(double amount)
    {

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à 0");
    
        }
        if (!SubtractFromBalance(amount))
        {
            throw new InsufficientBalanceException("Font insufisant");
        }
        
        Console.WriteLine($"Retrait de {amount} effectué");
    }
    public override void Deposit(double amount)
    {
        
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Le montant doit être supérieur à 0");
        }

        AddToBalance(amount);
        Console.WriteLine($"Dépot de {amount} EUR effectué");
    }

    protected override double CalculInterest()
    {
        double taux = (GetBalance() >= 0) ? 0.03 : 0.0975;
        return GetBalance() * taux;
    }
}

[Serializable]
internal class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException()
    {
    }

    public InsufficientBalanceException(string? message) : base(message)
    {
    }

    public InsufficientBalanceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}