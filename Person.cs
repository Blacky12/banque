using Microsoft.VisualBasic;

public class Person
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate{ get; private set; }

    public Person(int id, string firstName, string lastName, DateTime birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }


    public override string  ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public void UpdateInfo(int id, string firstName, string lastName, DateTime birthdate)
    {
        Id = id ;
        FirstName = firstName ;
        LastName = lastName ;
        BirthDate = birthdate ;
    }

}
