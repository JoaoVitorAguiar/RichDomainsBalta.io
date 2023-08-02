namespace PaymentContext.Domain.Entities;

public class Student
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }

    private IList<Subscription> _subscriptions;
    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get
        {
            return _subscriptions.ToArray();
        }
    }


    public Student(string firstName, string lastName, string document, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        // Address = address; Neste contexto não se precisa do endreço no aluno!
        _subscriptions = new List<Subscription>();
    }

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in Subscriptions)
        {
            sub.Inactivate();
        }
        _subscriptions.Add(subscription);
    }
}