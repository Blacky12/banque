public interface IBankAccount : IAccount
{
    string Number {get;}
    Person Owner{get;}
    void ApplyInterest();
}
