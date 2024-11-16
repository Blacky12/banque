class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; set; }
    
    public SavingsAccount(double initialBalance,string number,double creditLine,Person owner) : base(number,initialBalance,creditLine,owner)
    {

    }
    public override void Withdraw(double amount)
    {
       if (SubtractFromBalance(amount))
       {
        DateLastWithdraw = DateTime.Now;
        Console.WriteLine($"Retrait de {amount} éffectué");
       }
       else
       {
        Console.WriteLine("Font insuffisant");
       }
    }
    public override void Deposit(double amount)
    {
        if (amount > 0)
        {
            AddToBalance(amount);
            Console.WriteLine($"Dépot de {amount} éffectué");
        }
        else
        {
            Console.WriteLine("Le montant du dépot doit être positif");
        }
    }

    protected override double CalculInterest()
    {
        double taux = 0.045;
        return GetBalance() * taux;
    }

}