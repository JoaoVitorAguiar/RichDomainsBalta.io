using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }

    private IList<Subscription> _subscriptions;
    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get
        {
            return _subscriptions.ToArray();
        }
    }

    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        // Address = address; Neste contexto não se precisa do endreço no aluno!
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email);
    }

    public void AddSubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;
        foreach (var sub in Subscriptions)
        {
            if (sub.Active)
                hasSubscriptionActive = true;
        }

        AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já possui uma assinatura ativa")
            .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payment", "Essa assinatura não possui pagamentos"));


        //if (hasSubscriptionActive)
        //{
        //    AddNotification("Student.Subscriptions", "Você já possui uma assinatura ativa");
        //    return;
        //}
        _subscriptions.Add(subscription);
    }
}