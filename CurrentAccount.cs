class CurrentAccount : Account
{
    public CurrentAccount(string number, double initialBalance, double creditLine, Person owner)
    : base(number, initialBalance, creditLine, owner)
    {

    }
    public override void Withdraw(double amount)
    {
        if (SubtractFromBalance(amount))
        {
            Console.WriteLine($"Retrait de {amount} EUR. Effectué");
        }
        else
        {
            Console.WriteLine("Fond insuffisant");
        }
    }
    public override void Deposit(double amount)
    {
        if (amount > 0)
        {
            AddToBalance(amount);
            Console.WriteLine($"Dépot de {amount} EUR effectué ");
        }
        else
        {
            Console.WriteLine("Montant non valide");
        }
    }

    protected override double CalculInterest()
    {
        double taux = (GetBalance() >= 0) ? 0.03 : 0.0975;
        return GetBalance() * taux;
    }
}