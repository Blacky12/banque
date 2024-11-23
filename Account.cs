
abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; private set; }
    public double CreditLine { get; private set; }
    public Person Owner { get; private set; }

    public Account(string number, double initialBalance, double creditLine, Person owner)
    {
        Number = number;
        Balance = initialBalance;
        CreditLine = creditLine;
        Owner = owner;
    }

    double IAccount.Balance => Balance;

    public delegate void NegativeBalanceDelegate(Account account);
    public event NegativeBalanceDelegate NegativeBalanceEvent;

    protected void AddToBalance(double initialBalance)
    {
        Balance += initialBalance;
    }

    protected bool SubtractFromBalance(double amount)
    {
        if (Balance - amount >= -CreditLine)
        {
            Balance -= amount;

            if (Balance < 0)
            {
                NegativeBalanceEvent?.Invoke(this);
            }
            return true;
        }
        return false;


    }

    public double GetBalance()
    {
        return Balance;
    }

    protected abstract double CalculInterest();

    public void ApplyInterest()
    {
        double interest = CalculInterest();
        AddToBalance(interest);
        Console.WriteLine($"Interêt de {interest} EUR appliqués. Nouveau Solde : {Balance} EUR");
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);

}