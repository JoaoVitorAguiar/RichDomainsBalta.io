using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;
public class Subscription : Entity
{
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }
    private IList<Payment> _payments;
    public IReadOnlyCollection<Payment> Payments
    {
        get
        {
            return _payments.ToArray();
        }
    }

    // Toda vez que criar uma Subscription irá assumir que ela está ativa
    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
        Active = true;
        ExpireDate = expireDate;
        _payments = new List<Payment>();
    }

    public void AddPayment(Payment payment)
    {
        // Neste caso, ele deixa ocorrer o oagemneto mesmo tendo notificações
        // Ele trata isso antes de ser confirmado no banco

        AddNotifications( new Contract()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data de pagamento deve ser futura"));

        _payments.Add(payment);
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.UtcNow;
    }

    public void Inactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.UtcNow;
    }
}